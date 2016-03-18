using System;
using System.IO;
using System.Threading.Tasks;

namespace TrackSessionLibrary
{
    public class FileClosedMonitor
    {
        #region consts     
        private const int ExportFileClosedWaitTime = 1;
        #endregion

        #region events 
        public event EventHandler<string> FileClosed;
        protected virtual void OnFileCLosed(string fileName)
        {
            EventHandler<string> handler = FileClosed;
            if (handler != null)
            {
                handler(this, fileName);
            }
        }
        #endregion

        #region public
        public async void StartMonitor(string fileName)
        {
            var waitFileInfo = new FileInfo(fileName);
            await WaitUntilFileClosedAsync(waitFileInfo);           
            OnFileCLosed(fileName);
        }         
        #endregion

        #region protected 
        protected async Task<bool> WaitUntilFileClosedAsync(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                await Task.Delay(TimeSpan.FromSeconds(ExportFileClosedWaitTime));
                return await WaitUntilFileClosedAsync(file);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //file is not locked
            return true;
        }
        #endregion
    }
}
