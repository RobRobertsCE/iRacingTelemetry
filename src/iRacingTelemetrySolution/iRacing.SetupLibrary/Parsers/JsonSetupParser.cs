using Newtonsoft.Json;
using System;
using System.IO;

namespace iRacing.SetupLibrary.Parsers
{
    public class JsonSetupParser : SetupParserBase, ISetupParser
    {
        public ICarSetup GetSetup(Vehicles vehicle, string setupData)
        {
            return base.ParseJSON(vehicle, setupData);
        }     
        
        public static string GetJson(ICarSetup carData)
        {
            JsonSerializer jsonSerializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (var jsonStreamWriter = new StringWriter())
            {
                jsonSerializer.Serialize(jsonStreamWriter, carData);
                return jsonStreamWriter.ToString();
            }
        }
    }
}
