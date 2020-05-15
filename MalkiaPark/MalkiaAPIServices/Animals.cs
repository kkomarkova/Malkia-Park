namespace MalkiaAPIServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Animals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Dob { get; set; }

        public int TId { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public virtual Types Types { get; set; }
    }
}
