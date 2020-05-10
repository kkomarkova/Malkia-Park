using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Singleton
{
    class AnimalsAdopters
    {
        public AnimalsAdopters (int oId, int aId)
        {
            OId = oId;
            AId = aId;

        }
         public int OId { get; set; }
        public int AId { get; set; }

    }
}
