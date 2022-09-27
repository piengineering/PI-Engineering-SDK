using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PIEHid32Net;


namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        PIEDevice[] devices;
        
        int[] cbotodevice=null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        int selecteddevice=-1; //set to the index of CboDevice
       
        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void SetColorCallback(Color color);
        Control c;
        //end thread-safe

        //for reboot method
        bool EnumerationSuccess;
       
        public Form1()
        {
            InitializeComponent();
            
        }

        //data callback    
        public void HandlePIEHidData(Byte[] data, PIEDevice sourceDevice, int error)
        {
            //check the sourceDevice and make sure it is the same device as selected in CboDevice   
            if (sourceDevice == devices[selecteddevice])
            {
                //check the keyboard state byte 
                if (data[2] != 0xd8)
                {
                    byte val2 = (byte)(data[7] & 1);
                    if (val2 == 0)
                    {
                        c = this.LblNumLk;
                        this.SetText("NumLock: off");
                    }
                    else
                    {
                        c = this.LblNumLk;
                        this.SetText("NumLock: on");
                    }
                    val2 = (byte)(data[7] & 2);
                    if (val2 == 0)
                    {
                        c = this.LblCapsLk;
                        this.SetText("CapsLock: off");
                    }
                    else
                    {
                        c = this.LblCapsLk;
                        this.SetText("CapsLock: on");
                    }
                    val2 = (byte)(data[7] & 4);
                    if (val2 == 0)
                    {
                        c = this.LblScrLk;
                        this.SetText("ScrLock: off");
                    }
                    else
                    {
                        c = this.LblScrLk;
                        this.SetText("ScrLock: on");
                    }
                    //read the unit ID
                    c = this.LblUnitID;
                    this.SetText(data[1].ToString());
                }

                //write raw data to listbox1 in HEX
                String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                for (int i = 0; i < sourceDevice.ReadLength; i++)
                {
                    output = output + BinToHex(data[i]) + " ";
                }
                this.SetListBox(output);

                c = this.LblRS232;
                this.SetText("");
                if (data[2] == 0xd8) //this is RS232 incoming data
                {
                    this.SetText("RS232 incoming data");
                }
                else if (data[2] == 0 || data[2] == 2)
                {
                    this.SetText("Switches incoming data");
                }
                
                if (data[2] == 0xd9 && data[3]==1) //received message from connected serial device to wait
                {
                    c = this.LblCTS;
                    this.SetText("CTS Wait");
                }
                else if (data[2] == 0xd9 && data[3] == 0) //received message from connected serial device all clear to go
                {
                    c = this.LblCTS;
                    this.SetText("CTS Clear");
                }
            }
        }

        //error callback
        public void HandlePIEHidError(PIEDevice sourceDevice, Int32 error)
        {
            this.SetToolStrip("Error: " + error.ToString());
        }

        //for threadsafe setting of Windows Forms control
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.c.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.c.Text = text;
            }
        }

        //for threadsafe setting of Windows Forms control
        private void SetColor(Color color)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.c.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetColor);
                this.Invoke(d, new object[] { color });
            }
            else
            {
                this.c.BackColor = color;
            }
        }

        //for threadsafe setting of Windows Forms control
        private void SetListBox(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetListBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.listBox1.Items.Add(text);
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            }
        }

        //for threadsafe setting of Windows Forms control
        private void SetToolStrip(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.statusStrip1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetToolStrip);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.toolStripStatusLabel1.Text = text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closeinterfaces on all devices that have been setup (SetupInterface called)
            for (int i = 0; i < CboDevices.Items.Count; i++)
            {
                //if devices[].Connected=false don't call CloseInterface
                devices[cbotodevice[i]].CloseInterface();

            }
            System.Environment.Exit(0);
        }

        private void CboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecteddevice = cbotodevice[CboDevices.SelectedIndex];
            wData = new byte[devices[selecteddevice].WriteLength];//size write array 
        }

        private void BtnCallback_Click(object sender, EventArgs e)
        {
            //setup callback if there are devices found for each device found

            if (CboDevices.SelectedIndex != -1)
            {
                for (int i = 0; i < CboDevices.Items.Count; i++)
                {
                    //use the cbotodevice array which contains the mapping of the devices in the CboDevices to the actual device IDs
                    devices[cbotodevice[i]].SetErrorCallback(this);
                    devices[cbotodevice[i]].SetDataCallback(this);
                    devices[cbotodevice[i]].callNever = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            //test


            string text = "1";
            byte[] buffer = null;
            bool newline = true;
            if (newline == true)
            {
                text = text + "\n";
            }
            buffer = new byte[text.Length];


            for (int i = 0; i < (text.Length); i++)
            {
                buffer[i] = (byte)text[i];
            }
            int offset = 0; //not used here
            int bytestosend = text.Length;

            string temp = "";
            for (int i = 0; i < text.Length; i++)
            {
                temp = temp + Convert.ToChar(buffer[i]);
            }

          //  int offset = 0;
         //   byte[] buffer = null;
            //int count = 15;
            //buffer = new byte[40];
            //for (int i = 0; i < 40; i++) buffer[i] = (byte)i;
            //int bytestosend = count;
            int cnt = 0;
            int cntoffset = 0; //if sending multiple reports this goes to +32, +64 etc
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 209;               // 0xd1   
            while (bytestosend > 0)
            {
                    

                if ((cnt + offset) < buffer.Count()) //if this is not true, bad user input!
                {
                    //if ((cnt + offset) < bytestosend)
                    {
                        wData[3 + cnt] = (byte)(buffer[cnt + offset + cntoffset]);
                        bytestosend--;
                        if (cnt == 32) //trying to send more bytes than have room for, need to send in multiple reports
                        {
                            wData[2] = (byte)(cnt+1);
                            //int result = 404;
                            //while (result == 404)
                            //{
                            //    result = devices[selecteddevice].WriteData(wData);
                            //}
                            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                            {
                                wData[j] = 0;
                            }
                            wData[0] = 0;
                            wData[1] = 209;               // 0xd1   
                            cnt = -1; //so it will set to 0 
                            cntoffset = cntoffset + 33;
                        }

                        cnt++;
                    }
                }
                else
                {
                    MessageBox.Show(new Form() { TopMost = true, TopLevel = true }, "buffer not big enough for offset and count entered", "Bad buffer, offset, count combination", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                }
                
                int stop = 0;
                
            }
            int stipp = 0;
            wData[2] = (byte)cnt;
            //int result = 404;
            //while (result == 404)
            //{
            //    result = devices[selecteddevice].WriteData(wData);
            //}
        }

        private void BtnEnumerate_Click(object sender, EventArgs e)
        {
            EnumerationSuccess = false;
            CboDevices.Items.Clear();
            cbotodevice = new int[128]; //128=max # of devices
            //enumerate and setupinterfaces for all devices
            devices = PIEHid32Net.PIEDevice.EnumeratePIE();
            if (devices.Length == 0)
            {
                toolStripStatusLabel1.Text = "No Devices Found";
            }
            else
            {
                //System.Media.SystemSounds.Beep.Play(); 
                int cbocount=0; //keeps track of how many valid devices were added to the CboDevice box
                for (int i = 0; i < devices.Length; i++)
                {
                    //information about device
                    //PID = devices[i].Pid);
                    //HID Usage = devices[i].HidUsage);
                    //HID Usage Page = devices[i].HidUsagePage);
                    //HID Version = devices[i].Version);
                    int hidusagepg = devices[i].HidUsagePage;
                    int hidusage = devices[i].HidUsage;
                    if (devices[i].HidUsagePage == 0xc)// && devices[i].WriteLength==36)
                    {
                        switch (devices[i].Pid)
                        {
                            case 1257:
                                CboDevices.Items.Add("XC-RS232-DB9(" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1258:
                                CboDevices.Items.Add("XC-RS232-DB9(" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1259:
                                CboDevices.Items.Add("XC-RS232-DB9(" + devices[i].Pid + "=PID #3)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1260:
                                CboDevices.Items.Add("XC-RS232-DB9(" + devices[i].Pid + "=PID #4)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            default:
                                CboDevices.Items.Add("Unknown Device (" + devices[i].Pid+")");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                        }
                        devices[i].SetupInterface();
                        devices[i].suppressDuplicateReports = ChkSuppress.Checked;
                    }
                }
            }
            if (CboDevices.Items.Count > 0)
            {
                CboDevices.SelectedIndex = 0;
                selecteddevice = cbotodevice[CboDevices.SelectedIndex];
                wData = new byte[devices[selecteddevice].WriteLength];//go ahead and setup for write
                //fill in version
                LblVersion.Text = devices[selecteddevice].Version.ToString();
                EnumerationSuccess = true;
                this.Cursor = Cursors.Default;
            }
           
        }
       
      

        

        private void BtnUnitID_Click(object sender, EventArgs e)
        {
            //Write Unit ID to the device
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                //write Unit ID given in the TxtSetUnitID box
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 189;
                wData[2] = (byte)(Convert.ToInt16(TxtSetUnitID.Text));

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write Unit ID";
                }
            }
        }

        private void BtnKBreflect_Click(object sender, EventArgs e)
        {
            //Sends native keyboard messages
            //Write some keys to the textbox, should be Abcd
            //send some hid codes to the textbox, these will be coming in on the native keyboard endpoint
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                int result;
                textBox1.Focus();
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 201;

                wData[2] = 2;       //modifiers
                wData[3] = 0;       //always 0
                wData[4] = 0x04;    //hid code = a down
                wData[5] = 0;
                wData[6] = 0;
                wData[7] = 0;
                wData[8] = 0;
                wData[9] = 0;
                //use this loop to ensure done writing data before executing the next write command
                result = 404;
                while(result==404){result = devices[selecteddevice].WriteData(wData);}
                

                wData[2] = 0;       //modifiers
                wData[3] = 0;       //always 0
                wData[4] = 0;    //hid code = a up
                wData[5] = 0x05;    //hid code = b down
                wData[6] = 0x06;    //hid code = c down
                wData[7] = 0x07;    //hid code = d down
                wData[8] = 0;
                wData[9] = 0;

                result = 404;
                while(result==404){result = devices[selecteddevice].WriteData(wData);}
                
                wData[2] = 0;
                wData[4] = 0;
                wData[5] = 0;  //b up
                wData[6] = 0;  //c up
                wData[7] = 0;  //d up
                wData[8] = 0;
                wData[9] = 0;
                
                result = 404;
                while(result==404){result = devices[selecteddevice].WriteData(wData);}
                
                //using this method in real application if want to exactly duplicate down and up strokes would
                //probably do one key at a time.
                
            }
        }

        private void BtnJoyreflect_Click(object sender, EventArgs e)
        {
            //Sends native joystick messages
            //Open up the game controller control panel to test these features, after clicking this button
            //go and make active the control panel properties and change will be seen
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                int result;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 202;    //0xca
                wData[2] = (byte)Math.Abs((Convert.ToByte(TxtJoyX.Text) ^ 127) - 255);  //X, in raw form 0 to 127 from center to right, 255 to 128 from center to left but I like to use 0-255 where 0 is max left, 255 is max right
                wData[3] = (byte)(Convert.ToByte(TxtJoyY.Text) ^ 127); //Y, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[4] = (byte)(Convert.ToByte(TxtJoyZr.Text) ^ 127); //Z rotation, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[5] = (byte)(Convert.ToByte(TxtJoyZ.Text) ^ 127); //Z, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[6] = (byte)(Convert.ToByte(TxtJoySlider.Text) ^ 127); //Slider rotation, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255

                wData[7] = Convert.ToByte(TxtJoyGame1.Text); //buttons 1-8, where bit 1 is button 1, bit 1 is button 2, etc.
                wData[8] = Convert.ToByte(TxtJoyGame2.Text); //buttons 9-16
                wData[9] = Convert.ToByte(TxtJoyGame3.Text); //buttons 17-24
                wData[10] = Convert.ToByte(TxtJoyGame4.Text); //buttons 25-32

                wData[11] = 0;

                wData[12] = Convert.ToByte(TxtJoyHat.Text); //hat, where 0 is straight up, 1 is 45deg cw, etc and 8 is no hat
                result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - joystick reflector";
                }
            }
        }

        private void BtnDescriptor_Click(object sender, EventArgs e)
        {
            //Sending the command will make the device return information about it
            if (CboDevices.SelectedIndex != -1 && devices[selecteddevice].ReadLength>0)
            {
                //IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
                devices[selecteddevice].callNever = true;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 214;

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-Descriptor";
                }


                byte[] data = null;
                int countout = 0;
                data = new byte[80];
                data[1] = 0;
                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 214) || ret == 304)
                {
                    if (ret == 304)
                    {
                        // Didn't get any data for 100ms, increment the countout extra
                        countout += 99;
                    }
                    countout++;
                    
                    if (countout > 1000) //increase this if have to check more than once
                    {
                        //System.Media.SystemSounds.Beep.Play();
                        break;
                    }
                    ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                }
                listBox2.Items.Clear();
                if (data[3] == 0) listBox2.Items.Add("PID #1");
                else if (data[3] == 1) listBox2.Items.Add("PID #2"); //0=PID #1, 1=PID #2, 2=PID #3, 3=PID #4
                else if (data[3] == 2) listBox2.Items.Add("PID #3");
                else if (data[3] == 3) listBox2.Items.Add("PID #4");
                listBox2.Items.Add("Keymapstart=" + data[4].ToString());
                listBox2.Items.Add("Layer2offset=" + data[5].ToString());
                listBox2.Items.Add("Size of Eeprom MSB=" + data[6].ToString());
                listBox2.Items.Add("Size of Eeprom LSB=" + data[7].ToString());
                listBox2.Items.Add("MaxCol=" + data[8].ToString());
                listBox2.Items.Add("MaxRow=" + data[9].ToString());
               
                String greenled="Off";
                if ((data[10] & 64) != 0)
                {
                    greenled="On"; 
                }
                String redled="Off";
                if ((data[10] & 128) != 0)
                {
                    redled="On"; 
                }
                listBox2.Items.Add("Green LED=" + greenled);
                listBox2.Items.Add("Red LED=" + redled);
                listBox2.Items.Add("Firmware Version=" + data[11].ToString());
                
                string temp = "PID=" + (data[13] * 256 + data[12]).ToString();
                listBox2.Items.Add(temp);
                //data[14] = internal
                int MaxAddressToRead = 256 * data[16] + data[15]; //internal use only
                listBox2.Items.Add("MaxAddressToRead= " + (MaxAddressToRead).ToString());
                listBox2.Items.Add("Send incoming ascii data to keyboard=" + data[17].ToString());
                listBox2.Items.Add("RX Inverted=" + Convert.ToBoolean(data[23]).ToString());
                listBox2.Items.Add("TX Inverted=" + Convert.ToBoolean(data[24]).ToString());
                listBox2.Items.Add("RTSCTS Inverted=" + Convert.ToBoolean(data[25]).ToString());
                listBox2.Items.Add("Command/Pass Thru=" + data[27].ToString());
                ChkObeyCommands.Checked = false;
                ChkPassThru.Checked = false;
                byte cmdpass = (byte)(data[27] & 1);
                if (cmdpass == 1) ChkObeyCommands.Checked = true;
                cmdpass = (byte)(data[27] & 2);
                if (cmdpass == 2) ChkPassThru.Checked = true;
                double baudrate = 231.0/(double)data[26] ; //baud rate in kilobaud
                listBox2.Items.Add("Baud Rate= "+(baudrate * 1000).ToString());
                if (data[28] == 0)
                {
                    listBox2.Items.Add("Parity=None");
                }
                else if (data[28] == 2)
                {
                    listBox2.Items.Add("Parity=Even");
                }
                else if (data[28] == 6)
                {
                    listBox2.Items.Add("Parity=Odd");
                }


            }
        }


        private void BtnGetDataNow_Click(object sender, EventArgs e)
        {
            //After sending this command a general incoming data report will be given with
            //the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
            //and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
            //or unit id of the device before it sends any data.
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                devices[selecteddevice].callNever = false;
                //write Unit ID given in the TxtSetUnitID box
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 177; //0xb1

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Generate Data";
                }
            }
        }

       

        public static String BinToHex(Byte value)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(value.ToString("X2"));  //the 2 means 2 digits
            return sb.ToString();
        }

        public static Byte HexToBin(String value)
        {
            value = value.Trim();
            String addup = "0x" + value;
            return (Byte)Convert.ToInt32(value, 16);
        }

        private void ChkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                CheckBox thisChk = (CheckBox)sender;
                string temp = thisChk.Tag.ToString();
                byte LED = Convert.ToByte(temp); //6=green, 7=red
                byte state = 0;
                if (thisChk.Checked == true)
                {
                    state = 1;
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179;
                wData[2] = LED;
                wData[3] = state; //0=off, 1=on, 2=flash

                int result=404;
				while(result==404)
                {
                    result = devices[selecteddevice].WriteData(wData);
                   
                }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - LEDs and Outputs";
                }
            }
        }

        private void BtnPID1_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 204;
                wData[2] = 0; //0=pid1, 1=pid2, 2=pid3, 3=pid4

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - to PID #1";
                }

            }
        }

        private void BtnPID2_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 204;
                wData[2] = 1; //0=pid1, 1=pid2, 2=pid3, 3=pid4

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - to PID #2";
                }

            }
        }

        private void BtnPID3_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 204;
                wData[2] = 2; //0=pid1, 1=pid2, 2=pid3, 3=pid4

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - to PID #3";
                }

            }
        }

        private void BtnPID4_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 204;
                wData[2] = 3; //0=pid1, 1=pid2, 2=pid3, 3=pid4

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - to PID #4";
                }

            }
        }

       

        

        

        private void BtnMultiMedia_Click(object sender, EventArgs e)
        {
            //Many multimedia commands require the app to have focus to work.  Some that don't are Mute (E2), Volume Increment (E9), Volume Decrement (EA)
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


            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                int result = 0;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 0xe1;
                wData[2] = HexToBin(TxtMMLow.Text); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                wData[3] = HexToBin(TxtMMHigh.Text); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                result = 404;
                while(result==404){result = devices[selecteddevice].WriteData(wData);}
                

                wData[0] = 0;
                wData[1] = 0xe1;
                wData[2] = 0; //terminate
                wData[3] = 0; //terminate

                result = 404;
                while(result==404){result = devices[selecteddevice].WriteData(wData);}
                

                //note when the "terminate" command is sent can sometimes have an effect on the behavior of the command
                //for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the e1 command it will
                //decrement the volume one step, if you send the e1 on the press and the terminate on the release the volume will continuously
                //decrement until the key is released.
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write Multimedia";
                }
            }
        }

        private void BtnMyComputer_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 0xe1;
                wData[2] = HexToBin("94"); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                wData[3] = HexToBin("01"); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}

                wData[0] = 0;
                wData[1] = 0xe1;
                wData[2] = 0; //terminate
                wData[3] = 0; //terminate

                result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}

                //note that when the "terminate" command is sent can sometimes have an effect on the behavior of the command
                //for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the e1 command it will
                //decrement the volume one step, if you send the e1 on the press and the terminate on the release the volume will continuously
                //decrement until the key is released.
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write Multimedia";
                }
            }
        }

        private void BtnSleep_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 0xe2;
                wData[2] = 2; //1=power down, 2=sleep, 4=wake up

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                //NOTE this needs to be on the release of the key!!

                System.Threading.Thread.Sleep(1000); //this to simulate press/release

                wData[0] = 0;
                wData[1] = 0xe2;
                wData[2] = 0;

                result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write Multimedia";
                }
            }
        }

        private void BtnCustom_Click(object sender, EventArgs e)
        {
            //After sending this command a custom incoming data report will be given with
            //the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
            //and the following bytes whatever the user wishes.  In this example we are send 3 bytes; 1, 2, 3

            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                devices[selecteddevice].callNever = false;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 224; //0xe0
                wData[2] = 3; //count of bytes to follow
                wData[3] = 1; //1st custom byte
                wData[4] = 2; //2nd custom byte
                wData[5] = 3; //3rd custom byte

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Custom Data";
                }
            }
        }

        private void BtnVersion_Click(object sender, EventArgs e)
        {
            //Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
            //newly written version!
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 195; //c3
                wData[2] = (byte)(Convert.ToInt16(TxtVersion.Text));
                wData[3] = (byte)((Convert.ToInt16(TxtVersion.Text)) >> 8);

                int result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write Version";
                }

                System.Threading.Thread.Sleep(100);

                //reboot device and re-enumerate
                devices[selecteddevice].callNever = true;
                wData[0] = 0;
                wData[1] = 238; //ee
                wData[2] = 0;
                wData[3] = 0;

                //result=404;
                //while(result==404){result = devices[selecteddevice].WriteData(wData);}
                //if (result != 0)
                //{
                //    toolStripStatusLabel1.Text = "Write Fail: " + result;
                //}
                //else
                //{
                //    toolStripStatusLabel1.Text = "Write Success - Reboot";
                //}

                ////wait for reboot OR use device notification service (see http://www.piengineering.com/developer/mcode/DeviceNotification%20CSharp%20Express.zip)
                //System.Threading.Thread.Sleep(5000);

                //EnumerationSuccess = false;
                //int countout1 = 0;
                //while (EnumerationSuccess == false)
                //{
                //    countout1++;
                //    if (countout1 > 100)
                //    {
                //        this.Cursor = Cursors.Default;
                //        return;
                //    }
                //    BtnEnumerate_Click(this, null);
                //    System.Threading.Thread.Sleep(1000);

                //}
            }

        }

        private void ChkSuppress_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                if (ChkSuppress.Checked == false)
                {
                    devices[selecteddevice].suppressDuplicateReports = false;
                }
                else
                {
                    devices[selecteddevice].suppressDuplicateReports = true;
                }
            }
        }

        private void BtnBaud_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                if (CboBaud.SelectedIndex != -1)
                {
                    wData[0] = 0;
                    wData[1] = 217; // 0xd9; 
                    wData[2] = (byte)CboBaud.SelectedIndex; //0=1200, 1=2400, 2=4800, 3=9600, 4=19200, 5=38400, 6=57600, 7=115400
                    
                    int result=404;
				    while(result==404){result = devices[selecteddevice].WriteData(wData);}
                    if (result != 0)
                    {
                        toolStripStatusLabel1.Text = "Write Fail: " + result;
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Write Success - Baud Rate";
                    }
                }
            }
        }

        private void BtnParity_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            { 
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                int sindex=CboParity.SelectedIndex;
                if (sindex!=-1)
                {
                    wData[0] = 0;
                    wData[1] = 219; // 0xdb;
                    if (sindex == 0) wData[2] = 0; //None
                    else if (sindex == 1) wData[2] = 2; //Even
                    else if (sindex == 2) wData[2] = 6; //Odd
                    
                    int result=404;
				    while(result==404){result = devices[selecteddevice].WriteData(wData);}
                    if (result != 0)
                    {
                        toolStripStatusLabel1.Text = "Write Fail: " + result;
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Write Success - Parity";
                    }
                }
            }
        }

        private void ChkSendToKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 208; // 0xd0;
                if (ChkSendToKeyboard.Checked == true)
                {
                    wData[2] = 1;
                }
                else
                {
                    wData[2] = 0;
                }
                //note: the value set here can be read in from the descriptor to determine if it is on or off
                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Send to Keyboard";
                }
            }
        }

        private void BtnSendUART_Click(object sender, EventArgs e)
        {
            //if you know the commands for the connected serial device send them using this method
            //this example we are sending the command "\nB8"
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 209; // 0xd1;
                //the following bytes are dependent on the serial device message desired
                wData[2] = 04; // this is the number of bytes to follow
                wData[3] = 0x0A; //first byte, ascii linefeed
                //wData[4] = 0x42; //second byte, ascii for B
                //wData[5] = 0x38; //this is the third byte, ascii for 8
                //wData[6] = 0x3B; //this is ; which is the termination

                //other example, send ABC
                //wData[2] = 04; // this is the number of bytes to follow
                //wData[3] = 0x41; //A
                wData[4] = 0x44; //D
                wData[5] = 0x36; //6
                wData[6] = 0x3b; //this is ; which is the termination

                
                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Send to UART";
                }
            }
        }

        private void ChkSetRTS_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 218; // 0xda;
                if (ChkSetRTS.Checked == true)
                {
                    wData[2] = 1;
                }
                else
                {
                    wData[2] = 0;
                }
                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set RTS";
                }
            }
        }

        private void BtnSendCmdAscii_Click(object sender, EventArgs e)
        {
            //if you know the commands for the connected serial device send them using this method
            //this example we are converting the text in TxtAscii to bytes and sending it
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 209; // 0xd1;
                string text = TxtAscii.Text;
                int bytenum=3; //start of data bytes
                while (text.Length>0)
                {
                    wData[bytenum]=(byte)text[0];
                    bytenum++;
                    if (bytenum==devices[selecteddevice].WriteLength) //trying to send more bytes than allowed in one output report
                    {
                        //send it now
                        wData[2]=(byte)(bytenum-3); //number of bytes
                        int result=404;
				
				        while(result==404){result = devices[selecteddevice].WriteData(wData);}
                        if (result != 0)
                        {
                            toolStripStatusLabel1.Text = "Write Fail: " + result;
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = "Write Success - Send to UART";
                        }
                        bytenum=3;
                    }
               
                    text=text.Remove(0,1);
                    if (text=="") //reached end of string
                    {
                        wData[2]=(byte)(bytenum-3); //number of bytes
                        int result=404;
				
				        while(result==404){result = devices[selecteddevice].WriteData(wData);}
                        if (result != 0)
                        {
                            toolStripStatusLabel1.Text = "Write Fail: " + result;
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = "Write Success - Send to UART";
                        }
                    }
                }

             
            }
        }

        private void BtnCmdPass_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte cmd = 0;
                byte passthru = 0;
                if (ChkObeyCommands.Checked == true) cmd = 1; 
                if (ChkPassThru.Checked == true) passthru = 2; 
                byte cmdpass = (byte)(cmd|passthru);

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 222;  //0xde
                wData[2] = cmdpass;

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success";
                }
            }
        }

        private void BtnMousereflect_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                wData[0] = 0;
                wData[1] = 203;    //0xcb
                wData[2] = Convert.ToByte(TxtMouseButton.Text); //Buttons; 1=Left, 2=Right, 4=Center, 8=XButton1, 16=XButton2
                wData[3] = Convert.ToByte(TxtMouseX.Text); //Mouse X motion. 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129).
                wData[4] = Convert.ToByte(TxtMouseY.Text); //Mouse Y motion. 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129).
                wData[5] = Convert.ToByte(TxtMouseWheel.Text);//Wheel Y. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
                
                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                //now send all 0s
                wData[0] = 0;
                wData[1] = 203;    //0xcb
                wData[2] = 0; //buttons
                wData[3] = 0; //X
                wData[4] = 0; //Y
                wData[5] = 0; //wheel Y
                
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkObeyCommands_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkPassThru_CheckedChanged(object sender, EventArgs e)
        {

        }

        

       
        

        
       

        

        



        
 
       
    }
    
    
}
