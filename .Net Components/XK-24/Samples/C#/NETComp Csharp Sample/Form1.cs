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
    //The following is a sample showing how to interact with an XK-24 device using the X-keys XK-24 .NET component.

    public partial class Form1 : Form
    {
        //Variables to track the device lights, initial states here based on device defaults
       
        Boolean AllBlue = true;
        Boolean AllRed = true;
        long saveabsolutetime = -1;  //for timestamp demo

       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //When valid XK-24 devices are connected they are added to the ConnectedDevices list
            //If this list is empty, then no valid devices are connected currently
            
            if (xk24_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No XK-24 Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                int test = xk24_1.ConnectedDevices.Count();
                deviceStatus.Text = "XK-24 Connected";
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xk24_1.ConnectedDevices[0].UnitID;

                //Gets the OEM Version ID from the device
                lblOEM.Text = "OEM ID: " + xk24_1.ConnectedDevices[0].OEMVersion;

                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xk24_1.ConnectedDevices[0].Pid;
            }
        }

        private void HandleButtons(Xk24.XKeyEventArgs e)
        {
            //Handle state changes of the buttons
            if (e.PressState == true) //button press
            {
                switch (e.CID)
                {
                    case 1001:
                        lblButton01.Text = "01-dn";
                        xk24_1.SendMouse(0, false, false, false, false, false, (254), 128, 128);
                        break;
                    case 1002:
                        lblButton02.Text = "02-dn";
                        xk24_1.SendMouse(0, false, false, false, false, false, 128, (254), 128);
                        break;
                    case 1003:
                        lblButton03.Text = "03-dn";
                        break;
                    case 1004:
                        lblButton04.Text = "04-dn";
                        break;
                    case 1005:
                        lblButton05.Text = "05-dn";
                        break;
                    case 1006:
                        lblButton06.Text = "06-dn";
                        break;
                    case 1007:
                        lblButton07.Text = "07-dn";
                        break;
                    case 1008:
                        lblButton08.Text = "08-dn";
                        break;
                    case 1009:
                        lblButton09.Text = "09-dn";
                        break;
                    case 1010:
                        lblButton10.Text = "10-dn";
                        break;
                    case 1011:
                        lblButton11.Text = "11-dn";
                        break;
                    case 1012:
                        lblButton12.Text = "12-dn";
                        break;
                    case 1013:
                        lblButton13.Text = "13-dn";
                        break;
                    case 1014:
                        lblButton14.Text = "14-dn";
                        break;
                    case 1015:
                        lblButton15.Text = "15-dn";
                        break;
                    case 1016:
                        lblButton16.Text = "16-dn";
                        break;
                    case 1017:
                        lblButton17.Text = "17-dn";
                        break;
                    case 1018:
                        lblButton18.Text = "18-dn";
                        break;
                    case 1019:
                        lblButton19.Text = "19-dn";
                        break;
                    case 1020:
                        lblButton20.Text = "20-dn";
                        break;
                    case 1021:
                        lblButton21.Text = "21-dn";
                        break;
                    case 1022:
                        lblButton22.Text = "22-dn";
                        break;
                    case 1023:
                        lblButton23.Text = "23-dn";
                        break;
                    case 1024:
                        lblButton24.Text = "24-dn";
                        break;
                    case 1025:
                        lblProgSwitch.Text = "Prog. Switch-dn";
                        break;
                }
            }
            else //button release
            {
                switch (e.CID)
                {
                    case 1001:
                        lblButton01.Text = "01-up";
                        break;
                    case 1002:
                        lblButton02.Text = "02-up";
                        break;
                    case 1003:
                        lblButton03.Text = "03-up";
                        break;
                    case 1004:
                        lblButton04.Text = "04-up";
                        break;
                    case 1005:
                        lblButton05.Text = "05-up";
                        break;
                    case 1006:
                        lblButton06.Text = "06-up";
                        break;
                    case 1007:
                        lblButton07.Text = "07-up";
                        break;
                    case 1008:
                        lblButton08.Text = "08-up";
                        break;
                    case 1009:
                        lblButton09.Text = "09-up";
                        break;
                    case 1010:
                        lblButton10.Text = "10-up";
                        break;
                    case 1011:
                        lblButton11.Text = "11-up";
                        break;
                    case 1012:
                        lblButton12.Text = "12-up";
                        break;
                    case 1013:
                        lblButton13.Text = "13-up";
                        break;
                    case 1014:
                        lblButton14.Text = "14-up";
                        break;
                    case 1015:
                        lblButton15.Text = "15-up";
                        break;
                    case 1016:
                        lblButton16.Text = "16-up";
                        break;
                    case 1017:
                        lblButton17.Text = "17-up";
                        break;
                    case 1018:
                        lblButton18.Text = "18-up";
                        break;
                    case 1019:
                        lblButton19.Text = "19-up";
                        break;
                    case 1020:
                        lblButton20.Text = "20-up";
                        break;
                    case 1021:
                        lblButton21.Text = "21-up";
                        break;
                    case 1022:
                        lblButton22.Text = "22-up";
                        break;
                    case 1023:
                        lblButton23.Text = "23-up";
                        break;
                    case 1024:
                        lblButton24.Text = "24-up";
                        break;
                    case 1025:
                        lblProgSwitch.Text = "Prog. Switch-up";
                        break;
                }
            }
            lblUID.Text = "Unit ID: " + xk24_1.ConnectedDevices[0].UnitID.ToString();
            //Time Stamp Info
            long absolutetime = e.TimeStamp; //gives time in ms since boot of X-keys unit
            long absolutetimesec = absolutetime / 1000; //convert to seconds
            lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s";
            if (saveabsolutetime != -1)
            {
                lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms"; //this gives the time between button presses or between any generated data reports
            }
            saveabsolutetime = absolutetime;
        }

        private void btnGreenLED_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRedLED_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGreenLEDFlash_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRedLEDFlash_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            int LightState;

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
            else
            {
                LightState = 1;
            }

            int ButtonID = Convert.ToInt32(spnButton.Value);

            //Sets an individual LED (on bank 0) based on chosen ButtonID and LightState
            xk24_1.SetBacklightLED(0, ButtonID, 0, LightState);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            int LightState;

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
            else
            {
                LightState = 1;
            }

            int ButtonID = Convert.ToInt32(spnButton.Value);

            //Sets an individual LED (on bank 1) based on chosen ButtonID and LightState
            xk24_1.SetBacklightLED(0, ButtonID, 1, LightState);
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            //Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
            xk24_1.SaveBacklightState(0);
        }

        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xk24_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xk24_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOEM.Text);

            //Sets device OEM Version ID
            xk24_1.SetOEMVersionID(0, id, true); //must set to true for reboot in order for new version to be recognized. If set to false then won't be recognized til next reboot.
            
        }

        private void btnIntensity_Click(object sender, EventArgs e)
        {
            int Intensity1 = Convert.ToInt32(spnBlueIntensity.Value);
            int Intensity2 = Convert.ToInt32(spnRedIntensity.Value);

            //Sets the intensity for both backlighting banks
            xk24_1.SetBacklightIntensity(0, Intensity1, Intensity2);
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            int Frequency = Convert.ToInt32(spnFrequency.Value);

            //Sets the flash frequency for the device
            xk24_1.SetFlashFrequency(0, Frequency);
        }

        private void btnRowsBlue_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3, row4, row5, row6;

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

            //Sets individual rows of backlights on bank 0
            xk24_1.SetRowsOfBacklights(0, 0, row1, row2, row3, row4, row5, row6);
        }

        private void btnRowsRed_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3, row4, row5, row6;

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

            //Sets individual rows of backlights on bank 1
            xk24_1.SetRowsOfBacklights(0, 1, row1, row2, row3, row4, row5, row6);
        }

        private void btnToggleAll_Click(object sender, EventArgs e)
        {
            //Toggles current state of backlights on or off
            xk24_1.ToggleBacklights(0);
        }

        private void btnAllBlue_Click(object sender, EventArgs e)
        {
            //Sets all the blue on or off
            if (AllBlue == true)
            {
                xk24_1.SetAllBlue(0, false);
                AllBlue = false;
            }
            else
            {
                xk24_1.SetAllBlue(0, true);
                AllBlue = true;
            }
        }

        private void btnAllRed_Click(object sender, EventArgs e)
        {
            //Sets all of the red on or off
            if (AllRed == true)
            {
                xk24_1.SetAllRed(0, false);
                AllRed = false;
            }
            else
            {
                xk24_1.SetAllRed(0, true);
                AllRed = true;
            }
        }

        private void btn1029_Click(object sender, EventArgs e)
        {
            //Changes device to the 1029 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Keyboard and Mouse endpoints
            xk24_1.ChangePID(0, 1029);
        }

        private void btn1027_Click(object sender, EventArgs e)
        {
            //Changes device to the 1027 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Keyboard and Joystick endpoints
            xk24_1.ChangePID(0, 1027);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            txtKeyboard.Focus();
            if (xk24_1.ConnectedDevices[0].KeyboardInterface == true)
            {
                //Sends the letters 'a' 'b' and 'c'
                xk24_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
                //Releases all sent keys
                xk24_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0);
            }
            else
            {
                MessageBox.Show("No mouse endpoint available, change to pid 1029");
            }
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            //Moves mouse cursor right and up from its current position
            //Mouse endpoint required therefore must be in Product ID 1029 to work
            if (xk24_1.ConnectedDevices[0].MouseInterface == true)
            {
                xk24_1.SendMouse(0, false, false, false, false, false, 20, 20, 0);
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
            if (xk24_1.ConnectedDevices[0].JoystickInterface == true)
            {
                bool[] buttons = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                xk24_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons);
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
            bool dongle = xk24_1.GetSecurityKey(0, byte1, byte2, byte3, byte4);

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

            xk24_1.SetSecurityKey(0, byte1, byte2, byte3, byte4);
        }

        private void xk24_1_DevicePlug(Xk24.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-24 Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;

            lblUID.Text = "Unit ID: " + e.UID.ToString();
            lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();
        }
        
        private void xk24_1_DeviceUnplug(Xk24.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-24 Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;
            lblUID.Text = "Unit ID: ";
            lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xk24_1_ButtonChange(Xk24.XKeyEventArgs e)
        {
            //This method handles the button change event for the device
            HandleButtons(e);
        }

        private void xk24_1_GenerateReportData(Xk24.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons.
            //Sending this command will trigger the _GenerateReportData event
            xk24_1.GenerateReport(0);
           
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == false)
            {
                xk24_1.SetGreenIndicator(0, 0);
            }
            else
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk24_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk24_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == false)
            {
                xk24_1.SetRedIndicator(0, 0);
            }
            else
            {
                if (chkRedFlash.Checked == true)
                {
                    xk24_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk24_1.SetRedIndicator(0, 1);
                }
            }
        }

        private void chkGreenFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == true)
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk24_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk24_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRedFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == true)
            {
                if (chkRedFlash.Checked == true)
                {
                    xk24_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk24_1.SetRedIndicator(0, 1);
                }
            }
        }

       

      

        


    }
}
