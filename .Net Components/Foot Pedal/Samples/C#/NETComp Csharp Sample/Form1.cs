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
       
        long saveabsolutetime=-1;  //for timestamp demo
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //When valid XK-24 devices are connected they are added to the ConnectedDevices list
            //If this list is empty, then no valid devices are connected currently
           
            if (xk3FP_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No XK-3 Foot Pedal Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                deviceStatus.Text = "XK-3 Foot Pedal Connected";
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xk3FP_1.ConnectedDevices[0].UnitID;

                //Gets the OEM Version ID from the device
                lblOEM.Text = "OEM ID: " + xk3FP_1.ConnectedDevices[0].OEMVersion;

                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xk3FP_1.ConnectedDevices[0].Pid;
            }
        }

        private void HandleButtons(Xk3FP.XKeyEventArgs e)
        {
            //Handle state changes of the buttons
            if (e.PressState == true) //button press
            {
                switch (e.CID)
                {
                    case 1001:
                        
                        break;
                    case 1002:
                        lblButton01.Text = "left pedal-closed";
                        break;
                    case 1003:
                        lblButton02.Text = "middle pedal-closed";
                        break;
                    case 1004:
                        lblButton03.Text = "right pedal-closed";
                        break;
                    case 1005:
                        
                        break;
                    
                }
            }
            else //button release
            {
                switch (e.CID)
                {
                    case 1001:
                        
                        break;
                    case 1002:
                        lblButton01.Text = "left pedal-open";
                        break;
                    case 1003:
                        lblButton02.Text = "middle pedal-open";
                        break;
                    case 1004:
                        lblButton03.Text = "right pedal-open";
                        break;
                    case 1005:
                        
                        break;
                    
                }
            }
            lblUID.Text = "Unit ID: " + xk3FP_1.ConnectedDevices[0].UnitID.ToString();
            //Time Stamp Info
            long absolutetime = e.TimeStamp; //gives time in ms since boot of X-keys unit
            long absolutetimesec = absolutetime / 1000; //convert to seconds
            lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s";
            if (saveabsolutetime != -1)
            {
                lblDTime.Text = "Delta Time: " + (absolutetime-saveabsolutetime).ToString() + " ms"; //this gives the time between button presses or between any generated data reports
            }
            saveabsolutetime = absolutetime;
        }
        
        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xk3FP_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xk3FP_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOEM.Text);

            //Sets device OEM Version ID
            xk3FP_1.SetOEMVersionID(0, id, true);
            //after sending this command the device will disconnect and reconnect
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            int Frequency = Convert.ToInt32(spnFrequency.Value);

            //Sets the flash frequency for the device
            xk3FP_1.SetFlashFrequency(0, Frequency);
        }

        private void btn1082_Click(object sender, EventArgs e)
        {
            //Changes device to the 1224 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Keyboard and Mouse endpoints
            xk3FP_1.ChangePID(0, 1082);
        }

        private void btn1080_Click(object sender, EventArgs e)
        {
            //Changes device to the 1221 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Mouse and Joystick endpoints
            xk3FP_1.ChangePID(0, 1080);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            //Keyboard endpoint required therefore must be in Product ID 1195
            if (xk3FP_1.ConnectedDevices[0].KeyboardInterface == true)
            {
                txtKeyboard.Focus();
                //Sends the letters 'a' 'b' and 'c'
                xk3FP_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
                //Releases all sent keys
                xk3FP_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0);
            }
            else
            {
                MessageBox.Show("No keyboard endpoint available"); 

            }
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            //Moves mouse cursor right and up from its current position
            //Mouse endpoint required, both Product ID have mouse endpoint
            if (xk3FP_1.ConnectedDevices[0].MouseInterface == true)
            {
                xk3FP_1.SendMouse(0, false, false, false, false, false, 20, 20, 0);
            }
            else
            {
                MessageBox.Show("No mouse endpoint available, change to pid 1080");
            }
        }

        private void btnJoystick_Click(object sender, EventArgs e)
        {
            //Sends game controller message, open Game Controllers control panel to see
            //Joystick endpoint required therefore must be in Product ID 1192
            if (xk3FP_1.ConnectedDevices[0].JoystickInterface == true)
            {
                bool[] buttons = { true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                xk3FP_1.SendJoystick(0, 255, 127, 127, 127, 127, 6, buttons);
            }
            else
            {
                MessageBox.Show("No joystick endpoint available, change to pid 1082");
            }
        }

        private void btnCheckDongle_Click(object sender, EventArgs e)
        {
            //Enter the 4 bytes used when SetSecurityKey was called
            byte byte1 = Convert.ToByte(txtByte1.Text);
            byte byte2 = Convert.ToByte(txtByte2.Text);
            byte byte3 = Convert.ToByte(txtByte3.Text);
            byte byte4 = Convert.ToByte(txtByte4.Text);

            //Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
            bool dongle = xk3FP_1.GetSecurityKey(0, byte1, byte2, byte3, byte4);

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

            xk3FP_1.SetSecurityKey(0, byte1, byte2, byte3, byte4);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
            xk3FP_1.GenerateReport(0);
        }

        

        private void xk3FP_1_ButtonChange(Xk3FP.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void xk3FP_1_DevicePlug(Xk3FP.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-3 Foot Pedal Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;

            lblUID.Text = "Unit ID: " + e.UID.ToString();
            lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();
        }

        private void xk3FP_1_DeviceUnplug(Xk3FP.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XK-3 Foot Pedal Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;

            lblUID.Text = "Unit ID: ";
            lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xk3FP_1_GenerateReportData(Xk3FP.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == false)
            {
                xk3FP_1.SetGreenIndicator(0, 0);
            }
            else
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk3FP_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk3FP_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkGreenFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == true)
            {
                if (chkGreenFlash.Checked == true)
                {
                    xk3FP_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xk3FP_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == false)
            {
                xk3FP_1.SetRedIndicator(0, 0);
            }
            else
            {
                if (chkRedFlash.Checked == true)
                {
                    xk3FP_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk3FP_1.SetRedIndicator(0, 1);
                }
            }
        }

        private void chkRedFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == true)
            {
                if (chkRedFlash.Checked == true)
                {
                    xk3FP_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xk3FP_1.SetRedIndicator(0, 1);
                }
            }
        }

        


    }
}
