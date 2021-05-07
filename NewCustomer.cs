using JStudzinski_CapstoneA.model;
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
    public partial class NewCustomer : Form
    {
        private Customer _customer = new Customer();
        private Address _address = new Address();
        private DBHelper _dbhelp = new DBHelper();
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

                var result = _dbhelp.AddCustomer(_customer, _address);
                if (result)
                {
                    if (MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        MainScreen frm = new MainScreen();
                        this.Hide();
                        frm.Show();
                    }
                }
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
            if(!(radNo.Checked || radYes.Checked))
            {
                MessageBox.Show("Please mark either active or inactive.");
                return false;
            }
            if (!(validatePhone.IsMatch(txtPhone.Text) || validatePhone2.IsMatch(txtPhone.Text)))
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
    }
}
