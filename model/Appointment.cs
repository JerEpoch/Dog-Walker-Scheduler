using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JStudzinski_CapstoneA.model
{
    public class Appointment
    {
        private int Id;
        private int userId;
        private int customerId;
        private int addressId;
        //private int petId;
        private DateTime start;
        private DateTime end;
        private string createdBy;
        private string AppointmentType;
        private bool isComplete;

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public int userid
        {
            get { return userId; }
            set { userId = value; }
        }

        public int customerid
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public int addrId
        {
            get { return addressId; }
            set { addressId = value; }
        }

  /*      public int petid
        {
            get { return petId; }
            set { petId = value; }
        }*/

        public DateTime startTime
        {
            get { return start; }
            set { start = value; }
        }
        
        public DateTime endTime
        {
            get { return end; }
            set { end = value; }
        }

        public string createdby
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public string apptType
        {
            get { return AppointmentType; }
            set { AppointmentType = value; }
        }

        public bool apptComplete
        {
            get { return isComplete; }
            set { isComplete = value; }
        }
        public Appointment()
        {

        }
    }
}
