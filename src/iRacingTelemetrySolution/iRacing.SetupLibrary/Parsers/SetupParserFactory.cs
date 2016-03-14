namespace iRacing.SetupLibrary.Parsers
{
    public static class SetupParserFactory
    {
        public static ICarSetup GetSetupFromHtml(Vehicles vehicle, string setupData)
        {
            using (var parser = new HtmlExportParser())
            {
                return parser.GetSetup(vehicle, setupData);
            }
        }
        public static ICarSetup GetSetupFromYAML(Vehicles vehicle, string setupData)
        {
            using (var parser = new YamlSetupParser())
            {
                return parser.GetSetup(vehicle, setupData);
            }
        }
        public static ICarSetup GetSetupFromJSON(Vehicles vehicle, string setupData)
        {
            using (var parser = new JsonSetupParser())
            {
                return parser.GetSetup(vehicle, setupData);
            }
        }
        public static string SerializeSetupToJSON(ICarSetup setupObject)
        {
            return JsonSetupParser.GetJson(setupObject);
        }
    }
}
