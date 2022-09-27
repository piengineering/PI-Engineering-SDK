using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NETComp_Csharp_Sample
{
    //The following is a sample showing how to interact with an XKE-124 Tbar device using the X-keys XKE-124 Tbar .NET component.

    public partial class Form1 : Form
    {
        //Variables to track the device lights, initial states here based on device defaults
        Boolean AllBlue = true;
        Boolean AllRed = true;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //When valid devices are connected they are added to the ConnectedDevices list
            //If this list is empty, then no valid devices are connected currently
            if (xk124Tbar_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No XKE-124 Tbar Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                deviceStatus.Text = "XKE-124 Tbar Connected";
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xk124Tbar_1.ConnectedDevices[0].UnitID;

                //Gets the OEM Version ID from the device
                lblOEM.Text = "OEM ID: " + xk124Tbar_1.ConnectedDevices[0].OEMVersion;

                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xk124Tbar_1.ConnectedDevices[0].Pid;

                
            }
        }

        private void HandleButtons(XK_124Tbar.XKeyEventArgs e)
        {
            //This method handles the button change event for the device
            
            //Gets the button number (CID) of the button that has changed state
            if (e.CID > 1000)
            {
                String ButtonNum = (e.CID - 1000).ToString();

                //Logic structure to handle both "press" (true) and "release" (false) states
                if (e.PressState == true)
                {
                    lblPress.Text = "Button #" + ButtonNum + " Down";
                }
                else if (e.PressState == false)
                {
                    lblRelease.Text = "Button #" + ButtonNum + " Up";
                }
            }

            if (e.PressState == true) //button press
            {
                switch (e.CID)
                {
                    case 1001:
                        lblButton01.BackColor = Color.LimeGreen;
                        break;
                    case 1002:
                        lblButton02.BackColor = Color.LimeGreen;
                        break;
                    case 1003:
                        lblButton03.BackColor = Color.LimeGreen;
                        break;
                    case 1004:
                        lblButton04.BackColor = Color.LimeGreen;
                        break;
                    case 1005:
                        lblButton05.BackColor = Color.LimeGreen;
                        break;
                    case 1006:
                        lblButton06.BackColor = Color.LimeGreen;
                        break;
                    case 1007:
                        lblButton07.BackColor = Color.LimeGreen;
                        break;
                    case 1008:
                        lblButton08.BackColor = Color.LimeGreen;
                        break;
                    case 1009:
                        lblButton09.BackColor = Color.LimeGreen;
                        break;
                    case 1010:
                        lblButton10.BackColor = Color.LimeGreen;
                        break;
                    case 1011:
                        lblButton11.BackColor = Color.LimeGreen;
                        break;
                    case 1012:
                        lblButton12.BackColor = Color.LimeGreen;
                        break;
                    case 1013:
                        lblButton13.BackColor = Color.LimeGreen;
                        break;
                    case 1014:
                        lblButton14.BackColor = Color.LimeGreen;
                        break;
                    case 1015:
                        lblButton15.BackColor = Color.LimeGreen;
                        break;
                    case 1016:
                        lblButton16.BackColor = Color.LimeGreen;
                        break;
                    case 1017:
                        lblButton17.BackColor = Color.LimeGreen;
                        break;
                    case 1018:
                        lblButton18.BackColor = Color.LimeGreen;
                        break;
                    case 1019:
                        lblButton19.BackColor = Color.LimeGreen;
                        break;
                    case 1020:
                        lblButton20.BackColor = Color.LimeGreen;
                        break;
                    case 1021:
                        lblButton21.BackColor = Color.LimeGreen;
                        break;
                    case 1022:
                        lblButton22.BackColor = Color.LimeGreen;
                        break;
                    case 1023:
                        lblButton23.BackColor = Color.LimeGreen;
                        break;
                    case 1024:
                        lblButton24.BackColor = Color.LimeGreen;
                        break;
                    case 1025:
                        lblButton25.BackColor = Color.LimeGreen;
                        break;
                    case 1026:
                        lblButton26.BackColor = Color.LimeGreen;
                        break;
                    case 1027:
                        lblButton27.BackColor = Color.LimeGreen;
                        break;
                    case 1028:
                        lblButton28.BackColor = Color.LimeGreen;
                        break;
                    case 1029:
                        lblButton29.BackColor = Color.LimeGreen;
                        break;
                    case 1030:
                        lblButton30.BackColor = Color.LimeGreen;
                        break;
                    case 1031:
                        lblButton31.BackColor = Color.LimeGreen;
                        break;
                    case 1032:
                        lblButton32.BackColor = Color.LimeGreen;
                        break;
                    case 1033:
                        lblButton33.BackColor = Color.LimeGreen;
                        break;
                    case 1034:
                        lblButton34.BackColor = Color.LimeGreen;
                        break;
                    case 1035:
                        lblButton35.BackColor = Color.LimeGreen;
                        break;
                    case 1036:
                        lblButton36.BackColor = Color.LimeGreen;
                        break;
                    case 1037:
                        lblButton37.BackColor = Color.LimeGreen;
                        break;
                    case 1038:
                        lblButton38.BackColor = Color.LimeGreen;
                        break;
                    case 1039:
                        lblButton39.BackColor = Color.LimeGreen;
                        break;
                    case 1040:
                        lblButton40.BackColor = Color.LimeGreen;
                        break;
                    case 1041:
                        lblButton41.BackColor = Color.LimeGreen;
                        break;
                    case 1042:
                        lblButton42.BackColor = Color.LimeGreen;
                        break;
                    case 1043:
                        lblButton43.BackColor = Color.LimeGreen;
                        break;
                    case 1044:
                        lblButton44.BackColor = Color.LimeGreen;
                        break;
                    case 1045:
                        lblButton45.BackColor = Color.LimeGreen;
                        break;
                    case 1046:
                        lblButton46.BackColor = Color.LimeGreen;
                        break;
                    case 1047:
                        lblButton47.BackColor = Color.LimeGreen;
                        break;
                    case 1048:
                        lblButton48.BackColor = Color.LimeGreen;
                        break;
                    case 1049:
                        lblButton49.BackColor = Color.LimeGreen;
                        break;
                    case 1050:
                        lblButton50.BackColor = Color.LimeGreen;
                        break;
                    case 1051:
                        lblButton51.BackColor = Color.LimeGreen;
                        break;
                    case 1052:
                        lblButton52.BackColor = Color.LimeGreen;
                        break;
                    case 1053:
                        lblButton53.BackColor = Color.LimeGreen;
                        break;
                    case 1054:
                        lblButton54.BackColor = Color.LimeGreen;
                        break;
                    case 1055:
                        lblButton55.BackColor = Color.LimeGreen;
                        break;
                    case 1056:
                        lblButton56.BackColor = Color.LimeGreen;
                        break;
                    case 1057:
                        lblButton57.BackColor = Color.LimeGreen;
                        break;
                    case 1058:
                        lblButton58.BackColor = Color.LimeGreen;
                        break;
                    case 1059:
                        lblButton59.BackColor = Color.LimeGreen;
                        break;
                    case 1060:
                        lblButton60.BackColor = Color.LimeGreen;
                        break;
                    case 1061:
                        lblButton61.BackColor = Color.LimeGreen;
                        break;
                    case 1062:
                        lblButton62.BackColor = Color.LimeGreen;
                        break;
                    case 1063:
                        lblButton63.BackColor = Color.LimeGreen;
                        break;
                    case 1064:
                        lblButton64.BackColor = Color.LimeGreen;
                        break;
                    case 1065:
                        lblButton65.BackColor = Color.LimeGreen;
                        break;
                    case 1066:
                        lblButton66.BackColor = Color.LimeGreen;
                        break;
                    case 1067:
                        lblButton67.BackColor = Color.LimeGreen;
                        break;
                    case 1068:
                        lblButton68.BackColor = Color.LimeGreen;
                        break;
                    case 1069:
                        lblButton69.BackColor = Color.LimeGreen;
                        break;
                    case 1070:
                        lblButton70.BackColor = Color.LimeGreen;
                        break;
                    case 1071:
                        lblButton71.BackColor = Color.LimeGreen;
                        break;
                    case 1072:
                        lblButton72.BackColor = Color.LimeGreen;
                        break;
                    case 1073:
                        lblButton73.BackColor = Color.LimeGreen;
                        break;
                    case 1074:
                        lblButton74.BackColor = Color.LimeGreen;
                        break;
                    case 1075:
                        lblButton75.BackColor = Color.LimeGreen;
                        break;
                    case 1076:
                        lblButton76.BackColor = Color.LimeGreen;
                        break;
                    case 1077:
                        lblButton77.BackColor = Color.LimeGreen;
                        break;
                    case 1078:
                        lblButton78.BackColor = Color.LimeGreen;
                        break;
                    case 1079:
                        lblButton79.BackColor = Color.LimeGreen;
                        break;
                    case 1080:
                        lblButton80.BackColor = Color.LimeGreen;
                        break;
                    case 1081:
                        lblButton81.BackColor = Color.LimeGreen;
                        break;
                    case 1082:
                        lblButton82.BackColor = Color.LimeGreen;
                        break;
                    case 1083:
                        lblButton83.BackColor = Color.LimeGreen;
                        break;
                    case 1084:
                        lblButton84.BackColor = Color.LimeGreen;
                        break;
                    case 1085:
                        lblButton85.BackColor = Color.LimeGreen;
                        break;
                    case 1086:
                        lblButton86.BackColor = Color.LimeGreen;
                        break;
                    case 1087:
                        lblButton87.BackColor = Color.LimeGreen;
                        break;
                    case 1088:
                        lblButton88.BackColor = Color.LimeGreen;
                        break;
                    case 1089:
                        lblButton89.BackColor = Color.LimeGreen;
                        break;
                    case 1090:
                        lblButton90.BackColor = Color.LimeGreen;
                        break;
                    case 1091:
                        lblButton91.BackColor = Color.LimeGreen;
                        break;
                    case 1092:
                        lblButton92.BackColor = Color.LimeGreen;
                        break;
                    case 1093:
                        lblButton93.BackColor = Color.LimeGreen;
                        break;
                    case 1094:
                        lblButton94.BackColor = Color.LimeGreen;
                        break;
                    case 1095:
                        lblButton95.BackColor = Color.LimeGreen;
                        break;
                    case 1096:
                        lblButton96.BackColor = Color.LimeGreen;
                        break;
                    case 1097:
                        lblButton97.BackColor = Color.LimeGreen;
                        break;
                    case 1098:
                        lblButton98.BackColor = Color.LimeGreen;
                        break;
                    case 1099:
                        lblButton99.BackColor = Color.LimeGreen;
                        break;
                    case 1100:
                        lblButton100.BackColor = Color.LimeGreen;
                        break;
                    case 1101:
                        lblButton101.BackColor = Color.LimeGreen;
                        break;
                    case 1102:
                        lblButton102.BackColor = Color.LimeGreen;
                        break;
                    case 1103:
                        lblButton103.BackColor = Color.LimeGreen;
                        break;
                    case 1104:
                        lblButton104.BackColor = Color.LimeGreen;
                        break;
                    case 1105:
                        lblButton105.BackColor = Color.LimeGreen;
                        break;
                    case 1106:
                        lblButton106.BackColor = Color.LimeGreen;
                        break;
                    case 1107:
                        lblButton107.BackColor = Color.LimeGreen;
                        break;
                    case 1108:
                        lblButton108.BackColor = Color.LimeGreen;
                        break;
                    //case 1109:
                    //    lblButton109.BackColor = Color.LimeGreen;
                    //    break;
                    //case 1110:
                    //    lblButton110.BackColor = Color.LimeGreen;
                    //    break;
                    //case 1111:
                    //    lblButton111.BackColor = Color.LimeGreen;
                    //    break;
                    //case 1112:
                    //    lblButton112.BackColor = Color.LimeGreen;
                    //    break;
                    case 1113:
                        lblButton113.BackColor = Color.LimeGreen;
                        break;
                    case 1114:
                        lblButton114.BackColor = Color.LimeGreen;
                        break;
                    case 1115:
                        lblButton115.BackColor = Color.LimeGreen;
                        break;
                    case 1116:
                        lblButton116.BackColor = Color.LimeGreen;
                        break;
                    case 1117:
                        lblButton117.BackColor = Color.LimeGreen;
                        break;
                    case 1118:
                        lblButton118.BackColor = Color.LimeGreen;
                        break;
                    case 1119:
                        lblButton119.BackColor = Color.LimeGreen;
                        break;
                    case 1120:
                        lblButton120.BackColor = Color.LimeGreen;
                        break;
                    case 1121:
                        lblButton121.BackColor = Color.LimeGreen;
                        break;
                    case 1122:
                        lblButton122.BackColor = Color.LimeGreen;
                        break;
                    case 1123:
                        lblButton123.BackColor = Color.LimeGreen;
                        break;
                    case 1124:
                        lblButton124.BackColor = Color.LimeGreen;
                        break;
                    case 1125:
                        lblButton125.BackColor = Color.LimeGreen;
                        break;
                    case 1126:
                        lblButton126.BackColor = Color.LimeGreen;
                        break;
                    case 1127:
                        lblButton127.BackColor = Color.LimeGreen;
                        break;
                    case 1128:
                        lblButton128.BackColor = Color.LimeGreen;
                        break;
                }
            }
            else //button release
            {
                switch (e.CID)
                {
                    case 1001:
                        lblButton01.BackColor = default(Color);
                        break;
                    case 1002:
                        lblButton02.BackColor = default(Color);
                        break;
                    case 1003:
                        lblButton03.BackColor = default(Color);
                        break;
                    case 1004:
                        lblButton04.BackColor = default(Color);
                        break;
                    case 1005:
                        lblButton05.BackColor = default(Color);
                        break;
                    case 1006:
                        lblButton06.BackColor = default(Color);
                        break;
                    case 1007:
                        lblButton07.BackColor = default(Color);
                        break;
                    case 1008:
                        lblButton08.BackColor = default(Color);
                        break;
                    case 1009:
                        lblButton09.BackColor = default(Color);
                        break;
                    case 1010:
                        lblButton10.BackColor = default(Color);
                        break;
                    case 1011:
                        lblButton11.BackColor = default(Color);
                        break;
                    case 1012:
                        lblButton12.BackColor = default(Color);
                        break;
                    case 1013:
                        lblButton13.BackColor = default(Color);
                        break;
                    case 1014:
                        lblButton14.BackColor = default(Color);
                        break;
                    case 1015:
                        lblButton15.BackColor = default(Color);
                        break;
                    case 1016:
                        lblButton16.BackColor = default(Color);
                        break;
                    case 1017:
                        lblButton17.BackColor = default(Color);
                        break;
                    case 1018:
                        lblButton18.BackColor = default(Color);
                        break;
                    case 1019:
                        lblButton19.BackColor = default(Color);
                        break;
                    case 1020:
                        lblButton20.BackColor = default(Color);
                        break;
                    case 1021:
                        lblButton21.BackColor = default(Color);
                        break;
                    case 1022:
                        lblButton22.BackColor = default(Color);
                        break;
                    case 1023:
                        lblButton23.BackColor = default(Color);
                        break;
                    case 1024:
                        lblButton24.BackColor = default(Color);
                        break;
                    case 1025:
                        lblButton25.BackColor = default(Color);
                        break;
                    case 1026:
                        lblButton26.BackColor = default(Color);
                        break;
                    case 1027:
                        lblButton27.BackColor = default(Color);
                        break;
                    case 1028:
                        lblButton28.BackColor = default(Color);
                        break;
                    case 1029:
                        lblButton29.BackColor = default(Color);
                        break;
                    case 1030:
                        lblButton30.BackColor = default(Color);
                        break;
                    case 1031:
                        lblButton31.BackColor = default(Color);
                        break;
                    case 1032:
                        lblButton32.BackColor = default(Color);
                        break;
                    case 1033:
                        lblButton33.BackColor = default(Color);
                        break;
                    case 1034:
                        lblButton34.BackColor = default(Color);
                        break;
                    case 1035:
                        lblButton35.BackColor = default(Color);
                        break;
                    case 1036:
                        lblButton36.BackColor = default(Color);
                        break;
                    case 1037:
                        lblButton37.BackColor = default(Color);
                        break;
                    case 1038:
                        lblButton38.BackColor = default(Color);
                        break;
                    case 1039:
                        lblButton39.BackColor = default(Color);
                        break;
                    case 1040:
                        lblButton40.BackColor = default(Color);
                        break;
                    case 1041:
                        lblButton41.BackColor = default(Color);
                        break;
                    case 1042:
                        lblButton42.BackColor = default(Color);
                        break;
                    case 1043:
                        lblButton43.BackColor = default(Color);
                        break;
                    case 1044:
                        lblButton44.BackColor = default(Color);
                        break;
                    case 1045:
                        lblButton45.BackColor = default(Color);
                        break;
                    case 1046:
                        lblButton46.BackColor = default(Color);
                        break;
                    case 1047:
                        lblButton47.BackColor = default(Color);
                        break;
                    case 1048:
                        lblButton48.BackColor = default(Color);
                        break;
                    case 1049:
                        lblButton49.BackColor = default(Color);
                        break;
                    case 1050:
                        lblButton50.BackColor = default(Color);
                        break;
                    case 1051:
                        lblButton51.BackColor = default(Color);
                        break;
                    case 1052:
                        lblButton52.BackColor = default(Color);
                        break;
                    case 1053:
                        lblButton53.BackColor = default(Color);
                        break;
                    case 1054:
                        lblButton54.BackColor = default(Color);
                        break;
                    case 1055:
                        lblButton55.BackColor = default(Color);
                        break;
                    case 1056:
                        lblButton56.BackColor = default(Color);
                        break;
                    case 1057:
                        lblButton57.BackColor = default(Color);
                        break;
                    case 1058:
                        lblButton58.BackColor = default(Color);
                        break;
                    case 1059:
                        lblButton59.BackColor = default(Color);
                        break;
                    case 1060:
                        lblButton60.BackColor = default(Color);
                        break;
                    case 1061:
                        lblButton61.BackColor = default(Color);
                        break;
                    case 1062:
                        lblButton62.BackColor = default(Color);
                        break;
                    case 1063:
                        lblButton63.BackColor = default(Color);
                        break;
                    case 1064:
                        lblButton64.BackColor = default(Color);
                        break;
                    case 1065:
                        lblButton65.BackColor = default(Color);
                        break;
                    case 1066:
                        lblButton66.BackColor = default(Color);
                        break;
                    case 1067:
                        lblButton67.BackColor = default(Color);
                        break;
                    case 1068:
                        lblButton68.BackColor = default(Color);
                        break;
                    case 1069:
                        lblButton69.BackColor = default(Color);
                        break;
                    case 1070:
                        lblButton70.BackColor = default(Color);
                        break;
                    case 1071:
                        lblButton71.BackColor = default(Color);
                        break;
                    case 1072:
                        lblButton72.BackColor = default(Color);
                        break;
                    case 1073:
                        lblButton73.BackColor = default(Color);
                        break;
                    case 1074:
                        lblButton74.BackColor = default(Color);
                        break;
                    case 1075:
                        lblButton75.BackColor = default(Color);
                        break;
                    case 1076:
                        lblButton76.BackColor = default(Color);
                        break;
                    case 1077:
                        lblButton77.BackColor = default(Color);
                        break;
                    case 1078:
                        lblButton78.BackColor = default(Color);
                        break;
                    case 1079:
                        lblButton79.BackColor = default(Color);
                        break;
                    case 1080:
                        lblButton80.BackColor = default(Color);
                        break;
                    case 1081:
                        lblButton81.BackColor = default(Color);
                        break;
                    case 1082:
                        lblButton82.BackColor = default(Color);
                        break;
                    case 1083:
                        lblButton83.BackColor = default(Color);
                        break;
                    case 1084:
                        lblButton84.BackColor = default(Color);
                        break;
                    case 1085:
                        lblButton85.BackColor = default(Color);
                        break;
                    case 1086:
                        lblButton86.BackColor = default(Color);
                        break;
                    case 1087:
                        lblButton87.BackColor = default(Color);
                        break;
                    case 1088:
                        lblButton88.BackColor = default(Color);
                        break;
                    case 1089:
                        lblButton89.BackColor = default(Color);
                        break;
                    case 1090:
                        lblButton90.BackColor = default(Color);
                        break;
                    case 1091:
                        lblButton91.BackColor = default(Color);
                        break;
                    case 1092:
                        lblButton92.BackColor = default(Color);
                        break;
                    case 1093:
                        lblButton93.BackColor = default(Color);
                        break;
                    case 1094:
                        lblButton94.BackColor = default(Color);
                        break;
                    case 1095:
                        lblButton95.BackColor = default(Color);
                        break;
                    case 1096:
                        lblButton96.BackColor = default(Color);
                        break;
                    case 1097:
                        lblButton97.BackColor = default(Color);
                        break;
                    case 1098:
                        lblButton98.BackColor = default(Color);
                        break;
                    case 1099:
                        lblButton99.BackColor = default(Color);
                        break;
                    case 1100:
                        lblButton100.BackColor = default(Color);
                        break;
                    case 1101:
                        lblButton101.BackColor = default(Color);
                        break;
                    case 1102:
                        lblButton102.BackColor = default(Color);
                        break;
                    case 1103:
                        lblButton103.BackColor = default(Color);
                        break;
                    case 1104:
                        lblButton104.BackColor = default(Color);
                        break;
                    case 1105:
                        lblButton105.BackColor = default(Color);
                        break;
                    case 1106:
                        lblButton106.BackColor = default(Color);
                        break;
                    case 1107:
                        lblButton107.BackColor = default(Color);
                        break;
                    case 1108:
                        lblButton108.BackColor = default(Color);
                        break;
                    //case 1109:
                    //    lblButton109.BackColor = default(Color);
                    //    break;
                    //case 1110:
                    //    lblButton110.BackColor = default(Color);
                    //    break;
                    //case 1111:
                    //    lblButton111.BackColor = default(Color);
                    //    break;
                    //case 1112:
                    //    lblButton112.BackColor = default(Color);
                    //    break;
                    case 1113:
                        lblButton113.BackColor = default(Color);
                        break;
                    case 1114:
                        lblButton114.BackColor = default(Color);
                        break;
                    case 1115:
                        lblButton115.BackColor = default(Color);
                        break;
                    case 1116:
                        lblButton116.BackColor = default(Color);
                        break;
                    case 1117:
                        lblButton117.BackColor = default(Color);
                        break;
                    case 1118:
                        lblButton118.BackColor = default(Color);
                        break;
                    case 1119:
                        lblButton119.BackColor = default(Color);
                        break;
                    case 1120:
                        lblButton120.BackColor = default(Color);
                        break;
                    case 1121:
                        lblButton121.BackColor = default(Color);
                        break;
                    case 1122:
                        lblButton122.BackColor = default(Color);
                        break;
                    case 1123:
                        lblButton123.BackColor = default(Color);
                        break;
                    case 1124:
                        lblButton124.BackColor = default(Color);
                        break;
                    case 1125:
                        lblButton125.BackColor = default(Color);
                        break;
                    case 1126:
                        lblButton126.BackColor = default(Color);
                        break;
                    case 1127:
                        lblButton127.BackColor = default(Color);
                        break;
                    case 1128:
                        lblButton128.BackColor = default(Color);
                        break;
                }
            }
            lblUID.Text = "Unit ID: " + xk124Tbar_1.ConnectedDevices[0].UnitID.ToString();

            label8.Text = e.Shift.ToString();
            label9.Text = e.Control.ToString();
            label10.Text = e.Alt.ToString();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            int LightState=0;

            if (cboBacklightStatus.Text == "On")
            {
                LightState = 1;
            }
            else if (cboBacklightStatus.Text == "Off")
            {
                LightState = 0;
            }
            else if (cboBacklightStatus.Text == "Flash")
            {
                LightState = 2;
            }

            int ButtonID = Convert.ToInt32(spnButton.Value);

            //Sets an individual LED (on bank 0) based on chosen ButtonID and LightState
            xk124Tbar_1.SetBacklightLED(0, ButtonID, 0, LightState);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            int LightState=0;

            if (cboBacklightStatus.Text == "On")
            {
                LightState = 1;
            }
            else if (cboBacklightStatus.Text == "Off")
            {
                LightState = 0;
            }
            else if (cboBacklightStatus.Text == "Flash")
            {
                LightState = 2;
            }

            int ButtonID = Convert.ToInt32(spnButton.Value);

            //Sets an individual LED (on bank 1) based on chosen ButtonID and LightState
            xk124Tbar_1.SetBacklightLED(0, ButtonID, 1, LightState);
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            //Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
            xk124Tbar_1.SaveBacklightState(0);
        }

        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xk124Tbar_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xk124Tbar_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOEM.Text);

            //Sets device OEM Version ID
            xk124Tbar_1.SetOEMVersionID(0, id, true);
            //after sending this command the device will disconnect and reconnect
        }

        private void btnIntensity_Click(object sender, EventArgs e)
        {
            int Intensity1 = Convert.ToInt32(spnBlueIntensity.Value);
            int Intensity2 = Convert.ToInt32(spnRedIntensity.Value);

            //Sets the intensity for both backlighting banks
            xk124Tbar_1.SetBacklightIntensity(0, Intensity1, Intensity2);
        }

        private void btnRowsBlue_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3, row4, row5, row6, row7, row8;

            if (cboRow1.Text == "On")
            {
                row1 = true;
            }
            else
            {
                row1 = false;
            }

            if (cboRow2.Text == "On")
            {
                row2 = true;
            }
            else
            {
                row2 = false;
            }

            if (cboRow3.Text == "On")
            {
                row3 = true;
            }
            else
            {
                row3 = false;
            }

            if (cboRow4.Text == "On")
            {
                row4 = true;
            }
            else
            {
                row4 = false;
            }

            if (cboRow5.Text == "On")
            {
                row5 = true;
            }
            else
            {
                row5 = false;
            }

            if (cboRow6.Text == "On")
            {
                row6 = true;
            }
            else
            {
                row6 = false;
            }
            if (cboRow7.Text == "On")
            {
                row7 = true;
            }
            else
            {
                row7 = false;
            }

            if (cboRow8.Text == "On")
            {
                row8 = true;
            }
            else
            {
                row8 = false;
            }

            //Sets individual rows of backlights on bank 0
            xk124Tbar_1.SetRowsOfBacklights(0, 0, row1, row2, row3, row4, row5, row6, row7, row8);
        }

        private void btnRowsRed_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3, row4, row5, row6, row7, row8;

            if (cboRow1.Text == "On")
            {
                row1 = true;
            }
            else
            {
                row1 = false;
            }

            if (cboRow2.Text == "On")
            {
                row2 = true;
            }
            else
            {
                row2 = false;
            }

            if (cboRow3.Text == "On")
            {
                row3 = true;
            }
            else
            {
                row3 = false;
            }

            if (cboRow4.Text == "On")
            {
                row4 = true;
            }
            else
            {
                row4 = false;
            }

            if (cboRow5.Text == "On")
            {
                row5 = true;
            }
            else
            {
                row5 = false;
            }

            if (cboRow6.Text == "On")
            {
                row6 = true;
            }
            else
            {
                row6 = false;
            }
            if (cboRow7.Text == "On")
            {
                row7 = true;
            }
            else
            {
                row7 = false;
            }

            if (cboRow8.Text == "On")
            {
                row8 = true;
            }
            else
            {
                row8 = false;
            }

            //Sets individual rows of backlights on bank 1
            xk124Tbar_1.SetRowsOfBacklights(0, 1, row1, row2, row3, row4, row5, row6, row7, row8);
        }

        private void btnToggleAll_Click(object sender, EventArgs e)
        {
            //Toggles current state of backlights on or off
            xk124Tbar_1.ToggleBacklights(0);
        }

        private void btnAllBlue_Click(object sender, EventArgs e)
        {
            //Sets all the blue on or off
            if (AllBlue == true)
            {
                xk124Tbar_1.SetAllBlue(0, false);
                AllBlue = false;
            }
            else
            {
                xk124Tbar_1.SetAllBlue(0, true);
                AllBlue = true;
            }
        }

        private void btnAllRed_Click(object sender, EventArgs e)
        {
            //Sets all of the red on or off
            if (AllRed == true)
            {
                xk124Tbar_1.SetAllRed(0, false);
                AllRed = false;
            }
            else
            {
                xk124Tbar_1.SetAllRed(0, true);
                AllRed = true;
            }
        }

        private void btn1275_Click(object sender, EventArgs e)
        {
            //Changes device to the 1275 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Joystick and Mouse endpoints
            xk124Tbar_1.ChangePID(0, 1275);
        }

        private void btn1278_Click(object sender, EventArgs e)
        {
            //Changes device to the 1278 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Keyboard and Mouse endpoints
            xk124Tbar_1.ChangePID(0, 1278);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            txtKeyboard.Focus();
            //Sends the letters 'a' 'b' and 'c'
            xk124Tbar_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
            //Releases all sent keys
            xk124Tbar_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0);
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            //Moves mouse cursor right and up from its current position
            //Mouse endpoint required therefore must be in Product ID 1029 to work
            if (xk124Tbar_1.ConnectedDevices[0].MouseInterface == true)
            {
                xk124Tbar_1.SendMouse(0, false, false, false, false, false, 20, 20, 0);
            }
            else
            {
                MessageBox.Show("No mouse endpoint available, change to pid 1029");
            }
        }

        private void btnJoystick_Click(object sender, EventArgs e)
        {
            //Sends game controller message, open Game Controllers control panel to see
            //Joystick endpoint required therefore must be in Product ID 1027 to work
            if (xk124Tbar_1.ConnectedDevices[0].JoystickInterface == true)
            {
                bool[] buttons = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                xk124Tbar_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons);
            }
            else
            {
                MessageBox.Show("No joystick endpoint available, change to pid 1027");
            }
        }

        private void btnCheckDongle_Click(object sender, EventArgs e)
        {
            //Enter the 4 bytes used when xk24_1.SetSecurityKey was called
            byte byte1 = Convert.ToByte(txtByte1.Text);
            byte byte2 = Convert.ToByte(txtByte2.Text);
            byte byte3 = Convert.ToByte(txtByte3.Text);
            byte byte4 = Convert.ToByte(txtByte4.Text);

            //Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
            bool dongle = xk124Tbar_1.GetSecurityKey(0, byte1, byte2, byte3, byte4);

            if (dongle == true) //correct dongle was entered
            {
                grpDongle.BackColor = Color.Green;
            }
            if (dongle == false) //incorrect dongle was entered
            {
                grpDongle.BackColor = Color.Red;
            }
        }

        private void btnSetDongle_Click(object sender, EventArgs e)
        {
            //Enter in 4 bytes. REMEMBER these 4 bytes they will be required to check the dongle
            byte byte1 = Convert.ToByte(txtByte1.Text);
            byte byte2 = Convert.ToByte(txtByte2.Text);
            byte byte3 = Convert.ToByte(txtByte3.Text);
            byte byte4 = Convert.ToByte(txtByte4.Text);

            xk124Tbar_1.SetSecurityKey(0, byte1, byte2, byte3, byte4);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons.
            //Sending this command will trigger the _GenerateReportData event
            xk124Tbar_1.GenerateReport(0);
           
        }

        private void btnIncBlue_Click(object sender, EventArgs e)
        {
            //Increases the blue intensity in steps, set last argument to False if no wrapping is desired
            xk124Tbar_1.IncrementalBacklightIntensity(0, 0, true, true);
        }

        private void btnIncRed_Click(object sender, EventArgs e)
        {
            //Increases the red intensity in steps, set last argument to False if no wrapping is desired
            xk124Tbar_1.IncrementalBacklightIntensity(0, 1, true, true);
        }

        private void btnIncBlued_Click(object sender, EventArgs e)
        {
            //Decreases the blue intensity in steps, set last argument to False if no wrapping is desired
            xk124Tbar_1.IncrementalBacklightIntensity(0, 0, false, true);
        }

        private void btnIncRedd_Click(object sender, EventArgs e)
        {
            //Decreases the red intensity in steps, set last argument to False if no wrapping is desired
            xk124Tbar_1.IncrementalBacklightIntensity(0, 1, false, true);
        }

        private void btnStartCal_Click(object sender, EventArgs e)
        {
            xk124Tbar_1.StartCal(0);
            MessageBox.Show("Move T-bar slowly up and down to full extents.  When done click Stop Cal.");
        }

        private void btnStopCal_Click(object sender, EventArgs e)
        {
            xk124Tbar_1.StopCal(0);
        }

        private void xk124Tbar_1_ButtonChange(XK_124Tbar.XKeyEventArgs e)
        {
            //This method handles the button change event for the device
            HandleButtons(e);
            
        }

        private void xk124Tbar_1_DevicePlug(XK_124Tbar.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XKE-124 Tbar Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;

            lblUID.Text = "Unit ID: " + e.UID.ToString();
            lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();
            
        }

        private void xk124Tbar_1_DeviceUnplug(XK_124Tbar.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XKE-124 Tbar Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;

            lblUID.Text = "Unit ID: ";
            lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xk124Tbar_1_GenerateReportData(XK_124Tbar.XKeyEventArgs e)
        {
            HandleButtons(e);
            
        }

        private void xk124Tbar_1_TbarChange(XK_124Tbar.XKeyTbarArgs e)
        {
            //System.Media.SystemSounds.Beep.Play(); 
            lblTbarVal.Text = e.Tbar.ToString();
            lblTbarRaw.Text = e.TbarRaw.ToString();

            label8.Text = e.Shift.ToString();
            label9.Text = e.Control.ToString();
            label10.Text = e.Alt.ToString();
            
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            int Frequency = Convert.ToInt32(spnFrequency.Value);

            //Sets the flash frequency for the device
            xk124Tbar_1.SetFlashFrequency(0, Frequency);
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == false)
            {
                xk124Tbar_1.SetGreenIndicator(0, 0);
            }
            else
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk124Tbar_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk124Tbar_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == false)
            {
                xk124Tbar_1.SetRedIndicator(0, 0);
            }
            else
            {
                if (chkRedFlash.Checked == true)
                {
                    xk124Tbar_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk124Tbar_1.SetRedIndicator(0, 1);
                }
            }
        }

        private void chkGreenFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == true)
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk124Tbar_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk124Tbar_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRedFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == true)
            {
                if (chkRedFlash.Checked == true)
                {
                    xk124Tbar_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk124Tbar_1.SetRedIndicator(0, 1);
                }
            }
        }

        

        

        


    }
}
