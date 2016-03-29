using iRacing.TelemetryParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using TelemetryViewer.Business;

namespace TelemetryViewer.Controls
{
    interface ITelemetryViewControl : IDisposable
    {
        //event EventHandler RequestNextFrame;
        //event EventHandler RequestPreviousFrame;
        //event EventHandler RequestFirstFrame;
        //event EventHandler RequestLastFrame;
        event EventHandler RequestBringToFront;
      

        string Title { get; }
        Guid TelemetryControlId { get; }
        IList<TelemetryFrame> Frames { get; set; }
        int ZOrder { get; set; }
        Color BackColor { get; }

        void DisplayFrame(int frameIdx);
        WorkspaceDefinition.WorkspaceControlsSettings GetSettings();
    }
}
