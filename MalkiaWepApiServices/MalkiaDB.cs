namespace MalkiaWepApiServices
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

        public virtual DbSet<Adopters> Adopters { get; set; }
        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<AnimalsAdopters> AnimalsAdopters { get; set; }
        public virtual DbSet<Types> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adopters>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Adopters>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Animals>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Animals>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Types>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Types>()
                .Property(e => e.Origine)
                .IsUnicode(false);

            modelBuilder.Entity<Types>()
                .HasMany(e => e.Animals)
                .WithRequired(e => e.Types)
                .WillCascadeOnDelete(false);
        }
    }
}
