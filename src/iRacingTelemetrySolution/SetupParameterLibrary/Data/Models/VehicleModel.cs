using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetupParameterLibrary.Data.Models
{
    [Table("Vehicles")]
    class VehicleModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid VehicleId { get; set; }
        [Index("IX_Vehicles_CarId", IsUnique = true)]
        public virtual int CarId { get; set; }
        [Required, MaxLength(50)]
        public virtual string Name { get; set; }
    }
}
