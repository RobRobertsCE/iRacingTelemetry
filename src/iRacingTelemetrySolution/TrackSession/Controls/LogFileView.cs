using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrackSession.Controls
{
    public partial class LogFileView : UserControl
    {
        private DateTime _lastModifyDate = DateTime.MinValue;

        public virtual string FileName { get; set; }

        public LogFileView()
        {
            InitializeComponent();
        }

        private void LogFileView_Load(object sender, EventArgs e)
        {
            LoadFile();
        }

        protected virtual void LoadFile()
        {
            if (!String.IsNullOrEmpty(FileName))
            {
                this.txtLogFilePath.Text = FileName;

                if (File.Exists(FileName))
                {
                    Stream stream = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader streamReader = new StreamReader(stream);
                    string str = streamReader.ReadToEnd();
                    this.txtLogFile.Text = str;
                    streamReader.Close();
                    stream.Close();                    
                }
                _lastModifyDate = File.GetLastWriteTime(FileName);
            }
        }

        private void LogFileView_Enter(object sender, EventArgs e)
        {
            CheckFileChanged();
        }

        protected virtual void CheckFileChanged()
        {
            if (_lastModifyDate == DateTime.MinValue) return;

            var lastModifyDate = File.GetLastWriteTime(FileName);
            if (_lastModifyDate != lastModifyDate)
            {
                var result = MessageBox.Show(this, "File contents have changed! Reload file?", "File Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.OK == result)
                {
                    LoadFile();
                }
            }
        }
    }
}
