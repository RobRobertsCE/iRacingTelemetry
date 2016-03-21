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
    public partial class SetupGroupValueView : UserControl
    {
        private GroupField _field = new GroupField();
        public GroupField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
                UpdateDisplay();
            }
        }

        public SetupGroupValueView()
        {
            InitializeComponent();
            Field = new GroupField() { Name = "Name", Value = "Value" };
        }

        private void SetupGroupValueView_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (null != Field)
            {
                lblName.Text = String.Format("{0}:", Field.Name.AddSpacesToSentence(true));
                lblValue.Text = Field.Value.ToString();
            }
        }
    }
}
