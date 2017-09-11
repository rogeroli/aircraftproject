namespace AircraftProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AircraftModel")]
    public partial class AircraftModel
    {
        [Key]
        public int AIRCRAFT_MODEL_ID { get; set; }

        [Required]
        [StringLength(4)]
        public string CODE { get; set; }

        [Required]
        [StringLength(4)]
        public string ALTERNATIVE_CODE { get; set; }

        public decimal MAX_DEPARTURE_WEIGHT { get; set; }

        public decimal MAX_LANDING_WEIGHT { get; set; }
    }
}
