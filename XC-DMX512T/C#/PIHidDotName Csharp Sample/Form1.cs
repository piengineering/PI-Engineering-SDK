using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PIEHid32Net;
using System.IO; 

namespace PIHidDotName_Csharp_Sample
{
    public partial class Form1 : Form, PIEDataHandler, PIEErrorHandler
    {
        PIEDevice[] devices;
        
        int[] cbotodevice=null; //for each item in the CboDevice list maps this index to the device index.  Max devices =100 
        byte[] wData = null; //write data buffer
        int selecteddevice=-1; //set to the index of CboDevice
        long saveabsolutetime;  //for timestamp demo

        List <TrackBar> sliders = null;
        List <Label> sliderlabels = null;
        List <TextBox> slidertextboxes = null;

        Label[] DataLabels = new Label[8];
        TextBox[] DataTextBoxes = new TextBox[8];

        Label[] ReadLabels = new Label[8];
       
        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void SetColorCallback(Color color);
        Control c;
        ListBox thisListBox;
        //end thread-safe
        byte[] lastdata = null;

        //for reboot method
        bool EnumerationSuccess;

        List<string> sendthisascii; //text read in from the input file to be sent out 

        bool donttrigger = false;

        int startaddress = 0; //for reading DMX data

        public Form1()
        {
            InitializeComponent();
            
            sliders = new List<TrackBar>();
            sliderlabels = new List<Label>();
            slidertextboxes = new List<TextBox>();

            foreach (Control cl in Controls)
            {
                if (cl is Label)  //required for the tabcontrol
                {
                    if (cl.Name.Contains("lblData"))
                    {
                        Label p = (Label)cl;
                        string k = p.Tag.ToString();
                        int j = Convert.ToInt32(k);
                        DataLabels[j] = p;
                    }
                    else if (cl.Name.Contains("lblRead"))
                    {
                        Label p = (Label)cl;
                        string k = p.Tag.ToString();
                        int j = Convert.ToInt32(k);
                        ReadLabels[j] = p;
                    }
                }
                else if (cl is TextBox)
                {
                    if (cl.Name.Contains("txtManualData"))
                    {
                        TextBox p = (TextBox)cl;
                        string k = p.Tag.ToString();
                        int j = Convert.ToInt32(k);
                        DataTextBoxes[j] = p;
                    }
                }
            }

            txtManualStartAdd.Text = "0";
            txtManualStartAdd.Text = "1";
            txtManualSpan.Text = "0";
            txtManualSpan.Text = "3";
            int sopt = 0;
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

                c = this.LblUnitID;
                SetText(data[1].ToString());

                if (data[2] < 3) //general incoming data
                {
                    byte keystates;
                    keystates = (byte)(data[5] & 1);
                    if (keystates == 1)
                    {
                        c = LblNumLk;
                        SetText("NumLock: on");
                    }
                    else
                    {
                        c = LblNumLk;
                        SetText("NumLock: off");
                    }
                    keystates = (byte)(data[5] & 2);
                    if (keystates == 2)
                    {
                        c = LblCapsLk;
                        SetText("CapsLock: on");
                    }
                    else
                    {
                        c = LblCapsLk;
                        SetText("CapsLock: off");
                    }
                    keystates = (byte)(data[5] & 4);
                    if (keystates == 4)
                    {
                        c = LblScrLk;
                        SetText("ScrLock: on");
                    }
                    else
                    {
                        c = LblScrLk;
                        SetText("ScrLock: off");
                    }
                    //jacks
                    if (data[2] < 3)
                    {
                        int maxcols = 2;
                        int maxrows = 8;
                        for (int i = 0; i < maxcols; i++)
                        {
                            for (int j = 0; j < maxrows; j++)
                            {
                                int temp1 = (int)Math.Pow(2, j);
                                int keynum = maxrows * i + j;
                                byte temp2 = (byte)(data[i + 3] & temp1); //this time
                                byte temp3 = (byte)(lastdata[i + 3] & temp1);  //last time
                                int state = 0; //0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                                if (temp2 != 0 && temp3 == 0) state = 1; //press
                                else if (temp2 != 0 && temp3 != 0) state = 2; //held down
                                else if (temp2 == 0 && temp3 != 0) state = 3; //release

                                switch (keynum)
                                {
                                    case 0:
                                        if (state == 1)
                                        {
                                            btnSW1R.BackColor = Color.Lime;
                                        }
                                        else if (state == 3)
                                        {
                                            btnSW1R.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                    case 1:
                                        if (state == 1)
                                        {
                                            btnSW1L.BackColor = Color.Lime;
                                        }
                                        else if (state == 3)
                                        {
                                            btnSW1L.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                    case 2:
                                        if (state == 1)
                                        {
                                            btnSW2R.BackColor = Color.Lime;

                                        }
                                        else if (state == 3)
                                        {
                                            btnSW2R.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                    case 3:
                                        if (state == 1)
                                        {
                                            btnSW2L.BackColor = Color.Lime;
                                        }
                                        else if (state == 3)
                                        {
                                            btnSW2L.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                    case 4:
                                        if (state == 1)
                                        {
                                            btnSW3R.BackColor = Color.Lime;
                                        }
                                        else if (state == 3)
                                        {
                                            btnSW3R.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                    case 5:
                                        if (state == 1)
                                        {
                                            btnSW3L.BackColor = Color.Lime;
                                        }
                                        else if (state == 3)
                                        {
                                            btnSW3L.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                    case 6:
                                        if (state == 1)
                                        {
                                            btnSW4R.BackColor = Color.Lime;
                                        }
                                        else if (state == 3)
                                        {
                                            btnSW4R.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                    case 7:
                                        if (state == 1)
                                        {
                                            btnSW4L.BackColor = Color.Lime;
                                        }
                                        else if (state == 3)
                                        {
                                            btnSW4L.BackColor = SystemColors.ButtonFace;
                                        }
                                        break;
                                } //switch (keynum)
                            } //for maxrows
                        } //for maxcols

                        for (int i = 0; i < sourceDevice.ReadLength; i++)
                        {
                            lastdata[i] = data[i];
                        }
                    } //end of buttons

                    //time stamp info 4 bytes
                    long absolutetime = 16777216 * data[32] + 65536 * data[33] + 256 * data[34] + data[35];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    c = this.lblAbsTime;
                    this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    c = this.lblDeltaTime;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;
                } //end of general incoming data
                else if (data[2]==165) //0xA5 Incoming DMX Data via Read Once
                {
                    int count = data[5]; //number bytes (addresses) to follow
                    int thisstartaddress = data[4] * 256 + data[3]; //start address
                    thisListBox = listBox3;
                    
                    for (int i = 0; i < count; i++)
                    {
                        output = "Addr: " +(thisstartaddress+i).ToString()+ " = "+ data[6 + i].ToString();
                        this.SetListBox(output);
                    }
                    
                    //time stamp info 4 bytes
                    long absolutetime = 16777216 * data[32] + 65536 * data[33] + 256 * data[34] + data[35];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    c = this.lblAbsTime;
                    this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    c = this.lblDeltaTime;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;
                }
                else if (data[2] == 147) //0x93 Incoming DMX Data via Start Notification
                {
                    int count = data[5]; //number addresses to follow, always 1 in this case
                    int address = data[4] * 256 + data[3]; //address of changed DMX data
                    int thislabel = address - startaddress;
                    if (ReadLabels[thislabel] != null)
                    {
                        c = ReadLabels[thislabel];
                        SetText("Addr: " + address.ToString() + "="+data[6].ToString());
                    }

                    //time stamp info 4 bytes-Note if the time stamp is the same, change in DMX value occurred simultaneously
                    long absolutetime = 16777216 * data[32] + 65536 * data[33] + 256 * data[34] + data[35];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    c = this.lblAbsTime;
                    this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    c = this.lblDeltaTime;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;
                }
                else if (data[2] == 163) //0xA3 DMX Write Length
                {
                    c = lblDMXLength;
                    SetText((data[3] + (256 * data[4])).ToString());
                }
                else if (data[2] == 146) //0x92 DMX Read Length
                {
                    c = lblDMXReadLength;
                    SetText((data[3] + (256 * data[4])).ToString());
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
            sendthisascii = new List<string>();
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
            lastdata = new byte[devices[selecteddevice].ReadLength + 1];
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

            devices = PIEHid32Net.PIEDevice.EnumeratePIE();
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
                            case 1225:
                                CboDevices.Items.Add("XC-DMX512T-RJ45 (" + devices[i].Pid +")" +" version="+devices[i].Version.ToString());
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1324:
                                CboDevices.Items.Add("XC-DMX512T-ST (" + devices[i].Pid + ")");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            //case 1479:
                            //    CboDevices.Items.Add("XC-DMX512T-PSoC (" + devices[i].Pid + ")");
                            //    cbotodevice[cbocount] = i;
                            //    cbocount++;
                            //    break;
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

                selecteddevice = cbotodevice[0];
                wData = new byte[devices[selecteddevice].WriteLength];//go ahead and setup for write
                //fill in version
                LblVersion.Text = devices[selecteddevice].Version.ToString();
                EnumerationSuccess = true;
                CboDevices.SelectedIndex = 0; //does the descriptor not too so moved it down
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

        private void BtnJoyreflect_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnDescriptor_Click(object sender, EventArgs e)
        {
            //Sending the command will make the device return information about it
            if (CboDevices.SelectedIndex != -1 && devices[selecteddevice].ReadLength>0)
            {
                //IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later
                bool savecallback = devices[selecteddevice].callNever;
                devices[selecteddevice].callNever = true;
                LblVersion.Text = devices[selecteddevice].Version.ToString();
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
                //CboDevices.Items[CboDevices.SelectedIndex] =  "Unit ID: " + data[2].ToString();
              
                LblUnitID.Text = data[1].ToString();
                if (data[3] == 0) listBox2.Items.Add("PID #1");
                else if (data[3] == 1) listBox2.Items.Add("PID #2"); //0=PID #1, 1=PID #2, 2=PID #3, 3=PID #4
                else if (data[3] == 2) listBox2.Items.Add("PID #3");
                else if (data[3] == 3) listBox2.Items.Add("PID #4");
                listBox2.Items.Add("Keymapstart=" + data[4].ToString());
                listBox2.Items.Add("Layer2offset=" + data[5].ToString());
                listBox2.Items.Add("SizeOfEEProm=" + (data[7] * 256 + data[6]).ToString());
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
                if (data[18] == 0) temp = "transmit";
                else temp = "receive";
                listBox2.Items.Add("Current mode="+temp);
                if (data[19] == 0) temp = "transmit";
                else temp = "receive";
                listBox2.Items.Add("Default mode=" + temp);
                devices[selecteddevice].callNever = savecallback;
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

        private void ChkGreen_CheckStateChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte state = (byte) ChkGreen.CheckState;
                
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179;
                wData[2] = 6; //6 for green, 7 for red
                wData[3] = state; //0=off, 1=on, 2=flash

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - LEDs";
                }
            }
        }

        private void ChkRed_CheckStateChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte state = (byte)ChkRed.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179;
                wData[2] = 7; //6 for green, 7 for red
                wData[3] = state; //0=off, 1=on, 2=flash

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - LEDs";
                }
            }
        }

        private void chkDO1_CheckStateChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                byte state = (byte)chkDO1.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179; //0xB3
                wData[2] = 1; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
                wData[3] = state; //0=off, 1=on, 2=flash

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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

        private void chkDO2_CheckStateChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte state = (byte)chkDO2.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179; //0xB3
                wData[2] = 2; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
                wData[3] = state; //0=off, 1=on

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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

        private void chkDO3_CheckStateChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte state = (byte)chkDO3.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179; //0xB3
                wData[2] = 3; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
                wData[3] = state; //0=off, 1=on

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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

        private void chkDO4_CheckStateChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte state = (byte)chkDO4.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179; //0xB3
                wData[2] = 4; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
                wData[3] = state; //0=off, 1=on

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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
                //REBOOT device to see change!
                
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
                wData[1] = 201;  //0xC9

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
                while (result == 404)
                {
                    result = 404;
                    while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                }

                wData[2] = 0;       //modifiers
                wData[3] = 0;       //always 0
                wData[4] = 0;    //hid code = a up
                wData[5] = 0x05;    //hid code = b down
                wData[6] = 0x06;    //hid code = c down
                wData[7] = 0x07;    //hid code = d down
                wData[8] = 0;
                wData[9] = 0;

                result = 404;
                while (result == 404)
                {
                    result = 404;
                    while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                }

                wData[2] = 0;
                wData[4] = 0;
                wData[5] = 0;  //b up
                wData[6] = 0;  //c up
                wData[7] = 0;  //d up
                wData[8] = 0;
                wData[9] = 0;

                result = 404;
                while (result == 404)
                {
                    result = 404;
                    while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                }
            }
        }

        private void BtnSetDongle_Click(object sender, EventArgs e)
        {
            //Use the Dongle feature to set a 4 byte code into the device
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
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
                    toolStripStatusLabel1.Text = "Write Success-Set Dongle Key";
                }
            }
        }

        private void BtnCheckDongle_Click(object sender, EventArgs e)
        {
            //Reads the secret key set in Set Key
            //This is done within the developer's application to check for the correct
            //hardware.  The K0-K3 values must be the same as those entered in Set Key.
            if (CboDevices.SelectedIndex != -1)
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
                    toolStripStatusLabel1.Text = "Write Success-Check Dongle Key";
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

       

        private void btnMakeSliders_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //initialize DMX - This will automatically set the DMX Length based on entered start address and span and initialize everything to 0
            //transmission begins at the moment this command is sent
            int span = Convert.ToInt16(txtSpan.Text);
            int startaddress = Convert.ToInt16(txtStartAddress.Text);
            if ((startaddress + span) > 511)
            {
                span = 512 - startaddress;
                txtSpan.Text = span.ToString();
            }
            //note if startaddress+span>512 then DMX Length will be set to 0 on the next DMX Load Buffer command
            //transmission begins at the moment this command is sent
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 161; //0xA1
            wData[2] = (byte)(startaddress);
            wData[3] = (byte)(startaddress>>8);
            wData[4] = (byte)span;
            for (int i = 0; i < span; i++)
            {
                wData[5+i] = 0;
            }

            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;
            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success-Load DMX buffer";
            }
            //DMX is transmitting all 0s at this point.

            //Creates a trackbar, label, and textbox control for each "slot" or address based on start address and span.
            //When the value of the trackbar control or corresponding textbox is changed, the DMX buffer is updated with the
            //new values, see sliders_ValueChanged event.

            //remove any controls that were previously created
            for (int i = 0; i < sliders.Count; i++)
            {
                sliders[i].Dispose();
            }
            for (int i = 0; i < sliderlabels.Count; i++)
            {
                sliderlabels[i].Dispose();
            }
            for (int i = 0; i < slidertextboxes.Count; i++)
            {
                slidertextboxes[i].Dispose();
            }
            
            int left = txtSpan.Left;  //588;
            int top = txtSpan.Top + 70;

            sliders.Clear();
            sliderlabels.Clear();
            slidertextboxes.Clear();
            for (int i = 0; i < span; i++)
            {
                TrackBar thistrackbar = new TrackBar();
                thistrackbar.Orientation = Orientation.Vertical;
                thistrackbar.Top = top;
                thistrackbar.Left = left;
                thistrackbar.Maximum = 255;
                thistrackbar.TickFrequency = 17;
                thistrackbar.Height = 104;
                thistrackbar.Tag = i;
                thistrackbar.Name = "tkbSlider" + i.ToString();
                thistrackbar.Value = 0; // 0; //set all values to 0
                thistrackbar.ValueChanged += sliders_ValueChanged;

                this.Controls.Add(thistrackbar);
                sliders.Add(thistrackbar);

                //make a label
                Label thislabel = new Label();
                thislabel.Text = (i + startaddress).ToString();
                thislabel.Left = left;
                thislabel.Top = top + thistrackbar.Height + 3;
                thislabel.Tag = i;
                thislabel.Name = "lblSlider" + i.ToString();
                thislabel.Visible = true;
                thislabel.Width = 25;
                thislabel.Height = 13;

                this.Controls.Add(thislabel);
                sliderlabels.Add(thislabel);

                //make manual entry textbox
                TextBox thistextbox = new TextBox();
                thistextbox.Text = "0";
                thistextbox.Left = left;
                thistextbox.Top = thislabel.Top + 20;
                thistextbox.Tag = i;
                thistextbox.Name = "txtSlider" + i.ToString();
                thistextbox.Visible = true;
                thistextbox.Width = 25;
                thistextbox.Height = 13;
                thistextbox.TextChanged += slidertextboxes_TextChanged;

                this.Controls.Add(thistextbox);
                slidertextboxes.Add(thistextbox);

                left = left + 50;
            }

            this.Cursor = Cursors.Default;
        }

        private void sliders_ValueChanged(object sender, EventArgs e)
        {
            //When a value for one of the trackbars change the DMX buffer is updated here. 
            //The DMX buffer is always transmitting if the DMX Length is greater than 0. The DMX Length starts at 0 on bootup of the X-keys XK-DMT512T unit.
            //When the Load DMX Buffer command is sent, the DMX Length is checked, if it is too small then it is automatically increased to
            //(start address + span). The DMX Length is never decreased since the user may have devices on upper addresses. The DMX Length
            //can be manually changed using the Set DMX Length command and read with the Get DMX Length command.
            TrackBar thistrackbar = (TrackBar)sender;
            string tag = thistrackbar.Tag.ToString();
            //int startaddress = Convert.ToInt16(txtStartAddress.Text)+Convert.ToInt16(tag); //this also equals the label below the slider
            int startaddress = 0;
            for (int i = 0; i < sliderlabels.Count; i++)
            {
                string labeltag = sliderlabels[i].Tag.ToString();
                if (tag == labeltag)
                {
                    startaddress = Convert.ToInt16(sliderlabels[i].Text);
                    break;
                }
            }


            //load DMX
            //only one slider changes at a time so can just update this single address
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 161; //0xA1 Load DMX Buffer
            wData[2] = (byte)startaddress; //start addr lo
            wData[3] = (byte)(startaddress >> 8); //start addr hi
            wData[4] = 1; //span
            wData[5] = (byte)thistrackbar.Value; //data

            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;

            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Load DMX";
            }

            //change the matching textbox
            for (int i = 0; i < slidertextboxes.Count; i++)
            {
                if (slidertextboxes[i].Name == "txtSlider" + tag)
                {
                    donttrigger = true;
                    slidertextboxes[i].Text = thistrackbar.Value.ToString();
                    donttrigger = false;
                }
            }
        }

        private void slidertextboxes_TextChanged(object sender, EventArgs e)
        {
            //A value for the corresponding trackbar can be set by entering it in the textbox
            if (donttrigger == true) return;
            TextBox thistextbox = (TextBox)sender;
            string stag = thistextbox.Tag.ToString();
            //int tag = Convert.ToInt16(stag);
            int newvalue = -1;
            try
            {
                newvalue = Convert.ToInt16(thistextbox.Text);
            }
            catch
            {
                MessageBox.Show("Value must be 0-255", "Error", MessageBoxButtons.OK);
                return;
            }
            //find the matching trackbar
            for (int i = 0; i < sliders.Count; i++)
            {
                if (sliders[i].Name == "tkbSlider" + stag)
                {
                    sliders[i].Value = newvalue; //this will trigger the ValueChanged event which reloads the DMX buffer
                }
            }

        }

        private void btnSetDMXLength_Click(object sender, EventArgs e)
        {
            //Set DMX Length manually. This may be desireable of the DMX Length was set to something higher than is currently desired.
            //Otherwise the Load DMX Buffer command will automatically increase the DMX Length based on the start address and span it 
            //receives.
            int length = -1;
            try
            {
                length = Convert.ToInt16(txtSetDMXLength.Text);
                if (length > 511) txtSetDMXLength.Text = "0";
                if (length < 0) txtSetDMXLength.Text = "0";
            }
            catch
            {
                MessageBox.Show("Invalid entry", "Error", MessageBoxButtons.OK);
                return;
            }
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 162; // 0xA2 Set DMX Length
            wData[2] = (byte)length; //start len lo (LSB)
            wData[3] = (byte)(length >> 8); //start len hi (MSB)

            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;

            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Set DMX Length";
            }
        }

        private void btnGetDMXLength_Click(object sender, EventArgs e)
        {
            //Get DMX write length, result will return in callback in this sample but could also read them using BlockingReadData as demonstrated in BtnDescriptor_Click
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 163; // 0xA3 Get DMX Write Length

            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;

            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Get DMX Write Length";
            }
        }

        private void btnLoadDMXBuffer_Click(object sender, EventArgs e)
        {
            //Loads the DMX buffer
            //Due to the size of the output report, only 31 addresses can be loaded at a time. 
            //Thus if one wanted to change all 512 addresses, it would require 17 (512/31 rounded up)Load DMX Buffer commands.
            //The X-keys XC-DMX512T however is designed to only call the Load DMX Buffer command when required and only change
            //an address or subset of addresses that need updating.
            //The X-keys XC-DMX512T is continuously transmitting the desired addresses up to the DMX Length.
            if (selecteddevice == -1) return;

            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            int startaddress = Convert.ToInt16(txtManualStartAdd.Text);
            int span = Convert.ToInt16(txtManualSpan.Text);
            int data1 = Convert.ToInt16(txtManualData1.Text);
            int data2 = Convert.ToInt16(txtManualData2.Text);
            int data3 = Convert.ToInt16(txtManualData3.Text);
            
            
            wData[0] = 0;
            wData[1] = 161; //0xA1 Load DMX Buffer
            wData[2] = (byte) startaddress; //start addr lo
            wData[3] = (byte) (startaddress>>8); //start addr hi
            wData[4] = (byte) span; //span, max value 30 per WriteData
            wData[5] = (byte)data1; //data 1
            wData[6] = (byte)data2; //data 2
            wData[7] = (byte)data3; //data 3
            //add more data bytes up ot 31

            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;
            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Load DMX Buffer";
            }
        }

        private void txtSpan_TextChanged(object sender, EventArgs e)
        {
            //Check to make sure the span is not too big based on the start address
            try
            {
                int span = Convert.ToInt16(txtSpan.Text);
                int startadd = Convert.ToInt16(txtStartAddress.Text);
                if ((startadd + span) > 512)
                {
                    int recommend = 512 - startadd;
                    DialogResult result=MessageBox.Show("Span to big for start address, "+recommend.ToString()+" recommended", "Error", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        txtSpan.Text = recommend.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter number between 1 and 512", "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void txtManualStartAdd_TextChanged(object sender, EventArgs e)
        {
            int startadd = Convert.ToInt16(txtManualStartAdd.Text);
            int span = Convert.ToInt16(txtManualSpan.Text);
            if ((startadd + span) > 512)
            {
                MessageBox.Show("(Start address + span) > 512", "Error", MessageBoxButtons.OK);
            }
            if (span > 30)
            {
                MessageBox.Show("Span > 30, multiple WriteData commands required", "Error", MessageBoxButtons.OK);
            }
            for (int i = 0; i < 8; i++)
            {
                DataLabels[i].Text = "unused";
                DataTextBoxes[i].Enabled = false;
            }
            for (int i = 0; i < span; i++)
            {
                DataLabels[i].Text = "Data 1 - addr: " + (startadd + i).ToString();
                DataTextBoxes[i].Enabled = true;
            }
            
        }

        private void txtManualSpan_TextChanged(object sender, EventArgs e)
        {
            int startadd = Convert.ToInt16(txtManualStartAdd.Text);
            int span = Convert.ToInt16(txtManualSpan.Text);
            if ((startadd + span) > 512)
            {
                MessageBox.Show("(Start address + span) > 512", "Error", MessageBoxButtons.OK);
            }
            if (span > 30)
            {
                MessageBox.Show("Span > 30, multiple WriteData commands required", "Error", MessageBoxButtons.OK);
            }
            for (int i = 0; i < 8; i++)
            {
                DataLabels[i].Text = "unused";
                DataTextBoxes[i].Enabled = false;
            }
            for (int i = 0; i < span; i++)
            {
                DataLabels[i].Text = "Data "+(i+1).ToString() + " - addr: " + (startadd + i).ToString();
                DataTextBoxes[i].Enabled = true;
            }
        }

        private void btnDMXOff_Click(object sender, EventArgs e)
        {
            if (selecteddevice == -1) return;
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }

            wData[0] = 0;
            wData[1] = 164; //0xA4 Clear DMX Buffer
          
            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;
            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Clear DMX Buffer";
            }
        }

        private void btnReadOnlyDMX_Click(object sender, EventArgs e)
        {
            //Send this command to setup the XC-DMX512T to receive DMX data instead of transmit. This is the same as clicking Set mode Receive (btnModeRec).
            //If the default mode of the XC-DMX512T has been previously set to receive then this is not necessary.
            //Data can be read in 2 ways; reading 20 bytes from a specified start address (Read Once) or registering to receive notification of any changes (Start Notification).
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 171; //0xAB

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Configure for Read Only and clear buffers";
                }
            }
        }

        private void btnReadDMX_Click(object sender, EventArgs e)
        {
            //Sending this command will return the current values for 20 bytes of DMX data, starting at the desired start address
            //In this sample, the results will return in the callback (HandlePIEHidData), however the commented out code below shows how to read the 
            //data directly without using the callback.
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                listBox3.Items.Clear(); //clear for new results
                
                int startaddress = Convert.ToInt16(txtReadStartAdd.Text);
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 165; //0xA5;
                wData[2] = (byte)(startaddress);
                wData[3] = (byte)(startaddress >> 8);

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Read DMX data";
                }

                //This code demonstrates how to directly read the returned results without using the callback
                /*
                bool savecallback = devices[selecteddevice].callNever;  //IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later
                devices[selecteddevice].callNever = true;
                byte[] data = null;
                int countout = 0;
                data = new byte[80];
                data[1] = 0;
                int ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                while ((ret == 0 && data[2] != 165) || ret == 304)
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
                //returned values in data
                //data[1]=unit id
                //data[2]=165
                //data[3]=start address lo (LSB), this equals wData[2] above
                //data[4]=start address hi (MSB), this equals wData[3] above
                //data[5]=count, normally 20 but could be less is start address is over 491
                //data[6]=start of DMX data, this first byte is usually 0
                //data[7]=value of start address
                //data[8]=value of start address + 1
                //data[9]=value of start address + 2
                //etc.
                //display results in listBox3
                int count = data[5]; //number address reported
                int startaddress = data[4] * 256 + data[3]; //start address
                string output="";    
                for (int i = 0; i < count; i++)
                {
                    output = "Addr: " +(startaddress+i).ToString()+ " = "+ data[6 + i].ToString();
                    this.SetListBox(output);
                }
                
                //Turn back on callback, if it was on
                devices[selecteddevice].callNever = savecallback;
                
                */
            }
        }

        private void btnCallbackDMX_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte onoff = 0;
                if (btnCallbackDMX.Text.Contains("Start") == true)
                {
                    onoff = 1;
                    btnCallbackDMX.Text = "Stop Notification";
                }
                else
                {
                    onoff = 0;
                    btnCallbackDMX.Text = "Start Notification*";
                }   

                //setup to receive notification of DMX changes in desired range. This sample is looking for changes at addresses 1 to 8. If want to be notified of all DMX changes then use 0 to 511
                startaddress=1; //this is global so know what it is when reading the data back in HandlePIEHidData
                int endaddress=8;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 147; // 0x93
                wData[2] = onoff; //1=notification on, 0=notification off
                wData[3] = (byte)startaddress; //start address lo (LSB)
                wData[4] = (byte)(startaddress>>8); //start address hi (MSB)
                wData[5] = (byte)endaddress; //end address lo (LSB)
                wData[6] = (byte)(endaddress>>8); //end address hi (MSB)

                //setup the labels to display results
                int numberofaddresses=endaddress-startaddress+1;
                for (int i=0;i<numberofaddresses;i++)
                {
                    if (ReadLabels[i]!=null)
                    {
                        string thisaddress = "Addr: "+(startaddress+i).ToString();
                        ReadLabels[i].Text = thisaddress;
                    }
                }

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Setup DMX Notification";
                }
            }
        }

        private void rbCallbackDMXOn_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                //write Unit ID given in the TxtSetUnitID box
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 0x93;
                wData[2] = 01;

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

        private void rbCallbackDMXOff_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                //write Unit ID given in the TxtSetUnitID box
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 0x93;
                wData[2] = 00;

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

        private void btnSaveModeTrans_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                //Note: Command writes to EEPROM, do not perform this command excessively.
                //Save to device the default bootup mode (transmit or receive). Does not change mode.
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 172; //0xAC
                wData[2] = 00; //0=transmit, 1=receive

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - default bootup mode transmit";
                }
            }
        }

        private void btnSaveModeRec_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                //Note: Command writes to EEPROM, do not perform this command excessively 
                //Save to device the default bootup mode (transmit or receive). Does not change mode.
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 172; //0xAC
                wData[2] = 1; //0=transmit, 1=receive

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - default bootup mode receive";
                }
            }
        }

        private void BtnTimeStamp_Click(object sender, EventArgs e)
        {
            //Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 210; //0xD2
                wData[2] = 0; //0=off, 1=on

                int result = 404;

                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Time Stamp Off";
                }
            }
        }

        private void BtnTimeStampOn_Click(object sender, EventArgs e)
        {
            //Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
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
                    toolStripStatusLabel1.Text = "Write Success - Time Stamp On";
                }
            }
        }

        private void btnModeTrans_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                //Configure device to transmit. Factory default is configured in transmit mode. This command only used if changing between transmit and read modes.
                
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 169; //0xA9
                wData[2] = 00; //0=transmit, 1=receive

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - configure to transmit";
                }
            }
        }

        private void btnModeRec_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                //Configure device to receive. Factory default is configured in transmit mode. This command only used if changing between transmit and receive modes.
                //To make the device default (state on bootup) configured for receive mode, click Receive under "Set default bootup mode", see btnSaveModeRec_Click.
                
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 169; //0xA9
                wData[2] = 1; //0=transmit, 1=receive

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - configure to receive";
                }
            }
        }

        private void btnGetDMXReadLength_Click(object sender, EventArgs e)
        {
            //Get DMX read length, result will return in callback in this sample but could also read them using BlockingReadData as demonstrated in BtnDescriptor_Click
            for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
            {
                wData[j] = 0;
            }
            wData[0] = 0;
            wData[1] = 146; // 0x92 Get DMX Length

            int result = 404;

            while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
            if (result != 0)
            {
                toolStripStatusLabel1.Text = "Write Fail: " + result;

            }
            else
            {
                toolStripStatusLabel1.Text = "Write Success - Get DMX Read Length";
            }
        }

        
        

       

        

        
       

















    }
    
    
}
