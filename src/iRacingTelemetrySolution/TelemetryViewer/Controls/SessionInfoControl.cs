using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iRacing.TelemetryParser;
using TelemetryViewer.Business;

namespace TelemetryViewer.Controls
{
    public partial class SessionInfoControl : TelemetryViewControl
    {
        public static Guid ControlId = Guid.Parse("0d4cb0ac-32a0-4545-92e5-4bc614d478c3");
        public override Guid TelemetryControlId { get { return ControlId; } }
        public override string Title { get { return "Session Info"; } }
        public override Color BackColor { get { return Color.LightSteelBlue; } }

        public SessionInfoControl() : base()
        {
        }

        public override void DisplayFrame(int frameIdx)
        {
            throw new NotImplementedException();
        }
    }
}
