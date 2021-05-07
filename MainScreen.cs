using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JStudzinski_CapstoneA
{
    public partial class MainScreen : Form
    {
        private DBHelper _helper = new DBHelper();
        public static int CurrentSelectIndex = -1;
        public MainScreen()
        {
            InitializeComponent();

        }

        private void btnNewAppt_Click(object sender, EventArgs e)
        {
            NewAppointment frm = new NewAppointment();
            this.Hide();
            frm.Show();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomer frm = new NewCustomer();
            this.Hide();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            EditCustomer frm = new EditCustomer();
            this.Hide();
            frm.Show();
        }

        private void btnDelCustomer_Click(object sender, EventArgs e)
        {
            DeleteCustomer frm = new DeleteCustomer();
            this.Hide();
            frm.Show();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NewUser frm = new NewUser();
            this.Hide();
            frm.Show();
        }

        private void bntChangeUser_Click(object sender, EventArgs e)
        {
            EditUser frm = new EditUser();
            this.Hide();
            frm.Show();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser frm = new DeleteUser();
            this.Hide();
            frm.Show();
        }

        private void btnNewPet_Click(object sender, EventArgs e)
        {
            NewPet frm = new NewPet();
            this.Hide();
            frm.Show();
        }

        private void btnEditPet_Click(object sender, EventArgs e)
        {
            EditPet frm = new EditPet();
            this.Hide();
            frm.Show();
        }

        private void btnDelPet_Click(object sender, EventArgs e)
        {
            DeleteDog frm = new DeleteDog();
            this.Hide();
            frm.Show();
        }

 /*       private void cmbFrequency_SelectedValueChanged(object sender, EventArgs e)
        {
            refreshAppointments();
        }*/

        private void refreshAppointments()
        {
            
            switch (cmbFrequency.Text)
            {
                
                case "Today":
                    GetAppts(DateTime.UtcNow.Date.AddDays(-1), DateTime.UtcNow.Date.AddDays(1));
                    break;
                case "Next 7 days":
                    GetAppts(DateTime.UtcNow.Date.AddDays(-1), DateTime.UtcNow.Date.AddDays(8));
                    break;
                case "Next 31 days":
                    GetAppts(DateTime.UtcNow.Date.AddDays(-1), DateTime.UtcNow.Date.AddDays(32));
                    break;
                default:
                    GetAllAppts();
                    break;

            }
        }
        private void GetAllAppts()
        {
            string sqlAll;
            MySqlConnection _con = new MySqlConnection(_helper.GetConnection());
            if (chkSpecific.Checked)
            {
                sqlAll = "select AppointmentId, Customer.CustomerName, PhoneNumber, Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Appointment.start as 'Appointment Date', Appointment.start as 'Start Time', Appointment.end as 'End Time', Appointment.AppointmentType,  (CASE when Appointment.isCompleted='0' then 'Scheduled' else 'Completed' end) as " + "'Appointment Status' " +
                "FROM Appointment LEFT JOIN Customer ON Appointment.customerId = Customer.CustomerId " +
                "LEFT JOIN Address ON Appointment.addressId = Address.addressId " +
                "WHERE Appointment.userId = @uId " +
                "ORDER BY Appointment.start;";

                MySqlCommand _cmd = new MySqlCommand(sqlAll, _con);
                try
                {
                    _con.Open();
                    _cmd.Parameters.AddWithValue("@uId", _helper.getUserId());
                    MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAppts.DataSource = dt;
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("Error getting appointments. " + ex, "Error");
                }
                finally
                {
                    _con.Close();
                    dgvAppts.ClearSelection();
                }

            }
            else
            {
                sqlAll = "select AppointmentId, Customer.CustomerName, PhoneNumber, Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Appointment.start as 'Appointment Date', Appointment.start as 'Start Time', Appointment.end as 'End Time', Appointment.AppointmentType,  (CASE when Appointment.isCompleted='0' then 'Scheduled' else 'Completed' end) as " + "'Appointment Status' " +
                "FROM Appointment LEFT JOIN Customer ON Appointment.customerId = Customer.CustomerId " +
                "LEFT JOIN Address ON Appointment.addressId = Address.addressId " +
                
                "ORDER BY Appointment.start;";

                MySqlCommand _cmd = new MySqlCommand(sqlAll, _con);
                try
                {
                    _con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAppts.DataSource = dt;
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("Error getting appointments. " + ex, "Error");
                }
                finally
                {
                    _con.Close();
                    dgvAppts.ClearSelection();
                }

            }
            
   /*         string sqlAll = "select AppointmentId, Customer.CustomerName, Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Appointment.start, Appointment.end, Appointment.AppointmentType " +
                "FROM Appointment LEFT JOIN Customer ON Appointment.customerId = Customer.CustomerId " +
                "LEFT JOIN Address ON Appointment.addressId = Address.addressId " +
                "WHERE Appointment.userId = @uId " +
                "ORDER BY Appointment.start;";*/


           
        }

        private void GetAppts(DateTime today, DateTime intervalDate)
        {
            MySqlConnection _con = new MySqlConnection(_helper.GetConnection());
            string sqlAll;
            if (chkSpecific.Checked)
            {
                sqlAll = "SELECT AppointmentId, Customer.CustomerName, PhoneNumber,  Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Appointment.start as 'Appointment Date', Appointment.start as 'Start Time', Appointment.end as 'End Time', Appointment.AppointmentType, (CASE when Appointment.isCompleted='0' then 'Scheduled' else 'Completed' end) as " + "'Appointment Status'" +
                "FROM Appointment LEFT JOIN Customer ON Appointment.customerId = Customer.CustomerId " +
                 "LEFT JOIN Address ON Appointment.addressId = Address.addressId " +

                "WHERE start between @today and @intervalDate and Appointment.userId = @uId; ";
                MySqlCommand _cmd = new MySqlCommand(sqlAll, _con);
                try
                {
                  _con.Open();
                    _cmd.Parameters.AddWithValue("@today", today);
                    _cmd.Parameters.AddWithValue("@intervalDate", intervalDate);
                    _cmd.Parameters.AddWithValue("@uId", _helper.getUserId());
                    MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAppts.DataSource = dt;
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("Error getting appointments. " + ex, "Error");
                }
                finally
                {
                    _con.Close();
                    dgvAppts.ClearSelection();
                }
  
            }
            else
            {
                sqlAll = "select AppointmentId, Customer.CustomerName, PhoneNumber, Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Appointment.start as 'Appointment Date', Appointment.start as 'Start Time', Appointment.end as 'End Time', Appointment.AppointmentType, (CASE when Appointment.isCompleted='0' then 'Scheduled' else 'Completed' end) as " + "'Appointment Status'" +
                "FROM Appointment LEFT JOIN Customer ON Appointment.customerId = Customer.CustomerId " +
                 "LEFT JOIN Address ON Appointment.addressId = Address.addressId " +

                "WHERE start between @today and @intervalDate;";
                MySqlCommand _cmd = new MySqlCommand(sqlAll, _con);
                try
                {
                    _con.Open();
                    _cmd.Parameters.AddWithValue("@today", today);
                    _cmd.Parameters.AddWithValue("@intervalDate", intervalDate);
                    MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAppts.DataSource = dt;
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("Error getting appointments. " + ex, "Error");
                }
                finally
                {
                    _con.Close();
                    dgvAppts.ClearSelection();
                }

            }

/*            string sqlAll = "select AppointmentId, Customer.CustomerName,  Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Appointment.start, Appointment.end, Appointment.AppointmentType " +
                "FROM Appointment LEFT JOIN Customer ON Appointment.customerId = Customer.CustomerId " +
                 "LEFT JOIN Address ON Appointment.addressId = Address.addressId " +

                "WHERE start between @today and @intervalDate and Appointment.userId = @uId;";
            MySqlCommand _cmd = new MySqlCommand(sqlAll, _con);

            _con.Open();
            _cmd.Parameters.AddWithValue("@today", today);
            _cmd.Parameters.AddWithValue("@intervalDate", intervalDate);
            _cmd.Parameters.AddWithValue("@uId", _helper.getUserId());
            MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAppts.DataSource = dt;*/
            
        }

        private void dgvAppts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.Value is DateTime dt)
            {
                e.Value = dt.ToLocalTime();
            }
            dgvAppts.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvAppts.Columns[9].DefaultCellStyle.Format = "HH:mm";
            dgvAppts.Columns[10].DefaultCellStyle.Format = "HH:mm";
        }

        private void dgvAppts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectIndex = e.RowIndex;
        }

        private void btnModifyAppt_Click(object sender, EventArgs e)
        {
            if(CurrentSelectIndex > -1)
            {
                var id = (int)dgvAppts.Rows[CurrentSelectIndex].Cells[0].Value;
                EditAppointment frm = new EditAppointment(id);
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Please select an appointment from the list.");
            }
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + _helper.getCurrentUser();
            //GetAppts(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
            GetAllAppts();
            dgvAppts.Columns[0].Visible = false;
        }


        private void MainScreen_Shown(object sender, EventArgs e)
        {
            dgvAppts.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CurrentSelectIndex = -1;
            refreshAppointments();
        }

        private void btnCancelAppt_Click(object sender, EventArgs e)
        {
            if(CurrentSelectIndex > -1)
            {
             if (MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var id = (int)dgvAppts.Rows[CurrentSelectIndex].Cells[0].Value;
                    var result = _helper.cancelAppointment(id);
                    if (result)
                    {
                        MessageBox.Show("Appointment cancelled", "Success");
                        GetAllAppts();
                        CurrentSelectIndex = -1;

                    }
                }
            }
            else
            {
                MessageBox.Show("You must select an appointment to cancel.", "Error");
            }
   
        }

        private void btnViewRpt_Click(object sender, EventArgs e)
        {
            switch (cmbReports.Text)
            {
                case "View Inactive Customers":
                    InactiveCustomers frm = new InactiveCustomers();
                    frm.Show();
                    break;
                case "Active Customers Per City":
                    ActivePerCity frmActive = new ActivePerCity();
                    frmActive.Show();
                    break;
                case "View All Customers":
                    AllCustomers frmAll = new AllCustomers();
                    frmAll.Show();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(CurrentSelectIndex > -1)
            {
                var id = (int)dgvAppts.Rows[CurrentSelectIndex].Cells[0].Value;
                if (MessageBox.Show("Do you want to mark appointment completed?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var result = _helper.markComplete(id);
                    if (result)
                    {
                        MessageBox.Show("Appointment completed.");
                        CurrentSelectIndex = -1;
                        GetAllAppts();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select an appointment to complete.", "Error");
            }
        }
    }
}
