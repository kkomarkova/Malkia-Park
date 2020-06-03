namespace MalkiaWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnimalsAdopters
    {
        [Key]
        public int AdoptionId { get; set; }

        public int OId { get; set; }

        public int AId { get; set; }

        public DateTime Date { get; set; }

        public int? Amount { get; set; }

        public virtual Adopters Adopters { get; set; }

        public virtual Animals Animals { get; set; }
    }
}
