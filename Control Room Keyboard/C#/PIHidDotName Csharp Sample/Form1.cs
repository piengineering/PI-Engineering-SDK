using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PIEHid32Net;
using System.Security.Cryptography; //AES https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-8.0
using System.IO; //AES


namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        PIEDevice[] devices;
        
        int[] cbotodevice=null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        int selecteddevice=-1; //set to the index of CboDevice
        long saveabsolutetime;  //for timestamp demo
        byte[] lastdata = null;

        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void SetClearCallback();
        Control c;
        ListBox thisListBox;
        //end thread-safe

        int[] sctokey = new int[256]; //map byte/bit "scan code" to key number listed in SDK documentation

        //AES
        Aes myAes;
        byte[] myKey;
        byte[] myIV;
       
        public Form1()
        {
            InitializeComponent();
            //BtnEnumerate_Click(this, null);

            //AES
            myAes = Aes.Create(); //creates object with Key and IV
            myAes.Mode = CipherMode.CBC; //Must match X-keys mode which is CBC
            myAes.Padding = PaddingMode.Zeros; //Must match X-keys which is Zeros
            myAes.KeySize = 128; //Must match X-keys which is 16 byte AES key

            myKey = new byte[16];
            myIV = new byte[16];


            //this array maps the byte/bit "scan code" given in the general incoming data report to the key numbers shown in the SDK documentation
            for (int i = 0; i < 256; i++) sctokey[i] = -1;
            
            sctokey[0] = 1;
            sctokey[2] = 2;
            sctokey[3] = 3;
            sctokey[4] = 4;
            sctokey[5] = 5;
            sctokey[6] = 6;

            sctokey[8] = 7;
            sctokey[9] = 8;
            sctokey[10] = 9;
            sctokey[11] = 10;
            sctokey[12] = 11;
            sctokey[13] = 12;

            sctokey[16] = 13;
            sctokey[17] = 14;
            sctokey[18] = 15;
            sctokey[19] = 16;
            sctokey[20] = 17;
            sctokey[21] = 18;

            sctokey[24] = 19;
            sctokey[25] = 20;
            sctokey[26] = 21;
            sctokey[27] = 22;
            sctokey[28] = 23;
            sctokey[29] = 180; //Plus One and Plus Two

            sctokey[32] = 24;
            sctokey[33] = 25;
            sctokey[34] = 26;
            sctokey[35] = 27;
            sctokey[36] = 28;

            sctokey[40] = 29;
            sctokey[41] = 30;
            sctokey[42] = 31;
            sctokey[43] = 32;
            sctokey[44] = 33;
            sctokey[45] = 34;

            sctokey[48] = 35;
            sctokey[49] = 36;
            sctokey[50] = 37;
            sctokey[51] = 38;
            sctokey[52] = 39;

            sctokey[56] = 40;
            sctokey[57] = 41;
            sctokey[58] = 42;
            sctokey[59] = 43;
            sctokey[60] = 44;

            sctokey[64] = 45;
            sctokey[65] = 46;
            sctokey[66] = 47;
            sctokey[67] = 48;
            sctokey[68] = 49;

            sctokey[72] = 50;
            sctokey[73] = 51;
            sctokey[74] = 52;
            sctokey[75] = 53;
            sctokey[76] = 54;
            sctokey[77] = 55;

            sctokey[80] = 56;
            sctokey[81] = 57;
            sctokey[82] = 58;
            sctokey[83] = 59;
            sctokey[84] = 60;
            sctokey[85] = 61;

            sctokey[88] = 62;
            sctokey[89] = 63;
            sctokey[90] = 64;
            sctokey[91] = 65;

            sctokey[96] = 66;
            sctokey[97] = 67;
            sctokey[98] = 68;

            sctokey[104] = 69;
            sctokey[105] = 70;
            sctokey[106] = 71;
            sctokey[107] = 72;
            sctokey[108] = 73;
            sctokey[109] = 74;

            sctokey[112] = 75;
            sctokey[113] = 76;
            sctokey[116] = 185; //Plus Two only
            sctokey[117] = 77;

            sctokey[120] = 78;
            sctokey[121] = 79;
            sctokey[122] = 80;
            sctokey[123] = 81;
            sctokey[124] = 82;
            sctokey[125] = 83;

            sctokey[128] = 84;
            sctokey[129] = 85;
            sctokey[130] = 86;
            sctokey[131] = 87;
            sctokey[132] = 88;
            sctokey[133] = 89;

            sctokey[136] = 90;
            sctokey[137] = 91;
            sctokey[138] = 92;
            sctokey[139] = 93;
            sctokey[140] = 94;
            sctokey[141] = 95;

            sctokey[144] = 96;
            sctokey[145] = 97;
            sctokey[146] = 98;
            sctokey[147] = 99;
            sctokey[148] = 100;
            sctokey[149] = 101;

            sctokey[152] = 102;
            sctokey[153] = 103;
            sctokey[154] = 104;
            sctokey[155] = 105;
            sctokey[156] = 106;
            sctokey[157] = 107;

            sctokey[160] = 108;
            sctokey[161] = 109;
            sctokey[162] = 110;
            sctokey[163] = 111;
            sctokey[164] = 112;
            sctokey[165] = 113;

            sctokey[168] = 114;
            sctokey[169] = 115;
            sctokey[170] = 116;
            sctokey[171] = 117;
            sctokey[172] = 118;
            sctokey[173] = 119;

            sctokey[176] = 120;
            sctokey[177] = 121;
            sctokey[178] = 122;
            sctokey[179] = 123;
            sctokey[180] = 124;
            sctokey[181] = 125;

            sctokey[184] = 126;
            sctokey[185] = 127;
            sctokey[186] = 128;
            sctokey[187] = 129;
            sctokey[188] = 130;
            sctokey[189] = 131;

            sctokey[192] = 132;
            sctokey[193] = 133;
            sctokey[194] = 134;
            sctokey[195] = 135;
            sctokey[196] = 136;
            sctokey[197] = 137;
            sctokey[198] = 138;

            sctokey[200] = 139;
            sctokey[201] = 140;
            sctokey[202] = 141;
            sctokey[203] = 142;
            sctokey[204] = 143;
            sctokey[205] = 144;
            sctokey[206] = 145;

            sctokey[208] = 146;
            sctokey[209] = 147;
            sctokey[210] = 148;
            sctokey[211] = 149;
            sctokey[212] = 150;
            sctokey[213] = 151;
            sctokey[214] = 152;

            sctokey[216] = 153;
            sctokey[217] = 154;
            sctokey[218] = 155;
            sctokey[219] = 156;
            sctokey[220] = 157;
            sctokey[221] = 158;
            sctokey[222] = 159;

            sctokey[224] = 160;
            sctokey[225] = 161;
            sctokey[226] = 162;
            sctokey[227] = 163;
            sctokey[228] = 164;
            sctokey[229] = 165;
            sctokey[230] = 166;

            sctokey[232] = 167;
            sctokey[233] = 168;
            sctokey[234] = 169;
            sctokey[235] = 170;
            sctokey[236] = 171;
            sctokey[237] = 172;
            sctokey[238] = 173;

            sctokey[240] = 174;
            sctokey[241] = 175;
            sctokey[242] = 176;
            sctokey[243] = 177;
            sctokey[244] = 178;
            sctokey[245] = 179;
            
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

                //read the unit ID
                c = this.LblUnitID;
                this.SetText(data[1].ToString());

                if (data[2] < 4) //general incoming data
                {
                    int val2;
                    //check the keyboard state byte 
                    val2 = (byte)(data[34] & 1);
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
                    val2 = (byte)(data[34] & 2);
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
                    val2 = (byte)(data[34] & 4);
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

                    //time stamp info 4 bytes
                    long absolutetime = 16777216 * data[sourceDevice.ReadLength - 4] + 65536 * data[sourceDevice.ReadLength - 3] + 256 * data[sourceDevice.ReadLength - 2] + data[sourceDevice.ReadLength - 1];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    c = this.label19;
                    this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    c = this.label20;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;

                    //Buttons
                    int maxcols = 31; //number of columns of Xkeys digital button data, labeled "Keys" in P.I. Engineering SDK - General Incoming Data Input Report
                    int maxrows = 8; //constant, 8 bits per byte
                    c = this.lblButtons;
                    string buttonsdown = "Buttons: "; 
                    this.SetText(buttonsdown);
                    for (int i = 0; i < maxcols; i++) 
                    {
                        for (int j = 0; j < maxrows; j++) //loop through each bit in the button byte
                        {
                            int temp1 = (int)Math.Pow(2, j); //1, 2, 4, 8, 16, 32, 64, 128
                            int bitkeynum = 8 * i + j; //byte/bit "scan code"
                            byte temp2 = (byte)(data[i + 3] & temp1); //check using bitwise AND the current value of this bit. The + 3 is because the 1st button byte starts 3 bytes in at data[3]
                            byte temp3 = (byte)(lastdata[i + 3] & temp1); //check using bitwise AND the previous value of this bit
                            int state = 0; //0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                            if (temp2 != 0 && temp3 == 0) state = 1; //press
                            else if (temp2 != 0 && temp3 != 0) state = 2; //held down
                            else if (temp2 == 0 && temp3 != 0) state = 3; //release
                            switch (state)
                            {
                                case 1: //key was up and now is pressed
                                    buttonsdown = buttonsdown + sctokey[bitkeynum].ToString() + " ";
                                    c = this.lblButtons;
                                    SetText(buttonsdown);
                                    break;
                                case 2: //key was pressed and still is pressed
                                    buttonsdown = buttonsdown + sctokey[bitkeynum].ToString() + " ";
                                    c = this.lblButtons;
                                    SetText(buttonsdown);
                                    break;
                                case 3: //key was pressed and now released
                                    break;
                            }
                        }
                    }

                }
                else if (data[2] == 0x8B) //encrypt results
                {
                    c = lblXkeysEncrypt;
                    string encryptedbytes = "";
                    for (int j = 0; j < 32; j++)
                    {
                        encryptedbytes = encryptedbytes + BinToHex(data[3 + j]) + ", ";
                    }
                    SetText(encryptedbytes);
                }
                else if (data[2] == 0x8C) //decrypt results
                {
                    c = lblXkeysDecrypt;
                    string decryptedbytes = "";
                    for (int j = 0; j < 32; j++)
                    {
                        if (data[3 + j] != 0)
                        {
                            decryptedbytes = decryptedbytes + (char)(data[3 + j]);
                        }
                    }
                    SetText(decryptedbytes);
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
            toolStripStatusLabel1.Text = "";
            CboLED.SelectedIndex = 0;
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
                    if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength>1)
                    {
                        switch (devices[i].Pid)
                        {
                            case 1573:
                                //Device 4 Keyboard, Input and Output endpoints, PID #1
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 0;
                                break;
                            case 1583:
                                //Device 4 Keyboard, Input and Output endpoints, PID #1
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 0;
                                break;
                            case 1585:
                                //Device 4 Keyboard, Input and Output endpoints, PID #1
                                CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                cboPIDs.SelectedIndex = 0;
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
                        else if (devices[i].Pid == 1574 || devices[i].Pid == 1584 || devices[i].Pid == 1586)
                        {
                            //Device 11 Keyboard only endpoint
                            CboDevices.Items.Add(devices[i].ProductString + " (" + devices[i].Pid + "=PID #2), ID: " + i);
                            cbotodevice[cbocount] = i;
                            cbocount++;
                            cboPIDs.SelectedIndex = 1;
                            MessageBox.Show("Device in KVM mode. To exit KVM mode, replug device into usb port and immediately after press Scroll Lock 10-15 times.");
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
                lblSiliconGeneratedID.Text = devices[selecteddevice].SerialNumberString;
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

        private void BtnRed_Click(object sender, EventArgs e)
        {
            

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

        private void BtnBL_Click(object sender, EventArgs e)
        {
           
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
                wData[1] = 199;  //0xC7
                wData[2] = 1; //anything other than 0 will save bl state to eeprom, default is 0
                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
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
                wData[1] = 210;
                wData[2] = 0;

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
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

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
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
                //if (data[3] == 0) listBox2.Items.Add("PID #2");
                //else if (data[3] == 2) listBox2.Items.Add("PID #1"); //0=PID #2, 1=HW Mode PID, 2=PID #1
                listBox2.Items.Add("device(memory)=" + data[3].ToString());

                if (data[11] > 99)
                {
                    listBox2.Items.Add("Keymapstart=" + ((data[14] * 256) + data[4]).ToString());
                    listBox2.Items.Add("Layer2offset=" + ((data[17] * 256) + data[5]).ToString()); //not in use anymore, back to 255
                }
                else
                {
                    listBox2.Items.Add("Keymapstart=" + ((0 * 256) + data[4]).ToString());
                    listBox2.Items.Add("Layer2offset=" + ((0 * 256) + data[5]).ToString());
                }
                listBox2.Items.Add("SizeOfEEProm=" + (data[7] * 256 + data[6]).ToString());
                listBox2.Items.Add("MaxCol=" + data[8].ToString());
                listBox2.Items.Add("MaxRow=" + data[9].ToString());
                String ledon = "";
                if ((byte)(data[10] & 16) != 0) ledon = "Green LED ";
                if ((byte)(data[10] & 32) != 0) ledon = ledon + "Red LED 1 ";
                if ((byte)(data[10] & 64) != 0) ledon = ledon + "Red LED 2 ";
                if ((byte)(data[10] & 128) != 0) ledon = ledon + "Red LED 3 ";
                if (ledon == "") ledon = "None";
                listBox2.Items.Add("LEDs=" + ledon);
                listBox2.Items.Add("Firmware Version=" + data[11].ToString()); //firmware version

                string temp = "PID=" + (data[13] * 256 + data[12]).ToString();
                listBox2.Items.Add(temp);
                int MaxAddressToRead = 256 * data[16] + data[15];
                listBox2.Items.Add("MaxAddressToRead: "+MaxAddressToRead.ToString());
             
                devices[selecteddevice].callNever = savecallbackstate;
            }
        }

       

       

        private void ChkGreenLED_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkRedLED_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ChkFGreenLED_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkFRedLED_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ChkBLOnOff_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkFlash_CheckedChanged(object sender, EventArgs e)
        {
            
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

        private void BtnPID3_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
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

        private void BtnPID2_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnPID4_Click(object sender, EventArgs e)
        {

        }

        public static Byte HexToBin(String value)
        {
            value = value.Trim();
            String addup = "0x" + value;
            return (Byte)Convert.ToInt32(value, 16);
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
                //reboot device either manually with a hotplug or using the command below, to use this uncomment out the WriteData line,
                //must re-enumerate after sending
                devices[selecteddevice].callNever = true;
                wData[0] = 0;
                wData[1] = 238; //0xee, reboot device without unplugging
                wData[2] = 0;
                wData[3] = 0;
                result=404;
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
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
                wData[2] = 1;

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
            //Multimedia reflector
            if (selecteddevice != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 225; // 0xe1
                wData[2] = HexToBin("94"); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                wData[3] = HexToBin("01"); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                wData[0] = 0;
                wData[1] = 225; // 0xe1
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
            //Multimedia reflector
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 226; // 0xe2
                wData[2] = 2; //1=power down, 2=sleep, 4=wake up

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                //NOTE this needs to be on the release of the key!!

                System.Threading.Thread.Sleep(1000); //this to simulate press/release

                wData[0] = 0;
                wData[1] = 226; // 0xe2
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

        private void BtnSetDongle_Click(object sender, EventArgs e)
        {
            //Sets the 16 byte AES key in the X-keys, keep track of this key, it is are required for decryption
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                //pick a secret 16 byte key and save this Key!!
                myKey[0] = 7;
                myKey[1] = 58;
                myKey[2] = 33;
                myKey[3] = 243;
                myKey[4] = 7;
                myKey[5] = 58;
                myKey[6] = 33;
                myKey[7] = 243;
                myKey[8] = 7;
                myKey[9] = 58;
                myKey[10] = 33;
                myKey[11] = 243;
                myKey[12] = 7;
                myKey[13] = 58;
                myKey[14] = 33;
                myKey[15] = 243;

                //Write AES key to X-keys, this key is stored in eeprom
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 137; //0x89 Set AES Key
                for (int i = 0; i < 16; i++)
                {
                    wData[2 + i] = myKey[i];
                }

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set AES Dongle";
                }
            }
        }

        private void BtnCheckDongle_Click(object sender, EventArgs e)
        {
            //Check dongle by encrypting a phrase and checking with C# decryption
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                //Before each encryption MUST set the initialization vector. The initialzation vector is set to all 0s after each encryption and decryption in the X-keys.   
                Random rnd = new Random();
                for (int i = 0; i < 16; i++)
                {
                    myIV[i] = (byte)rnd.Next(0, 254); //valid values are 0-255 HOWEVER all 0s is not allowed because that is interpreted as an non-initialized IV
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 138; //0x8A Set AES IV
                for (int i = 0; i < 16; i++)
                {
                    wData[2 + i] = myIV[i];
                }

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }


                //Encrypt
                bool savecallbackstate = devices[selecteddevice].callNever;
                devices[selecteddevice].callNever = true;

                string mymessage = "Enter any phrase";
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 139; //0x8B AES Encrypt
                for (int i = 0; i < mymessage.Length; i++)
                {
                    wData[2 + i] = (byte)mymessage[i];
                }

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Check AES Dongle";
                }
                //read back the encrypted data
                byte[] encrypteddata = new byte[32];
                byte[] data = null;
                int countout = 0;
                data = new byte[80];

                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 139) || ret == 304)
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
                for (int i = 0; i < 32; i++)
                {
                    encrypteddata[i] = data[i + 3];
                }

                devices[selecteddevice].callNever = savecallbackstate;

                //Decrypt
                //use the same secret 16 byte key that was used in Set Dongle and the same IV as used above to encrypt
                myKey[0] = 7;
                myKey[1] = 58;
                myKey[2] = 33;
                myKey[3] = 243;
                myKey[4] = 7;
                myKey[5] = 58;
                myKey[6] = 33;
                myKey[7] = 243;
                myKey[8] = 7;
                myKey[9] = 58;
                myKey[10] = 33;
                myKey[11] = 243;
                myKey[12] = 7;
                myKey[13] = 58;
                myKey[14] = 33;
                myKey[15] = 243;

                string decryptresults = DecryptStringFromBytes_Aes(encrypteddata, myKey, myIV, CipherMode.CBC, PaddingMode.Zeros);
                //remove padded 0s
                decryptresults = decryptresults.Replace("\0", string.Empty);
                if (mymessage == decryptresults)
                {
                    lblAESPassFail.Text = "Pass";
                    lblAESPassFail.BackColor = Color.Lime;
                }
                else
                {
                    lblAESPassFail.Text = "Fail";
                    lblAESPassFail.BackColor = Color.Red;
                }
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV, CipherMode thismode, PaddingMode thispadding)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Mode = thismode; // CipherMode.CBC; 
                aesAlg.Padding = thispadding; // PaddingMode.Zeros;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.

            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV, CipherMode thismode, PaddingMode thispadding)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV; //IV not needed for ECB mode
                aesAlg.Mode = thismode; // CipherMode.CBC; 
                aesAlg.Padding = thispadding; // PaddingMode.Zeros; 

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        private void btnRawAESSetKey_Click(object sender, EventArgs e)
        {
            //Sets the 16 byte AES key in the X-keys, keep track of this key, it is are required for decryption
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                myAes.GenerateKey(); //securely generated random key
                //save this Key!!
                for (int i = 0; i < 16; i++)
                {
                    myKey[i] = myAes.Key[i];
                }
                //Write Key to X-keys, this key is stored in eeprom
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 137; //0x89 Set AES Key
                for (int i = 0; i < 16; i++)
                {
                    wData[2 + i] = myKey[i];
                }

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Set AES key";
                }
            }
        }

        private void btnAESEncrypt_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                //input data (up to 32 bytes), outputs encryption
                //AES Key should have been previously set and recorded (if decrypting)

                //Before each encryption MUST set the initialization vector. The initialzation vector is set to all 0s after each encryption and decryption in the X-keys.   
                Random rnd = new Random();
                for (int i = 0; i < 16; i++)
                {
                    myIV[i] = (byte)rnd.Next(0, 254); //valid values are 0-255 HOWEVER all 0s is not allowed because that is interpreted as an non-initialized IV
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 138; //0x8A Set AES IV
                for (int i = 0; i < 16; i++)
                {
                    wData[2 + i] = myIV[i];
                }

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                string mymessage = txtXkeysEncrypt.Text;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 139; //0x8B AES Encrypt
                for (int i = 0; i < mymessage.Length; i++)
                {
                    wData[2 + i] = (byte)mymessage[i];
                }

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - AES encrypt";
                }
                //results in callback
            }
        }

        private void btnXkeysDecrypt_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                //input encrypted data (up to 32 bytes), outputs decryption
                //AES Key and IV should have been previously set and recorded

                //Before each decryption MUST set the initialization vector with that used for the encryption.
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 138; //0x8A Set AES IV
                for (int i = 0; i < 16; i++)
                {
                    wData[2 + i] = myIV[i];
                }
                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                //Decrypt
                string decryptthis = lblXkeysEncrypt.Text;
                byte[] encryptedbytes = new byte[32];
                int count = 0;
                while (decryptthis.Length > 0)
                {
                    int pos = decryptthis.IndexOf(",");
                    if (pos != -1)
                    {
                        encryptedbytes[count] = HexToBin(decryptthis.Substring(0, 2));
                        decryptthis = decryptthis.Remove(0, pos + 1).Trim();
                        count++;
                    }
                }

                //input encrypted data (up to 32 bytes), outputs decryption
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 140; //0x8C

                for (int i = 0; i < 32; i++)
                {
                    wData[2 + i] = encryptedbytes[i];
                }

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - AES decrypt";
                }
                //results in callback
            }
        }

        private void ChkLEDOnOff_CheckStateChanged(object sender, EventArgs e)
        {
            //Turn on the desired indicator LED
            if (selecteddevice != -1) //do nothing if not enumerated
            {
              
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xB3
                wData[2] = (byte)CboLED.SelectedIndex;
                wData[3] = (byte)ChkLEDOnOff.CheckState;

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Indicator LED";
                }
            }
        }

        private void rbTraditional_CheckedChanged(object sender, EventArgs e)
        {
            
        }

       
        

       
        

        

        

       

        




    }
    
    
}
