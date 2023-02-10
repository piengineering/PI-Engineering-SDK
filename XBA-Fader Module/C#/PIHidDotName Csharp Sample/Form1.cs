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
        long saveabsolutetime;  //for timestamp demo

        double ratio1 = 0.0; //for use with intensity
        double ratio2 = 0.0; //for use with intensity

        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void SetColorCallback(Color color);
        delegate void SetClearCallback();
        delegate void SetTrackBarCallback(int value);
        Control c;
        ListBox thisListBox;
        TrackBar thisTrackBar;
        //end thread-safe

        byte[] lastdata = null;
        
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
                    byte val2;

                    //check the keyboard state byte 
                    val2 = (byte)(data[4] & 1);
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
                    val2 = (byte)(data[4] & 2);
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
                    val2 = (byte)(data[4] & 4);
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

                    //Buttons
                    //this routine is for separating out the individual button presses/releases from the data byte array.
                    int maxcols = 1; //number of columns of Xkeys digital button data, labeled "Keys" in P.I. Engineering SDK - General Incoming Data Input Report
                    int maxrows = 8; //constant, 8 bits per byte
                    c = this.lblButtons;
                    string buttonsdown = "Buttons: "; //for demonstration, reset this every time a new input report received
                    this.SetText(buttonsdown);
                    for (int i = 0; i < maxcols; i++) //loop through digital button bytes 
                    {
                        for (int j = 0; j < maxrows; j++) //loop through each bit in the button byte
                        {
                            int temp1 = (int)Math.Pow(2, j); //1, 2, 4, 8, 16, 32, 64, 128
                            int bitkeynum = 8 * i + j; //using key numbering in sdk; column 1 = 0,1,2... column 2 = 8,9,10... column 3 = 16,17,18... column 4 = 24,25,26... etc
                            byte temp2 = (byte)(data[i + 3] & temp1); //check using bitwise AND the current value of this bit. The + 3 is because the 1st button byte starts 3 bytes in at data[3]
                            byte temp3 = (byte)(lastdata[i + 3] & temp1); //check using bitwise AND the previous value of this bit
                            int state = 0; //0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                            if (temp2 != 0 && temp3 == 0) state = 1; //press
                            else if (temp2 != 0 && temp3 != 0) state = 2; //held down
                            else if (temp2 == 0 && temp3 != 0) state = 3; //release
                            int[] keynumbermap = new int[24]; //map the bitwise keynum to index given in SDK documentation
                            //column 1
                            keynumbermap[0] = 0; keynumbermap[1] = 1; keynumbermap[2] = 2; keynumbermap[3] = 3;
                            keynumbermap[4] = 4; keynumbermap[5] = 5; keynumbermap[6] = 6; keynumbermap[7] = 7;
                           
                            int keynum = keynumbermap[bitkeynum];
                            switch (state)
                            {
                                case 1: //key was up and now is pressed
                                    buttonsdown = buttonsdown + keynum.ToString() + " ";
                                    c = this.lblButtons;
                                    SetText(buttonsdown);
                                    break;
                                case 2: //key was pressed and still is pressed
                                    buttonsdown = buttonsdown + keynum.ToString() + " ";
                                    c = this.lblButtons;
                                    SetText(buttonsdown);
                                    break;
                                case 3: //key was pressed and now released
                                    break;
                            }
                            //or perform action based on key number
                            switch (keynum)
                            {
                                //Column 1
                                case 0: //button 0 (leftmost)
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
                                case 3: //button 3 (rightmost)
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                //the following 4 "buttons" are pressed when a fader is touched and released when the touch is removed
                                case 4: //button 4 (leftmost fader touched)
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                        //turn backcolor to Yellow
                                        c = this.lblFader1;
                                        SetColor(Color.Yellow);
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                        //turn backcolor to Control
                                        c = this.lblFader1;
                                        SetColor(SystemColors.Control);
                                    }
                                    break;
                                case 5: //button 5 (fader touched)
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                        //turn backcolor to Yellow
                                        c = this.lblFader2;
                                        SetColor(Color.Yellow);
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                        //turn backcolor to Control
                                        c = this.lblFader2;
                                        SetColor(SystemColors.Control);
                                    }
                                    break;
                                case 6: //button 6 (fader touched)
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                        //turn backcolor to Yellow
                                        c = this.lblFader3;
                                        SetColor(Color.Yellow);
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                        //turn backcolor to Control
                                        c = this.lblFader3;
                                        SetColor(SystemColors.Control);
                                    }
                                    break;
                                case 7: //button 7 (rightmost fader touched)
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                        //turn backcolor to Yellow
                                        c = this.lblFader4;
                                        SetColor(Color.Yellow);
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                        //turn backcolor to Control
                                        c = this.lblFader4;
                                        SetColor(SystemColors.Control);
                                    }
                                    break;
                            }
                        }
                    }
                    for (int i = 0; i < sourceDevice.ReadLength; i++)
                    {
                        lastdata[i] = data[i];
                    }
                    //end Buttons

                    //Faders
                    c = this.lblFader1;
                    this.SetText(data[5].ToString());
                    
                    c = this.lblFader2;
                    this.SetText(data[6].ToString());
                   
                    c = this.lblFader3;
                    this.SetText(data[7].ToString());
                    
                    c = this.lblFader4;
                    this.SetText(data[8].ToString());

                    thisTrackBar = tbFader1;
                    SetTrackBarValue(data[5]);
                    thisTrackBar = tbFader2;
                    SetTrackBarValue(data[6]);
                    thisTrackBar = tbFader3;
                    SetTrackBarValue(data[7]);
                    thisTrackBar = tbFader4;
                    SetTrackBarValue(data[8]);
                    

                    //time stamp info 4 bytes
                    long absolutetime = 16777216 * data[sourceDevice.ReadLength - 5] + 65536 * data[sourceDevice.ReadLength - 4] + 256 * data[sourceDevice.ReadLength - 3] + data[sourceDevice.ReadLength - 2];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    c = this.label19;
                    this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    c = this.label20;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;
                }
                else if (data[2] == 167) //0xA7 backlight LED state request
                {
                    thisListBox = listBox3;
                    this.ClearListBox();
                    this.SetListBox("Button=" + (data[3]));
                    this.SetListBox("Red=" + (data[4]));
                    this.SetListBox("Green=" + (data[5]));
                    this.SetListBox("Blue=" + (data[6]));
                    this.SetListBox("Dim Factor=" + (data[14])); //255=100%
                    this.SetListBox("Flash (0=flashing, 255=not) =" + (data[10])); //inverted 255=no flash, 0=flash
                    
                    this.SetListBox("Indicator Flash=" + (data[12]));
                    this.SetListBox("Flash frequency=" + (data[13]));
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
        private void SetTrackBarValue(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.thisTrackBar.InvokeRequired)
            {
                SetTrackBarCallback d = new SetTrackBarCallback(SetTrackBarValue);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.thisTrackBar.Value=value;
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
                this.Invoke(d, new object[] { });
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
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closeinterfaces on all devices that have been setup (SetupInterface called)
            for (int i = 0; i < CboDevices.Items.Count; i++)
            {
                devices[cbotodevice[i]].CloseInterface();
            }
            System.Environment.Exit(0);
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
                int cbocount = 0; //keeps track of how many valid devices were added to the CboDevice box
                for (int i = 0; i < devices.Length; i++)
                {
                    //information about device
                    //PID = devices[i].Pid);
                    //HID Usage = devices[i].HidUsage);
                    //HID Usage Page = devices[i].HidUsagePage);
                    //HID Version = devices[i].Version); //NOTE: this is NOT the firmware version which is given in the descriptor
                    int hidusagepg = devices[i].HidUsagePage;
                    int hidusage = devices[i].HidUsage;
                    if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength > 1)
                    {
                        switch (devices[i].Pid)
                        {
                            case 1480:
                                //Device 1 Keyboard, Multimedia, Input and Output endpoints, PID #1
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 0;
                                break;
                            case 1481:
                                //Device 2 Keyboard (boot), Multimedia, Input and Output endpoints, PID #2
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 1;
                                break;
                            case 1482:
                                //Device 3 Keyboard, Joystick, Input and Output endpoints, PID #3
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #3)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 2;
                                break;
                            case 1483:
                                //Device 4 Mouse, Joystick, Input and Output endpoints, PID #4
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #4)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 3;
                                break;
                            case 1484:
                                //Device 5 Keyboard (boot), Mouse (boot), Input and Output endpoints, PID #5
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #5)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 4;
                                break;
                            case 1485:
                                //Device 6 Input and Output endpoints, PID #6
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #6)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 5;
                                break;
                            case 1486:
                                //Device 7 Keyboard, Joystick, Mouse, Multimedia, Input and Output endpoints, PID #7
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #7)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 6;
                                break;
                            default:
                                CboDevices.Items.Add("Unknown Device: " + devices[i].ProductString + " (" + devices[i].Pid + ")");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 0;
                                break;
                        }
                        devices[i].SetupInterface();
                        devices[i].suppressDuplicateReports = false;
                        //at this point callback is not on
                        devices[i].callNever = true;
                        EnableAllControls();
                    }
                    else
                    {
                        if (devices[i].Pid == 1292)
                        {
                            CboDevices.Items.Add("Bootload device: " + devices[i].ProductString + " (" + devices[i].Pid + ")");
                            cbotodevice[cbocount] = i;
                            cbocount++;
                            DisableAllControls(devices[i].Pid);
                        }
                        else if (devices[i].Pid == 1487)
                        {
                            //Device 8 Keyboard only endpoint
                            CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #8), ID: " + i);
                            cbotodevice[cbocount] = i;
                            cbocount++;
                            cboPIDs.SelectedIndex = 7;
                            DisableAllControls(devices[i].Pid);
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
                LblVersion.Text = devices[selecteddevice].Version.ToString();
                toolStripStatusLabel1.Text = devices[selecteddevice].ProductString + " found";

                //Fader specific stuff
                //get the current positions of the faders
                GetFaderPositions();
                btnVoltage_Click(this, null); //get the voltage for the external power supply required to power the fader motors
            }

        }

        private void GetFaderPositions()
        {
            //Sending the command will make the device return information about it, in this case the button states and fader locations
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
                wData[1] = 177; //0xb1
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                byte[] data = null;
                int countout = 0;
                data = new byte[80];
                data[1] = 0;
                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 177) || ret == 304)
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
                tbFader1.Value = data[5];
                tbFader2.Value = data[6];
                tbFader3.Value = data[7];
                tbFader4.Value = data[8];

                lbltbFader1.Text = data[5].ToString();
                lbltbFader2.Text = data[6].ToString();
                lbltbFader3.Text = data[7].ToString();
                lbltbFader4.Text = data[8].ToString();

                devices[selecteddevice].callNever = savecallbackstate;
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

            if (thispid == 1342)
                MessageBox.Show("Device in PID #12 (KVM), no input or output reports are available.  To change to PID #3 press and hold the program switch while plugging the device into usb port.");
            else if (thispid == 1292) //include or no?
                MessageBox.Show("Device in bootloader mode.  Contact P.I. Engineering.");

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

        private void CboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1)
            {
                selecteddevice = cbotodevice[CboDevices.SelectedIndex];
                wData = new byte[devices[selecteddevice].WriteLength];//size write array 
                lastdata = new byte[devices[selecteddevice].ReadLength];
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           

        }

        private void chkLED1_CheckStateChanged(object sender, EventArgs e)
        {
            if (selecteddevice != -1)
            {
                CheckBox thischkbox = (CheckBox)sender;
                byte ledindex = Convert.ToByte(thischkbox.Tag.ToString());

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = ledindex; //0=LED1, 1=LED2, 2=LED3, 3=LED4
                wData[3] = (byte)thischkbox.CheckState; //0=off, 1=on, 2=flash

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set LED";
                }
            }
        }

        private void BtnUnitID_Click(object sender, EventArgs e)
        {
            //Write Unit ID to the device
            if (selecteddevice != -1) //do nothing if not enumerated
            {

                //write Unit ID given in the TxtSetUnitID box
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 189; //0xBD
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

        //RGB Backlight Features
        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            double red = 0.0;
            double green = 0.0;
            double blue = 0.0;

            switch (cboColor.SelectedIndex)
            {
                case 0: //off
                    txtR.Text = "0";
                    txtG.Text = "0";
                    txtB.Text = "0";
                    break;
                case 1: //red
                    txtR.Text = "255";
                    txtG.Text = "0";
                    txtB.Text = "0";
                    break;
                case 2: //orange
                    txtR.Text = "255";
                    txtG.Text = "20";
                    txtB.Text = "0";
                    break;
                case 3: //yellow
                    txtR.Text = "255";
                    txtG.Text = "129";
                    txtB.Text = "0";
                    break;
                case 4: //green
                    txtR.Text = "0";
                    txtG.Text = "255";
                    txtB.Text = "0";
                    break;
                case 5: //turquoise
                    txtR.Text = "0";
                    txtG.Text = "255";
                    txtB.Text = "129";
                    break;
                case 6: //blue
                    txtR.Text = "0";
                    txtG.Text = "0";
                    txtB.Text = "255";
                    break;
                case 7: //pink
                    txtR.Text = "255";
                    txtG.Text = "8";
                    txtB.Text = "40";
                    break;
                case 8: //purple
                    txtR.Text = "150";
                    txtG.Text = "0";
                    txtB.Text = "255";
                    break;
                case 9: //white
                    txtR.Text = "255";
                    txtG.Text = "255";
                    txtB.Text = "255";
                    break;
            }
        }

        private void btnSetRGB_Click(object sender, EventArgs e)
        {
            //Set individual led 
            //RGB LED Index (in decimal)
            //Columns-->
            //  0   1   2  3 

            if (selecteddevice != -1)
            {
                byte ledindex = Convert.ToByte(cboRGBIndex.Text);
               
                int checkstate = (int)chkRGBFlash.CheckState;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                int result = 0;
                
                wData[1] = 165; //0xA5
                wData[2] = ledindex;
                wData[3] = 0; //0=bank 1 (top), 1=bank 2 (bottom)
                wData[4] = Convert.ToByte(txtR.Text);
                wData[5] = Convert.ToByte(txtG.Text);
                wData[6] = Convert.ToByte(txtB.Text);
                wData[7] = (byte)chkRGBFlash.CheckState; //0=no flash, 1=flash

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - RGB LED";
                }
            }
        }

        private void btnSetAllBank1_Click(object sender, EventArgs e)
        {
            //LED Index (in decimal)
            //Columns-->
            //  0   1   2  3 
            if (selecteddevice != -1)
            {
                int result = 0;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[1] = 166; //0xA6
                wData[2] = 0; 
                wData[3] = Convert.ToByte(txtR.Text);
                wData[4] = Convert.ToByte(txtG.Text);
                wData[5] = Convert.ToByte(txtB.Text);

                result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }


                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set All Bank 1 RGB LED";
                }
            }
        }

        //Legacy Backlight Features
        private void ChkBLOnOff_CheckStateChanged(object sender, EventArgs e)
        {
            //This command is a legacy command meant to mimick the Set Individual Backlight command on non-RGB LED X-keys devices.
            //Using the legacy backlight commands will force the upper bank of LEDs to be blue and the lower to be red

            //Use the Set Flash Freq to control frequency of blink
            //RGB LED Index (in decimal)
            //Columns-->
            //  0 1 2 3 
        
           
            if (selecteddevice != -1)
            {
                //first get selected index
                string sindex = CboBL.Text;
                int bank = 0; //this product has only 1 bank of LEDs
                int ledindex = CboBL.SelectedIndex;
                if (bank == 1) ledindex = ledindex + 24;

                //now get state
                int state = (int)ChkBLOnOff.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 181; //0xB5
                wData[2] = (byte)(ledindex); //Index
                wData[3] = (byte)state; //0=off, 1=on, 2=flash

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Legacy Backlight";
                }
            }
        }

        private void ChkBank1OnOff_CheckedChanged(object sender, EventArgs e)
        {
            //Legacy Backlight (blue/red style)
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                byte sl = 0;

                if (ChkBank1OnOff.Checked == true) sl = 255;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 182; //0xb6
                wData[2] = 0;  //0 for Blue
                wData[3] = (byte)sl; //0 for all off, 255 for all on

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - All Green BL on/off";
                }
            }
        }

        private void BtnLegacyIntensity_Click(object sender, EventArgs e)
        {
            //This command is a legacy command meant to mimick the Set Intensity command on non-RGB LED X-keys devices.
            //Same as "Dim Factor" 
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 187;
                wData[2] = (byte)(Convert.ToInt16(TxtIntensity.Text)); ; //0-255 for brightness of bank 1 bl leds
               
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Backlighting Intensity";
                }
                txtBank1.Text = TxtIntensity.Text;
            }
        }

        //Global Backlight Features
        private void BtnSetFlash_Click(object sender, EventArgs e)
        {
            //Sets the frequency of flashing for both the LEDs and backlighting
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 180; // 0xb4
                wData[2] = (byte)(Convert.ToInt16(TxtFlashFreq.Text));

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set Flash Frequency";
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
                wData[1] = 184;

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

        private void BtnSaveBL_Click(object sender, EventArgs e)
        {
            //Write current state of backlighting to EEPROM.  
            //NOTE: Is it not recommended to do this frequently as there are a finite number of writes to the EEPROM allowed
            if (selecteddevice != -1)
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 199;  //0xc7
                wData[2] = 1; //anything other than 0 will save bl state to eeprom, default is 0
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Save Backlight to EEPROM";
                }
            }
        }

        private void btnGetBLState_Click(object sender, EventArgs e)
        {
            //Request the state of the desired RGB LED
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                //Button Index (in decimal)
                //Columns-->
                //  0   1   2  3 
                
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 167; //0xA7;
                wData[2] = (byte)(cboKeyIndexGet.SelectedIndex);
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Get BL state";
                }
                //see HandlePIEHidData for handling of the returned data
            }
        }

        private void BtnGetDataNow_Click(object sender, EventArgs e)
        {
            //After sending this command a general incoming data report will be given with
            //the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
            //and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
            //or unit id of the device before it sends any data.
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 177; //0xb1

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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

        private void BtnCustom_Click(object sender, EventArgs e)
        {
            //This report available only on v30 firmware and above
            //After sending this command a custom incoming data report will be given with
            //the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
            //and the following bytes whatever the user wishes.  In this example we are sending 3 bytes; 1, 2, 3

            if (selecteddevice != -1) //do nothing if not enumerated
            {
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


                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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
            //This report available only on v30 firmware and above
            //Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
            //newly written version!
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 195; //c3
                wData[2] = (byte)(Convert.ToInt16(TxtVersion.Text));
                wData[3] = (byte)((Convert.ToInt16(TxtVersion.Text)) >> 8);
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Write Version";
                }
                //reboot device either manually with a hotplug or using the command below, to use this uncomment out the WriteData line,
                //must re-enumerate after sending
                devices[selecteddevice].callNever = true;
                wData[0] = 0;
                wData[1] = 238; //0xee, reboot device without unplugging
                wData[2] = 0;
                wData[3] = 0;
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Reboot";
                }
            }
        }

        private void BtnKBreflect_Click(object sender, EventArgs e)
        {
            //Sends native keyboard messages
            //Write some keys to the textbox, should be Abcd
            //send some hid codes to the textbox, these will be coming in on the native keyboard endpoint
            if (selecteddevice != -1) //do nothing if not enumerated
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

                //use this method to ensure done writing data before executing the next write command
                result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                

                wData[2] = 0;       //modifiers
                wData[3] = 0;       //always 0
                wData[4] = 0;    //hid code = a up
                wData[5] = 0x05;    //hid code = b down
                wData[6] = 0x06;    //hid code = c down
                wData[7] = 0x07;    //hid code = d down
                wData[8] = 0;
                wData[9] = 0;

                result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                

                wData[2] = 0;
                wData[4] = 0;
                wData[5] = 0;  //b up
                wData[6] = 0;  //c up
                wData[7] = 0;  //d up
                wData[8] = 0;
                wData[9] = 0;

                result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                
            }
        }

        private void BtnJoyreflect_Click(object sender, EventArgs e)
        {
            //Sends native joystick messages
            //Open up the game controller control panel to test these features, after clicking this button
            //go and make active the control panel properties and change will be seen
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                int result;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 202;    //0xca
                wData[2] = (byte)Math.Abs((Convert.ToByte(textBox2.Text) ^ 127) - 255);  //X, in raw form 0 to 127 from center to right, 255 to 128 from center to left but I like to use 0-255 where 0 is max left, 255 is max right
                wData[3] = (byte)(Convert.ToByte(textBox3.Text) ^ 127); //Y, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[4] = (byte)(Convert.ToByte(textBox12.Text) ^ 127); //Z rotation, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[5] = (byte)(Convert.ToByte(textBox4.Text) ^ 127); //Z, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                wData[6] = (byte)(Convert.ToByte(textBox13.Text) ^ 127); //Slider rotation, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255

                wData[7] = Convert.ToByte(textBox5.Text); //buttons 1-8, where bit 1 is button 1, bit 1 is button 2, etc.
                wData[8] = Convert.ToByte(textBox7.Text); //buttons 9-16
                wData[9] = Convert.ToByte(textBox8.Text); //buttons 17-24
                wData[10] = Convert.ToByte(textBox9.Text); //buttons 25-32

                wData[11] = 0;

                wData[12] = Convert.ToByte(textBox6.Text); //hat, where 0 is straight up, 1 is 45deg cw, etc and 8 is no hat
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

        private void BtnMousereflect_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                wData[0] = 0;
                wData[1] = 203;    //0xcb
                wData[2] = Convert.ToByte(textBox14.Text); //Buttons; 1=Left, 2=Right, 4=Center, 8=XButton1, 16=XButton2
                wData[3] = Convert.ToByte(textBox16.Text); //Mouse X motion. 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129).
                wData[4] = Convert.ToByte(textBox15.Text); //Mouse Y motion. 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129).
                wData[5] = Convert.ToByte(textBox11.Text);//Wheel Y. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
                devices[selecteddevice].WriteData(wData);

                //now send all 0s
                wData[0] = 0;
                wData[1] = 203;    //0xcb
                wData[2] = 0; //buttons
                wData[3] = 0; //X
                wData[4] = 0; //Y
                wData[5] = 0; //wheel Y
                devices[selecteddevice].WriteData(wData);
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

            if (selecteddevice != -1) //do nothing if not enumerated
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
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }


                wData[0] = 0;
                wData[1] = 0xe1;
                wData[2] = 0; //terminate
                wData[3] = 0; //terminate
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }


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
            //Multimedia available on v30 firmware or above.
            if (selecteddevice != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 0xe1;
                wData[2] = HexToBin("94"); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                wData[3] = HexToBin("01"); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                wData[0] = 0;
                wData[1] = 225;  //0xe1;
                wData[2] = 0; //terminate
                wData[3] = 0; //terminate
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

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
            //Multimedia available on v30 firmware or above.
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 226; //0xe2;
                wData[2] = 2; //1=power down, 2=sleep, 4=wake up

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                //NOTE this needs to be on the release of the key!!

                System.Threading.Thread.Sleep(1000); //this to simulate press/release

                wData[0] = 0;
                wData[1] = 226; //0xe2;
                wData[2] = 0;

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

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
                listBox2.Items.Add("PID " + (data[3] + 1).ToString());
                listBox2.Items.Add("Keymapstart=" + data[4].ToString());
                listBox2.Items.Add("Layer2offset=" + data[5].ToString());
                listBox2.Items.Add("SizeOfEEProm=" + (data[7] * 256 + data[6]).ToString());
                listBox2.Items.Add("MaxCol=" + data[8].ToString());
                listBox2.Items.Add("MaxRow=" + data[9].ToString());
                String ledon = "";
                if ((byte)(data[10] & 1) != 0) ledon = "NumLock, ";
                if ((byte)(data[10] & 2) != 0) ledon = ledon + "CapsLock, ";
                if ((byte)(data[10] & 4) != 0) ledon = ledon + "ScrLock, ";
                if ((byte)(data[10] & 16) != 0) ledon = ledon + "LED1, ";
                if ((byte)(data[10] & 32) != 0) ledon = ledon + "LED2, ";
                if ((byte)(data[10] & 64) != 0) ledon = ledon + "LED3, ";
                if ((byte)(data[10] & 128) != 0) ledon = ledon + "LED4, ";
                if (ledon == "") ledon = "None";
                listBox2.Items.Add("LEDs=" + ledon);
                listBox2.Items.Add("Firmware Version=" + data[11].ToString()); //firmware version

                string temp = "PID=" + (data[13] * 256 + data[12]).ToString();
                listBox2.Items.Add(temp);
                
                listBox2.Items.Add("Fader 1 Touch Stop Enabled =" + data[19].ToString());
                listBox2.Items.Add("Fader 2 Touch Stop Enabled =" + data[20].ToString());
                listBox2.Items.Add("Fader 3 Touch Stop Enabled =" + data[21].ToString());
                listBox2.Items.Add("Fader 4 Touch Stop Enabled =" + data[22].ToString());
                
                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

        //Change PIDs
        private void BtnPID3_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1 && (cboPIDs.SelectedIndex != -1)) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 204; //0xcc
                wData[2] = (byte)cboPIDs.SelectedIndex;  

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Change endpoints";
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

        //KVM Settings
        private void BtnNoChange_Click(object sender, EventArgs e)
        {
            //Do not change PID on reboot
            if (selecteddevice != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 196; //0xc4
                wData[2] = 0; 

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 196; //0xc4
                wData[2] = 7;

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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

        private void btnBank2Off_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1)
            {
                int result = 0;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                for (int i = 14; i < 28; i++)
                {
                    wData[1] = 181; //0xb5
                    wData[2] = (byte)i;
                    wData[3] = 0;
                    wData[4] = 0;
                    wData[5] = 0;
                    

                    result = 404;

                    while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - RGB LED";
                }
            }
        }

        private void BtnTimeStamp_Click(object sender, EventArgs e)
        {
            //Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 210;
                wData[2] = 0;

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Time Stamp";
                }
            }
        }

        private void BtnTimeStampOn_Click(object sender, EventArgs e)
        {
            //Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 210;
                wData[2] = 1;  //default ON

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Time Stamp";
                }
            }
        }

        private void BtnSetDongle_Click(object sender, EventArgs e)
        {
            //Use the Dongle feature to set a 4 byte code into the device
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                //This routine is done once per unit by the developer prior to sale.
                //Pick 4 numbers between 1 and 254.
                int K0 = 7;    //pick any number between 1 and 254, 0 and 255 not allowed
                int K1 = 58;   //pick any number between 1 and 254, 0 and 255 not allowed
                int K2 = 33;   //pick any number between 1 and 254, 0 and 255 not allowed
                int K3 = 243;  //pick any number between 1 and 254, 0 and 255 not allowed
                //Save these numbers, they are needed to check the key!

                //Write these to the device
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 192;
                wData[2] = (byte)K0;
                wData[3] = (byte)K1;
                wData[4] = (byte)K2;
                wData[5] = (byte)K3;

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set Dongle Key";
                }
            }
        }

        private void BtnCheckDongle_Click(object sender, EventArgs e)
        {
            //Reads the secret key set in Set Key
            //This is done within the developer's application to check for the correct
            //hardware.  The K0-K3 values must be the same as those entered in Set Key.
            if (selecteddevice != -1)
            {
                //check hardware

                //IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
                devices[selecteddevice].callNever = true;

                //these will be returned from the hash
                int R0 = 0;
                int R1 = 0;
                int R2 = 0;
                int R3 = 0;

                //this is the key from set key
                int K0 = 7;
                int K1 = 58;
                int K2 = 33;
                int K3 = 243;

                //randomn numbers, use different numbers every check, we use the time to generate some random numbers below
                Random rnd = new Random();
                int N0 = rnd.Next(1, 254); //pick any number between 1 and 254, 0 and 255 not allowed
                int N1 = rnd.Next(1, 254); //pick any number between 1 and 254, 0 and 255 not allowed
                int N2 = rnd.Next(1, 254); //pick any number between 1 and 254, 0 and 255 not allowed
                int N3 = rnd.Next(1, 254); //pick any number between 1 and 254, 0 and 255 not allowed
                N0 = 1;
                N1 = 2;
                N2 = 3;
                N3 = 4;

                PIEDevice.DongleCheck2(K0, K1, K2, K3, N0, N1, N2, N3, out R0, out R1, out R2, out R3);

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 193;  //c1  
                wData[2] = (byte)N0;
                wData[3] = (byte)N1;
                wData[4] = (byte)N2;
                wData[5] = (byte)N3;

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Check Dongle Key";
                }


                //after this write the next read with the 3rd byte=193 will give 4 values which are used below for comparison
                byte[] data = new byte[100];
                int countout = 0;
                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 193) || ret == 304)
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

                if (ret == 0 && data[2] == 193)
                {
                    bool fail = false;
                    if (R0 != data[3]) fail = true;
                    if (R1 != data[4]) fail = true;
                    if (R2 != data[5]) fail = true;
                    if (R3 != data[6]) fail = true;

                    if (fail == false)
                    {
                        LblPassFail.Text = "Pass-Correct Hardware Found";
                    }
                    else
                    {
                        LblPassFail.Text = "Fail-Correct Hardward Not Found";
                    }
                }
            }
        }

        private void btnRGBIntensity_Click(object sender, EventArgs e)
        {
            //RGB global (per bank) dimming control - this command is meant to be used once the banks of LEDs have been configured to the desired colors. 255 is the brightest or 100% on and 0 is the dimmest.
            //Use caution if set a dim factor to 0, LEDs will be off and will not be able to be turned on without changing the dim factor to a non-0 value.
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 164; //0xA4
                wData[2] = (byte)(Convert.ToInt16(txtBank1.Text)); //1-255 for brightness of bank 1 bl leds
                
                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Dim Factors";
                }
            }
        }
       
        private void Form1_Shown(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = 1;
            cboRGBIndex.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.Text = "";
            CboBL.SelectedIndex = 0;
            cboKeyIndexGet.SelectedIndex = 0;
        }

        private void tbFader1_Scroll(object sender, EventArgs e)
        {
            //set position of a fader
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                TrackBar thistrackbarr = (TrackBar)sender;
                byte faderindex = Convert.ToByte(thistrackbarr.Tag.ToString());
                int position=thistrackbarr.Value;
                
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 149; //0x95
                wData[2] = (byte)(faderindex); //0=fader 1, 1=fader 2, 2=fader 3, 3=fader 4
                wData[3] = (byte)(position); //0 to 255

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set fader position";
                   
                }
            }
        }

        private void tbFader1_ValueChanged(object sender, EventArgs e)
        {
            //update labels
            TrackBar thistrackbarr = (TrackBar)sender;
            byte index = Convert.ToByte(thistrackbarr.Tag.ToString());
            switch (index)
            {
                case 0:
                    lbltbFader1.Text = thistrackbarr.Value.ToString();
                    break;
                case 1:
                    lbltbFader2.Text = thistrackbarr.Value.ToString();
                    break;
                case 2:
                    lbltbFader3.Text = thistrackbarr.Value.ToString();
                    break;
                case 3:
                    lbltbFader4.Text = thistrackbarr.Value.ToString();
                    break;
            }
           
        }

        private void btnSetAllFaders_Click(object sender, EventArgs e)
        {
            //Sets the position of all 4 faders at once
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            int pos = Convert.ToInt16(textBox10.Text);
            wData[0] = 0;
            wData[1] = 168; //0xa8
            wData[2] = (byte)pos; //desired position for fader 1
            wData[3] = (byte)pos; //desired position for fader 2
            wData[4] = (byte)pos; //desired position for fader 3
            wData[5] = (byte)pos; //desired position for fader 4
            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;
            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Set position all faders";
            }
        }

        private void btnEnableTouchStop_Click(object sender, EventArgs e)
        {
            //Enables the touch stop feature, if enabled then faders, when being driven to a position, will stop when user touches fader, user will not feel resistance
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 161; // 0xA1
                wData[2] = 255; //0=fader 1, 1=fader 2, 2=fader 3, 3=fader 4 OR 255 to set all
                wData[3] = 1; //0=disabled, 1=enabled (factory default)

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Enable fader touch stop";
                }
            }
        }

        private void btnDisableTouchStop_Click(object sender, EventArgs e)
        {
            //Disables the touch stop feature, if disabled then faders, when being driven to a position, will not stop  when user touches fader, user will feel resistance
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 161; //0xA1
                wData[2] = 255; //0=fader 1, 1=fader 2, 2=fader 3, 3=fader 4 OR 255 to set all
                wData[3] = 0; //0=disabled, 1=enabled (factory default)

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Disable fader touch stop";
                }
            }
        }

        private void btnSetCapSens_Click(object sender, EventArgs e)
        {
            //Set the touch sensitivity of the fader, factory default is 511 (0x01FF)
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 152; //0x98
                wData[2] = 255; //0=fader 1, 1=fader 2, 2=fader 3, 3=fader 4 OR 255 to set all
                wData[3] = 1; //MSB of sensitivity
                wData[4] = 255; //LSB of sensitivity

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set fader touch sensitivity";
                }
            }
        }

        private void btnGetCapSens_Click(object sender, EventArgs e)
        {
            //Touch sensitivities for all 4 faders returned
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
                wData[1] = 153; //0x99
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Get touch sensitivity";
                }

                byte[] data = null;
                int countout = 0;
                data = new byte[80];
                data[1] = 0;
                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 153) || ret == 304)
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
                listBox4.Items.Clear();
                listBox4.Items.Add("Fader 1 =" + (data[3] * 256 + data[4]).ToString());
                listBox4.Items.Add("Fader 2 =" + (data[5] * 256 + data[6]).ToString());
                listBox4.Items.Add("Fader 3 =" + (data[7] * 256 + data[8]).ToString());
                listBox4.Items.Add("Fader 4 =" + (data[9] * 256 + data[10]).ToString());

                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

        private void btnVoltage_Click(object sender, EventArgs e)
        {
            //Voltage for the external power required for fader motors returned, 8V-12V required for fader motors
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
                wData[1] = 173; //0xad
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Get voltage";
                }

                byte[] data = null;
                int countout = 0;
                data = new byte[80];
                data[1] = 0;
                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 173) || ret == 304)
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

                lblVoltage.Text = data[6].ToString() + "." + data[7].ToString()+"V";
                float voltage=data[6]+ (data[7]/10.0f);
                if (voltage < 8.0)
                {
                    lblVoltage.BackColor = Color.Red;
                }
                else
                {
                    lblVoltage.BackColor = SystemColors.Control;
                }
                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

       

        

        

        

        

        

        

      

        


        

       
        

        

        

       

        




    }
    
    
}
