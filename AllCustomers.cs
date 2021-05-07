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
    public partial class AllCustomers : Form
    {
        DBHelper _dbhelper = new DBHelper();
        public AllCustomers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AllCustomers_Load(object sender, EventArgs e)
        {
            getCustomers();
            dgvCustomers.ClearSelection();
        }

        private void getCustomers()
        {
            string sqlCustomers = "select  Customer.CustomerName, PhoneNumber, Address.Address1, Address.Address2, Address.City, Address.State, Address.PostalCode, DATE(Customer.createDate) as 'Joined on' FROM Customer " +
                "LEFT JOIN Address ON Address.AddressId = Customer.AddressId " +
                "ORDER BY Customer.createDate;";
            MySqlConnection _con = new MySqlConnection(_dbhelper.GetConnection());
            MySqlCommand _cmd = new MySqlCommand(sqlCustomers, _con);
            try
            {
                _con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error getting customer report. " + ex, "Error");
            }
            finally
            {
                _con.Close();
                dgvCustomers.ClearSelection();
            }
        }
    }
}
