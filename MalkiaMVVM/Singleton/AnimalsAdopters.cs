using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Singleton
{
    class AnimalsAdopters
    {
        public AnimalsAdopters() { }
        public AnimalsAdopters (int oId, int aId, DateTime date)
        {
            OId = oId;
            AId = aId;
            Date = date;

        }
         public int OId { get; set; }
        public int AId { get; set; }
        public DateTime Date { get; set; }
    }
}
