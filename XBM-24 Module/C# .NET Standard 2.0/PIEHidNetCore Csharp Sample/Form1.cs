﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIEHidNetCore;

namespace PIEHidNetCore_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        PIEDevice[] devices;

        int[] cbotodevice = null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        int selecteddevice = -1; //set to the index of CboDevice
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
        public Form1()
        {
            InitializeComponent();
        }
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
                if (data[2] < 4)
                {
                    byte val2 = (byte)(data[2] & 1);

                    //check the keyboard state byte 
                    val2 = (byte)(data[7] & 1);
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

                    //gpio inputs
                    val2 = (byte)(data[7] & 16);
                    if (val2 == 0)
                    {
                        c = this.lblPin1;
                        this.SetText("GPIO pin 1: off");
                    }
                    else
                    {
                        c = this.lblPin1;
                        this.SetText("GPIO pin 1: on");
                    }
                    val2 = (byte)(data[7] & 32);
                    if (val2 == 0)
                    {
                        c = this.lblPin2;
                        this.SetText("GPIO pin 2: off");
                    }
                    else
                    {
                        c = this.lblPin2;
                        this.SetText("GPIO pin 2: on");
                    }
                    val2 = (byte)(data[7] & 64);
                    if (val2 == 0)
                    {
                        c = this.lblPin3;
                        this.SetText("GPIO pin 3: off");
                    }
                    else
                    {
                        c = this.lblPin3;
                        this.SetText("GPIO pin 3: on");
                    }
                    val2 = (byte)(data[7] & 128);
                    if (val2 == 0)
                    {
                        c = this.lblPin4;
                        this.SetText("GPIO pin 4: off");
                    }
                    else
                    {
                        c = this.lblPin4;
                        this.SetText("GPIO pin 4: on");
                    }

                    //read the unit ID
                    c = this.LblUnitID;
                    this.SetText(data[1].ToString());

                    //buttons
                    //this routine is for separating out the individual button presses/releases from the data byte array.
                    int maxcols = 4; //number of columns of Xkeys digital button data, labeled "Keys" in P.I. Engineering SDK - General Incoming Data Input Report
                    int maxrows = 6; //number of rows of Xkeys digital button data
                    c = this.LblButtons;
                    string buttonsdown = "Buttons: "; //for demonstration, reset this every time a new input report received
                    this.SetText(buttonsdown);

                    for (int i = 0; i < maxcols; i++) //loop through digital button bytes 
                    {
                        for (int j = 0; j < maxrows; j++) //loop through each bit in the button byte
                        {
                            int temp1 = (int)Math.Pow(2, j); //1, 2, 4, 8, 16, 32, 64, 128
                            int keynum = maxrows * i + j; //using key numbering in sdk; column 1 = 0,1,2... column 2 = 6,7,8... column 3 = 12,13,14... column 4 = 18,19,20... etc
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
                                case 4: //button 4
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 5: //button 5
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;

                                //Next column of buttons
                                case 6: //button 6
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 7: //button 7
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 8: //button 8
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 9: //button 9
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 10: //button 10
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 11: //button 11
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;

                                //Next column of buttons
                                case 12: //button 12
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 13: //button 13
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 14: //button 14
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 15: //button 15
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 16: //button 16
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 17: //button 17
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;

                                //Next column of buttons
                                case 18: //button 18
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 19: //button 19
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 20: //button 20
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 21: //button 21
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 22: //button 22
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 23: //button 23
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;

                            }
                        }
                    }

                    for (int i = 0; i < sourceDevice.ReadLength; i++)
                    {
                        lastdata[i] = data[i];
                    }
                    //end buttons

                    //time stamp info 4 bytes
                    long absolutetime = 16777216 * data[sourceDevice.ReadLength - 5] + 65536 * data[sourceDevice.ReadLength - 4] + 256 * data[sourceDevice.ReadLength - 3] + data[sourceDevice.ReadLength - 2];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    c = this.label19;
                    this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    c = this.label20;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;
                } //end General Incoming Data
                else if (data[2] == 167) //0xA7 backlight LED state request
                {
                    thisListBox = listBox3;
                    this.ClearListBox();
                    this.SetListBox("Button=" + (data[3]));
                    //bank 1
                    this.SetListBox("Bank 1 Red=" + (data[4]));
                    this.SetListBox("Bank 1 Green=" + (data[5]));
                    this.SetListBox("Bank 1 Blue=" + (data[6]));
                    this.SetListBox("Bank 1 Dim Factor=" + (data[14])); //255=100%
                    if (data[10] == 1) //0=no flash, 1=flashing
                        this.SetListBox("Flash Bank 1 = flashing");
                    else this.SetListBox("Flash Bank 1 = not flashing");
                    //bank 2
                    this.SetListBox("Bank 2 Red=" + (data[7]));
                    this.SetListBox("Bank 2 Green=" + (data[8]));
                    this.SetListBox("Bank 2 Blue=" + (data[9]));
                    this.SetListBox("Bank 2 Dim Factor=" + (data[15])); //255=100%
                    if (data[11] == 1)
                        this.SetListBox("Flash Bank 2 = flashing");
                    else this.SetListBox("Flash Bank 2 = not flashing");

                    this.SetListBox("Indicator Flash=" + (data[12]));
                    this.SetListBox("Flash frequency=" + (data[13]));
                }


            }
        }

        public void HandlePIEHidError(PIEDevice sourceDevice, Int32 error)
        {
            this.SetToolStrip("Error: " + error.ToString());
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
        private void BtnEnumerate_Click(object sender, EventArgs e)
        {
            CboDevices.Items.Clear();
            cbotodevice = new int[128]; //128=max # of devices
            //enumerate and setupinterfaces for all devices
            devices = PIEDevice.EnumeratePIE();
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
                    if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength > 1)
                    {
                        switch (devices[i].Pid)
                        {
                            case 1365:
                                //Device 1 Keyboard, Multimedia, Input and Output endpoints, PID #1
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 0;
                                break;
                            case 1366:
                                //Device 2 Keyboard (boot), Multimedia, Input and Output endpoints, PID #2
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #2)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 1;
                                break;
                            case 1367:
                                //Device 3 Keyboard, Joystick, Input and Output endpoints, PID #3
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #3)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 2;
                                break;
                            case 1368:
                                //Device 4 Mouse, Joystick, Input and Output endpoints, PID #4
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #4)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 3;
                                break;
                            case 1369:
                                //Device 5 Keyboard (boot), Mouse (boot), Input and Output endpoints, PID #5
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #5)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 4;
                                break;
                            case 1370:
                                //Device 6 Input and Output endpoints, PID #6
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #6)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 5;
                                break;
                            case 1371:
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
                    }
                    else
                    {
                        if (devices[i].Pid == 1292)
                        {
                            CboDevices.Items.Add("Bootload device: " + devices[i].ProductString + " (" + devices[i].Pid + ")");
                            cbotodevice[cbocount] = i;
                            cbocount++;
                        }
                        else if (devices[i].Pid == 1372)
                        {
                            //Device 11 Keyboard only endpoint
                            CboDevices.Items.Add(devices[i].ProductString + " KVM (" + devices[i].Pid + "=PID #8), ID: " + i);
                            cbotodevice[cbocount] = i;
                            cbocount++;
                            cboPIDs.SelectedIndex = 7;
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
                lblSiliconGeneratedID.Text = devices[selecteddevice].SerialNumberString;
                toolStripStatusLabel1.Text = devices[selecteddevice].ProductString + " found";
                if (devices[selecteddevice].Pid == 1292 || devices[selecteddevice].Pid == 1372)
                {
                    selecteddevice = -1; //if bootload or KVM mode can't do anything with it
                }
            }
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
                 //   devices[cbotodevice[i]].callNever = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboColor.SelectedIndex = 1;
            CboRGBIndex.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "";
            CboBL.SelectedIndex = 0;
            CboBankLegacy.SelectedIndex = 0;
            cboKeyIndexGet.SelectedIndex = 0;
            cboBank.SelectedIndex = 0;
        }

        private void CboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecteddevice = cbotodevice[CboDevices.SelectedIndex];
            wData = new byte[devices[selecteddevice].WriteLength];//size write array 
            if (devices[selecteddevice].Pid == 1292 || devices[selecteddevice].Pid == 1372)
            {
                selecteddevice = -1; //if bootload or KVM mode can't do anything with it
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
                wData[1] = 189; //0xbd
                wData[2] = (byte)(Convert.ToInt16(TxtSetUnitID.Text));

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

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
                wData[1] = 182; //0xb6;
                wData[2] = 0;  //0 for Green, 1 for Red
                wData[3] = (byte)sl; //OR turn individual rows on or off using bits.  1st bit=row 1, 2nd bit=row 2, 3rd bit =row 3, etc

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-All Bank1 BL on/off";
                }
            }
        }

        private void ChkBank2OnOff_CheckedChanged(object sender, EventArgs e)
        {
            //Legacy Backlight (blue/red style)
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                byte sl = 0;

                if (ChkBank2OnOff.Checked == true) sl = 255;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 182; //0xb6;
                wData[2] = 1;  //0 for Blue, 1 for Red
                wData[3] = (byte)sl; //OR turn individual rows on or off using bits.  1st bit=row 1, 2nd bit=row 2, 3rd bit =row 3, etc

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-All Red BL on/off";
                }
            }
        }

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
                wData[1] = 180; // 0xb4;
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
                wData[1] = 184; //0xb8;

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-Toggle BL";
                }
            }
        }

        private void ChkScrollLock_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnBL_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 187; //0xbb
                wData[2] = (byte)(Convert.ToInt16(TxtIntensity.Text)); ; //0-255 for brightness of bank 1 bl leds
                wData[3] = (byte)(Convert.ToInt16(TxtIntensity2.Text)); ; //0-255 for brightness of bank 2 bl leds

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-Backlighting Intensity";
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
                wData[1] = 199; //0xc7;
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
                wData[1] = 210; //0xd2;
                wData[2] = 0;

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-Time Stamp";
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
                wData[1] = 210; //0xd2;
                wData[2] = 1;  //default ON

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-Time Stamp";
                }
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
                wData[1] = 177; //0xb1;

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
                wData[1] = 224; //0xe0;
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
                wData[1] = 201; //0xc9;

                wData[2] = 2;       //modifiers
                wData[3] = 0;       //always 0
                wData[4] = 0x04;    //hid code = a down
                wData[5] = 0;
                wData[6] = 0;
                wData[7] = 0;
                wData[8] = 0;
                wData[9] = 0;

                //use this method to ensure done writing data before executing the next write command
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }


                wData[2] = 0;       //modifiers
                wData[3] = 0;       //always 0
                wData[4] = 0;    //hid code = a up
                wData[5] = 0x05;    //hid code = b down
                wData[6] = 0x06;    //hid code = c down
                wData[7] = 0x07;    //hid code = d down
                wData[8] = 0;
                wData[9] = 0;

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                wData[2] = 0;
                wData[4] = 0;
                wData[5] = 0;  //b up
                wData[6] = 0;  //c up
                wData[7] = 0;  //d up
                wData[8] = 0;
                wData[9] = 0;

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            }
        }

        private void BtnJoyreflect_Click(object sender, EventArgs e)
        {
            //Sends native joystick messages
            //Open up the game controller control panel to test these features, after clicking this button
            //go and make active the control panel properties and change will be seen
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 202;  //0xca;
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

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

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
                wData[1] = 203; //0xcb;
                wData[2] = Convert.ToByte(TxtMouseButton.Text); //Buttons; 1=Left, 2=Right, 4=Center, 8=XButton1, 16=XButton2
                wData[3] = Convert.ToByte(TxtMouseX.Text); //Mouse X motion. 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129).
                wData[4] = Convert.ToByte(TxtMouseY.Text); //Mouse Y motion. 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129).
                wData[5] = 0;//Wheel X. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
                wData[6] = Convert.ToByte(TxtMouseWheel.Text);//Wheel Y. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }


                //now send all 0s
                wData[0] = 0;
                wData[1] = 203; //0xcb;
                wData[2] = 0; //buttons
                wData[3] = 0; //X
                wData[4] = 0; //Y
                wData[5] = 0; //wheel X
                wData[6] = 0; //wheel Y

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

            }
        }

        private void BtnMultiMedia_Click(object sender, EventArgs e)
        {
            //Multimedia available on v30 firmware or above.
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
                wData[1] = 225; // 0xe1;
                wData[2] = HexToBin(TxtMMLow.Text); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                wData[3] = HexToBin(TxtMMHigh.Text); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                wData[0] = 0;
                wData[1] = 225; // 0xe1;
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
                wData[1] = 225; // 0xe1;
                wData[2] = HexToBin("94"); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                wData[3] = HexToBin("01"); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }


                wData[0] = 0;
                wData[1] = 225; // 0xe1;
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
                wData[1] = 226; // 0xe2;
                wData[2] = 2; //1=power down, 2=sleep, 4=wake up

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                //NOTE this needs to be on the release of the key!!

                System.Threading.Thread.Sleep(1000); //this to simulate press/release

                wData[0] = 0;
                wData[1] = 226; // 0xe2;
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
                wData[1] = 214;
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Descriptor";
                }

                byte[] data = null;
                int countout = 0;
                data = new byte[80];

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
                String pinson = "";
                if ((byte)(data[10] & 1) != 0) pinson = "NumLock, ";
                if ((byte)(data[10] & 2) != 0) pinson = pinson + "CapsLock, ";
                if ((byte)(data[10] & 4) != 0) pinson = pinson + "ScrLock, ";
                if ((byte)(data[10] & 16) != 0) pinson = pinson + "Pin 1, ";
                if ((byte)(data[10] & 32) != 0) pinson = pinson + "Pin 2, ";
                if ((byte)(data[10] & 64) != 0) pinson = pinson + "Pin 3, ";
                if ((byte)(data[10] & 128) != 0) pinson = pinson + "Pin 4, ";
                if (pinson == "") pinson = "Pins On=None";
                listBox2.Items.Add("Pins On=" + pinson);
                listBox2.Items.Add("Firmware Version=" + data[11].ToString()); //firmware version

                string temp = "PID=" + (data[13] * 256 + data[12]).ToString();
                listBox2.Items.Add(temp);

                listBox2.Items.Add("Dim Factor Bank 1=" + data[17].ToString());
                listBox2.Items.Add("Dim Factor Bank 2=" + data[18].ToString());
                txtBank1.Text = data[17].ToString();
                txtBank2.Text = data[18].ToString();

                listBox2.Items.Add("GPIO Input/Output Configuration=" + data[19].ToString());
                listBox2.Items.Add("GPIO Input Configuration=" + data[20].ToString());
                rb1O.Checked = true; rb2O.Checked = true; rb3O.Checked = true; rb4O.Checked = true;
                if ((byte)(data[19] & 1) == 1) //pin is input, check which type of input
                {
                    rb1ID.Checked = true;
                    if ((byte)(data[20] & 1) == 1) rb1I.Checked = true;
                }
                if ((byte)(data[19] & 2) == 2) //pin is input, check which type of input
                {
                    rb2ID.Checked = true;
                    if ((byte)(data[20] & 2) == 2) rb2I.Checked = true;
                }
                if ((byte)(data[19] & 4) == 4) //pin is input, check which type of input
                {
                    rb3ID.Checked = true;
                    if ((byte)(data[20] & 4) == 4) rb3I.Checked = true;
                }
                if ((byte)(data[19] & 8) == 8) //pin is input, check which type of input
                {
                    rb4ID.Checked = true;
                    if ((byte)(data[20] & 8) == 8) rb4I.Checked = true;
                }

                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

        private void BtnPID1_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1)
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 204; // 0xcc;
                wData[2] = (byte)cboPIDs.SelectedIndex;

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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
                wData[1] = 195; //0xc3;
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
                //reboot and re-enumerate
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void chkLED1_CheckStateChanged(object sender, EventArgs e)
        {
            //Write to GPIO outputs
            if (selecteddevice != -1)
            {
                CheckBox thischkbox = (CheckBox)sender;
                byte ledindex = Convert.ToByte(thischkbox.Tag.ToString());
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = ledindex; //1=Pin 1, 2=Pin 2, 3=Pin 3, 4=Pin 4
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

        private void btnSetRGB_Click(object sender, EventArgs e)
        {
            //Set individual led 
            //Use the Set Flash Freq to control frequency of blink
            //Button Index (in decimal)
            //Columns-->
            //  0   6   12  18  
            //  1   7   13  19 
            //  2   8   14  20
            //  3   9   15  21
            //  4   10  16  22
            //  5   11  17  23

            //Upper LEDs are bank 1, bankindex = 0
            //Lower LEDs are bank 2, bankindex = 1

            if (selecteddevice != -1)
            {
                byte buttonindex = Convert.ToByte(CboRGBIndex.Text);
                byte bank = (byte)cboBank.SelectedIndex;
                int checkstate = (int)chkRGBFlash.CheckState;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                int result = 0;
                if ((bank == 0) || (bank == 1))
                {
                    wData[1] = 165; //0xA5
                    wData[2] = buttonindex;
                    wData[3] = bank; //0=bank 1 (top), 1=bank 2 (bottom)
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
                else if (bank == 2) //do both
                {
                    wData[1] = 165; //0xA5
                    wData[2] = buttonindex;
                    wData[3] = 0; //0=bank 1 (top), 1=bank 2 (bottom)
                    wData[4] = Convert.ToByte(txtR.Text);
                    wData[5] = Convert.ToByte(txtG.Text);
                    wData[6] = Convert.ToByte(txtB.Text);
                    wData[7] = (byte)chkRGBFlash.CheckState; //0=no flash, 1=flash

                    result = 404;
                    while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                    wData[1] = 165; //0xA5
                    wData[2] = buttonindex;
                    wData[3] = 1; //0=bank 1 (top), 1=bank 2 (bottom)
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
        }

        private void btnSetAllBank1_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1)
            {
                int result = 0;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[1] = 166;//0xA6
                wData[2] = 0; //0=Bank 1 (upper LEDs), 1=Bank 2 (lower LEDs)
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

        private void btnSetAllBank2_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1)
            {
                int result = 0;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[1] = 166; //0xA6
                wData[2] = 1; //0=Bank 1 (upper LEDs), 1=Bank 2 (lower LEDs)
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
                    toolStripStatusLabel1.Text = "Write Success - Set All Bank 2 RGB LED";
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
                wData[3] = (byte)(Convert.ToInt16(txtBank2.Text)); //1-255 for brightness of bank 2 bl leds

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

        private void ChkBLOnOff_CheckStateChanged(object sender, EventArgs e)
        {
            //Legacy Backlight (blue/red style)
            //Use the Set Flash Freq to control frequency of blink
            //Button Index (in decimal)
            //Columns-->
            //Bank 1 (Upper) LEDs
            //  0   6   12  18  
            //  1   7   13  19 
            //  2   8   14  20
            //  3   9   15  21
            //  4   10  16  22
            //  5   11  17  23
            //Bank 2 (Lower) LEDs
            //  24   30  36  42  
            //  25   31  37  43 
            //  26   32  38  44
            //  27   33  39  45
            //  28   34  40  46
            //  29   35  41  47
            if (selecteddevice != -1)
            {
                //first get selected index
                string sindex = CboBL.Text;
                int bank = CboBankLegacy.SelectedIndex;
                int iindex = CboBL.SelectedIndex;
                if (bank == 1) iindex = iindex + 24;

                //now get state
                int state = (int)ChkBLOnOff.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 181; //0xB5
                wData[2] = (byte)(iindex); //Index
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

        private void btnGetBLState_Click(object sender, EventArgs e)
        {
            //Request the state of the desired RGB LED, returns states for both upper and lower banks
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                //Button Index (in decimal)
                //Columns-->
                //  0   6   12  18  
                //  1   7   13  19 
                //  2   8   14  20
                //  3   9   15  21
                //  4   10  16  22
                //  5   11  17  23
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

        private void btnSetInOut_Click(object sender, EventArgs e)
        {
            //Configure the GPIO for output or input and which type of input
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                byte gpioconfig = 0xff; //for each bit 0=output, 1=input
                byte inputconfig = 0; //if gpioconfig bit = 1 (input) then the corresponding bit in this byte gives the type of input 0=resistive pull up (short to ground), 1=resistive pull down (drive high) 
                if (rb1O.Checked == true)
                {
                    gpioconfig = (byte)(gpioconfig & ~1);
                }
                else
                {
                    if (rb1I.Checked == true) { inputconfig = (byte)(inputconfig | 1); }
                }
                if (rb2O.Checked == true) gpioconfig = (byte)(gpioconfig & ~2);
                else
                {
                    if (rb2I.Checked == true) { inputconfig = (byte)(inputconfig | 2); }
                }
                if (rb3O.Checked == true) gpioconfig = (byte)(gpioconfig & ~4);
                else
                {
                    if (rb3I.Checked == true) { inputconfig = (byte)(inputconfig | 4); }
                }
                if (rb4O.Checked == true) gpioconfig = (byte)(gpioconfig & ~8);
                else
                {
                    if (rb4I.Checked == true) { inputconfig = (byte)(inputconfig | 8); }
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 147; //0x93
                wData[2] = gpioconfig; //pins 1, 2, 3, 4   MSB 0-0-0-0-4-3-2-1 LSB   0=output, 1=input
                wData[3] = inputconfig; //pins 1, 2, 3, 4  MSB 0-0-0-0-4-3-2-1 LSB   0=resistive pull up, 1=resistive pull down, note: if a bit is configured as output in gpioconfig, then its bit setting here doesn't matter

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Configure GPIO";
                }
            }
        }

        private void btnSaveInOut_Click(object sender, EventArgs e)
        {
            //Save the GPIO configuration to the eeprom
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }

            wData[0] = 0;
            wData[1] = 148; //0x94

            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;
            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Save GPIO Configuration";
            }
        }

        private void btnSiliconGeneratedID_Click(object sender, EventArgs e)
        {
            //This command is only necessary if devices[].SerialNumberString is not available on enumerate
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
                wData[1] = 157; //0x9D
                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Silicon Generated ID";
                }

                byte[] data = null;
                int countout = 0;
                data = new byte[80];

                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 157) || ret == 304)
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
                string uniqueID = "";
                for (int i = 0; i < 8; i++)
                {
                    uniqueID = uniqueID + BinToHex(data[i + 3]);
                }

                lblSiliconGeneratedID.Text = uniqueID;

                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
