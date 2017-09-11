namespace AircraftControlProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloDeDados : DbContext
    {
        public ModeloDeDados()
            : base("name=ModeloDeDados")
        {
        }

        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<AircraftModel> AircraftModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>()
                .Property(e => e.MAX_DEPARTURE_WEIGHT)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Aircraft>()
                .Property(e => e.MAX_LANDING_WEIGHT)
                .HasPrecision(18, 3);

            modelBuilder.Entity<AircraftModel>()
                .Property(e => e.MAX_DEPARTURE_WEIGHT)
                .HasPrecision(18, 3);

            modelBuilder.Entity<AircraftModel>()
                .Property(e => e.MAX_LANDING_WEIGHT)
                .HasPrecision(18, 3);
        }
    }
}
