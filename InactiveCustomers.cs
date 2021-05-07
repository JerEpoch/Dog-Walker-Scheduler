using JStudzinski_CapstoneA.model;
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
    public partial class InactiveCustomers : Form
    {
        DBHelper _dbhelper = new DBHelper();
        Address _addr = new Address();
        Customer _cust = new Customer();
        Pet _dog = new Pet();
        public InactiveCustomers()
        {
            InitializeComponent();
        }

        private void InactiveCustomers_Load(object sender, EventArgs e)
        {
            string sqlInactive = "SELECT  Customer.CustomerName,  PhoneNumber, Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, Pet.DogName, DATE( Customer.createDate) as 'Signup Date' " +
                "FROM Customer " +
                "LEFT JOIN Address on Customer.addressId = Address.AddressId " +
                "LEFT JOIN Pet on Pet.PetId = Customer.CustomerId " +
                "WHERE Customer.active = 0;";

            MySqlConnection _con = new MySqlConnection(_dbhelper.GetConnection());
            MySqlCommand _cmd = new MySqlCommand(sqlInactive, _con);
            try
            {
                _con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInactive.DataSource = dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting report " + ex, "Error");
            }
            finally
            {
                _con.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InactiveCustomers_Shown(object sender, EventArgs e)
        {
            dgvInactive.ClearSelection();
        }
    }
}
