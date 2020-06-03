using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Singleton
{
    public class AnimalsAdopters
    {
        public AnimalsAdopters() { }
        public AnimalsAdopters (int adoptionId, int oId, int aId, DateTime? date, int amount)
        {
            AdoptionId = adoptionId;
            OId = oId;
            AId = aId;
            Date = date;
            Amount = amount;
        }
        public int AdoptionId { get; set; }
         public int OId { get; set; }
        public int AId { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }
       
    }
}
