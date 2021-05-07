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
    public partial class DeleteCustomer : Form
    {
        Customer _customer = new Customer();
        Address _address = new Address();
        DBHelper _dbhelp = new DBHelper();
        private bool doneLoading = false;
        public DeleteCustomer()
        {
            InitializeComponent();
            getCustomers();
            cmbCustomerDefault();
        }

        public void cmbCustomerDefault()
        {
            cmbCustomers.SelectedItem = null;
            cmbCustomers.Text = "Select Customer";
            btnDelete.Enabled = false;
            doneLoading = true;
        }

        public void getCustomers()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "Select * from Customer;";
            MySqlConnection _con = new MySqlConnection(DBConnection.connectSqlString);
            _con.Open();
            MySqlCommand _cmd = new MySqlCommand(sql, _con);
            da.SelectCommand = _cmd;
            da.Fill(dt);

            cmbCustomers.ValueMember = "CustomerId";
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.DataSource = dt;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainScreen frm = new MainScreen();
            this.Hide();
            frm.Show();
        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            var id = Convert.ToInt32(cmbCustomers.SelectedValue);

            if (doneLoading)
            {
                _customer = _dbhelp.getCustomer(id);
                _address = _dbhelp.getAddress(_customer.addrId);
                txtName.Text = _customer.Name;
                txtPhone.Text = _customer.Phone;
                if (_customer.isActive)
                {
                    radYes.Checked = true;
                }
                else
                {
                    radNo.Checked = true;
                }
                txtAddress.Text = _address.addr1;
                txtAddress2.Text = _address.addr2;
                txtCity.Text = _address.city;
                txtPostalCode.Text = _address.postCode;
                cmbState.SelectedItem = _address.state;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var result = _dbhelp.DeleteCustomer(_customer, _address);
                if (result)
                {
                    if (MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        MainScreen frm = new MainScreen();
                        this.Hide();
                        frm.Show();
                    }
                }
            }

        }
    }
}
