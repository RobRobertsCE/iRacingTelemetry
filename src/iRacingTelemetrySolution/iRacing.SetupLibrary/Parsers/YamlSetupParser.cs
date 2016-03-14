using Newtonsoft.Json;
using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace iRacing.SetupLibrary.Parsers
{
    public class YamlSetupParser : SetupParserBase, ISetupParser
    {
        public ICarSetup GetSetup(Vehicles vehicle, string yamlString)
        {
            var json = GetJson(yamlString);
            return base.ParseJSON(vehicle, json);
        }

        public static string GetJson(string yamlString)
        {
            var yamlObject = GetYamlObject(yamlString);
            return GetJson(yamlObject);
        }

        public static string GetJson(object yamlObject)
        {
            JsonSerializer jsonSerializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (var jsonStreamWriter = new StringWriter())
            {
                jsonSerializer.Serialize(jsonStreamWriter, yamlObject);
                return jsonStreamWriter.ToString();
            }
        }

        public static object GetYamlObject(string yamlString)
        {
            using (var yamlStream = ConvertStringToStream(yamlString))
            {
                using (var yamlStreamReader = new StreamReader(yamlStream))
                {
                    var yamlDeserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
                    return yamlDeserializer.Deserialize(yamlStreamReader);
                }
            }
        }

        private static Stream ConvertStringToStream(string yamlString)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(yamlString);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
