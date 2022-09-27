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
        delegate void SetIntCallback(int text);
        Control c;
        //end thread-safe
        int mouseport; //this used to store which port the mouse is plugged in for the message timing commands, 1=Device 1, 0=Device 2
        string[] hidtochar = null;
        


        public Form1()
        {
            InitializeComponent();
            hidtochar = new string[256];
            for (int i = 0; i < 256; i++)
            {
                hidtochar[i] = "";
            }
           
            hidtochar[4] = "a";
            hidtochar[5] = "b";
            hidtochar[6] = "c";
            hidtochar[7] = "d";
            hidtochar[8] = "e";
            hidtochar[9] = "f";
            hidtochar[10] = "g";
            hidtochar[11] = "h";
            hidtochar[12] = "i";
            hidtochar[13] = "j";
            hidtochar[14] = "k";
            hidtochar[15] = "l";
            hidtochar[16] = "m";
            hidtochar[17] = "n";
            hidtochar[18] = "o";
            hidtochar[19] = "p";
            hidtochar[20] = "q";
            hidtochar[21] = "r";
            hidtochar[22] = "s";
            hidtochar[23] = "t";
            hidtochar[24] = "u";
            hidtochar[25] = "v";
            hidtochar[26] = "w";
            hidtochar[27] = "x";
            hidtochar[28] = "y";
            hidtochar[29] = "z";
            hidtochar[30] = "1";
            hidtochar[31] = "2";
            hidtochar[32] = "3";
            hidtochar[33] = "4";
            hidtochar[34] = "5";
            hidtochar[35] = "6";
            hidtochar[36] = "7";
            hidtochar[37] = "8";
            hidtochar[38] = "9";
            hidtochar[39] = "0";
            hidtochar[40] = "Return";
            hidtochar[41] = "Escape";
            hidtochar[42] = "Backspace";
            hidtochar[43] = "Tab"; 
            hidtochar[44] = "Space";
            hidtochar[45] = "-_";
            hidtochar[46] = "=+";
            hidtochar[47] = "[{";
            hidtochar[48] = "]}";
            hidtochar[49] = "'\'";
            hidtochar[50] = "Europe 1";
            hidtochar[51] = ";:";
            hidtochar[52] = "'";
            hidtochar[53] = "`~";
            hidtochar[54] = ",<";
            hidtochar[55] = ".>";
            hidtochar[56] = "/?";
            hidtochar[57] = "Capslock";
            hidtochar[58] = "F1"; 
            hidtochar[59] = "F2";
            hidtochar[60] = "F3";
            hidtochar[61] = "F4";
            hidtochar[62] = "F5";
            hidtochar[63] = "F6";
            hidtochar[64] = "F7";
            hidtochar[65] = "F8";
            hidtochar[66] = "F9";
            hidtochar[67] = "F10";
            hidtochar[68] = "F11";
            hidtochar[69] = "F12";
            hidtochar[70] = "Print Screen";
            hidtochar[71] = "Scroll Lock";
            hidtochar[72] = "Break";
            hidtochar[73] = "Insert";
            hidtochar[74] = "Home";
            hidtochar[75] = "Page Up";
            hidtochar[76] = "Delete";
            hidtochar[77] = "End";
            hidtochar[78] = "Page Down";
            hidtochar[79] = "Right Arrow";
            hidtochar[80] = "Left Arrow";
            hidtochar[81] = "Down Arrow";
            hidtochar[82] = "Up Arrow";
            hidtochar[83] = "Num Lock";
            hidtochar[84] = "Keypad /";
            hidtochar[85] = "Keypad *";
            hidtochar[86] = "Keypad -";
            hidtochar[87] = "Keypad +";
            hidtochar[88] = "Keypad Enter";
            hidtochar[89] = "Keypad 1 End";
            hidtochar[90] = "Keypad 2 Down";
            hidtochar[91] = "Keypad 3 PageDn";
            hidtochar[92] = "Keypad 4 Left";
            hidtochar[93] = "Keypad 5";
            hidtochar[94] = "Keypad 6 Right";
            hidtochar[95] = "Keypad 7 Home";
            hidtochar[96] = "Keypad 8 Up";
            hidtochar[97] = "Keypad 9 PageUp";
            hidtochar[98] = "Keypad 0 Insert";
            hidtochar[99] = "Keypad . Delete";
            hidtochar[100] = "Europe 2";
            hidtochar[101] = "App";
            hidtochar[102] = "Pause/Break";  //unique to PS2 Host Emulator
            hidtochar[103] = "Keypad =";
            hidtochar[104] = "F13";
            hidtochar[105] = "F14";
            hidtochar[106] = "F15";
            hidtochar[107] = "F16";
            hidtochar[108] = "F17";
            hidtochar[109] = "F18";
            hidtochar[110] = "F19";
            hidtochar[111] = "F20";
            hidtochar[112] = "F21"; 
            hidtochar[113] = "F22";
            hidtochar[114] = "F23";
            hidtochar[115] = "F24";
            hidtochar[116] = "Keyboard Execute";
            hidtochar[117] = "Keyboard Help";
            hidtochar[118] = "Keyboard Menu";
            hidtochar[119] = "Keyboard Select";
            hidtochar[120] = "Keyboard Stop";
            hidtochar[121] = "Keyboard Again";
            hidtochar[122] = "Keyboard Undo";
            hidtochar[123] = "Keyboard Cut";
            hidtochar[124] = "Keyboard Copy";
            hidtochar[125] = "Keyboard Paste";
            hidtochar[126] = "Keyboard Find";  
            hidtochar[127] = "Keyboard Mute";
            hidtochar[128] = "Keyboard Volume Up";
            hidtochar[129] = "Keyboard Volume Dn";
            hidtochar[130] = "Keyboard Locking Caps Lock";
            hidtochar[131] = "Keyboard Locking Num Lock";
            hidtochar[132] = "Keyboard Locking Scroll Lock";
            hidtochar[133] = "Keyboard ,";
            hidtochar[134] = "Keyboard Equal Sign";
            hidtochar[135] = "Keyboard Int'l 1";
            hidtochar[136] = "Keyboard Int'l 2";
            hidtochar[137] = "Keyboard Int'l 2 Yen";
            hidtochar[138] = "Keyboard Int'l 4";
            hidtochar[139] = "Keyboard Int'l 5";
            hidtochar[140] = "Keyboard Int'l 6";
            hidtochar[141] = "Keyboard Int'l 7";
            hidtochar[142] = "Keyboard Int'l 8";
            hidtochar[143] = "Keyboard Int'l 9";
            hidtochar[144] = "Keyboard Lang 1";
            hidtochar[145] = "Keyboard Lang 2";
            hidtochar[146] = "Keyboard Lang 3";
            hidtochar[147] = "Keyboard Lang 4";
            hidtochar[148] = "Keyboard Lang 5";
            hidtochar[149] = "Keyboard Lang 6";
            hidtochar[150] = "Keyboard Lang 7";
            hidtochar[151] = "Keyboard Lang 8";
            hidtochar[152] = "Keyboard Lang 9";
            //note modifier keys do not follow the HID code standard
            hidtochar[160] = "Left Control";
            hidtochar[161] = "Left Shift";
            hidtochar[162] = "Left Alt";
            hidtochar[163] = "Left GUI";
            hidtochar[164] = "Right Control";
            hidtochar[165] = "Right Shift";
            hidtochar[166] = "Right Alt";
            hidtochar[167] = "Right GUI";
            
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
                int cbocount=0; //keeps track of how many valid devices were added to the CboDevice box
                for (int i = 0; i < devices.Length; i++)
                {
                    //information about device
                    //PID = devices[i].Pid);
                    //HID Usage = devices[i].HidUsage);
                    //HID Usage Page = devices[i].HidUsagePage);
                    //HID Version = devices[i].Version);
                    if (devices[i].HidUsagePage == 0xc)
                    {
                        switch (devices[i].Pid)
                        {
                            case 525:
                                CboDevices.Items.Add("PS2 Host Emulator (" + devices[i].Pid + "), ID: " + i);
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 514:
                                CboDevices.Items.Add("PS2 Host Emulator (" + devices[i].Pid + "), ID: " + i);
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 515:
                                CboDevices.Items.Add("PS2 Host Emulator (" + devices[i].Pid + "), ID: " + i);
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            default:
                                CboDevices.Items.Add("Unknown Device (" + devices[i].Pid + "), ID: " + i);
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                        }
                        devices[i].SetupInterface();
                    }
                }
            }
            if (CboDevices.Items.Count > 0)
            {
                CboDevices.SelectedIndex = 0;
                selecteddevice = cbotodevice[CboDevices.SelectedIndex];
                wData = new byte[devices[selecteddevice].WriteLength];//go ahead and setup for write
            }
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //closeinterfaces on all devices
            for (int i = 0; i < CboDevices.Items.Count; i++)
            {
                devices[cbotodevice[i]].CloseInterface();
            }
            System.Environment.Exit(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
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
        //data callback    
        public void HandlePIEHidData(Byte[] data, PIEDevice sourceDevice, int error)
        {
            //check the sourceDevice and make sure it is the same device as selected in CboDevice   
            if (sourceDevice == devices[selecteddevice])
            {
                //finish reading whole buffer so don't miss any data
                
                    //write raw data to listbox1
                    String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                    String keysdown = "";
                    String mousedata;
                    for (int i = 0; i < 6; i++)
                    {
                        output = output + data[i].ToString() + " ";
                    }
                    this.SetListBox(output);
                    //mouse data has 2nd byte = 4 if plugged in Device 1 port or 2nd byte = 8 if plugged in Device 2 port.

                    if (data[1] == 4 || data[1] == 8) //mouse data
                    {
                        //fill in mouseport
                        switch (data[1])
                        {
                            case 4:
                                mouseport = 0;  //mouse on Device 2
                                break;
                            case 8:
                                mouseport = 1;  //mouse on Device 1
                                break;
                        }

                        mousedata = "X: " + data[3].ToString() + "  Y: " + data[4].ToString() + "  ";
                        byte val = (byte)(data[2] & 1);
                        if (val!=0)
                        {
                            mousedata = mousedata + "Left Click  ";
                        }
                        val = (byte)(data[2] & 2);
                        if (val!=0)
                        {
                            mousedata = mousedata + "Right Click  ";
                        }
                        val = (byte)(data[2] & 4);
                        if (val!=0)
                        {
                            mousedata = mousedata + "Center Click  ";
                        }
                        c = this.LblMouse;
                        this.SetText(mousedata);
                        //scroll bar
                        if (data[5] == 1) SetScrollBar(-10);
                        else if (data[5] == 255) SetScrollBar(10);
                        
                    }
                
                    //keyboard data has 2nd byte = 5 if plugged in Device 1 port or 2nd byte = 1 if plugged in Device 2 port.
                    if (data[1] == 1 || data[1] == 5) //this is keyboard data
                    {
                        //write out the keys pressed
                        for (int i = 2; i < 6; i++)
                        {
                            keysdown = keysdown + hidtochar[data[i]] + "  ";
                        }
                        
                        c = this.LblKeysPressed;
                        this.SetText(keysdown);
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
        private void SetScrollBar(int text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.vScrollBar1.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(SetScrollBar);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.vScrollBar1.Value = this.vScrollBar1.Value + text;    
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

      

        private void BtnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void BtnSlow_Click(object sender, EventArgs e)
        {
            //This code is for slowing down the mouse messages if there is too much "lag" .
            
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                
                string portdes="Device 2";
                if (mouseport == 1) portdes = "Device 1"; 
                string msg="Is mouse plugged into "+portdes+"?  If so click Yes.  To change to the other port click No. To do nothing click Cancel.";
                DialogResult dlgresult = MessageBox.Show(msg, "PS2 Host Emulator Demo", MessageBoxButtons.YesNoCancel);
                if (dlgresult == System.Windows.Forms.DialogResult.Cancel)
                {
                     return;  
                }
                else if (dlgresult == System.Windows.Forms.DialogResult.No)
                {
                    mouseport = (mouseport)^1;
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = (byte) mouseport;
                wData[2] = 0xF3;

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "1st Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success";
                }
                System.Threading.Thread.Sleep(50);  //wait for first write to finish and do second
                wData[1] = (byte) mouseport;
                wData[2] = 0x14;

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "2nd Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success";
                }
            }
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            //This code is for returning the mouse messages to the default setting.

            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                string portdes = "Device 2";
                if (mouseport == 1) portdes = "Device 1";
                string msg = "Is mouse plugged into " + portdes + "?  If so click Yes.  To change to the other port click No. To do nothing click Cancel.";
                DialogResult dlgresult = MessageBox.Show(msg, "PS2 Host Emulator Demo", MessageBoxButtons.YesNoCancel);
                if (dlgresult == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                else if (dlgresult == System.Windows.Forms.DialogResult.No)
                {
                    mouseport = (mouseport)^1;
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = (byte) mouseport;
                wData[2] = 0xF3;

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }

                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "1st Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success";
                }
                System.Threading.Thread.Sleep(50);  //wait for first write to finish and do second
                wData[1] = (byte) mouseport;
                wData[2] = 0x3C;

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "2nd Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success";
                }
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

       
     
       
       
    }
    
    
}
