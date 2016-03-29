using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TelemetryViewer.Business
{
    public class WorkspaceDefinition
    {
        public IList<WorkspaceControlsSettings> WorkspaceControls { get; set; }
        public WorkspaceMappings Mapping { get; set; }

        public WorkspaceDefinition()
        {
            WorkspaceControls = new List<WorkspaceControlsSettings>();
        }

        public static WorkspaceDefinition Load(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject< WorkspaceDefinition>(json);
        }

        public void Save(string fileName)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public class WorkspaceControlsSettings
        {
            public Guid TelemetryControlId { get; set; }
            public Point Location { get; set; }
            public Size Size { get; set; }
            public int ZOrder { get; set; }
            public FormWindowState WindowState { get; set; }
        }
    }
}
