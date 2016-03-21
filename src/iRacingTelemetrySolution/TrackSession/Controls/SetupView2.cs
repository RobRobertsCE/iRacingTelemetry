using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iRacing;

namespace TrackSession.Controls
{
    public partial class SetupView2 : UserControl
    {
        private SetupValueParser.SetupValues _setupValues = new SetupValueParser.SetupValues();
        public SetupValueParser.SetupValues SetupValues
        {
            get
            {
                return _setupValues;
            }
            set
            {
                _setupValues = value;
                UpdateDisplay();
            }
        }
        public SetupView2()
        {
            InitializeComponent();
        }
        private void UpdateDisplay()
        {
            if (null != SetupValues)
            {
                var setupGroups = new Dictionary<string, Dictionary<string, GroupField>>();

                setupGroups.Add(Constants.SetupGroupTires_LeftFront, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupTires_RightFront, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupTires_LeftRear, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupTires_RightRear, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupChassis_LeftFront, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupChassis_RightFront, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupChassis_LeftRear, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupChassis_RightRear, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupChassis_Front, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupChassis_Rear, new Dictionary<string, GroupField>());
                setupGroups.Add(Constants.SetupGroupChassis_FrontARB, new Dictionary<string, GroupField>());

                foreach (var setupGroupName in Constants.SetupGroupList)
                {
                    if (SetupValues.SetupGroups.ContainsKey(setupGroupName))
                    {
                        var groupValues = SetupValues.SetupGroups[setupGroupName];
                        var setupValues = new Dictionary<string, GroupField>();
                        foreach (var property in groupValues)
                        {
                            var groupField = new GroupField() { Name = property.Key, Value = property.Value };
                             try
                            {
                                setupValues.Add(property.Key, groupField);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        try
                        {
                            setupGroups[setupGroupName] = setupValues;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                sgvChassisFront.GroupName = Constants.SetupGroupChassis_Front;
                sgvChassisFront.GroupValues = setupGroups[Constants.SetupGroupChassis_Front];

                sgvChassisLeftFront.GroupName = Constants.SetupGroupChassis_LeftFront;
                sgvChassisLeftFront.GroupValues = setupGroups[Constants.SetupGroupChassis_LeftFront];

                sgvChassisRightFront.GroupName = Constants.SetupGroupChassis_RightFront;
                sgvChassisRightFront.GroupValues = setupGroups[Constants.SetupGroupChassis_RightFront];

                sgvChassisLeftRear.GroupName = Constants.SetupGroupChassis_LeftRear;
                sgvChassisLeftRear.GroupValues = setupGroups[Constants.SetupGroupChassis_LeftRear];

                sgvChassisRightRear.GroupName = Constants.SetupGroupChassis_RightRear;
                sgvChassisRightRear.GroupValues = setupGroups[Constants.SetupGroupChassis_RightRear];

                sgvChassisRear.GroupName = Constants.SetupGroupChassis_Rear;
                sgvChassisRear.GroupValues = setupGroups[Constants.SetupGroupChassis_Rear];
            }
        }
    }
}
