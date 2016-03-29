using log4net;
using iRacing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelemetryViewer.Controls;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using TelemetryViewer.Business;

namespace TelemetryViewer
{
    public partial class MainViewer : Form
    {
        #region fields
        // ADD [assembly: log4net.Config.XmlConfigurator(Watch = true)] TO ASSEMBLY.INFO
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainViewer));
        #endregion

        #region private properties
        private IList<ITelemetryViewControl> TelemetryViewControls { get; set; }
        private WorkspaceDefinition _workspace;
        private WorkspaceDefinition Workspace
        {
            get
            {
                return _workspace;
            }
            set
            {
                _workspace = value;
                DisplayWorkspace(_workspace);
            }
        }
        #endregion

        #region ctor
        public MainViewer()
        {
            InitializeComponent();
        }
        #endregion

        #region Load/Close App
        private void MainViewer_Load(object sender, EventArgs e)
        {
            try
            {
                TelemetryViewControls = new List<ITelemetryViewControl>();
                NewWorkspace();
                LogMessage("App Loaded");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApp();
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            CloseApp();
        }
        void CloseApp()
        {
            this.Close();
        }
        #endregion        

        #region Open/New/Close Workspace
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWorkspace();
        }
        private void tsbOpen_Click(object sender, EventArgs e)
        {
            OpenWorkspace();
        }
        void OpenWorkspace()
        {
            using (var dialog = new OpenFileDialog())
            {
                var result = dialog.ShowDialog();
                //dialog.DefaultExt = ".wbk";
                dialog.Filter = "Workbook (*.wbk)|*.wbk|All Files (*.*)|*.*";
                dialog.FilterIndex = 0;
                if (result != DialogResult.OK) return;
                Workspace = WorkspaceDefinition.Load(dialog.FileName);
            }
        }

        private void newWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewWorkspace();
        }
        void NewWorkspace()
        {
            Workspace = new WorkspaceDefinition();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseWorkspace();
        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseWorkspace();
        }
        void CloseWorkspace()
        {
            CloseTelemetry();
            ClearViews();
        }

        private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWorkspace();
        }
        void SaveWorkspace()
        {
            SaveWorkspaceViewSettings();
            using (var dialog = new SaveFileDialog())
            {
                var result = dialog.ShowDialog();
                dialog.DefaultExt = ".wbk";
                dialog.Filter = "Workbook (*.wbk)|*.wbk|All Files (*.*)|*.*";
                dialog.FilterIndex = 0;
                if (result != DialogResult.OK) return;
                Workspace.Save(dialog.FileName);
            }
        }
        void SaveWorkspaceViewSettings()
        {
            Workspace.WorkspaceControls.Clear();
            foreach (var view in TelemetryViewControls.ToList())
            {
                Workspace.WorkspaceControls.Add(view.GetSettings());
            }
        }
        #endregion

        #region Open/Close Telemetry File
        private void tsbOpenTelemetry_Click(object sender, EventArgs e)
        {
            OpenTelemetry();
        }
        private void openTelemetryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTelemetry();
        }
        void OpenTelemetry()
        {

        }

        private void tsbCloseTelemetry_Click(object sender, EventArgs e)
        {
            CloseTelemetry();
        }
        private void closeTelemetryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTelemetry();
        }
        void CloseTelemetry()
        {

        }
        #endregion

        #region UI
        void DisplayWorkspace(WorkspaceDefinition workspace)
        {
            if (null == workspace)
            {
                ClearViews();
                return;
            }
            LoadWorkspaceViews(workspace);
        }
        void LoadWorkspaceViews(WorkspaceDefinition workspace)
        {
            foreach (var viewSettings in workspace.WorkspaceControls)
            {
                if (viewSettings.TelemetryControlId == SessionInfoControl.ControlId)
                {
                    AddSessionInfoControl(viewSettings);
                }
                else if (viewSettings.TelemetryControlId == LineGraphControl.ControlId)
                {
                    AddLineGraphControl(viewSettings);
                }

            }
        }

        void ClearViews()
        {
            foreach (var view in TelemetryViewControls.ToList())
            {
                pnlViews.Controls.Remove((Control)view);
                view.Dispose();
            }
        }
        #endregion

        #region logging/exceptions
        #region exceptions
        protected virtual void ExceptionHandler(Exception ex)
        {
            var exceptionMessage = String.Format("***** EXCEPTION *****\r\n{0}\r\n", ex.ToString());
            LogMessage(exceptionMessage);
            Console.WriteLine(exceptionMessage);
        }
        #endregion
        #region logging
        protected virtual void LogMessage(string message)
        {
            Log.Info(message);
        }
        protected virtual void LogErrorMessage(string message)
        {
            Log.Error(message);
        }
        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLogFile();
        }
        protected virtual void OpenLogFile()
        {
            Process.Start(LogFileName);
        }
        private string LogFileName
        {
            get
            {
                var rootAppender = ((Hierarchy)LogManager.GetRepository())
                                         .Root.Appenders.OfType<FileAppender>()
                                         .FirstOrDefault();

                string filename = rootAppender != null ? rootAppender.File : string.Empty;

                return filename;
            }
        }
        #endregion

        #endregion

        #region add view
        private void tsbAddSessionView_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new WorkspaceDefinition.WorkspaceControlsSettings() {
                    Location = new Point(10,25),
                    Size = new Size(100,300),
                    ZOrder = 0
                };
                AddSessionInfoControl(settings);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        void AddSessionInfoControl(WorkspaceDefinition.WorkspaceControlsSettings settings)
        {
            var view = new SessionInfoControl()
            {
                Location = settings.Location,
                Size = settings.Size,
                ZOrder = settings.ZOrder
            };
            pnlViews.Controls.Add(view);
            TelemetryViewControls.Add(view);
            view.RequestBringToFront += (s, e) => view.BringToFront();
        }
        private void tsbAddGraphView_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new WorkspaceDefinition.WorkspaceControlsSettings()
                {
                    Location = new Point(100, 100),
                    Size = new Size(100, 300),
                    ZOrder = 0
                };
                AddLineGraphControl(settings);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        void AddLineGraphControl(WorkspaceDefinition.WorkspaceControlsSettings settings)
        {
            var view = new LineGraphControl()
            {
                Location = settings.Location,
                Size = settings.Size,
                ZOrder = settings.ZOrder
            };
            pnlViews.Controls.Add(view);
            TelemetryViewControls.Add(view);
            view.RequestBringToFront += (s, e) => view.BringToFront();
        }

        #endregion
    }
}
