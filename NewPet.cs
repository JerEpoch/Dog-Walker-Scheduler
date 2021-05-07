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
    public partial class NewPet : Form
    {
        
        DBHelper _dbhelp = new DBHelper();
        Pet _dog = new Pet();
        public NewPet()
        {
            InitializeComponent();
            getCustomers();
            cmbCustomerDefault();
        }

        public void cmbCustomerDefault()
        {
            cmbCustomers.SelectedItem = null;
            cmbCustomers.Text = "Select Customer";
            btnAdd.Enabled = false;
            
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
            btnAdd.Enabled = true;
        }

        public bool checkInfo()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("You must enter a name.");
                return false;
            }
            if(cmbCustomers.Text == "")
            {
                MessageBox.Show("You must select a customer.");
                return false;
            }
            return true;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //verify still
            if (checkInfo())
            {
                _dog.dogName = txtName.Text;
                _dog.note = richTxtNotes.Rtf;
                _dog.custId = Convert.ToInt32(cmbCustomers.SelectedValue);
                var result = _dbhelp.AddNewDog(_dog);
                if (result)
                {
                    if (MessageBox.Show("Dog information added successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
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
