using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Singleton
{
    class Adopters
    {
        public Adopters() { }


        public Adopters (int oId, string username, string password)
        {
            OId = OId;
            Username = username;
            Password = password;
        }

        public int OId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

       
    }
}
