namespace TestSessionLibrary.Views
{
    public class TireSheetView
    {
        public TireView LF { get; set; }
        public TireView LR { get; set; }
        public TireView RF { get; set; }
        public TireView RR { get; set; }
    }
    public class TireView
    {
        public float OutsideTemp { get; set; }
        public float MiddleTemp { get; set; }
        public float InsideTemp { get; set; }

        public float OutsideWear { get; set; }
        public float MiddleWear { get; set; }
        public float InsideWear { get; set; }
    }
}
