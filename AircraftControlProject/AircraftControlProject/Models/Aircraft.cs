namespace AircraftControlProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aircraft
    {
        [Key]
        public int AIRCRAFT_ID { get; set; }

        [Required]
        [StringLength(6)]
        public string PREFIX { get; set; }

        public decimal MAX_DEPARTURE_WEIGHT { get; set; }

        public decimal MAX_LANDING_WEIGHT { get; set; }

        public bool ACTIVE { get; set; }

        public int? AIRCRAFT_MODEL_ID { get; set; }

        public virtual AircraftModel AircraftModel { get; set; }
    }
}
