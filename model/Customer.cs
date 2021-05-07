using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JStudzinski_CapstoneA.model
{
    
    public class Customer
    {
        private int Id { get; set; }
        private int addressId { get; set; }
        private string CustomerName { get; set; }
        private string PhoneNumber { get; set; }
        private DateTime create { get; set; }
        private bool active { get; set; }

        public int custId
        {
            get { return Id; }
            set { Id = value; }
        }

        public int addrId
        {
            get { return addressId; }
            set { addressId = value; }
        }
        public string Name
        {
            get
            { return CustomerName;}

            set
            { CustomerName = value;}
        } 


        public string Phone
        {
            get
            { return PhoneNumber;}

            set
            { PhoneNumber = value;}
        }

        public bool isActive
        {
            get { return active; }
            set { active = value; }
        }

        public Customer(int id, string name, string phone, bool _active)
        {
            
            CustomerName = name;
            PhoneNumber = phone;
            create = DateTime.UtcNow;
            active = _active;
        }

        public Customer()
        {

        }

    }

  

}
