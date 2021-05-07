using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JStudzinski_CapstoneA.model
{
    public class Address
    {
        private int Id { get; set; }
        
        private string address1 { get; set; }
        private string address2 { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string PostalCode { get; set; }

/*        public int Customerid
        {
            get { return customerId; }
            set { customerId = value; }
        }*/

        public int addrId
        {
            get { return Id; }
            set { Id = value; }
        }


        public string addr1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string addr2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string city
        {
            get { return City; }
            set { City = value; }
        }

        public string postCode
        {
            get { return PostalCode; }
            set { PostalCode = value; }
        }

        public string state
        {
            get { return State; }
            set { State = value; }
        }

        public Address(int id, string addr1, string addr2, string city, string state, string postalcode)
        {
            Id = id;
  
            address1 = addr1;
            address2 = addr2;
            City = city;
            State = state;
            PostalCode = postalcode;
        }

        public Address() { }
    }
}
