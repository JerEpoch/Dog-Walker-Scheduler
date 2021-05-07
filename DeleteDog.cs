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
    public partial class DeleteDog : Form
    {
        private bool doneLoading = false;
        DBHelper _dbhelp = new DBHelper();
        Pet _dog = new Pet();
        
        public DeleteDog()
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
            try
            {
                _con.Open();
                MySqlCommand _cmd = new MySqlCommand(sql, _con);
                da.SelectCommand = _cmd;
                da.Fill(dt);

                cmbCustomers.ValueMember = "customerId";
                cmbCustomers.DisplayMember = "CustomerName";
                cmbCustomers.DataSource = dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting customer list " + ex, "Error");
            }
            finally
            {
                _con.Close();
            }



        }

        public void getDogs(int custId)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "Select * from Pet where CustomerId=@id;";
            MySqlConnection _con = new MySqlConnection(DBConnection.connectSqlString);
            try
            {
                _con.Open();
                MySqlCommand _cmd = new MySqlCommand(sql, _con);
                _cmd.Parameters.AddWithValue("@id", custId);
                da.SelectCommand = _cmd;
                da.Fill(dt);

                cmbDogs.ValueMember = "PetId";
                cmbDogs.DisplayMember = "DogName";
                cmbDogs.DataSource = dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting dog list " + ex, "Error");
            }
            finally
            {
                _con.Close();
            }

        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            if (doneLoading)
            {
                var id=Convert.ToInt32(cmbCustomers.SelectedValue);
                getDogs(id);
                //txtName.Text = _dog.dogName;
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainScreen frm = new MainScreen();
            this.Hide();
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this information?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var result = _dbhelp.DeleteDogInfo(_dog.dogId);
                if (result)
                {
                    if (MessageBox.Show("Dog information deleted successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        MainScreen frm = new MainScreen();
                        this.Hide();
                        frm.Show();
                    }
                }
            }
        }

        private void cmbDogs_SelectedValueChanged(object sender, EventArgs e)
        {
            _dog = _dbhelp.getPetInfo(Convert.ToInt32(cmbDogs.SelectedValue));
            richTxtNotes.Rtf = _dog.note;
        }
    }

 
}
