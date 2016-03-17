using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ibtParserLibrary
{
    public class TelemetryChannelValue
    {
        #region props
        public TelemetryChannelDefinition Definition { get; set; }

        public string Value
        {
            get
            {
                return GetFieldValue().ToString();
            }
        }

        [Browsable(false)]
        public string ByteString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int s = 0; s < Bytes.Count(); s++)
                {
                    var hexString = Bytes[s].ToString("X");
                    hexString = (hexString.Length % 2 == 0 ? "" : "0") + hexString + " ";
                    sb.Append(hexString);
                }
                return sb.ToString();
            }
        }

        [Browsable(false)]
        public byte[] Bytes
        {
            get; set;
        }
        #endregion

        #region ctor
        public TelemetryChannelValue()
        {

        }
        public TelemetryChannelValue(TelemetryChannelDefinition definition)
        {
            this.Definition = definition;
        }
        #endregion

        #region private methods
        object GetFieldValue()
        {
            object fieldValue = null;

            switch (Definition.DataType)
            {
                case 1:
                    {
                        fieldValue = BitConverter.ToBoolean(Bytes, 0);
                        break;
                    }
                case 2:
                    {
                        fieldValue = BitConverter.ToInt16(Bytes, 0);
                        break;
                    }
                case 3:
                    {
                        fieldValue = BitConverter.ToInt16(Bytes, 0);
                        break;
                    }
                case 4:
                    {
                        fieldValue = BitConverter.ToSingle(Bytes, 0);
                        break;
                    }
                case 5:
                    {
                        fieldValue = BitConverter.ToDouble(Bytes, 0);
                        break;
                    }
            }
            return fieldValue;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} [{1}]", Definition.ToString(), Value.ToString());
        }
    }
}
