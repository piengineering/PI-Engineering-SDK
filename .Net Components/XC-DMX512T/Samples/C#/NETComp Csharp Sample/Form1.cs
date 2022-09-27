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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //When valid devices are connected they are added to the ConnectedDevices list
            //If this list is empty, then no valid devices are connected currently
           
            if (xkDMXT_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No XC-DMX512T Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                deviceStatus.Text = "XC-DMX512T Connected";
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xkDMXT_1.ConnectedDevices[0].UnitID;

                //Gets the OEM Version ID from the device
                lblOEM.Text = "OEM ID: " + xkDMXT_1.ConnectedDevices[0].OEMVersion;

                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xkDMXT_1.ConnectedDevices[0].Pid;
            }
        }

        private void HandleButtons(XkDMXT.XKeyEventArgs e)
        {
            //Handle state changes of the buttons
            if (e.PressState == true) //button press
            {
                switch (e.CID)
                {
                    case 1001:
                        lblButton01.Text = "Jack 1R-dn";
                        break;
                    case 1002:
                        lblButton02.Text = "Jack 1L-dn";
                        break;
                    case 1003:
                        lblButton03.Text = "Jack 2R-dn";
                        break;
                    case 1004:
                        lblButton04.Text = "Jack 2L-dn";
                        break;
                    case 1005:
                        lblButton05.Text = "Jack 3R-dn";
                        break;
                    case 1006:
                        lblButton06.Text = "Jack 3L-dn";
                        break;
                    case 1007:
                        lblButton07.Text = "Jack 4R-dn";
                        break;
                    case 1008:
                        lblButton08.Text = "Jack 4L-dn";
                        break;
                    case 1009:
                        lblButton09.Text = "Jack 5R-dn";
                        break;
                    case 1010:
                        lblButton10.Text = "Jack 5L-dn";
                        break;
                    case 1011:
                        lblButton11.Text = "Jack 6R-dn";
                        break;
                    case 1012:
                        lblButton12.Text = "Jack 6L-dn";
                        break;
                    
                }
            }
            else //button release
            {
                switch (e.CID)
                {
                    case 1001:
                        lblButton01.Text = "Jack 1R-up";
                        break;
                    case 1002:
                        lblButton02.Text = "Jack 1L-up";
                        break;
                    case 1003:
                        lblButton03.Text = "Jack 2R-up";
                        break;
                    case 1004:
                        lblButton04.Text = "Jack 2L-up";
                        break;
                    case 1005:
                        lblButton05.Text = "Jack 3R-up";
                        break;
                    case 1006:
                        lblButton06.Text = "Jack 3L-up";
                        break;
                    case 1007:
                        lblButton07.Text = "Jack 4R-up";
                        break;
                    case 1008:
                        lblButton08.Text = "Jack 4L-up";
                        break;
                    case 1009:
                        lblButton09.Text = "Jack 5R-up";
                        break;
                    case 1010:
                        lblButton10.Text = "Jack 5L-up";
                        break;
                    case 1011:
                        lblButton11.Text = "Jack 6R-up";
                        break;
                    case 1012:
                        lblButton12.Text = "Jack 6L-up";
                        break;
                }
            }
            lblUID.Text = "Unit ID: " + xkDMXT_1.ConnectedDevices[0].UnitID.ToString();
            
        }
        
        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xkDMXT_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xkDMXT_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOEM.Text);

            //Sets device OEM Version ID
            xkDMXT_1.SetOEMVersionID(0, id, true);
            //after sending this command the device will disconnect and reconnect
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            //Keyboard endpoint required therefore must be in Product ID 1195
            if (xkDMXT_1.ConnectedDevices[0].KeyboardInterface == true)
            {
                txtKeyboard.Focus();
                //Sends the letters 'a' 'b' and 'c'
                xkDMXT_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
                //Releases all sent keys
                xkDMXT_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0);
            }
            else
            {
                MessageBox.Show("No keyboard endpoint available, change to pid 1195");

            }
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
        }

        private void btnJoystick_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCheckDongle_Click(object sender, EventArgs e)
        {
            //Enter the 4 bytes used when SetSecurityKey was called
            byte byte1 = Convert.ToByte(txtByte1.Text);
            byte byte2 = Convert.ToByte(txtByte2.Text);
            byte byte3 = Convert.ToByte(txtByte3.Text);
            byte byte4 = Convert.ToByte(txtByte4.Text);

            //Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
            bool dongle = xkDMXT_1.GetSecurityKey(0, byte1, byte2, byte3, byte4);

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

            xkDMXT_1.SetSecurityKey(0, byte1, byte2, byte3, byte4);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
            xkDMXT_1.GenerateReport(0);
        }

        private void xkDMXT_1_ButtonChange(XkDMXT.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void xkDMXT_1_DevicePlug(XkDMXT.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XC-DMX512T, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;
            
            lblUID.Text = "Unit ID: " + e.UID.ToString();
            lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();
        }

        private void xkDMXT_1_DeviceUnplug(XkDMXT.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XC-DMX512T Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;

            lblUID.Text = "Unit ID: ";
            lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xkDMXT_1_GenerateReportData(XkDMXT.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void btnSetSlots_Click(object sender, EventArgs e)
        {
            xkDMXT_1.SetNumberOfSlots(0, Convert.ToInt16(txtMaxSlots.Text));
        }

        private void btnSetSlotVals_Click(object sender, EventArgs e)
        {
            //example setting all of the values of the slots
            int numberslots = xkDMXT_1.GetNumberOfSlots(0);
            for (int i = 0; i < numberslots; i++)
            {
                xkDMXT_1.SetSlotValue(0, i + 1, 128); //setting them all with a value of 128
            }
            //set the trackbar so it reflects the same value
            trackBar1.Value = xkDMXT_1.GetSlotValue(0, Convert.ToInt16(txtSlot.Text));

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                btnStart.Text = "Stop";
                xkDMXT_1.TransmitContinuous(0, true);
            }
            else
            {
                btnStart.Text = "Start";
                xkDMXT_1.TransmitContinuous(0, false);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int slot = Convert.ToInt16(txtSlot.Text);
            byte val = (byte)trackBar1.Value;
            lblSlotVal.Text = val.ToString();
            xkDMXT_1.SetSlotValue(0, slot, val);
        }

        private void btnFirmwareVersion_Click(object sender, EventArgs e)
        {
            lblFirmwareVersion.Text = xkDMXT_1.ConnectedDevices[0].FirmwareVersion.ToString();
        }

        private void btnTransmitOnce_Click(object sender, EventArgs e)
        {
            //sending only 3 channels for this example
            xkDMXT_1.SetNumberOfSlots(0, 3);
            xkDMXT_1.SetSlotValue(0, 1, 0); //slot 1 = 0
            xkDMXT_1.SetSlotValue(0, 2, 255); //slot 2 = 255
            xkDMXT_1.SetSlotValue(0, 3, 0); //slot 3 = 0

            xkDMXT_1.Transmit(0);
        }

        
        


    }
}
