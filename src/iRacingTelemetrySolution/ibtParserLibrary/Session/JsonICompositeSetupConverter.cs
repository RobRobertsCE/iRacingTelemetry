using iRacing.SetupLibrary;
using Newtonsoft.Json.Linq;
using System;

namespace iRacing.TelemetryParser.Session
{
    public class JsonICompositeSetupConverter : JsonCreationConverter<ICompositeSetup>
    {
        protected override ICompositeSetup Create(Type objectType, JObject jsonObject)
        {
            return new ModifiedSetup();

            //var typeName = jsonObject["Device"].ToString();
            //switch (typeName)
            //{
            //    case "TV":
            //        return new ModifiedSetup();
            //    case "Phone":
            //        return new ModifiedSetup();
            //    default: return new ModifiedSetup();
            //}
        }
    }
}
