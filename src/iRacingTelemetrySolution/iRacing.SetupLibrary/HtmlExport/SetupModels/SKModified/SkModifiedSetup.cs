using SetupExportParser.Logic;

namespace SetupExportParser.SetupModels.SKModified
{
    public class SKModifiedSetup : Setup
    {
        public SKModifiedSetup(string data, int carNumber, int trackNumber) 
            :base(data, carNumber, trackNumber)
        {

        }
        public SKModifiedSetup(string data) : base(data)
        {
        }        
    }
}
