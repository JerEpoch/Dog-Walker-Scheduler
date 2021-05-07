using JStudzinski_CapstoneA.model;
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
    public partial class EditAppointment : Form
    {
        Appointment _appt = new Appointment();
        Customer _cust = new Customer();
        DBHelper _dbhelper = new DBHelper();
        public EditAppointment(int apptId)
        {
            InitializeComponent();
            setApptInfo(apptId);
            getCustomer();
            setInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainScreen frm = new MainScreen();
            this.Hide();
            frm.Show();
        }

        private void setApptInfo(int _id)
        {
            _appt = _dbhelper.getAppointment(_id);
            
        }

        private void getCustomer()
        {
            _cust = _dbhelper.getCustomer(_appt.customerid);
        }

        private void setInfo()
        {
            txtCustomerName.Text = _cust.Name;
            dateDay.Value = _appt.startTime.ToLocalTime();
            dateStart.Value = _appt.startTime.ToLocalTime();
            dateEnd.Value = _appt.endTime.ToLocalTime();
            cmbType.Text = _appt.apptType;
        }

        private bool checkInfo()
        {
            DateTime start = dateDay.Value.Date + dateStart.Value.TimeOfDay;
            DateTime end = dateDay.Value.Date + dateEnd.Value.TimeOfDay;
            DateTime startNew = start.ToUniversalTime();
            DateTime endNew = end.ToUniversalTime();

            if (cmbType.Text == "")
            {
                MessageBox.Show("You must select an appointment type.", "Error");
                return false;
            }
            if (dateStart.Value.Hour >= dateEnd.Value.Hour)
            {
                MessageBox.Show("The start time can not be after the end time.");
                return false;
            }

            if (dateStart.Value.Hour < 7 || dateStart.Value.Hour > 19 || dateEnd.Value.Hour < 7 || dateEnd.Value.Hour > 19)
            {
                MessageBox.Show("The hours must be between 7am and 7pm.");
                return false;
            }
            if (_dbhelper.doesOverLap(startNew, endNew))
            {
                MessageBox.Show("An appointment exists already for that time.");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //verify stuff
            if (checkInfo())
            {
                DateTime start = dateDay.Value.Date + dateStart.Value.TimeOfDay;
                DateTime end = dateDay.Value.Date + dateEnd.Value.TimeOfDay;
                DateTime startNew = start.ToUniversalTime();
                DateTime endNew = end.ToUniversalTime();

                _appt.startTime = startNew;
                _appt.endTime = endNew;
                _appt.apptType = cmbType.Text;
/*                if (chkComplete.Checked)
                {
                    _appt.apptComplete = true;
                }
                else
                {
                    _appt.apptComplete = false;
                }*/
                var result = _dbhelper.changeAppointment(_appt);
                if (result)
                {
                    if (MessageBox.Show("Appointment changed successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
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
