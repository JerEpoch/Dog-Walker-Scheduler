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
    public partial class ActivePerCity : Form
    {
        private int CurrentSelectIndex = -1;
        DBHelper _dbhelper = new DBHelper();

        public ActivePerCity()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ActivePerCity_Load(object sender, EventArgs e)
        {
            getCities();
            dgvActive.Columns[0].Visible = false;
            dgvActive.ClearSelection();
        }

        private void getCities()
        {
            string sqlActive = "select Address.AddressId, City, count(Customer.active) as 'Active customers in city' FROM Address  left join Customer on Customer.addressId=Address.AddressId WHERE Customer.active = true group by City ;";
            MySqlConnection _con = new MySqlConnection(_dbhelper.GetConnection());
            MySqlCommand _cmd = new MySqlCommand(sqlActive, _con);
            try
            {
                _con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvActive.DataSource = dt;
                
                dgvActive.ClearSelection();
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

        private void getCustomers()
        {
            string sqlCustomers = "select CustomerName, Address1, Address2, City, State, PostalCode, PhoneNumber from Address  left join Customer on Customer.addressId = Address.AddressId where City =@cityName;";
            MySqlConnection _con = new MySqlConnection(_dbhelper.GetConnection());
            MySqlCommand _cmd = new MySqlCommand(sqlCustomers, _con);
            try
            {
                _con.Open();
                _cmd.Parameters.AddWithValue("@cityName", dgvActive.Rows[CurrentSelectIndex].Cells[1].Value.ToString());
                MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
                dgvCustomers.ClearSelection();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting reports. " + ex, "Error");
            }
            finally
            {
                _con.Close();
            }

        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            if(CurrentSelectIndex > -1)
            {
                getCustomers();
            }
            else
            {
                MessageBox.Show("Please select from the list.", "Error");
            }
        }

        private void dgvActive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectIndex = e.RowIndex;
        }

        private void ActivePerCity_Shown(object sender, EventArgs e)
        {
            dgvActive.ClearSelection();
        }
    }
}
