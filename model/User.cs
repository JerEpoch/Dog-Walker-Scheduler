using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JStudzinski_CapstoneA.model
{
    public class User
    {
        private int Id;
        private string username;
        private string password;

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string userName
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User()
        {

        }
    }




}
