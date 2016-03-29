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
    public partial class TelemetryViewControl : UserControl, ITelemetryViewControl
    {
        public event EventHandler RequestFirstFrame;
        protected void OnRequestFirstFrame()
        {
            var handler = this.RequestFirstFrame;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public event EventHandler RequestLastFrame;
        protected void OnRequestLastFrame()
        {
            var handler = this.RequestLastFrame;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public event EventHandler RequestNextFrame;
        protected void OnRequestNextFrame()
        {
            var handler = this.RequestNextFrame;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public event EventHandler RequestPreviousFrame;
        protected void OnRequestPreviousFrame()
        {
            var handler = this.RequestPreviousFrame;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public event EventHandler RequestBringToFront;
        protected void OnRequestBringToFront()
        {
            var handler = this.RequestBringToFront;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private Point MouseDownLocation;

        public virtual string Title { get; }
        public IList<TelemetryFrame> Frames { get; set; }
        public virtual Guid TelemetryControlId { get { throw new NotImplementedException(); } }
        public int ZOrder { get; set; }

        public TelemetryViewControl()
        {
            InitializeComponent();
            lblTelemetryViewControl.Text = Title;
            Canvas.BackColor = BackColor;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.Style |= 0x840000;  // Turn on WS_BORDER + WS_THICKFRAME
                return cp;
            }
        }
        public virtual void DisplayFrame(int frameIdx)
        {
            throw new NotImplementedException();
        }

        public virtual WorkspaceDefinition.WorkspaceControlsSettings GetSettings()
        {
            var settings = new WorkspaceDefinition.WorkspaceControlsSettings()
            {
                Location = this.Location,
                Size = this.Size,
                ZOrder = this.ZOrder,
                TelemetryControlId = this.TelemetryControlId
            };

            return settings;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void Canvas_DoubleClick(object sender, EventArgs e)
        {
            OnRequestBringToFront();
        }
    }
}
