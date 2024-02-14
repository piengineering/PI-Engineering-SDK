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

        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
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

                    //write raw data to listbox1 in HEX
                    String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                    for (int i = 0; i < sourceDevice.ReadLength; i++)
                    {
                        output = output + BinToHex(data[i]) + " ";
                    }
                    this.SetListBox(output);

                    //set jack labels
                    //Jack 1
                    val2 = (byte)(data[3] & 1);
                    c = this.LblJack1R;
                    if (val2 == 0)
                    {
                        this.SetText("1: O");
                    }
                    else
                    {
                        this.SetText("1: C");
                    }
                    val2 = (byte)(data[3] & 2);
                    c = this.LblJack1L;
                    if (val2 == 0)
                    {
                        this.SetText("2: O");
                    }
                    else
                    {
                        this.SetText("2: C");
                    }
                    //Jack 2
                    val2 = (byte)(data[3] & 4);
                    c = this.LblJack2R;
                    if (val2 == 0)
                    {
                        this.SetText("3: O");
                    }
                    else
                    {
                        this.SetText("3: C");
                    }
                    val2 = (byte)(data[3] & 8);
                    c = this.LblJack2L;
                    if (val2 == 0)
                    {
                        this.SetText("4: O");
                    }
                    else
                    {
                        this.SetText("4: C");
                    }
                    //Jack 3
                    val2 = (byte)(data[3] & 16);
                    c = this.LblJack3R;
                    if (val2 == 0)
                    {
                        this.SetText("5: O");
                    }
                    else
                    {
                        this.SetText("5: C");
                    }
                    val2 = (byte)(data[3] & 32);
                    c = this.LblJack3L;
                    if (val2 == 0)
                    {
                        this.SetText("6: O");
                    }
                    else
                    {
                        this.SetText("6: C");
                    }
                    //Jack 4
                    val2 = (byte)(data[3] & 64);
                    c = this.LblJack4R;
                    if (val2 == 0)
                    {
                        this.SetText("7: O");
                    }
                    else
                    {
                        this.SetText("7: C");
                    }
                    val2 = (byte)(data[3] & 128);
                    c = this.LblJack4L;
                    if (val2 == 0)
                    {
                        this.SetText("8: O");
                    }
                    else
                    {
                        this.SetText("8: C");
                    }
                    //Jack 4
                    val2 = (byte)(data[4] & 1);
                    c = this.LblJack5R;
                    if (val2 == 0)
                    {
                        this.SetText("9: O");
                    }
                    else
                    {
                        this.SetText("9: C");
                    }
                    val2 = (byte)(data[4] & 2);
                    c = this.LblJack5L;
                    if (val2 == 0)
                    {
                        this.SetText("10: O");
                    }
                    else
                    {
                        this.SetText("10: C");
                    }
                    //Jack 6
                    val2 = (byte)(data[4] & 4);
                    c = this.LblJack6R;
                    if (val2 == 0)
                    {
                        this.SetText("11: O");
                    }
                    else
                    {
                        this.SetText("11: C");
                    }
                    val2 = (byte)(data[4] & 8);
                    c = this.LblJack6L;
                    if (val2 == 0)
                    {
                        this.SetText("12: O");
                    }
                    else
                    {
                        this.SetText("12: C");
                    }


                    //time stamp info 4 bytes
                    long absolutetime = 16777216 * data[sourceDevice.ReadLength-5] + 65536 * data[sourceDevice.ReadLength - 4] + 256 * data[sourceDevice.ReadLength - 3] + data[sourceDevice.ReadLength - 2];  //ms
                    long absolutetime2 = absolutetime / 1000; //seconds
                    c = this.label19;
                    this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                    long deltatime = absolutetime - saveabsolutetime;
                    c = this.label20;
                    this.SetText("delta time: " + deltatime + " ms");
                    saveabsolutetime = absolutetime;
            }
        }

        //error callback
        public void HandlePIEHidError(PIEDevice sourceDevice, Int32 error)
        {
            String errorstring = sourceDevice.GetErrorString(error);
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
            if (selecteddevice != -1)
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
            
        }

        private void BtnEnumerate_Click(object sender, EventArgs e)
        {
            EnumerationSuccess = false;
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

                    if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength == 36)
                    {
                        switch (devices[i].Pid)
                        {
                            case 1300:
                                CboDevices.Items.Add("XK-3 Switch Interface KVM (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 1302:
                                CboDevices.Items.Add("XK-12 Switch Interface KVM (" + devices[i].Pid + "=PID #1)");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            default:
                                CboDevices.Items.Add("Unknown Device (" + devices[i].Pid + ")");
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                        }
                        devices[i].SetupInterface();
                        devices[i].suppressDuplicateReports = ChkSuppress.Checked;

                    }
                    else
                    {
                        if (devices[i].Pid == 1301 || devices[i].Pid == 1303)
                        {
                            MessageBox.Show("Device in KVM mode. To exit KVM mode, replug unit and immediately press Scroll Lock 10-15 times.", "KVM Mode", MessageBoxButtons.OK);

                        }
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
                    toolStripStatusLabel1.Text = "Write Success-Time Stamp";
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
                listBox2.Items.Add("SizeOfEEProm=" + (data[7] * 256 + data[6]).ToString());
                listBox2.Items.Add("MaxCol=" + data[8].ToString());
                listBox2.Items.Add("MaxRow=" + data[9].ToString());
                //(byte)(rdata[7] & 1
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
                listBox2.Items.Add("cred flag=" + data[17].ToString());
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
            //String addup = "0x" + value;
            return (Byte)Convert.ToInt32(value, 16);
        }

       
        private void BtnPID2_Click(object sender, EventArgs e)
        {
            //Note: once you are in this mode input and output reports are no longer available. To change back to PID #1 user must
            //replug device and press the Scroll Lock key 10-15 times within 10 seconds of plugging in.
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 204;
                wData[2] = 1; //0=pid1, 1=pid2

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
            
        }

        private void BtnPID4_Click(object sender, EventArgs e)
        {
            
        }

       

        

        

        private void BtnMultiMedia_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnMyComputer_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnSleep_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCustom_Click(object sender, EventArgs e)
        {
            //After sending this command a custom incoming data report will be given with
            //the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
            //and the following bytes whatever the user wishes.  In this example we are send 3 bytes; 1, 2, 3

            if (selecteddevice != -1) //do nothing if not enumerated
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

                System.Threading.Thread.Sleep(100);

                //reboot device and re-enumerate
               
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

        private void BtnMousereflect_Click(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
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

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}
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

                int result=404;
				
				while(result==404){result = devices[selecteddevice].WriteData(wData);}

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

        private void BtnNoChange_Click(object sender, EventArgs e)
        {
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
                wData[1] = 196;
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

        private void ChkGreen_CheckStateChanged(object sender, EventArgs e)
        {
            if (selecteddevice != -1) //do nothing if not enumerated
            {
                CheckBox thisChk = (CheckBox)sender;
                string temp = thisChk.Tag.ToString();
                byte LED = Convert.ToByte(temp);
                byte state = (byte)thisChk.CheckState;

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 179;
                wData[2] = LED; //6=green, 7=red
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

        
       

        

      

        

        



        
 
       
    }
    
    
}
