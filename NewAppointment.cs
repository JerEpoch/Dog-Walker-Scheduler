using JStudzinski_CapstoneA.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JStudzinski_CapstoneA
{
    public partial class NewAppointment : Form
    {
        private bool doneLoading = false;
        DBHelper _dbhelp = new DBHelper();
        Address _address = new Address();
        Customer _customer = new Customer();
        Pet _dog = new Pet();
        List<Pet> _dogList = new List<Pet>();
        Appointment _appt = new Appointment();
        public NewAppointment()
        {
            InitializeComponent();
            
            getCustomers();
            cmbCustomerDefault();
        }

        public void cmbCustomerDefault()
        {
            cmbCustomers.SelectedItem = null;
            cmbCustomers.Text = "Select Customer";
            doneLoading = true;
            btnNew.Enabled = true;
        }

        public void getCustomers()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "Select * from Customer;";
            MySqlConnection _con = new MySqlConnection(DBConnection.connectSqlString);
            _con.Open();
            MySqlCommand _cmd = new MySqlCommand(sql, _con);
            try
            {
                da.SelectCommand = _cmd;
                da.Fill(dt);
                cmbCustomers.ValueMember = "CustomerId";
                cmbCustomers.DisplayMember = "CustomerName";
                cmbCustomers.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Error getting customer list.", "Error");

            }
            finally
            {
                _con.Close();
            }



            
            
        }

        private void setCustomerInfo()
        {
            txtCustName.Text = _customer.Name;
            txtPhone.Text = _customer.Phone;
            txtAddr1.Text = _address.addr1;
            txtAddr2.Text = _address.addr2;
            txtCity.Text = _address.city;
            txtState.Text = _address.state;
            //txtDogName.Text = _dog.dogName;
            richTxtNotes.Rtf = _dog.note;

  
        }

        private void setDogs(int custId)
        {
            lstDogs.Items.Clear();
            _dogList = _dbhelp.getCustomerDogs(custId);

            foreach(Pet p in _dogList)
            {
                lstDogs.Items.Add(p.dogName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainScreen frm = new MainScreen();
            this.Hide();
            frm.Show();
        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {

            var id = Convert.ToInt32(cmbCustomers.SelectedValue);
            if (doneLoading)
            {
                _customer = _dbhelp.getCustomer(id);
                _address = _dbhelp.getAddress(_customer.addrId);
                //_dog = _dbhelp.getPetInfo(_customer.custId);
                setCustomerInfo();
                setDogs(_customer.custId);
            }
        }
        private bool checkInfo()
        {
            DateTime start = dateDay.Value.Date + dateStart.Value.TimeOfDay;
            DateTime end = dateDay.Value.Date + dateEnd.Value.TimeOfDay;
            DateTime startNew = start.ToUniversalTime();
            DateTime endNew = end.ToUniversalTime();


            if (cmbCustomers.Text == "")
            {
                MessageBox.Show("You must select a customer.", "Error");
                return false;
            }
            if(cmbType.Text == "")
            {
                MessageBox.Show("You must select an appointment type.", "Error");
                return false;
            }
            if(dateStart.Value.Hour >= dateEnd.Value.Hour)
            {
                MessageBox.Show("The start time can not be after the end time.");
                return false;
            }
            if(dateStart.Value.Hour < 7 || dateStart.Value.Hour > 19 || dateEnd.Value.Hour < 7 || dateEnd.Value.Hour > 19)
            {
                MessageBox.Show("The hours must be between 7am and 7pm.");
                return false;
            }
            if(_dbhelp.doesOverLap(startNew, endNew))
            {
                MessageBox.Show("An appointment exists already for that time.");
                return false;
            }


            return true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            
            if (checkInfo())
            {
                DateTime start = dateDay.Value.Date + dateStart.Value.TimeOfDay;
                DateTime end = dateDay.Value.Date + dateEnd.Value.TimeOfDay;
                DateTime startNew = start.ToUniversalTime();
                DateTime endNew = end.ToUniversalTime();

                _appt.startTime = startNew;
                _appt.endTime = endNew;
                _appt.addrId = _address.addrId;
                // _appt.petid = _dog.dogId;
                _appt.customerid = _customer.custId;
                _appt.apptType = cmbType.Text;
                var result = _dbhelp.NewAppointment(_appt);
                if (result)
                {
                    if (MessageBox.Show("Appointment added successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        MainScreen frm = new MainScreen();
                        this.Hide();
                        frm.Show();
                    }
                }
            }
            

        }



        private void lstDogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = _dogList[lstDogs.SelectedIndex].dogId;
            _dog = _dbhelp.getPetInfo(id);
            richTxtNotes.Rtf = _dog.note;
        }

        private void NewAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
