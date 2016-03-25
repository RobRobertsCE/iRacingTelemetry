using iRacing.SetupLibrary.Data;
using iRacing.TelemetryParser;
using iRacing.TelemetryParser.Session;
using iRacing.TrackSession.Data;
using iRacing.TrackSession.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetupParameterDefinitions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuildSetupInterfaces();
            BuildSetupbaseClass();
        }
        void BuildSetupbaseClass()
        {
            try
            {
                var interfaces = new List<string>();
                var data = new SetupDefinitionData();

                var cars = data.GetVehicles().Where(c => !String.IsNullOrEmpty(c.ClassName));
                foreach (var car in cars)
                {
                    var sbClass = new StringBuilder();
                    var sbInterface = new StringBuilder();

                    sbInterface.AppendLine("///");
                    sbInterface.AppendFormat("///\t[{0}] {1}\r\n", car.VehicleNumber, car.DisplayName);
                    sbInterface.AppendLine("///");

                    sbClass.AppendLine("///");
                    sbClass.AppendFormat("///\t[{0}] {1}\r\n", car.VehicleNumber, car.DisplayName);
                    sbClass.AppendLine("///");

                    var details = data.GetVehicleDefinitions(car.VehicleNumber);
                    if (details.Count > 0)
                    {
                        var sorted = details.OrderBy(d => d.SubGroup.Group.DisplayIdx).ThenBy(d => d.SubGroup.DisplayIdx).ThenBy(d => d.DisplayIdx);
                        var className = car.ClassName;
                        var interfaceName = String.Format("I{0}Setup", car.ClassName);
                        if (!interfaces.Contains(interfaceName))
                        {
                            interfaces.Add(interfaceName);
                        }
                        sbInterface.AppendFormat("public interface {0}\r\n", interfaceName);
                        sbInterface.AppendLine("{");
                        
                        var sbGroup = new StringBuilder();
                        foreach (var group in sorted.Select(s => s.SubGroup.Group).Distinct().OrderBy(g => g.DisplayIdx))
                        {
                            var groupName = String.Format("{0}{1}", interfaceName, group.Name);
                            if (!interfaces.Contains(groupName))
                            {
                                interfaces.Add(groupName);
                            }
                            sbGroup.AppendFormat("public interface {0}{1}\r\n", interfaceName, group.Name);
                            sbGroup.AppendLine("{");
                            sbInterface.AppendFormat("\t{0} {1} {2}\r\n", interfaceName, group.Name, "{ get; set; }");
                            
                            var sbSubGroup = new StringBuilder();
                            foreach (var subgroup in group.SubGroups.Distinct().OrderBy(s => s.DisplayIdx))
                            {
                                var subGroupName = String.Format("{0}{1}", groupName, subgroup.Key);
                                if (!interfaces.Contains(subGroupName))
                                {
                                    interfaces.Add(subGroupName);
                                }
                                sbGroup.AppendFormat("\t{0} {1} {2}\r\n", subGroupName, subgroup.Key, "{ get; set; }");
                                sbSubGroup.AppendFormat("public interface {0}\r\n", subGroupName);
                                sbSubGroup.AppendLine("{");

                                foreach (var definition in subgroup.Definitions.OrderBy(s => s.DisplayIdx))
                                {
                                    sbSubGroup.AppendFormat("\t{0} {1} {2}\r\n", definition.DataType, definition.Key, "{ get; set; }");
                                }

                                sbSubGroup.AppendLine("}\r\n");
                            }
                            sbGroup.AppendLine("}\r\n");
                            sbGroup.AppendLine(sbSubGroup.ToString());
                        }
                        sbInterface.AppendLine("}\r\n");
                        sbInterface.AppendLine(sbGroup.ToString());

                        var newTab = new TabPage() { Text = car.DisplayName };
                        var newTabText = new TextBox() { ScrollBars = ScrollBars.Both, Multiline = true, Dock = DockStyle.Fill };
                        newTabText.Text = sbInterface.ToString();
                        newTab.Controls.Add(newTabText);
                        this.tabControl1.TabPages.Add(newTab);
                    }
                }
                var ilist = String.Join(", ", interfaces);

                txtMain.Text = ilist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        void BuildSetupInterfaces()
        {
            try
            {
                var interfaces = new List<string>();
                var data = new SetupDefinitionData();

                var cars = data.GetVehicles().Where(c => !String.IsNullOrEmpty(c.ClassName));
                foreach (var car in cars)
                {
                    var sbClass = new StringBuilder();
                    var sbInterface = new StringBuilder();

                    sbInterface.AppendLine("///");
                    sbInterface.AppendFormat("///\t[{0}] {1}\r\n", car.VehicleNumber, car.DisplayName);
                    sbInterface.AppendLine("///");

                    sbClass.AppendLine("///");
                    sbClass.AppendFormat("///\t[{0}] {1}\r\n", car.VehicleNumber, car.DisplayName);
                    sbClass.AppendLine("///");

                    var details = data.GetVehicleDefinitions(car.VehicleNumber);
                    if (details.Count > 0)
                    {
                        var sorted = details.OrderBy(d => d.SubGroup.Group.DisplayIdx).ThenBy(d => d.SubGroup.DisplayIdx).ThenBy(d => d.DisplayIdx);
                        var className = car.ClassName;
                        var interfaceName = String.Format("I{0}Setup", car.ClassName);
                        if (!interfaces.Contains(interfaceName))
                        {
                            interfaces.Add(interfaceName);
                        }
                        sbInterface.AppendFormat("public interface {0}\r\n", interfaceName);
                        sbInterface.AppendLine("{");

                        //sbClass.AppendFormat("public partial class {0}Setup : SetupBase,  I{0}Setup\r\n", className);
                        //sbClass.AppendLine("{");
                        var sbGroup = new StringBuilder();
                        foreach (var group in sorted.Select(s => s.SubGroup.Group).Distinct().OrderBy(g => g.DisplayIdx))
                        {
                            var groupName = String.Format("{0}{1}", interfaceName, group.Name);
                            sbGroup.AppendFormat("public interface {0}{1}\r\n", interfaceName, group.Name);
                            sbGroup.AppendLine("{");
                            sbInterface.AppendFormat("\t{0} {1} {2}\r\n", interfaceName, group.Name, "{ get; set; }");

                            //sbClass.AppendFormat("\tpublic partial class {0}Setup{1}\r\n", className, group.Name);
                            //sbClass.AppendLine("\t{");
                            //
                            var sbSubGroup = new StringBuilder();
                            foreach (var subgroup in group.SubGroups.Distinct().OrderBy(s => s.DisplayIdx))
                            {
                                var subGroupName = String.Format("{0}{1}", groupName, subgroup.Key);
                                sbGroup.AppendFormat("\t{0} {1} {2}\r\n", subGroupName, subgroup.Key, "{ get; set; }");
                                sbSubGroup.AppendFormat("public interface {0}\r\n", subGroupName);
                                sbSubGroup.AppendLine("{");

                                //sbClass.AppendFormat("\t\tpublic partial class {0}Setup{1}{2}\r\n", className, group.Name, subgroup.Key);
                                //sbClass.AppendLine("\t\t{");
                                //
                                foreach (var definition in subgroup.Definitions.OrderBy(s => s.DisplayIdx))
                                {
                                    sbSubGroup.AppendFormat("\t{0} {1} {2}\r\n", definition.DataType, definition.Key, "{ get; set; }");
                                    // sbClass.AppendFormat("\t\t\tpublic {0} {1} {2}\r\n", definition.DataType, definition.Key, "{ get; set; }");
                                }
                                //
                                // sbClass.AppendLine("\t\t}");

                                sbSubGroup.AppendLine("}\r\n");
                            }
                            //
                            //sbClass.AppendLine("\t}");
                            sbGroup.AppendLine("}\r\n");
                            sbGroup.AppendLine(sbSubGroup.ToString());
                        }

                        //sbClass.AppendLine("}");
                        // sbGroup.AppendLine("}\r\n");
                        sbInterface.AppendLine("}\r\n");
                        // sbClass.AppendLine();
                        //sbClass.AppendLine(sbInterface.ToString());
                        sbInterface.AppendLine(sbGroup.ToString());

                        var newTab = new TabPage() { Text = car.DisplayName };
                        var newTabText = new TextBox() { ScrollBars = ScrollBars.Both, Multiline = true, Dock = DockStyle.Fill };
                        newTabText.Text = sbInterface.ToString();
                        newTab.Controls.Add(newTabText);
                        this.tabControl1.TabPages.Add(newTab);
                    }
                }
                var ilist = String.Join(", ", interfaces);

                txtMain.Text = ilist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopulateVehicles();
        }
        void PopulateVehicles()
        {
            try
            {
                var carIdList = new List<int>();
                var tParser = new ParserEngine();
                var sParser = new TelemetryFileParser();
                var data = new TrackSessionData();
                IList<VehicleModel> existingVehicles = null;
                IList<Guid> telemetryIdList = null;
                IList<TelemetrySessionInfoView> telemViews = null;
                using (var tData = new TrackSessionData())
                {
                    existingVehicles = data.GetVehicles().ToList();
                    //telemetryIdList = data.GetTelemetryIdList().ToList();
                    telemViews = data.GetTelemetryViews().ToList();
                }
                int i = 0;
                foreach (var view in telemViews) // foreach (var id in telemetryIdList)
                {
                    var sessionInfo = TelemetrySessionInfoFactory.GetSessionInfo(view.YamlData);
                    if (sessionInfo.DriverInfo.Drivers.Count() > 0)
                    {
                        var vehicleNumber = sessionInfo.DriverInfo.Drivers[0].CarID;
                        var carId = Convert.ToInt32(vehicleNumber);
                        if (!carIdList.Contains(carId))
                        {
                            var vehicle = existingVehicles.FirstOrDefault(v => v.VehicleNumber == carId);
                            if (null == vehicle)
                            {
                                vehicle = new iRacing.TrackSession.Data.Models.VehicleModel()
                                {
                                    VehicleNumber = carId,
                                    Name = sessionInfo.DriverInfo.Drivers[0].CarScreenName,
                                    DisplayName = sessionInfo.DriverInfo.Drivers[0].CarScreenName,
                                    Path = sessionInfo.DriverInfo.Drivers[0].CarPath,
                                    CarClassId = Convert.ToInt32(sessionInfo.DriverInfo.Drivers[0].CarClassID),
                                    CarClassShortName = sessionInfo.DriverInfo.Drivers[0].CarClassShortName
                                };
                                using (var tData = new TrackSessionData())
                                {
                                    data.SaveVehicle(vehicle);
                                }
                                Console.WriteLine("Added {0}:{1}", vehicleNumber, sessionInfo.DriverInfo.Drivers[0].CarScreenName);
                            }
                            else if (String.IsNullOrEmpty(vehicle.CarClassShortName))
                            {
                                vehicle.Name = sessionInfo.DriverInfo.Drivers[0].CarScreenName;
                                vehicle.DisplayName = sessionInfo.DriverInfo.Drivers[0].CarScreenName;
                                vehicle.Path = sessionInfo.DriverInfo.Drivers[0].CarPath;
                                vehicle.CarClassId = Convert.ToInt32(sessionInfo.DriverInfo.Drivers[0].CarClassID);
                                vehicle.CarClassShortName = sessionInfo.DriverInfo.Drivers[0].CarClassShortName;
                                using (var tData = new TrackSessionData())
                                {
                                    data.SaveVehicle(vehicle);
                                }
                                Console.WriteLine("Updated {0}:{1}", vehicleNumber, sessionInfo.DriverInfo.Drivers[0].CarScreenName);
                            }
                            Console.WriteLine("Found {0}", carId);
                            carIdList.Add(carId);
                        }
                    }

                    Console.WriteLine(i.ToString());
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
