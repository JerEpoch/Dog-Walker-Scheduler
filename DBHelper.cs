using JStudzinski_CapstoneA.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JStudzinski_CapstoneA
{
    
    public class DBHelper
    {
        public static string  _connection = DBConnection.connectSqlString;
        private static string CurrentUser;
        private static int CurrentUserId;



        public string getCurrentUser()
        {
            return CurrentUser;
        }

        public int getUserId()
        {
            return CurrentUserId;
        }

        public string GetConnection()
        {
            return _connection;
        }

        

        public bool Login(string username, string password)
        {
            string sql = "Select * from User where username = @username and password = @password;";
           
            MySqlConnection _con = new MySqlConnection(DBConnection.connectSqlString);
            _con.Open();
            MySqlCommand _cmd = new MySqlCommand(sql, _con);
            _cmd.Parameters.AddWithValue("@username", username);
            _cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader _rdr = _cmd.ExecuteReader();
            try
            {
                if (_rdr.HasRows)
                {
                    _rdr.Read();
                    CurrentUser = _rdr["username"].ToString();
                    CurrentUserId = (int)_rdr["UserId"];

                    return true;
                }
                return false;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error attempting to login. " + ex);
                return false;
            }
            finally
            {
                _con.Close();
                _rdr.Close();
            }
            
        }

        public bool AddCustomer(Customer _customer, Address _address)
        {
            int addressID;
            MySqlConnection _con = new MySqlConnection(_connection);

            try
            {
                string sqlAddress = "INSERT INTO Address (Address1, Address2, City, State, PostalCode) " +
                    "VALUES (@addr1, @addr2, @city, @state, @postalcode); SELECT LAST_INSERT_ID();";
                
                MySqlCommand _cmd = new MySqlCommand(sqlAddress, _con);
                //begin
                _cmd.Parameters.AddWithValue("@addr1", _address.addr1);
                _cmd.Parameters.AddWithValue("@addr2", _address.addr2);
                _cmd.Parameters.AddWithValue("@city", _address.city);
                _cmd.Parameters.AddWithValue("@state", _address.state);
                _cmd.Parameters.AddWithValue("@postalcode", _address.postCode);
                _con.Open();
                addressID = Convert.ToInt32(_cmd.ExecuteScalar());

                string sqlCustomer = "INSERT INTO Customer (addressId, CustomerName, createDate, active, PhoneNumber) " +
                    "VALUES (@addrId, @name, @createdate, @_active, @phone);";
                MySqlCommand _cmdCust = new MySqlCommand(sqlCustomer, _con);
                //begin
                _cmdCust.Parameters.AddWithValue("@addrId", addressID);
                _cmdCust.Parameters.AddWithValue("@name", _customer.Name);
                _cmdCust.Parameters.AddWithValue("@createdate", getDateTime());
                _cmdCust.Parameters.AddWithValue("@_active", _customer.isActive);
                _cmdCust.Parameters.AddWithValue("@phone", _customer.Phone);
                _cmdCust.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error adding customer " + ex);
                return false;
            }
            finally
            {
                _con.Close();
            }

            
        }

        public Customer getCustomer(int _id)
        {
            Customer _cust = new Customer();
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlCust = "SELECT * FROM Customer where CustomerId = @id;";
            MySqlCommand _cmd = new MySqlCommand(sqlCust, _con);
            _cmd.Parameters.AddWithValue("@id", _id);
            _con.Open();
            MySqlDataReader _rdr = _cmd.ExecuteReader();
            try
            {
                while (_rdr.Read())
                {
                    _cust.custId = (int)_rdr["CustomerId"];
                    _cust.addrId = (int)_rdr["addressId"];
                    _cust.Name = _rdr["CustomerName"].ToString();
                    _cust.isActive = Convert.ToBoolean(_rdr["active"]);
                    _cust.Phone = _rdr["PhoneNumber"].ToString();
                
                }
                return _cust;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting customer information. " + ex);
                return null;
            }
            finally
            {
                _rdr.Close();
                _con.Close();
            }


        }

        public Address getAddress(int _id)
        {
            Address _addr = new Address();
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlAddr = "SELECT * FROM Address where AddressId=@id";
            MySqlCommand _cmd = new MySqlCommand(sqlAddr, _con);
            _cmd.Parameters.AddWithValue("@id", _id);
            _con.Open();
            MySqlDataReader _rdr = _cmd.ExecuteReader();
            try
            {
                while (_rdr.Read())
                {
                    _addr.addrId = (int)_rdr["AddressId"];
                    _addr.addr1 = _rdr["Address1"].ToString();
                    _addr.addr2 = _rdr["Address2"].ToString();
                    _addr.city = _rdr["City"].ToString();
                    _addr.state = _rdr["State"].ToString();
                    _addr.postCode = _rdr["PostalCode"].ToString();
                }
                return _addr;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting customer's address. " + ex);
                return null;
            }
            finally
            {
                _rdr.Close();
                _con.Close();
            }



        }

        public bool updateCustomerInfo(Customer _cust, Address _addr)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlUpdate = "UPDATE Customer SET CustomerName=@name, active=@isactive, PhoneNumber=@phone WHERE CustomerId=@id; " +
            "UPDATE Address SET Address1=@addr1, Address2=@addr2, City=@city, State=@state, PostalCode=@postcode WHERE AddressId=@addrid;";
            _con.Open();
            MySqlCommand _cmd = new MySqlCommand(sqlUpdate, _con);
            try
            {
                _cmd.Parameters.AddWithValue("@id", _cust.custId);
                _cmd.Parameters.AddWithValue("@name", _cust.Name);
                _cmd.Parameters.AddWithValue("@isactive", _cust.isActive);
                _cmd.Parameters.AddWithValue("@phone", _cust.Phone);
                _cmd.Parameters.AddWithValue("@addrid", _addr.addrId);
                _cmd.Parameters.AddWithValue("@addr1", _addr.addr1);
                _cmd.Parameters.AddWithValue("@addr2", _addr.addr2);
                _cmd.Parameters.AddWithValue("@city", _addr.city);
                _cmd.Parameters.AddWithValue("@state", _addr.state);
                _cmd.Parameters.AddWithValue("@postcode", _addr.postCode);
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error updating customer's information. " + ex);
                return false;
            }
            finally
            {
                 _con.Close();
            }



        }

        public bool CreateUser(string username, string password)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlUser = "INSERT INTO User (username, password) VALUES (@name, @pass);";
            try
            {
                _con.Open();
                MySqlCommand _cmd = new MySqlCommand(sqlUser, _con);
                _cmd.Parameters.AddWithValue("@name", username);
                _cmd.Parameters.AddWithValue("@pass", password);
                _cmd.ExecuteNonQuery();
                
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Could not create new user " + ex);
                return false;
            }
            finally
            {
                _con.Close();
            }


        }
        
        public User getUserInfo(int _id)
        {
            User _user = new User();
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlUser = "SELECT * FROM User where UserId=@id;";
            _con.Open();
            MySqlCommand _cmd = new MySqlCommand(sqlUser, _con);
            _cmd.Parameters.AddWithValue("@id", _id);
            MySqlDataReader _rdr = _cmd.ExecuteReader();

            while (_rdr.Read())
            {
                _user.id = (int)_rdr["UserId"];
                _user.userName = _rdr["username"].ToString();
                _user.Password = _rdr["password"].ToString();
            }
            _con.Close();
            _rdr.Close();
            return _user;

        }

        public bool UpdateUser(User _user)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlUpdate = "UPDATE User SET username=@name, password=@pass WHERE UserId=@id;";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(sqlUpdate, _con);
            
                _cmd.Parameters.AddWithValue("@id", _user.id);
                _cmd.Parameters.AddWithValue("@name", _user.userName);
                _cmd.Parameters.AddWithValue("@pass", _user.Password);
                _con.Open();
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Could not update the user. " +ex, "Error");
                return false;
            }
            finally
            {
                 _con.Close();
            }


        }

        public bool DeleteUser(int _id)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlDel = "DELETE FROM User where UserId = @id;";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(sqlDel, _con);
                _con.Open();
                _cmd.Parameters.AddWithValue("@id", _id);
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error deleting the user " + ex);
                return false;
            }
            finally
            {
                _con.Close();
            }

            
        }

        public bool DeleteCustomer(Customer _customer, Address _address)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlDelete = "DELETE FROM Address WHERE AddressId=@addrId; DELETE FROM Customer WHERE CustomerId=@custId; " +
                "DELETE FROM Pet WHERE customerId=@custId; DELETE FROM Appointment WHERE customerId=@custId;";
            MySqlCommand _cmd = new MySqlCommand(sqlDelete, _con);
            _cmd.Parameters.AddWithValue("@addrId", _address.addrId);
            _cmd.Parameters.AddWithValue("@custId", _customer.custId);
            try
            {
                _con.Open();
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error deleting customer information. " + ex);
                return false;
            }
            finally
            {
                _con.Close();
            }

        }

        public bool AddNewDog(Pet _dog)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlAdd = "INSERT INTO Pet (customerId , DogName, Note) " +
                "VALUES (@cId,  @name, @note);";
            MySqlCommand _cmd = new MySqlCommand(sqlAdd, _con);
            try
            {
                _con.Open();
                _cmd.Parameters.AddWithValue("@cId", _dog.custId);
                _cmd.Parameters.AddWithValue("@name", _dog.dogName);
                _cmd.Parameters.AddWithValue("@note", _dog.note);
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error adding dog information " + ex);
                return false;
            }
            finally
            {
                _con.Close();
            }

            
        }

        public bool markComplete(int apptId)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlComplete = "UPDATE Appointment SET isCompleted=@status WHERE AppointmentId=@Id; ";
            MySqlCommand _cmd = new MySqlCommand(sqlComplete, _con);
            _cmd.Parameters.AddWithValue("@status", true);
            _cmd.Parameters.AddWithValue("@id", apptId);
            try
            {
                _con.Open();
                _cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error completing appointment.", "Error");
                return false;
            }
            finally
            {
                _con.Close();
            }
            return true;
        }

        /*      public List<Pet> getPetInfo(int _id)
              {
                  List<Pet> _dogList = new List<Pet>();

                  MySqlConnection _con = new MySqlConnection(_connection);
                  string sqlInfo = "SELECT * FROM Pet Where customerId = @id;";
                  MySqlCommand _cmd = new MySqlCommand(sqlInfo, _con);
                  _cmd.Parameters.AddWithValue("@id", _id);
                  _con.Open();
                  MySqlDataReader _rdr = _cmd.ExecuteReader();

                  try
                  {

                      while (_rdr.Read())
                      {
                          Pet _dog = new Pet();
                          _dog.dogId = (int)_rdr["PetId"];
                          _dog.custId = (int)_rdr["customerId"];
                          _dog.dogName = _rdr["DogName"].ToString();
                          _dog.note = _rdr["Note"].ToString();
                          _dogList.Add(_dog);

                      }
                      return _dogList;
                  }
                  catch (MySqlException ex)
                  {
                      MessageBox.Show("Error getting information. " + ex);
                      return null;
                  }
                  finally
                  {
                      _con.Close();
                      _rdr.Close();
                  }



              }*/
        public Pet getPetInfo(int _id)
        {
            Pet _dog = new Pet();
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlInfo = "SELECT * FROM Pet Where petId = @id;";
            MySqlCommand _cmd = new MySqlCommand(sqlInfo, _con);
            _cmd.Parameters.AddWithValue("@id", _id);
            _con.Open();
            MySqlDataReader _rdr = _cmd.ExecuteReader();

            try
            {

                while (_rdr.Read())
                {
                    _dog.dogId = (int)_rdr["PetId"];
                    _dog.custId = (int)_rdr["customerId"];
                    _dog.dogName = _rdr["DogName"].ToString();
                    _dog.note = _rdr["Note"].ToString();
                }
                return _dog;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error getting information. " + ex);
                return null;
            }
            finally
            {
                _con.Close();
                _rdr.Close();
            }



        }

        public List<Pet> getCustomerDogs(int custId)
        {
            List<Pet> _dogList = new List<Pet>();
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlDogs = "SELECT * FROM Pet where customerId = @cId;";
            MySqlCommand _cmd = new MySqlCommand(sqlDogs, _con);
            _cmd.Parameters.AddWithValue("@cId", custId);
            _con.Open();
            MySqlDataReader _rdr = _cmd.ExecuteReader();

            while (_rdr.Read())
            {
                Pet _dog = new Pet();
                _dog.dogId = (int)_rdr["PetId"];
                _dog.custId = (int)_rdr["customerId"];
                _dog.dogName = _rdr["DogName"].ToString();
                _dog.note = _rdr["Note"].ToString();
                _dogList.Add(_dog);
            }
            return _dogList;
        }

        public bool UpdateDogInfo(Pet _dog)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlUpdate = "UPDATE Pet SET DogName=@name, Note=@note WHERE PetId=@id;";
            MySqlCommand _cmd = new MySqlCommand(sqlUpdate, _con);
            try
            {
                _con.Open();
                _cmd.Parameters.AddWithValue("@id", _dog.dogId);
                _cmd.Parameters.AddWithValue("@name", _dog.dogName);
                _cmd.Parameters.AddWithValue("@note", _dog.note);
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error updating " + ex);
                return false;
            }
            finally
            {
                _con.Close();
            }
            
        }

        public bool DeleteDogInfo(int _id)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlDel = "DELETE FROM Pet where PetId=@id;";
            MySqlCommand _cmd = new MySqlCommand(sqlDel, _con);
            try
            {
                _con.Open();
                _cmd.Parameters.AddWithValue("@id", _id);
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Could not delete dog information. " + ex);
                return false;
            }
            finally
            {
               _con.Close();
            }
 
           
        }

        public bool NewAppointment(Appointment _appt)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlNew = "INSERT INTO Appointment (userId, customerId, addressId, start, end, createdBy, AppointmentType) " +
                "VALUES (@uId, @cId, @aId, @start, @end, @createdby, @appttype);";
            MySqlCommand _cmd = new MySqlCommand(sqlNew, _con);
            _cmd.Parameters.AddWithValue("@uId", CurrentUserId);
            _cmd.Parameters.AddWithValue("@cId", _appt.customerid);
            _cmd.Parameters.AddWithValue("@aId", _appt.addrId);
            _cmd.Parameters.AddWithValue("@start", _appt.startTime);
            _cmd.Parameters.AddWithValue("@end", _appt.endTime);
            _cmd.Parameters.AddWithValue("@createdby", CurrentUser);
            _cmd.Parameters.AddWithValue("@appttype", _appt.apptType);
            try
            {
                _con.Open();
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error adding appointment. " + ex);
                return false;
            }
            finally
            {
                _con.Close();
            }

            
        }

        /*        public void NewAppointment(Appointment _appt)
                {
                    MySqlConnection _con = new MySqlConnection(_connection);
                    string sqlNew = "INSERT INTO Appointment (userId, customerId, addressId, PetId, start, end, createdBy, AppointmentType) " +
                        "VALUES (@uId, @cId, @aId, @pId, @start, @end, @createdby, @appttype);";
                    MySqlCommand _cmd = new MySqlCommand(sqlNew, _con);
                    _cmd.Parameters.AddWithValue("@uId", CurrentUserId);
                    _cmd.Parameters.AddWithValue("@cId", _appt.customerid);
                    _cmd.Parameters.AddWithValue("@aId", _appt.addrId);
                    _cmd.Parameters.AddWithValue("@pId", _appt.petid);
                    _cmd.Parameters.AddWithValue("@start", _appt.startTime);
                    _cmd.Parameters.AddWithValue("@end", _appt.endTime);
                    _cmd.Parameters.AddWithValue("@createdby", CurrentUser);
                    _cmd.Parameters.AddWithValue("@appttype", _appt.apptType);
                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }*/

/*        public BindingList<Appointment> GetAllAppts()
        {
            BindingList<Appointment> AllAppts = new BindingList<Appointment>();
            Appointment _appt = new Appointment();
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlAll = "select AppointmentId, Customer.CustomerName, Pet.DogName, Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Appointment.start, Appointment.end, Appointment.AppointmentType, Appointment.isCompleted " +
                "FROM Appointment LEFT JOIN Customer ON Appointment.customerId = Customer.CustomerId " +
                "LEFT JOIN Address ON Appointment.addressId = Address.addressId " +
                "LEFT JOIN Pet ON Appointment.petId = Pet.petId " +
                "ORDER BY Appointment.start;";
            MySqlCommand _cmd = new MySqlCommand(sqlAll, _con);
            _con.Open();
            MySqlDataReader _rdr = _cmd.ExecuteReader();

            while (_rdr.Read())
            {
                _appt.id = (int)_rdr["AppointmentId"];
                _appt.userid = (int)_rdr["userId"];
                

                AllAppts.Add(_appt);
            }
            _con.Close();
            return AllAppts;
        }*/

        public Appointment getAppointment(int apptId)
        {
            Appointment _appt = new Appointment();
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlAppt = "SELECT * FROM Appointment where AppointmentId=@id;";
            MySqlCommand _cmd = new MySqlCommand(sqlAppt, _con);
            _con.Open();
            _cmd.Parameters.AddWithValue("@id", apptId);

            MySqlDataReader _rdr = _cmd.ExecuteReader();
            try
            {
                while (_rdr.Read())
                {
                    _appt.id = (int)_rdr["AppointmentId"];
                    _appt.userid = (int)_rdr["userId"];
                    _appt.customerid = (int)_rdr["customerId"];
                    _appt.addrId = (int)_rdr["addressId"];
                    _appt.startTime = Convert.ToDateTime(_rdr["start"]);
                    _appt.endTime = Convert.ToDateTime(_rdr["end"]);
                    _appt.createdby = _rdr["createdBy"].ToString();
                    _appt.apptType = _rdr["AppointmentType"].ToString();
                    _appt.apptComplete = Convert.ToBoolean( _rdr["isCompleted"]);
                }
                return _appt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Could not get appointment " + ex, "Error");
                return null;
            }
            finally
            {
                _rdr.Close();
                _con.Close();
            }

            
        }

        public bool changeAppointment(Appointment _appt)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlChange = "UPDATE Appointment SET start=@startTime, end=@endTime, AppointmentType=@apptType, isCompleted=@complete WHERE AppointmentId=@id;";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(sqlChange, _con);
                _cmd.Parameters.AddWithValue("@id", _appt.id);
                _cmd.Parameters.AddWithValue("@startTime", _appt.startTime);
                _cmd.Parameters.AddWithValue("@endTime", _appt.endTime);
                _cmd.Parameters.AddWithValue("@apptType", _appt.apptType);
                _cmd.Parameters.AddWithValue("@complete", _appt.apptComplete);
                _con.Open();
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Could not change appointment " + ex, "Error");
                return false;
            }
            finally
            {
                _con.Close();
            }

        }

        public bool cancelAppointment(int _id)
        {
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlCancel = "DELETE FROM Appointment WHERE AppointmentId = @id;";
            try
            {
                _con.Open();
                MySqlCommand _cmd = new MySqlCommand(sqlCancel, _con);
                _cmd.Parameters.AddWithValue("@id", _id);
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Could not cancel appointment " + ex, "Error");
                return false;
            }
            finally
            {
                _con.Close();
            }
        }

        public bool doesOverLap(DateTime _start, DateTime _end)
        {
           
            MySqlConnection _con = new MySqlConnection(_connection);
            string sqlOverlap = "select EXISTS (select * from Appointment where @start < end AND @end > start); ";
            MySqlCommand _cmd = new MySqlCommand(sqlOverlap, _con);
            try
            {
                _cmd.Parameters.AddWithValue("@start", _start);
                _cmd.Parameters.AddWithValue("@end", _end);
                _con.Open();

                if(_cmd.ExecuteScalar().ToString() == "1")
                {
                    return true;
                }
                return false;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error checking for appointment overlap " + ex);
                return true;
            }
            finally
            {
                _con.Close();
            }

        }


        public static string getDateTime()
        {

            DateTime date = DateTime.UtcNow;
            string newDate = date.ToString("yyyy-MM-dd H:mm:ss");
            return newDate;
        }


    }
}
