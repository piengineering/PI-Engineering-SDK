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
    //The following is a sample showing how to interact with an XK-16 LCD device using the X-keys XK-16 LCD .NET component.

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
            //When valid XK-16 LCD devices are connected they are added to the ConnectedDevices list
            //If this list is empty, then no valid devices are connected currently
            if (xk16LCD_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No XK-16 LCD Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                deviceStatus.Text = "XK-16 LCD Connected";
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xk16LCD_1.ConnectedDevices[0].UnitID;

                //Gets the OEM Version ID from the device
                lblOEM.Text = "OEM ID: " + xk16LCD_1.ConnectedDevices[0].OEMVersion;

                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xk16LCD_1.ConnectedDevices[0].Pid;

                //Select the Product ID in the cboPIDs
                cboPIDs.SelectedIndex = (xk16LCD_1.ConnectedDevices[0].Pid - 1316);
            }
        }

        private void HandleButtons(Xk16LCD.XKeyEventArgs e)
        {
            //Handle state changes of the buttons
            if (e.PressState == true) //button press
            {
                switch (e.CID)
                {
                    case 1001:
                        lblButton01.Text = "01-dn";
                        break;
                    case 1002:
                        lblButton02.Text = "02-dn";
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
                        lblProgSwitch.Text = "Prog. Switch-up";
                        break;
                }
            }
            lblUID.Text = "Unit ID: " + xk16LCD_1.ConnectedDevices[0].UnitID.ToString();
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
            xk16LCD_1.SetBacklightLED(0, ButtonID, 0, LightState);
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
            xk16LCD_1.SetBacklightLED(0, ButtonID, 1, LightState);
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            //Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
            xk16LCD_1.SaveBacklightState(0);
        }

        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xk16LCD_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xk16LCD_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOEM.Text);

            //Sets device OEM Version ID
            xk16LCD_1.SetOEMVersionID(0, id, true);
            //after sending this command the device will disconnect and reconnect
        }

        private void btnIntensity_Click(object sender, EventArgs e)
        {
            int Intensity1 = Convert.ToInt32(spnBlueIntensity.Value);
            int Intensity2 = Convert.ToInt32(spnRedIntensity.Value);

            //Sets the intensity for both backlighting banks, valid values 0-255
            xk16LCD_1.SetBacklightIntensity(0, Intensity1, Intensity2);
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            int Frequency = Convert.ToInt32(spnFrequency.Value);

            //Sets the flash frequency for the device
            xk16LCD_1.SetFlashFrequency(0, Frequency);
        }

        private void btnRowsBlue_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3, row4;

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

            

            //Sets individual rows of backlights on bank 0
            xk16LCD_1.SetRowsOfBacklights(0, 0, row1, row2, row3, row4);
        }

        private void btnRowsRed_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3, row4;

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

            

            //Sets individual rows of backlights on bank 1
            xk16LCD_1.SetRowsOfBacklights(0, 1, row1, row2, row3, row4);
        }

        private void btnToggleAll_Click(object sender, EventArgs e)
        {
            //Toggles current state of backlights on or off
            xk16LCD_1.ToggleBacklights(0);
        }

        private void btnAllBlue_Click(object sender, EventArgs e)
        {
            //Sets all the blue on or off
            if (AllBlue == true)
            {
                xk16LCD_1.SetAllBlue(0, false);
                AllBlue = false;
            }
            else
            {
                xk16LCD_1.SetAllBlue(0, true);
                AllBlue = true;
            }
        }

        private void btnAllRed_Click(object sender, EventArgs e)
        {
            //Sets all of the red on or off
            if (AllRed == true)
            {
                xk16LCD_1.SetAllRed(0, false);
                AllRed = false;
            }
            else
            {
                xk16LCD_1.SetAllRed(0, true);
                AllRed = true;
            }
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            txtKeyboard.Focus();
            if (xk16LCD_1.ConnectedDevices[0].KeyboardInterface == true)
            {
                //Sends the letters 'a' 'b' and 'c'
                xk16LCD_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
                //Releases all sent keys
                xk16LCD_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0);
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
            if (xk16LCD_1.ConnectedDevices[0].MouseInterface == true)
            {
                xk16LCD_1.SendMouse(0, false, false, false, false, false, 20, 20, 0);
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
            if (xk16LCD_1.ConnectedDevices[0].JoystickInterface == true)
            {
                bool[] buttons = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                xk16LCD_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons);
            }
            else
            {
                MessageBox.Show("No joystick endpoint available, change to pid 1027");
            }
        }

        private void btnMultimedia_Click(object sender, EventArgs e)
        {
            //Enter in high and low bytes of the multimedia code
            //Many multimedia commands require the app to have focus to work.  Some that don't are Mute (00E2), Volume Increment (00E9), Volume Decrement (00EA)
            //The Multimedia reflector is mainly designed to be used as hardware mode macros.
            //Some common multimedia codes
            //Scan Next Track	00B5
            //Scan Previous Track	00B6
            //Stop	00B7
            //Play/Pause	00CD
            //Mute	00E2
            //Bass Boost	00E5
            //Loudness	00E7
            //Volume Up	00E9
            //Volume Down	00EA
            //Bass Up	0152
            //Bass Down	0153
            //Treble Up	0154
            //Treble Down	0155
            //Media Select	0183
            //Mail	018A
            //Calculator	0192
            //My Computer	0194
            //Search	0221
            //Home	0223
            //Back	0224
            //Forward	0225
            //Stop	0226
            //Refresh	0227
            //Favorites	022A
            if (xk16LCD_1.ConnectedDevices[0].MultimediaInterface == true)
            {
                xk16LCD_1.SendMultimedia(0, txtMMCode.Text.Substring(0, 2), txtMMCode.Text.Substring(2, 2));
                //IMPORTANT must send a terminate command
                //note when the "terminate" command is sent can sometimes have an effect on the behavior of the command,
                //for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the first SendMultimedia command it will
                //decrement the volume one step, if you send the SendMultimedia("00 "EA") on the press and the terminate SendMultimedia("00 "00") on the release the volume will continuously
                //decrement until the key is released.
                xk16LCD_1.SendMultimedia(0, "00", "00");
            }
            else
            {
                MessageBox.Show("No multimedia endpoint available");
            }
        }

        private void btnCheckDongle_Click(object sender, EventArgs e)
        {
            //Enter the 4 bytes used when xk16LCD_1.SetSecurityKey was called
            byte byte1 = Convert.ToByte(txtByte1.Text);
            byte byte2 = Convert.ToByte(txtByte2.Text);
            byte byte3 = Convert.ToByte(txtByte3.Text);
            byte byte4 = Convert.ToByte(txtByte4.Text);

            //Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
            bool dongle = xk16LCD_1.GetSecurityKey(0, byte1, byte2, byte3, byte4);

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

            xk16LCD_1.SetSecurityKey(0, byte1, byte2, byte3, byte4);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons.
            //Sending this command will trigger the _GenerateReportData event
            xk16LCD_1.GenerateReport(0);
           
        }

        private void xk16LCD_1_ButtonChange(Xk16LCD.XKeyEventArgs e)
        {
            //This method handles the button change event for the device
            HandleButtons(e);
        }

        private void xk16LCD_1_DevicePlug(Xk16LCD.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-16 LCD Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;

            lblUID.Text = "Unit ID: " + e.UID.ToString();
            lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();
        }

        private void xk16LCD_1_DeviceUnplug(Xk16LCD.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-16 LCD Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;

            lblUID.Text = "Unit ID: ";
            lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xk16LCD_1_GenerateReportData(Xk16LCD.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void btnChangePID_Click(object sender, EventArgs e)
        {
            //Changes device to the selected Product ID
            int newpid = -1;
            switch (cboPIDs.SelectedIndex)
            {
                case 0:
                    newpid = 1316;
                    break;
                case 1:
                    newpid = 1317;
                    break;
                case 2:
                    newpid = 1318;
                    break;
                case 3:
                    newpid = 1319;
                    break;
                case 4:
                    newpid = 1320;
                    break;
                case 5:
                    newpid = 1321;
                    break;
                case 6:
                    newpid = 1322;
                    break;
            }
            if (newpid != -1)
            {
                xk16LCD_1.ChangePID(0, newpid);
            }
        }

        private void btnWriteLCD1_Click(object sender, EventArgs e)
        {
            int blstate=1;
            if (chkBacklight.Checked==false) blstate=0;
            xk16LCD_1.SetLCDRow(0, 0, blstate, txtWriteLCD1.Text);
        }

        private void btnWriteLCD2_Click(object sender, EventArgs e)
        {
            int blstate = 1;
            if (chkBacklight.Checked == false) blstate = 0;
            xk16LCD_1.SetLCDRow(0, 1, blstate, txtWriteLCD2.Text);
        }

        private void btnClearLCD_Click(object sender, EventArgs e)
        {
            int blstate = 1;
            if (chkBacklight.Checked == false) blstate = 0;
            xk16LCD_1.SetLCDRow(0, 0, blstate, "");
            xk16LCD_1.SetLCDRow(0, 1, blstate, "");
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == false)
            {
                xk16LCD_1.SetGreenIndicator(0, 0);
            }
            else
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk16LCD_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk16LCD_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == false)
            {
                xk16LCD_1.SetRedIndicator(0, 0);
            }
            else
            {
                if (chkRedFlash.Checked == true)
                {
                    xk16LCD_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk16LCD_1.SetRedIndicator(0, 1);
                }
            }
        }

        private void chkGreenFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == true)
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk16LCD_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk16LCD_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRedFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == true)
            {
                if (chkRedFlash.Checked == true)
                {
                    xk16LCD_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk16LCD_1.SetRedIndicator(0, 1);
                }
            }
        }

        

        

        


    }
}
