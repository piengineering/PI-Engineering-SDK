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
            if (xk12Jog_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No XK-12 Jog && Shuttle Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                deviceStatus.Text = "XK-12 Jog && Shuttle Connected";
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xk12Jog_1.ConnectedDevices[0].UnitID;

               
                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xk12Jog_1.ConnectedDevices[0].Pid;
            }
        }

        private void HandleButtons(Xk12Jog.XKeyEventArgs e)
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
                        lblProgSwitch.Text = "Prog. Switch-dn";
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
                        lblProgSwitch.Text = "Prog. Switch-up";
                        break;
                    
                    
                }
            }
            lblUID.Text = "Unit ID: " + xk12Jog_1.ConnectedDevices[0].UnitID.ToString();
            //Time Stamp Info
            long absolutetime = e.TimeStamp; //gives time in ms since boot of X-keys unit
            long absolutetimesec = absolutetime / 1000; //convert to seconds
            lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s";
            if (saveabsolutetime != -1)
            {
                lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms"; //this gives the time between button presses or between any generated data reports
            }
            else
            {
                lblDTime.Text = "Delta Time: "; 
            }
            saveabsolutetime = absolutetime;

            label8.Text = e.Shift.ToString();
            label9.Text = e.Control.ToString();
            label10.Text = e.Alt.ToString();
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
            xk12Jog_1.SetBacklightLED(0, ButtonID, 0, LightState);
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
            xk12Jog_1.SetBacklightLED(0, ButtonID, 1, LightState);
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            //Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
            xk12Jog_1.SaveBacklightState(0);
        }

        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xk12Jog_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xk12Jog_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            
        }

        private void btnIntensity_Click(object sender, EventArgs e)
        {
            int Intensity1 = Convert.ToInt32(spnBlueIntensity.Value);
            int Intensity2 = Convert.ToInt32(spnRedIntensity.Value);

            //Sets the intensity for both backlighting banks
            xk12Jog_1.SetBacklightIntensity(0, Intensity1, Intensity2);
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            int Frequency = Convert.ToInt32(spnFrequency.Value);

            //Sets the flash frequency for the device
            xk12Jog_1.SetFlashFrequency(0, Frequency);
        }

        private void btnRowsBlue_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3;

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

            

            //Sets individual rows of backlights on bank 0
            xk12Jog_1.SetRowsOfBacklights(0, 0, row1, row2, row3);
        }

        private void btnRowsRed_Click(object sender, EventArgs e)
        {
            Boolean row1, row2, row3;

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

            //Sets individual rows of backlights on bank 1
            xk12Jog_1.SetRowsOfBacklights(0, 1, row1, row2, row3);
        }

        private void btnToggleAll_Click(object sender, EventArgs e)
        {
            //Toggles current state of backlights on or off
            xk12Jog_1.ToggleBacklights(0);
        }

        private void btnAllBlue_Click(object sender, EventArgs e)
        {
            //Sets all the blue on or off
            if (AllBlue == true)
            {
                xk12Jog_1.SetAllBlue(0, false);
                AllBlue = false;
            }
            else
            {
                xk12Jog_1.SetAllBlue(0, true);
                AllBlue = true;
            }
        }

        private void btnAllRed_Click(object sender, EventArgs e)
        {
            //Sets all of the red on or off
            if (AllRed == true)
            {
                xk12Jog_1.SetAllRed(0, false);
                AllRed = false;
            }
            else
            {
                xk12Jog_1.SetAllRed(0, true);
                AllRed = true;
            }
        }

        private void btn1062_Click(object sender, EventArgs e)
        {
            //Changes device to the 1089 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Keyboard and Mouse endpoints
            xk12Jog_1.ChangePID(0, 1062);
        }

        private void btn1064_Click(object sender, EventArgs e)
        {
            //Changes device to the 1091 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Keyboard and Joystick endpoints
            xk12Jog_1.ChangePID(0, 1064);
        }

       

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            txtKeyboard.Focus();
            //Sends the letters 'a' 'b' and 'c'
            xk12Jog_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
            //Releases all sent keys
            xk12Jog_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0);
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            //Moves mouse cursor right and up from its current position
            //Mouse endpoint required therefore must be in Product ID 1029 to work
            if (xk12Jog_1.ConnectedDevices[0].MouseInterface == true)
            {
                xk12Jog_1.SendMouse(0, false, false, false, false, false, 20, 20, 0);
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
            if (xk12Jog_1.ConnectedDevices[0].JoystickInterface == true)
            {
                bool[] buttons = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                xk12Jog_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons);
            }
            else
            {
                MessageBox.Show("No joystick endpoint available, change to pid 1027");
            }
        }

        private void btnCheckDongle_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSetDongle_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons.
            //Sending this command will trigger the _GenerateReportData event
            xk12Jog_1.GenerateReport(0);
           
        }

       

        private void xk12Jog_1_ButtonChange(Xk12Jog.XKeyEventArgs e)
        {
            //This method handles the button change event for the device
            HandleButtons(e);
        }

        private void xk12Jog_1_DevicePlug(Xk12Jog.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-12 Jog & Shuttle Plugged, Unit ID: " + e.UID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;

            lblUID.Text = "Unit ID: " + e.UID.ToString();
           // lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();

            saveabsolutetime = -1;
        }

        private void xk12Jog_1_DeviceUnplug(Xk12Jog.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-12 Jog & Shuttle Unplugged, Unit ID: " + e.UID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;

            lblUID.Text = "Unit ID: ";
           // lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xk12Jog_1_GenerateReportData(Xk12Jog.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void xk12Jog_1_JogChange(Xk12Jog.XKeyJogArgs e)
        {
            switch (e.Jog)
            {
                case 0:
                    lblJog.Text = "Jog:";
                    break;
                case 1:
                    lblJog.Text = "Jog: Clockwise";
                    break;
                case 255:
                    lblJog.Text = "Jog: Counterclockwise";
                    break;
            }
            //time stamp
            long absolutetime = e.TimeStamp; //gives time in ms since boot of X-keys unit
            long absolutetimesec = absolutetime / 1000; //convert to seconds
            lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s";
            if (saveabsolutetime != -1)
            {
                lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms"; //this gives the time between button presses or between any generated data reports
            }
            else
            {
                lblDTime.Text = "Delta Time: ";
            }
            saveabsolutetime = absolutetime;

            label8.Text = e.Shift.ToString();
            label9.Text = e.Control.ToString();
            label10.Text = e.Alt.ToString();

        }

        private void xk12Jog_1_ShuttleChange(Xk12Jog.XKeyShuttleArgs e)
        {
            lblShuttle.Text = "Shuttle: " + e.Shuttle.ToString();

            //time stamp
            long absolutetime = e.TimeStamp; //gives time in ms since boot of X-keys unit
            long absolutetimesec = absolutetime / 1000; //convert to seconds
            lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s";
            if (saveabsolutetime != -1)
            {
                lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms"; //this gives the time between button presses or between any generated data reports
            }
            else
            {
                lblDTime.Text = "Delta Time: ";
            }
            saveabsolutetime = absolutetime;

            label8.Text = e.Shift.ToString();
            label9.Text = e.Control.ToString();
            label10.Text = e.Alt.ToString();
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == false)
            {
                xk12Jog_1.SetGreenIndicator(0, 0);
            }
            else
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk12Jog_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk12Jog_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == false)
            {
                xk12Jog_1.SetRedIndicator(0, 0);
            }
            else
            {
                if (chkRedFlash.Checked == true)
                {
                    xk12Jog_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk12Jog_1.SetRedIndicator(0, 1);
                }
            }
        }

        private void chkGreenFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == true)
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk12Jog_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk12Jog_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRedFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == true)
            {
                if (chkRedFlash.Checked == true)
                {
                    xk12Jog_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk12Jog_1.SetRedIndicator(0, 1);
                }
            }
        }

        

        


    }
}
