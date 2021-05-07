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
    

    public partial class EditCustomer : Form
    {
        Customer _customer = new Customer();
        Address _address = new Address();
        DBHelper _dbhelp = new DBHelper();
        private bool doneLoading = false;
        public EditCustomer()
        {
            InitializeComponent();
            getCustomers();
            cmbCustomerDefault();
        }

        public void cmbCustomerDefault()
        {
            cmbCustomers.SelectedItem = null;
            cmbCustomers.Text = "Select Customer";
            btnSave.Enabled = false;
            doneLoading = true;
        }

        public void getCustomers()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "Select * from Customer;";
            MySqlConnection _con = new MySqlConnection(DBConnection.connectSqlString);
            try
            {
                _con.Open();
                MySqlCommand _cmd = new MySqlCommand(sql, _con);
                da.SelectCommand = _cmd;
                da.Fill(dt);

                cmbCustomers.ValueMember = "CustomerId";
                cmbCustomers.DisplayMember = "CustomerName";
                cmbCustomers.DataSource = dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting customer list " + ex);
            }
            finally
            {
                _con.Close();
            }


        }

        private bool checkCustomerInfo()
        {
            Regex validateZip = new Regex(@"^\(?([0-9]{5})$");
            Regex validatePhone = new Regex(@"(?<!\d)\d{10}(?!\d)");
            Regex validatePhone2 = new Regex(@"\d{3}-\d{3}-\d{4}");

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter an Address. Note address 2 can be left blank.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Please enter a city.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbState.Text))
            {
                MessageBox.Show("Please select a state.");
                return false;
            }
            if (!(radNo.Checked || radYes.Checked))
            {
                MessageBox.Show("Please mark either active or inactive.");
                return false;
            }
            if (!(validatePhone.IsMatch(txtPhone.Text) || validatePhone2.IsMatch(txtPhone.Text)) )
            {
                MessageBox.Show("Please enter a valid phone number (XXX-XXX-XXXX or XXXXXXXXXX).");
                return false;
            }
            if (!validateZip.IsMatch(txtPostalCode.Text))
            {
                MessageBox.Show("Please enter a valid postal code (XXXXX).");
                return false;
            }

            return true;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainScreen frm = new MainScreen();
            this.Hide();
            frm.Show();
        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //verify still
            if (checkCustomerInfo())
            {
                _customer.Name = txtName.Text;
                _customer.Phone = txtPhone.Text;
                if (radYes.Checked)
                {
                    _customer.isActive = true;
                }
                else
                {
                    _customer.isActive = false;
                }

                _address.addr1 = txtAddress.Text;
                _address.addr2 = txtAddress2.Text;
                _address.city = txtCity.Text;
                _address.postCode = txtPostalCode.Text;
                _address.state = cmbState.SelectedItem.ToString();

                var result = _dbhelp.updateCustomerInfo(_customer, _address);
                if (result)
                {
                    if (MessageBox.Show("Customer changes saved successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
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
