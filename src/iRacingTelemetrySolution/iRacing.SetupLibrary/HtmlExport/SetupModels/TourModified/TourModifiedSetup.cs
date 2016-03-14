using SetupExportParser.SetupModels.SKModified;

namespace SetupExportParser.SetupModels
{
    public class TourModifiedSetup : SKModifiedSetup
    {
        public TourModifiedSetup(string data, int carNumber, int trackNumber) 
            :base(data, carNumber, trackNumber)
        {

        }
        public TourModifiedSetup(string data) : base(data)
        {
        }        
    }
}
