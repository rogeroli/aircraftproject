namespace AircraftProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModeloDeDados")
        {
        }

        public virtual DbSet<AircraftModel> AircraftModel { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircraftModel>()
                .Property(e => e.MAX_DEPARTURE_WEIGHT)
                .HasPrecision(18, 3);

            modelBuilder.Entity<AircraftModel>()
                .Property(e => e.MAX_LANDING_WEIGHT)
                .HasPrecision(18, 3);
        }
    }
}
