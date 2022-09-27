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
           
            if (xkRS232_1.ConnectedDevices == null)
            {
                deviceStatus.Text = "No XC-RS232-DB9 Switch Interface Connected";
                deviceStatus.ForeColor = Color.Red;
            }
            else
            {
                deviceStatus.Text = "SC-RS232-DB9 Connected";
                deviceStatus.ForeColor = Color.Green;

                //Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " + xkRS232_1.ConnectedDevices[0].UnitID;

                //Gets the OEM Version ID from the device
                lblOEM.Text = "OEM ID: " + xkRS232_1.ConnectedDevices[0].OEMVersion;

                //Gets the Product ID from the device
                lblProductID.Text = "Product ID: " + xkRS232_1.ConnectedDevices[0].Pid;

                //Get the current baudrate setting
                int baudrate = xkRS232_1.ConnectedDevices[0].BaudRate;
                switch (baudrate)
                {
                    case 1200:
                        cboBaud.SelectedIndex = 0;
                        break;
                    case 2400:
                        cboBaud.SelectedIndex = 1;
                        break;
                    case 4800:
                        cboBaud.SelectedIndex = 2;
                        break;
                    case 9600:
                        cboBaud.SelectedIndex = 3;
                        break;
                    case 19200:
                        cboBaud.SelectedIndex = 4;
                        break;
                    case 38400:
                        cboBaud.SelectedIndex = 5;
                        break;
                    case 57600:
                        cboBaud.SelectedIndex = 6;
                        break;
                    case 115400:
                        cboBaud.SelectedIndex = 7;
                        break;
                }

                //Get the current parity setting
                XkRS232.XkRS232_.XkeysParityType currentparity = xkRS232_1.ConnectedDevices[0].Parity;
                switch (currentparity)
                {
                    case XkRS232.XkRS232_.XkeysParityType.None:
                        cboParity.SelectedIndex = 0;
                        break;
                    case XkRS232.XkRS232_.XkeysParityType.Even:
                        cboParity.SelectedIndex = 1;
                        break;
                    case XkRS232.XkRS232_.XkeysParityType.Odd:
                        cboParity.SelectedIndex = 2;
                        break;
                }

                //Get other settings
                lblPassThrough.Text = "Pass through data from COM device: " + xkRS232_1.ConnectedDevices[0].PassThrough.ToString();
                lblSendAscii.Text = "Send Ascii to keyboard: " + xkRS232_1.ConnectedDevices[0].SendAsciiToKeyboard.ToString();
                
            }
        }

        private void HandleButtons(XkRS232.XKeyEventArgs e)
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
            lblUID.Text = "Unit ID: " + xkRS232_1.ConnectedDevices[0].UnitID.ToString();
          
        }

       
        private void btnUID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUID.Text);

            //Sets device Unit ID
            xkRS232_1.SetDeviceUID(0, id);
            lblUID.Text = "Unit ID: " + xkRS232_1.ConnectedDevices[0].UnitID.ToString();
        }

        private void btnOEM_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtOEM.Text);

            //Sets device OEM Version ID
            xkRS232_1.SetOEMVersionID(0, id, true);
            //after sending this command the device will disconnect and reconnect
        }

        private void btnFrequency_Click(object sender, EventArgs e)
        {
            
        }

        private void btn1260_Click(object sender, EventArgs e)
        {
            //Changes device to the 1260 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Keyboard and Mouse endpoints
            xkRS232_1.ChangePID(0, 1260);
        }

        private void btn1257_Click(object sender, EventArgs e)
        {
            //Changes device to the 1257 Product ID (device will "replug" itself)
            //Change to this Product ID if you desire Mouse and Joystick endpoints
            xkRS232_1.ChangePID(0, 1257);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            //Keyboard endpoint required therefore must be in Product ID 1260
            if (xkRS232_1.ConnectedDevices[0].KeyboardInterface == true)
            {
                txtKeyboard.Focus();
                //Sends the letters 'a' 'b' and 'c'
                xkRS232_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 4, 5, 6, 0, 0, 0);
                //Releases all sent keys
                xkRS232_1.SendKeystrokes(0, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0);
            }
            else
            {
                MessageBox.Show("No keyboard endpoint available, change to pid 1260");
            }
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            //Moves mouse cursor right and up from its current position
            if (xkRS232_1.ConnectedDevices[0].MouseInterface == true)
            {
                xkRS232_1.SendMouse(0, false, false, false, false, false, 20, 20, 0);
            }
            else
            {
                MessageBox.Show("No mouse endpoint available");
            }
        }

        private void btnJoystick_Click(object sender, EventArgs e)
        {
            //Sends game controller message, open Game Controllers control panel to see
            //Joystick endpoint required therefore must be in Product ID 1257
            if (xkRS232_1.ConnectedDevices[0].JoystickInterface == true)
            {
                bool[] buttons = { true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                xkRS232_1.SendJoystick(0, 255, 127, 127, 127, 127, 6, buttons);
            }
            else
            {
                MessageBox.Show("No joystick endpoint available, change to pid 1257");
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
            bool dongle = xkRS232_1.GetSecurityKey(0, byte1, byte2, byte3, byte4);

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

            xkRS232_1.SetSecurityKey(0, byte1, byte2, byte3, byte4);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
            xkRS232_1.GenerateReport(0);
        }

        private void xkRS232_1_ButtonChange(XkRS232.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void xkRS232_1_DataReceived(XkRS232.XKeyRS232EventArgs e)
        {
            listBox1.Focus();
            listBox1.Items.Add(e.AsciiReceived);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void xkRS232_1_DevicePlug(XkRS232.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XC-RS232-DB9 Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Green;

            lblUID.Text = "Unit ID: " + e.UID.ToString();
            lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString();
            lblProductID.Text = "Product ID: " + e.PID.ToString();
        }

        private void xkRS232_1_DeviceUnplug(XkRS232.XKeyPlugEventArgs e)
        {
            deviceStatus.Text = "XC-RS232-DB9 Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString();
            deviceStatus.ForeColor = Color.Red;

            lblUID.Text = "Unit ID: ";
            lblOEM.Text = "OEM ID: ";
            lblProductID.Text = "Product ID: ";
        }

        private void xkRS232_1_GenerateReportData(XkRS232.XKeyEventArgs e)
        {
            HandleButtons(e);
        }

        private void btnBaud_Click(object sender, EventArgs e)
        {
            //Will cause a reboot if the desired baud is different from the current baud
            int baudrate = Convert.ToInt32(cboBaud.Text);
            xkRS232_1.SetBaudRate(0, baudrate);
        }

        private void btnParity_Click(object sender, EventArgs e)
        {
            //Will cause a reboot if the desired parity is different from the current parity
            if (cboParity.SelectedIndex == 0)
            {
                xkRS232_1.SetParity(0, XkRS232.XkRS232_.XkeysParityType.None);
            }
            else if (cboParity.SelectedIndex == 1)
            {
                xkRS232_1.SetParity(0, XkRS232.XkRS232_.XkeysParityType.Even);
            }
            else if (cboParity.SelectedIndex == 2)
            {
                xkRS232_1.SetParity(0, XkRS232.XkRS232_.XkeysParityType.Odd);
            }
        }

        private void chkSetRTS_CheckedChanged(object sender, EventArgs e)
        {
            int ClearWait=0; //clear
            if (chkSetRTS.Checked == true)
            {
                ClearWait = 1; //wait
            }
            xkRS232_1.SetRTS(0, ClearWait);
        }

        private void btnCmdPass_Click(object sender, EventArgs e)
        {
            //Toggles the option for passing through COM data, if this is 
            if (xkRS232_1.ConnectedDevices[0].PassThrough == false)
            {
                xkRS232_1.SetPassThrough(0, true);
            }
            else
            {
                xkRS232_1.SetPassThrough(0, false);
            }
            lblPassThrough.Text = "Pass through data from COM device: " + xkRS232_1.ConnectedDevices[0].PassThrough.ToString();
        }

        private void btnSendAscii_Click(object sender, EventArgs e)
        {
            //Toggles the option for sending any incoming ascii data to the keyboard, PID 1260 only. Note: it recommended to exit the sdk sample and set focus on a text application such as Notepad for this feature.
            if (xkRS232_1.ConnectedDevices[0].SendAsciiToKeyboard == false)
            {
                xkRS232_1.SetSendAsciiToKeyboard(0, true);
            }
            else
            {
                xkRS232_1.SetSendAsciiToKeyboard(0, false);
            }
            lblSendAscii.Text = "Send Ascii to keyboard: " + xkRS232_1.ConnectedDevices[0].SendAsciiToKeyboard.ToString();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            xkRS232_1.WriteString(0,txtAsciiCommand.Text,false, false);

            //other valid ways to write-send array of bytes
            //byte[] buffer = null;
            //buffer = new byte[40];
            //buffer[10] = 0x42;
            //buffer[11] = 0x38;
            //buffer[12] = 0x3b;
            //xkRS232_1.WriteBytes(0, buffer, 10, 3);

            //send array of char
           // char[] buffer = null;
            //buffer = new char[40];
            //buffer[10] = 'b';
            //buffer[11] = '8';
            //buffer[12] = ';';
            //xkRS232_1.WriteChars(0, buffer, 10, 3);

            

        }

        private void xkRS232_1_PinChange(XkRS232.XKeyRS232PinChangedEventArgs e)
        {
            if (e.ClearToSend == true)
            {
                listBox1.Items.Add("CTS clear");
            }
            else
            {
                listBox1.Items.Add("CTS wait");
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void chkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGreen.Checked == false)
            {
                xkRS232_1.SetGreenIndicator(0, 0);
            }
            else
            {
                xkRS232_1.SetGreenIndicator(0, 1);
            }
        }

        

        


    }
}
