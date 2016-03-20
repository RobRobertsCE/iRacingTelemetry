using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackSession
{
    public static class TrackSessionSettings
    {
        public static bool AutoSaveSetup
        {
            get
            {
                return Properties.Settings.Default.AutoSaveSetup;
            }
            set
            {
                Properties.Settings.Default.AutoSaveSetup = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool AutoStartMonitor
        {
            get
            {
                return Properties.Settings.Default.AutoStartMonitor;
            }
            set
            {
                Properties.Settings.Default.AutoStartMonitor = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string AutoSaveSetupDirectory
        {
            get
            {
                return Properties.Settings.Default.AutoSaveSetupDirectory;
            }
            set
            {
                Properties.Settings.Default.AutoSaveSetupDirectory = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
