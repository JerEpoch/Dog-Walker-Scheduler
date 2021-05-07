using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JStudzinski_CapstoneA.model
{
    public class Pet
    {
        private int Id;
        private int customerId;
        private string DogName;
        private string Note;

        public int dogId
        {
            get { return Id; }
            set { Id = value; }
        }

        public int custId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public string dogName
        {
            get { return DogName; }
            set { DogName = value; }
        }

        public string note
        {
            get { return Note; }
            set { Note = value; }
        }

        public Pet()
        {

        }
    }
}
