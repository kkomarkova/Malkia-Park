namespace MalkiaParkWebApiServices
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MalkiaDB : DbContext
    {
        public MalkiaDB()
            : base("name=MalkiaDB")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Adopter> Adopters { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalsAdopter> AnimalsAdopters { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adopter>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Adopter>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.Type1)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.Origine)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Animals)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);
        }
    }
}
