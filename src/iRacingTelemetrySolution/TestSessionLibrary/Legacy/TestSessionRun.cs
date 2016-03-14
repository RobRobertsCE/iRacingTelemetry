using System;
using System.IO;
using TestSessionLibrary.Data;

namespace TestSessionLibrary
{
    public class TestSessionRun
    {
        private const string DefaultCurrentSetupFile = "-Current-";

        public Guid TestSessionRunId { get; set; }
        public string ExportFile { get; set; }
        public byte[] SetupFile { get; set; }
        public byte[] TelemetryFile { get; set; }
        public DateTime Timestamp { get; set; }
        public string Notes { get; set; }
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
        public Guid? SetupId { get; set; }        
        
        public ModifiedSetupModel Setup { get; set; }

        public TestSessionRunData Data { get; set; }

        public TestSessionRun()
        {
            Timestamp = DateTime.Now;
        }
        public TestSessionRun(TestSessionRunModel model)
        {
            this.TestSessionRunId = model.TestSessionRunId;
            this.SetupId = model.SetupId;
            this.ExportFile = model.ExportFile;
            this.SetupFile = model.SetupFile;
            this.TelemetryFile = model.TelemetryFile;
            this.TrackName = model.TrackName;
            this.TrackIdNumber = model.TrackIdNumber;
            this.CarName = model.CarName;
            this.CarPath = model.CarPath;
            this.CarIdNumber = model.CarIdNumber;
            this.TrackTemp = model.TrackTemp;
            this.AirTemp = model.AirTemp;
            this.Skies = model.Skies;
            this.Night = model.Night;
            this.Night = model.Night;
            this.SessionType = model.SessionType;
            this.TelemetryDiskFile = model.TelemetryDiskFile;
            this.SetupName = model.SetupName;
            this.SetupIsModified = model.SetupIsModified;
            this.LapCount = model.LapCount;
            this.Timestamp = model.Timestamp;
            this.Setup = model.Setup;
        }

        public TestSessionRun(string exportFileName, string telemetryFileName)
        {
            Timestamp = DateTime.Now;
            LoadTelemetryFile(telemetryFileName);
            if (!String.IsNullOrEmpty(exportFileName))
            {
                LoadExportFile(exportFileName);
                var setupDirectory = Path.GetDirectoryName(exportFileName);
                var currentSetupFile = Path.Combine(setupDirectory, DefaultCurrentSetupFile);
                LoadSetupFile(currentSetupFile);
            }         
        }

        public virtual void LoadExportFile(string exportFile)
        {
            if (!File.Exists(exportFile))
                throw new ArgumentException("exportFile");

            ExportFile = File.ReadAllText(exportFile);
        }

        public virtual void LoadCurrentSetupFile(string setupDirectory)
        {
            var currentSetupFile = Path.Combine(setupDirectory, DefaultCurrentSetupFile);
            LoadSetupFile(currentSetupFile);
        }

        public virtual void LoadSetupFile(string setupFile)
        {
            if (!File.Exists(setupFile))
                throw new ArgumentException("setupFile");

            SetupFile = File.ReadAllBytes(setupFile);
        }

        public virtual void LoadTelemetryFile(string telemetryFile)
        {
            if (!File.Exists(telemetryFile))
                throw new ArgumentException("telemetryFile");

            TelemetryFile = File.ReadAllBytes(telemetryFile);

        }

        internal virtual TestSessionRunModel ToNewModel()
        {
            var model = new TestSessionRunModel();
            UpdateModel(ref model);
            return model;
        }
        internal virtual void UpdateModel(ref TestSessionRunModel model)
        {
            model.SetupId = this.SetupId;
            model.ExportFile = this.ExportFile;
            model.SetupFile = this.SetupFile;
            model.TelemetryFile = this.TelemetryFile;
            model.TrackName = this.TrackName;
            model.TrackIdNumber = this.TrackIdNumber;
            model.CarName = this.CarName;
            model.CarPath = this.CarPath;
            model.CarIdNumber = this.CarIdNumber;
            model.TrackTemp = this.TrackTemp;
            model.AirTemp = this.AirTemp;
            model.Skies = this.Skies;
            model.Night = this.Night;
            model.Night = this.Night;
            model.SessionType = this.SessionType;
            model.TelemetryDiskFile = this.TelemetryDiskFile;
            model.SetupName = this.SetupName;
            model.SetupIsModified = this.SetupIsModified;
            model.LapCount = this.LapCount;
            model.Timestamp = this.Timestamp;
        }
    }
}
