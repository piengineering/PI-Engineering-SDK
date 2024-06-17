
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PIEHid32Net;
using System.Text.RegularExpressions;


namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        
        PIEDevice[] devices;
        
        int[] cbotodevice=null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        int selecteddevice=-1; //set to the index of CboDevice
        long saveabsolutetime;  //for timestamp demo

        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void SetClearCallback();
        Control c;
        ListBox thisListBox;
        //end thread-safe

        byte[] lastdata = null;

        int JsonCount = 0; //for decoding incoming  UART PI Base64 Input Report Transmit Messages
        string thispid;
        string thisuid;
        string Jsondata; //Base64 encoded data
        string Jsonsndata; //Base64 encoded data of the silicon generated id

        bool pidata = false;
        string RxString = null;
        int RxByte;

       
        public Form1()
        {
            InitializeComponent();
            //BtnEnumerate_Click(this, null);
        }

        //data callback    
        public void HandlePIEHidData(Byte[] data, PIEDevice sourceDevice, int error)
        {
            //check the sourceDevice and make sure it is the same device as selected in CboDevice   
            if (sourceDevice == devices[selecteddevice])
            {
                //write raw data to listbox1 in HEX
                String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                for (int i = 0; i < sourceDevice.ReadLength; i++)
                {
                    output = output + BinToHex(data[i]) + " ";
                }
                thisListBox = listBox1;
                this.SetListBox(output);
                if (data[2] < 4) //general incoming data
                {
                    //buttons
                    //this routine is for separating out the individual button presses/releases from the data byte array.
                    int maxcols = 4; //number of columns, adjust if necessary
                    int maxrows = 8; //constant, 8 bits per byte
                    c = this.LblButtons;
                    string buttonsdown = "Buttons: "; //for demonstration, reset this every time a new input report received
                    this.SetText(buttonsdown);

                    for (int i = 0; i < maxcols; i++) //loop through digital button bytes 
                    {
                        for (int j = 0; j < maxrows; j++) //loop through each bit in the button byte
                        {
                            int temp1 = (int)Math.Pow(2, j); //1, 2, 4, 8, 16, 32, 64, 128
                            int keynum = 8 * i + j; //using key numbering in sdk; column 1 = 0,1,2... column 2 = 8,9,10... column 3 = 16,17,18... column 4 = 24,25,26... etc
                            byte temp2 = (byte)(data[i + 3] & temp1); //check using bitwise AND the current value of this bit. The + 3 is because the 1st button byte starts 3 bytes in at data[3]
                            byte temp3 = (byte)(lastdata[i + 3] & temp1); //check using bitwise AND the previous value of this bit
                            int state = 0; //0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                            if (temp2 != 0 && temp3 == 0) state = 1; //press
                            else if (temp2 != 0 && temp3 != 0) state = 2; //held down
                            else if (temp2 == 0 && temp3 != 0) state = 3; //release
                            switch (state)
                            {
                                case 1: //key was up and now is pressed
                                    buttonsdown = buttonsdown + keynum.ToString() + " ";
                                    c = this.LblButtons;
                                    SetText(buttonsdown);
                                    break;
                                case 2: //key was pressed and still is pressed
                                    buttonsdown = buttonsdown + keynum.ToString() + " ";
                                    c = this.LblButtons;
                                    SetText(buttonsdown);
                                    break;
                                case 3: //key was pressed and now released
                                    break;
                            }
                            //Perform action based on key number, consult P.I. Engineering SDK documentation for the key numbers
                            switch (keynum)
                            {
                                case 0: //button 0 (top left)
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 1: //button 1
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 2: //button 2
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 3: //button 3
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                               	    //etc.

                            }
                        }
                    }
                    for (int i = 0; i < sourceDevice.ReadLength; i++)
                    {
                        lastdata[i] = data[i];
                    }
                    //end buttons
                
                    //check the switch byte 
                    byte val2 = (byte)(data[2] & 1);
                    if (val2 == 0)
                    {
                        c = this.LblSwitchPos;
                        this.SetText("switch up");
                    }
                    else
                    {
                        c = this.LblSwitchPos;
                        this.SetText("switch down");
                    }

                   
                    
                    //time stamp info 4 bytes
                    long absolutetime = 16777216 * data[32] + 65536 * data[33] + 256 * data[34] + data[35];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    //c = this.label19;
                    //this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    //c = this.label20;
                    //this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;

                    
                }
                else if (data[2] == 216) //0xd8 uart data
                {
                   
                    
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
        private void SetListBox(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.thisListBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetListBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.thisListBox.Items.Add(text);
                this.thisListBox.SelectedIndex = this.thisListBox.Items.Count - 1;
            }
        }
        //for threadsafe setting of Windows Forms control
        private void ClearListBox()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.thisListBox.InvokeRequired)
            {
                SetClearCallback d = new SetClearCallback(ClearListBox);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                this.thisListBox.Items.Clear();
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
           
            for (int i = 1; i < 20; i++) //?? how high 256
            {
                if (serialPort1.IsOpen == true) serialPort1.Close();
                serialPort1.PortName = "COM" + i.ToString();

                try
                {
                    serialPort1.Open();
                    CboPorts.Items.Add(serialPort1.PortName);

                }
                catch (System.Exception ex)
                {
                    toolStripStatusLabel1.Text = ex.ToString();
                }
            }
            if (CboPorts.Items.Count == 0)
                toolStripStatusLabel1.Text = "No available COM Ports";
            else
            {
                CboPorts.SelectedIndex = CboPorts.Items.Count - 1;  //pick last one in the list
            }
            if (CboPorts.SelectedIndex != -1)
            {
                cboCOMBaud.SelectedIndex = 9;//default to highest baud which is the X-keys factory default
                serialPort1.BaudRate = Convert.ToInt32(cboCOMBaud.GetItemText(this.cboCOMBaud.SelectedItem));

                cboCOMParity.SelectedIndex = 2; //default to none
                serialPort1.Parity = System.IO.Ports.Parity.None;

                cboCOMData.SelectedIndex = 8 - 5; //default to 8
                serialPort1.DataBits = 8;

                cboCOMStop.SelectedIndex = 0; //default to 1
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
            }
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closeinterfaces on all devices that have been setup (SetupInterface called)
            for (int i = 0; i < CboDevices.Items.Count; i++)
            {
                devices[cbotodevice[i]].CloseInterface();
            }
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

            }
            catch (System.Exception ex)
            {
                toolStripStatusLabel1.Text = ex.ToString();
            }

            System.Environment.Exit(0);
        }

        private void CboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecteddevice = cbotodevice[CboDevices.SelectedIndex];
            wData = new byte[devices[selecteddevice].WriteLength];//size write array 
            lastdata = new byte[devices[selecteddevice].ReadLength];
        }

        private void BtnCallback_Click(object sender, EventArgs e)
        {
            //setup callback if there are devices found for each device found

            if (selecteddevice != -1)
            {
                for (int i = 0; i < CboDevices.Items.Count; i++)
                {
                    //use the cbotodevice array which contains the mapping of the devices in the CboDevices to the actual device IDs
                    devices[cbotodevice[i]].SetErrorCallback(this);
                    devices[cbotodevice[i]].SetDataCallback(this);
                    devices[cbotodevice[i]].callNever = false;
                }
                toolStripStatusLabel1.Text = "Callback on";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            
          
        }

        private void BtnEnumerate_Click(object sender, EventArgs e)
        {
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
                    //HID Version = devices[i].Version); //NOTE: this is NOT the firmware version which is given in the descriptor
                    int hidusagepg = devices[i].HidUsagePage;
                    int hidusage = devices[i].HidUsage;
                    
                    if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength>0)
                    {
                       
                        CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + ")");
                        cbotodevice[cbocount] = i;
                        cbocount++;
                        
                        devices[i].SetupInterface();
                        devices[i].suppressDuplicateReports = false;
                        EnableAllControls();
                    }
                    else
                    {
                        if (devices[i].Pid == 1292) //if pid=1292, contact tech support: tech@piengineering.com
                        {
                            CboDevices.Items.Add("Bootload device: " + devices[i].ProductString + " (" + devices[i].Pid + ")");
                            cbotodevice[cbocount] = i;
                            cbocount++;
                            DisableAllControls(devices[i].Pid);
                            MessageBox.Show("Device in bootloader mode.  Contact P.I. Engineering.");
                        }
                       
                    }
                }
            }
            if (CboDevices.Items.Count > 0)
            {
                CboDevices.SelectedIndex = 0;
                selecteddevice = cbotodevice[CboDevices.SelectedIndex];
                wData = new byte[devices[selecteddevice].WriteLength];//go ahead and setup for write
                lastdata = new byte[devices[selecteddevice].ReadLength];
               
                toolStripStatusLabel1.Text = devices[selecteddevice].ProductString + " found";
            }
        }

        private void DisableAllControls(int thispid)
        {
            foreach (Control cl in Controls)
            {
                if (cl.Name != "BtnEnumerate")
                {
                    cl.Enabled = false;
                }
            }
        }

        private void EnableAllControls()
        {
            foreach (Control cl in Controls)
            {
                if (cl.Name != "BtnEnumerate")
                {
                    cl.Enabled = true;
                }
            }
        }

     

        

       

        private void BtnBLToggle_Click(object sender, EventArgs e)
        {
            //Sending this command toggles the backlights
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 184; //b8

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Toggle BL";
                }
            }
        }

        

       
      

        private void BtnDescriptor_Click(object sender, EventArgs e)
        {
            //Sending the command will make the device return information about it
            if (selecteddevice != -1)
            {
                //IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later
                bool savecallbackstate = devices[selecteddevice].callNever;
                devices[selecteddevice].callNever = true;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 214; //0xd6
                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Descriptor, callback off";
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
                        break;
                    ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                }
                listBox2.Items.Clear();
                listBox2.Items.Add("PID #"+(data[3]+1).ToString());
                listBox2.Items.Add("Keymapstart=" + data[4].ToString());
                listBox2.Items.Add("Layer2offset=" + data[5].ToString());
                listBox2.Items.Add("Size of Eeprom MSB=" + data[6].ToString());
                listBox2.Items.Add("Size of Eeprom LSB=" + data[7].ToString());
                listBox2.Items.Add("MaxCol=" + data[8].ToString());
                listBox2.Items.Add("MaxRow=" + data[9].ToString());
                String ledon = "";
                if ((byte)(data[10] & 64) != 0) ledon = "Green LED On"; else ledon = "Green LED Off";
                if ((byte)(data[10] & 128) != 0) ledon = ledon + " Red LED On"; else ledon = ledon+" Red LED Off";
                if (ledon == "") ledon = "None";
                listBox2.Items.Add("LEDs=" + ledon);
                listBox2.Items.Add("Firmware Version=" + data[11].ToString()); //firmware version

                string temp = "PID=" + (data[13] * 256 + data[12]).ToString();
                listBox2.Items.Add(temp);

                //temp = "Divider=" + (data[18] * 256 + data[17]).ToString();
                //listBox2.Items.Add(temp);
                //listBox2.Items.Add("Parity=" + data[19].ToString());
                //label59.Text = data[19].ToString();
                //listBox2.Items.Add("Data bits=" + data[20].ToString());
                //label61.Text = data[20].ToString();
                //listBox2.Items.Add("Stop bits=" + data[21].ToString());
                //label62.Text = data[21].ToString();
                

                //uart stuff
                if ((byte)(data[21] & 1) == 1)
                {
                    listBox2.Items.Add("UART PI Base64 Input Report Transmit Messages=enabled");
                    lblJsonState.Text = "on";
                }
                else
                {
                    listBox2.Items.Add("UART PI Base64 Input Report Transmit Messages=disabled");
                    lblJsonState.Text = "off";
                }

                if ((byte)(data[21] & 2) == 2)
                {
                    listBox2.Items.Add("echo op code=enabled");
                    lblEchoState.Text = "on";
                }
                else
                {
                    listBox2.Items.Add("echo op code=disabled");
                    lblEchoState.Text = "off";

                }

                if ((byte)(data[21] & 4) == 4)
                {
                    listBox2.Items.Add("USB sleep=disabled");
                    lblReawakeState.Text = "disabled";
                }
                else
                {
                    listBox2.Items.Add("USB sleep=enabled");
                    lblReawakeState.Text = "enabled";

                }

                if ((byte)(data[21] & 8) == 8)
                {
                    listBox2.Items.Add("USB check=disabled");
                    lblUSBCheckState.Text = "disabled";
                }
                else
                {
                    listBox2.Items.Add("USB check=enabled");
                    lblUSBCheckState.Text = "enabled";
                }

                listBox2.Items.Add("start byte opcode" + data[23].ToString());
                listBox2.Items.Add("stop byte opcode=" + data[24].ToString());
                listBox2.Items.Add("start byte PI Base64=" + data[25].ToString());
                listBox2.Items.Add("stop byte PI Base64=" + data[26].ToString());

             
             
                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

        private void ChkSuppress_CheckedChanged(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
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
       
       
        public static Byte HexToBin(String value)
        {
            value = value.Trim();
            String addup = "0x" + value;
            return (Byte)Convert.ToInt32(value, 16);
        }


        public static String BinToHex(Byte value)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(value.ToString("X2"));  //the 2 means 2 digits
            return sb.ToString();
        }
       

        private void btnEchoOn_Click(object sender, EventArgs e)
        {
            //If echo is on then when a UART Output Report Received Message is received an Incoming UART Data - Echo UART input report will be generated 
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 217; // 0xd9;
                wData[2] = 1; //echo on

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Echo output command";
                }
            }
        }

        private void btnEchoOff_Click(object sender, EventArgs e)
        {
            //If echo is on then when a UART Output Report Received Message is received an Incoming UART Data - Echo UART input report will be generated
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 217; // 0xd9;
                wData[2] = 0; //echo off (factory default)

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Echo output command";
                }
            }
        }

        private void btnJsonOn_Click(object sender, EventArgs e)
        {
            //If enabled then any standard input report will be accompanied by a corresponding UART PI Base64 Input Report Transmit Message sent out on the X-keys TX
            //The message is in a special format, see the UART Port Information section of the documentation for details
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                wData[0] = 0;
                wData[1] = 215; //0xd7
                wData[2] = 1; //0=off (factory default, 1=on)

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Json message on off";
                }
            }
        }

        private void btnJsonOff_Click(object sender, EventArgs e)
        {
            //If enabled then any standard input report will be accompanied by a corresponding UART PI Base64 Input Report Transmit Message sent out on the X-keys TX
            //The message is in a special format, see the UART Port Information section of the documentation for details
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                wData[0] = 0;
                wData[1] = 0xd7; //0xd7
                wData[2] = 0; //0=off (factory default, 1=on)

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Json message on off";
                }
            }
        }

        private void btnSleepDisabled_Click(object sender, EventArgs e)
        {
            //If sleep enabled  the X-keys will turn off its LEDs and any GPIO output pins when a USB suspend condition occurs. To override this behavior set sleep disable
            //UART users may want to disable the sleep feature by setting this to 1
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 218; // 0xDA
                wData[2] = 1; //0=enabled (factory default), 1=disabled

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Disable Reawake";
                }
            }
        }

        private void btnSleepEnabled_Click(object sender, EventArgs e)
        {
            //If sleep enabled  the X-keys will turn off its LEDs and any GPIO output pins when a USB suspend condition occurs. To override this behavior set sleep disable
            //UART users may want to disable the sleep feature by setting this to 1
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 218; // 0xda
                wData[2] = 0; //0=enabled (factory default), 1=disabled

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Enable Reawake";
                }
            }
        }

        private void btnUSBCheckOff_Click(object sender, EventArgs e)
        {
            //If no USB detected and this is 0 then device will periodically check to see if USB has been connected. If this is 1 then it will not check to see if the USB was connected.
            //Set to 1 if using the USB connection for power only.
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 143; // 0x8F;
                wData[2] = 1; //0=enabled (factory default), 1=disabled

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Disable USB check";
                }
            }
        }

        private void btnUSBCheckOn_Click(object sender, EventArgs e)
        {
            //If no USB detected and this is 0 then device will periodically check to see if USB has been connected. If this is 1 then it will not check to see if the USB was connected.
            //Set to 1 if using the USB connection for power only.
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 143; // 0x8F;
                wData[2] = 0; //0=enabled (factory default), 1=disabled

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Enable USB check";
                }
            }
        }

       

       

        public static string Base64Encode(string plainText)
        {
            try
            {
                //original code
                //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText); //converts to ascii bytes
                //return System.Convert.ToBase64String(plainTextBytes);

                int baseType = 16; //data coming in hex
                string csvInString = plainText;

                string byteText = csvInString.Replace(" ", ""); // the input string, remove spaces
                if (baseType != 16) baseType = 10; // if not 16 then use base 10


                string[] stringbytes = byteText.Split(','); // comma sepertated

                byte[] dataArray = new byte[stringbytes.Length];

                for (int i = 0; i < stringbytes.Length; i++)
                {
                    dataArray[i] = Convert.ToByte(stringbytes[i], baseType); // baseType can be 16 for Hex or 10 for Dec
                }

                string bytesBase64 = Convert.ToBase64String(dataArray);

                return bytesBase64;

            }
            catch
            {
                return "";
            }
        }

        private string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData); //converts to ascii bytes
                string thesebytes = "";
                for (int i = 0; i < base64EncodedBytes.Length; i++)
                {
                    thesebytes = thesebytes + BinToHex(base64EncodedBytes[i]) + ", ";
                }
                return thesebytes;
                //return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch
            {
                return "";
            }
        }

        //for threadsafe setting of Windows Forms control
        private void DisplayText(object sender, EventArgs e)
        {
            listBox5.Items.Add(RxString);
            listBox5.SelectedIndex = listBox5.Items.Count - 1;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
            //Read raw data as it comes in ASCII
            //RxString = serialPort1.ReadExisting();
            //this.Invoke(new EventHandler(DisplayText));

            //or byte by byte
            string tmp = ""; //bytes
            string tmp2 = ""; //ascii characters
            while (serialPort1.BytesToRead != 0)
            {
                RxByte = serialPort1.ReadByte();
                tmp = tmp + BinToHex((Byte)RxByte) + " ";

                Byte[] bytelist = null;
                bytelist = new Byte[1];
                bytelist[0] = (Byte)RxByte;
                tmp2 = tmp2 + System.Text.Encoding.ASCII.GetString(bytelist);

            }
            RxString = tmp + " (" + tmp2 + ")";
            //this.Invoke(new EventHandler(DisplayText));
            thisListBox = listBox5;
            SetListBox(RxString);

            //decode the data
            
        }

        private void CboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change selected port
            if (serialPort1.IsOpen == true) serialPort1.Close();
            serialPort1.PortName = (string)CboPorts.Items[CboPorts.SelectedIndex];
            try
            {
                serialPort1.Open();
                toolStripStatusLabel1.Text = "Opened COM port successful";


            }
            catch (System.Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void btnCOMPortUSB_Click(object sender, EventArgs e)
        {
            //Serial messages received by the X-keys in this format will cause the X-keys to generate an Incoming UART Data - UART Custom Received Message input report
            //This is an input report with 00 UID 0xD8 02 Byte1 Byte2 ... 03 00 00 00 ...
            byte[] data = null;
            data = new byte[serialPort1.WriteBufferSize];
            string sendthis = txtSendCOMUSB.Text;
            int length = sendthis.Length;

            int count = length+2; //number of bytes to send
            //Must add start byte of 2 and stop byte of 3 to send message to USB
            data[0] = 2; //start byte
            //data[1 to length]=Byte1, Byte2, etc.
            for (int i = 0; i < length; i++)
            {
                data[i + 1] = (byte)sendthis[i];
            }
            data[length+1] = 3; //stop byte


            serialPort1.Write(data, 0, count);
            //serialPort1.WriteLine(sendthis);
           
        }

        private void btnCOMPortInternal_Click(object sender, EventArgs e)
        {
            //Serial messages received by the X-keys in this format will cause the X-keys to execute output reports
            //In this example we want to toggle the backlights which has a command byte of 0xB8, the trailing 0s are included only for format demonstration for longer reports
            //Encode the output report bytes to base64, in this example 0xB8, 00, 00 encodes to UAAA
            //Add start and stop bytes for 4 and 5, respectively
            //If Echo UART messages is on then an Incoming UART Data - Echo of UART Output Report Received Message input report will also be generated
            
            string encodethis = txtBase64Encode.Text;
            lblEncoded.Text = Base64Encode(encodethis);

            string sendthis = lblEncoded.Text;

            int length = sendthis.Length;
            byte[] data = null;
            data = new byte[serialPort1.WriteBufferSize];
            int count = length + 2; //number of bytes to send
            data[0] = 4; //start byte
            for (int i = 0; i < length; i++)
            {
                data[i + 1] = (byte)sendthis[i];
            }
            data[length + 1] = 5; //stop byte
            serialPort1.Write(data, 0, count);

        }

        
        

        private void btnWriteXkeysTx_Click(object sender, EventArgs e)
        {
            //Send data to the TX port, ie X-keys transmits this data to connected RS232 device
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                string sendthis = txtSendText.Text;
                
                int length = sendthis.Length;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 216; //0xd8
                wData[2] = (byte)(length); //number of bytes sent to the uart including start and stop bytes
            
                for (int i = 0; i < length; i++)
                {
                    wData[i + 3] = (byte)sendthis[i];
                }
            

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write to UART";
                }
            }
        }


        private void btnRS232Settings_Click(object sender, EventArgs e)
        {
            //Write RS232 settings to the device
            if (selecteddevice != -1) //do nothing if not enumerated
            {

                //write Unit ID given in the TxtSetUnitID box
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 142; //0x8E
                wData[2] = (byte)(cboBaudRate.SelectedIndex); //0=300, 1=1200, ... 9=230400
                wData[3] = (byte)(cboParity.SelectedIndex); //0=even, 1=odd, 2=none
                wData[4] = (byte)(cboDataBits.SelectedIndex+5); //5, 6, 7, 8
                wData[5] = (byte)(cboStopBits.SelectedIndex+2); //2=1, 3=1.5, 4=2

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Change RS232 Settings";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();

          



        }

        private void cboCOMBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change port baud rate
            if (cboCOMBaud.SelectedIndex != -1)
            {
                if (serialPort1.IsOpen == true)
                {
                    serialPort1.BaudRate = Convert.ToInt32(cboCOMBaud.GetItemText(this.cboCOMBaud.SelectedItem));
                }
            }
            
           
        }

        private void cboCOMParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change port parity
            if (cboCOMParity.SelectedIndex != -1)
            {
                if (serialPort1.IsOpen == true)
                {
                    switch (cboCOMParity.SelectedIndex)
                    {
                        case 0: //even
                            serialPort1.Parity = System.IO.Ports.Parity.Even;
                            break;
                        case 1: //odd
                            serialPort1.Parity = System.IO.Ports.Parity.Odd;
                            break;
                        case 2: //none
                            serialPort1.Parity = System.IO.Ports.Parity.None;
                            break;
                    }
                }
            }
        }

        private void cboCOMData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCOMData.SelectedIndex != -1)
            {
                if (serialPort1.IsOpen == true)
                {

                    switch (cboCOMData.SelectedIndex)
                    {
                        case 0:
                            serialPort1.DataBits = (int)5; //crash, if enter in properties won't find any com port at all
                            break;
                        case 1:
                            serialPort1.DataBits = (int)6; //crash
                            break;
                        case 2:
                            serialPort1.DataBits = (int)7;
                            break;
                        case 3:
                            serialPort1.DataBits = (int)8;
                            break;
                        
                    }
                }
            }
        }

        private void cboCOMStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCOMStop.SelectedIndex != -1)
            {
                if (serialPort1.IsOpen == true)
                {
                    switch (cboCOMStop.SelectedIndex)
                    {
                        case 0: //1
                            serialPort1.StopBits = System.IO.Ports.StopBits.One;
                            break;
                        case 1: //1.5
                            serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive; //why is this crashing ??
                            break;
                        case 2: //2
                            serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                            break;
                    }
                }
            }
        }

        private void btnReadRS232Settings_Click(object sender, EventArgs e)
        {
            //Sending this command will make the device return information about it
            if (selecteddevice != -1)
            {
                //IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later
                bool savecallbackstate = devices[selecteddevice].callNever;
                devices[selecteddevice].callNever = true;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 141; //0x8d
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Read RS232 Settings, callback off";
                }

                byte[] data = null;
                int countout = 0;
                data = new byte[80];
                data[1] = 0;
                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 141) || ret == 304)
                {
                    if (ret == 304)
                    {
                        // Didn't get any data for 100ms, increment the countout extra
                        countout += 99;
                    }
                    countout++;
                    if (countout > 1000) //increase this if have to check more than once
                        break;
                    ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                }

                cboBaudRate.SelectedIndex = data[3]; //0=300, 1=1200, 2=2400, 3=4800, 4=9600, 5=19200, 6=38400, 7=57600, 8=115200, 9=230400 (factory default)
                cboParity.SelectedIndex = data[4]; //0=even, 1=odd, 2=none (factory default)
                cboDataBits.SelectedIndex = data[5] - 5; //5, 6, 7, or 8
                cboStopBits.SelectedIndex = data[6] - 2; //2=1 bit (factory default), 3=1.5 bits, 4=2 bits
                string temp = "Divider=" + (data[8] * 256 + data[7]).ToString(); //clock divider (determines baud rate)

                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
       
        

        

        

       

        




    }
    
    
}
