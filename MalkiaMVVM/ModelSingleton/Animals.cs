using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Singleton
{
    public class Animals
    {

        public string DateOfBirth = DateTime.UtcNow.ToString("DD,MM,YYYY");
        public Animals() { }
        public Animals(int aId, string name, DateTime dob, string image, int tId)
        {
            Name = name;
            AId = aId;
            Dob = dob;
            Image = image;
            TId = tId;
        }
        public int AId { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
      



        public int TId { get; set; }
        public string Image { get; set; }

    }
}
