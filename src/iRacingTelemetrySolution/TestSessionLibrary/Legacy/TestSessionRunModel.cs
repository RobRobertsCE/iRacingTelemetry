using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSessionLibrary.Data
{
    [Table("TestSessionRun")]
    public class TestSessionRunModel
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TestSessionRunId { get; set; }

        public string ExportFile { get; set; }
        public byte[] SetupFile { get; set; }
        public byte[] TelemetryFile { get; set; }
        public DateTime Timestamp { get; set; }
        public string TrackName { get; set; }
        public string TrackIdNumber { get; set; }
        public string CarName { get; set; }
        public string CarPath { get; set; }
        public string CarIdNumber { get; set; }
        public string TrackTemp { get; set; }
        public string AirTemp { get; set; }
        public string Skies { get; set; }
        public bool Night { get; set; }
        public string SessionType { get; set; }
        public string TelemetryDiskFile { get; set; }
        public string SetupName { get; set; }
        public bool SetupIsModified { get; set; }
        public int LapCount { get; set; }
        [ForeignKey("Setup")]
        public Guid? SetupId { get; set; }
        public string Notes { get; set; }

        public ModifiedSetupModel Setup
        {
            get; set;
        }

        public TestSessionRunModel()
        {

        }
    }
}
