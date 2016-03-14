using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//namespace ibtAnalysis
//{
//    public enum Corner
//    {
//        LF = 0,
//        LR = 1,
//        RF = 2,
//        RR = 3
//    }
//}
namespace ibtParser.WinApp
{
    public partial class TelemConstBuilder : Form
    {
        // test
        public TelemConstBuilder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var lines = System.IO.File.ReadAllLines(@"C:\Users\rroberts\Source\Repos\ircc\src\ibtParser\ibtParser.WinApp\TelemetryParamList.txt");

                var sb = new StringBuilder();
                sb.AppendLine("namespace ibtAnalysis");
                sb.AppendLine("{");
                sb.AppendLine("\tpublic enum TelemetryKeys");
                sb.AppendLine("\t{");
                foreach (var line in lines.Take(lines.Length-2))
                {
                    var fieldName = line.Substring(5, 33).Trim();
                    var description = line.Substring(38, 65).Trim();
                    var dataType = line.Substring(103, 32).Trim();
                    sb.AppendFormat("\t\t// {0} [{1}]\r\n", description, dataType);
                    sb.AppendFormat("\t\t{0},\r\n\r\n", fieldName);
                }
                var lastLine = lines[lines.Length - 1];
                var lastFieldName = lastLine.Substring(5, 33).Trim();
                var lastDescription = lastLine.Substring(38, 65).Trim();
                var lastDataType = lastLine.Substring(103, 32).Trim();
                sb.AppendFormat("\t\t// {0} [{1}]\r\n", lastDescription, lastDataType);
                sb.AppendFormat("\t\t{0}\r\n", lastFieldName);
                sb.AppendLine("\t}");
                sb.AppendLine("}");
                txtMessages.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtMessages.Text = ex.ToString();
            }
        }
    }
}
