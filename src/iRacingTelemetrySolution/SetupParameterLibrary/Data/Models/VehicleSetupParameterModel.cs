using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetupParameterLibrary.Data.Models
{
    [Table("VehicleSetupParameter")]
    class VehicleSetupParameterModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid VehicleSetupParameterId { get; set; }
        [ForeignKey("Vehicle")]
        public virtual Guid VehicleId { get; set; }
        public virtual VehicleModel Vehicle { get; set; }
        public virtual IList<SetupParameterModel> Parameters { get; set; }
    }
}
