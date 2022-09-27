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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //When valid XK-24 devices are connected they are added to the ConnectedDevices list
            //If this list is empty, then no valid devices are connected currently

            if (xkGEN_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No X-keys Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                int test = xkGEN_1.ConnectedDevices.Count();
                deviceStatus.Text = xkGEN_1.ConnectedDevices[0].ProductString;
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xkGEN_1.ConnectedDevices[0].UnitID;

                //Gets the OEM Version ID from the device
                lblOEM.Text = "OEM ID: " + xkGEN_1.ConnectedDevices[0].OEMVersion;

                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xkGEN_1.ConnectedDevices[0].Pid;
            }
        }

        private void HandleButtons(XkGEN.XKeyEventArgs e)
        {
            //Handle state changes of the buttons
            if (e.PressState == true) //button press
            {
                lblButton.Text = e.CID.ToString() + " press";
                
            }
            else //button release
            {
                lblButton.Text = e.CID.ToString() + " release";
            }
            lblUID.Text = "Unit ID: " + xkGEN_1.ConnectedDevices[0].UnitID.ToString();
            
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

            int BacklightIndex = Convert.ToInt32(txtBacklightIndex.Text);

            //Sets an individual LED based on chosen BacklightIndex and LightState-reference PIEngineeringSDK.chm for BacklightIndex for specific products
            xkGEN_1.SetBacklightLED(0, BacklightIndex, LightState);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            //Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
            xkGEN_1.SaveBacklightState(0);
        }

        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xkGEN_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xkGEN_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOEM.Text);

            //Sets device OEM Version ID
            xkGEN_1.SetOEMVersionID(0, id, true); //must set to true for reboot in order for new version to be recognized. If set to false then won't be recognized til next reboot.
            
        }

        private void btnIntensity_Click(object sender, EventArgs e)
        {
            int Intensity1 = Convert.ToInt32(spnBlueIntensity.Value);
            int Intensity2 = Convert.ToInt32(spnRedIntensity.Value);

            //Sets the intensity for both backlighting banks
            xkGEN_1.SetBacklightIntensity(0, Intensity1, Intensity2);
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            int Frequency = Convert.ToInt32(spnFrequency.Value);

            //Sets the flash frequency for the device
            xkGEN_1.SetFlashFrequency(0, Frequency);
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
            xkGEN_1.SetRowsOfBacklights(0, 0, row1, row2, row3, row4, row5, row6, row7, row8);
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
            xkGEN_1.SetRowsOfBacklights(0, 1, row1, row2, row3, row4, row5, row6, row7, row8);
        }

        private void btnToggleAll_Click(object sender, EventArgs e)
        {
            //Toggles current state of backlights on or off
            xkGEN_1.ToggleBacklights(0);
        }

        private void btnAllBlue_Click(object sender, EventArgs e)
        {
            //Sets all the blue on or off
            if (AllBlue == true)
            {
                xkGEN_1.SetAllBlue(0, false);
                AllBlue = false;
            }
            else
            {
                xkGEN_1.SetAllBlue(0, true);
                AllBlue = true;
            }
        }

        private void btnAllRed_Click(object sender, EventArgs e)
        {
            //Sets all of the red on or off
            if (AllRed == true)
            {
                xkGEN_1.SetAllRed(0, false);
                AllRed = false;
            }
            else
            {
                xkGEN_1.SetAllRed(0, true);
                AllRed = true;
            }
        }

        private void btn1029_Click(object sender, EventArgs e)
        {
            //Changes device to PID selected based on its index (device will "replug" itself), PID #1 has index=0, PID#2=1, etc.
            //consult PIEngineeringSDK.chm for available PIDs and their endpoints
            int PIDIndex = System.Convert.ToInt16(txtPIDIndex.Text);
            xkGEN_1.ChangePID(0, PIDIndex);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            txtKeyboard.Focus();
            
            //Sends the letters 'a' 'b' and 'c'
            xkGEN_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
            //Releases all sent keys
           
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            //Moves mouse cursor right and up from its current position
            //Mouse endpoint required therefore must be in Product ID 1029 to work
            xkGEN_1.SendMouse(0, false, false, false, false, false, 20, 20, 0);
           
        }

        private void btnJoystick_Click(object sender, EventArgs e)
        {
            //Sends game controller message, open Game Controllers control panel to see
            //Joystick endpoint required
            bool[] buttons = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
            xkGEN_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons);
           
        }

        private void btnCheckDongle_Click(object sender, EventArgs e)
        {
            //Enter the 4 bytes used when xk24_1.SetSecurityKey was called
            byte byte1 = Convert.ToByte(txtByte1.Text);
            byte byte2 = Convert.ToByte(txtByte2.Text);
            byte byte3 = Convert.ToByte(txtByte3.Text);
            byte byte4 = Convert.ToByte(txtByte4.Text);

            //Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
            bool dongle = xkGEN_1.GetSecurityKey(0, byte1, byte2, byte3, byte4);

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

            xkGEN_1.SetSecurityKey(0, byte1, byte2, byte3, byte4);
        }

       

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons.
            //Sending this command will trigger the _GenerateReportData event
            xkGEN_1.GenerateReport(0);
           
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == false)
            {
                xkGEN_1.SetGreenIndicator(0, 0);
            }
            else
            {
                if (chkGreenFlash.Checked == true)
                {
                    xkGEN_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xkGEN_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == false)
            {
                xkGEN_1.SetRedIndicator(0, 0);
            }
            else
            {
                if (chkRedFlash.Checked == true)
                {
                    xkGEN_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xkGEN_1.SetRedIndicator(0, 1);
                }
            }
        }

        private void chkGreenFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == true)
            {
                if (chkGreenFlash.Checked == true)
                {
                    xkGEN_1.SetGreenIndicator(0, 2);
                }
                else
                {
                    xkGEN_1.SetGreenIndicator(0, 1);
                }
            }
        }

        private void chkRedFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRed.Checked == true)
            {
                if (chkRedFlash.Checked == true)
                {
                    xkGEN_1.SetRedIndicator(0, 2);
                }
                else
                {
                    xkGEN_1.SetRedIndicator(0, 1);
                }
            }
        }

        private void xkGEN_1_ButtonChange(XkGEN.XKeyEventArgs e)
        {
            //This method handles the button change event for the device
            HandleButtons(e);
            //Time Stamp - user must know the time stamp byte positions for the specific device being used, this sample for XK-68 Joystick
            long absolutetime = 16777216 * e.RawData[19] + 65536 * e.RawData[20] + 256 * e.RawData[21] + e.RawData[22];
            lblTimeStamp.Text = "Time Stamp: "+absolutetime.ToString();
        }

        private void xkGEN_1_DevicePlug(XkGEN.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = e.ProductString+" Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;

            lblUID.Text = "Unit ID: " + e.UID.ToString();
            lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();
        }

        private void xkGEN_1_DeviceUnplug(XkGEN.XKeyPlugEventArgs e)
        {
            //System.Media.SystemSounds.Beep.Play();

            deviceStatus.Text = e.ProductString + " Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;
            lblUID.Text = "Unit ID: ";
            lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xkGEN_1_GenerateReportData(XkGEN.XKeyEventArgs e)
        {
            string states = "";
            for (int i = 0; i < e.ButtonStates.Count(); i++)
            {
                if (e.ButtonStates[i] == 1 || e.ButtonStates[i] == 2)
                {
                    states = states + "CID " + (i + 1001).ToString() + " dn ";
                }
                else
                {
                    states = states + "CID " + (i + 1001).ToString() + " up ";
                }
            }
            lblButton.Text = states;
            //Time Stamp - user must know their own time stamp bytes and do their own calcs, this sample for XK-68 Joystick
            long absolutetime = 16777216 * e.RawData[19] + 65536 * e.RawData[20] + 256 * e.RawData[21] + e.RawData[22];
            lblTimeStamp.Text = "Time Stamp: " + absolutetime.ToString();
        }

        private void xkGEN_1_AnalogChange(XkGEN.XKeyAnalogArgs e)
        {
            lblAnalogs.Text = "byte "+ e.AnalogByte.ToString() + " = " + e.AnalogVal.ToString();
            //specific example for XK-68 Joystick
            switch (e.AnalogByte)
            {
                case 16:
                    lblJoyX.Text = "X: "+e.AnalogVal.ToString();
                    break;
                case 17:
                    lblJoyY.Text = "Y: " + e.AnalogVal.ToString();
                    break;
                case 18:
                    lblJoyZ.Text = "Z: " + e.AnalogVal.ToString();
                    break;

            }

            //Time Stamp - user must know their own time stamp bytes and do their own calcs, this sample for XK-68 Joystick
            long absolutetime = 16777216 * e.RawData[19] + 65536 * e.RawData[20] + 256 * e.RawData[21] + e.RawData[22];
            lblTimeStamp.Text = "Time Stamp: " + absolutetime.ToString();
        }

        private void btnRegisterAnalog_Click(object sender, EventArgs e)
        {
            //If you don't want to receive an AnalogChange event then unregister it, 
            //AnalogByte is the byte position of the desired analog value, see PIEngineeringSDK documentation for specific products
            xkGEN_1.RegisterAnalog(0, 16); //XK-68 Joystick X
            xkGEN_1.RegisterAnalog(0, 17); //XK-68 Joystick Y
            xkGEN_1.RegisterAnalog(0, 18); //XK-68 Joystick Z
          
        }

        private void btnUnregisterAnalog_Click_1(object sender, EventArgs e)
        {
            //In order to receive an AnalogChange event user must first register the desired analog byte or bytes
            xkGEN_1.UnRegisterAnalog(0, 18); //XK-68 Joystick Z
        }

        private void xkGEN_1_RawDataChange(XkGEN.XKeyRawDataArgs e)
        {

            String output = "Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString() + ", data=";
            for (int i = 0; i < e.RawData.Length; i++)
            {
                output = output + BinToHex((byte)e.RawData[i]) + " ";
            }
            listBox1.Items.Add(output);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           
        }

        public static String BinToHex(Byte value)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(value.ToString("X2"));  //the 2 means 2 digits
            return sb.ToString();
        }

        private void btnGenericWriteData_Click(object sender, EventArgs e)
        {
            //sample of generic write data
            byte[] wData = new byte[xkGEN_1.ConnectedDevices[0].WriteLength];
            for (int j = 0; j < xkGEN_1.ConnectedDevices[0].WriteLength; j++)
            {
                wData[j] = 0;
            }

            wData[0] = 0;
            wData[1] = 184; //toggle backlights
            xkGEN_1.GenericWriteData(0, wData);

        }
        

       

      

        


    }
}
