using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iRacing.Common;

namespace TrackSession.Controls
{
    public partial class SetupGroupView : UserControl
    {
        private string _groupName = "GROUP";
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
                if (null != GroupName)
                {
                    if (GroupName.Contains('.'))
                    {
                        //var title = AddSpacesToSentence("", true);
                        lblGroupName.Text = String.Format("{0}:", GroupName.AddSpacesToSentence(true).Split('.')[1].Trim().ToUpper());
                    }
                    else
                    {
                        lblGroupName.Text = String.Format("{0}:", GroupName.Trim().ToUpper());
                    }
                }
            }
        }

        private IDictionary<string, GroupField> _groupValues = new Dictionary<string, GroupField>();
        public IDictionary<string, GroupField> GroupValues
        {
            get
            {
                return _groupValues;
            }
            set
            {
                _groupValues = value;
                UpdateDisplay();
            }
        } 

        public SetupGroupView()
        {
            InitializeComponent();
            GroupValues = new Dictionary<string, GroupField>();
        }

        private void SetupGroupView_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            pnlLayout.Controls.Clear();
            if (null != GroupValues)
            {
                foreach (var item in GroupValues)
                {
                    var fieldView = new SetupGroupValueView() { Field = item.Value };
                    pnlLayout.Controls.Add(fieldView);
                }
            }
        }
     
    }
    public class GroupField
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return String.Format("  {0}: {1}", Name, Value);
        }
    }
}

