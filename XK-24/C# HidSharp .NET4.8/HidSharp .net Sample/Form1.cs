using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HidSharp; //documentation: https://docs.zer7.com/hidsharp/#, nuget: https://www.nuget.org/packages/HidSharp/
using System.Threading; //add for ReadInputThreadFunction

namespace HidSharp_Sample
{
    public partial class Form1 : Form
    {
        HidDevice[] cbotodeviceHS = null; //for each item in the CboDevice list maps this index to the device index. 

       
        HidDevice selecteddeviceHS = null;
        //HidStream hidStream;
        Thread thread; //for reading input 

        long saveabsolutetime;  //for timestamp demo

        
        //for thread-safe way to call a Windows Forms control
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        Control c;
        ListBox lb;
        //end thread-safe
        byte[] lastdata = null;


        public Form1()
        {
            InitializeComponent();
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
            if (this.lb.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetListBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lb.Items.Add(text);
                this.lb.SelectedIndex = this.lb.Items.Count - 1;
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
            CboBL.SelectedIndex = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

      

      



        private void BtnUnitID_Click(object sender, EventArgs e)
        {
            //Write Unit ID to the device
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 189; //0xbd
                        outputReportBuffer[2] = (byte)(Convert.ToInt16(TxtSetUnitID.Text));
                       
                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }

        private void BtnBL_Click(object sender, EventArgs e)
        {
            //Set backlight intensity
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 187; //0xbb
                        outputReportBuffer[2] = (byte)(Convert.ToInt16(TxtIntensity.Text)); //0-255 for brightness of bank 1 bl leds
                        outputReportBuffer[3] = (byte)(Convert.ToInt16(TxtIntensity2.Text)); //0-255 for brightness of bank 2 bl leds
                        
                        hidStream.Write(outputReportBuffer);
                    }
                }
            }
            
        }

        private void BtnBLToggle_Click(object sender, EventArgs e)
        {
            //Sending this command toggles the backlights
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 184; //0xb8

                        hidStream.Write(outputReportBuffer);
                    }
                }
            }
            
        }

        private void ChkScrollLock_CheckedChanged(object sender, EventArgs e)
        {
            
           
        }

        

        private void BtnSetFlash_Click(object sender, EventArgs e)
        {
            //Sets the frequency of flashing for both the LEDs and backlighting
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 180; // 0xb4
                        outputReportBuffer[2] = (byte)(Convert.ToInt16(TxtFlashFreq.Text));

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }



        private void BtnSaveBL_Click(object sender, EventArgs e)
        {
            //Write current state of backlighting to EEPROM.  
            //NOTE: Is it not recommended to do this frequently as there are a finite number of writes to the EEPROM allowed
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 199;
                        outputReportBuffer[2] = 1; //anything other than 0 will save bl state to eeprom, default is 0

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }

        private void BtnTimeStamp_Click(object sender, EventArgs e)
        {
            //Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 210; //0xd2
                        outputReportBuffer[2] = 0;

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
          
        }

        private void BtnTimeStampOn_Click(object sender, EventArgs e)
        {
            //Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 210;
                        outputReportBuffer[2] = 1;  //default ON

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }

        private void BtnKBreflect_Click(object sender, EventArgs e)
        {
            //Sends native keyboard messages
            //Write some keys to the textbox, should be Abcd
            //send some hid codes to the textbox, these will be coming in on the native keyboard endpoint
            if (selecteddeviceHS != null)
            {
                textBox1.Focus();
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 201;

                        outputReportBuffer[2] = 2;       //modifiers
                        outputReportBuffer[3] = 0;       //always 0
                        outputReportBuffer[4] = 0x04;    //hid code = a down
                        outputReportBuffer[5] = 0;
                        outputReportBuffer[6] = 0;
                        outputReportBuffer[7] = 0;
                        outputReportBuffer[8] = 0;
                        outputReportBuffer[9] = 0;

                        hidStream.Write(outputReportBuffer);

                        outputReportBuffer[2] = 0;       //modifiers
                        outputReportBuffer[3] = 0;       //always 0
                        outputReportBuffer[4] = 0;    //hid code = a up
                        outputReportBuffer[5] = 0x05;    //hid code = b down
                        outputReportBuffer[6] = 0x06;    //hid code = c down
                        outputReportBuffer[7] = 0x07;    //hid code = d down
                        outputReportBuffer[8] = 0;
                        outputReportBuffer[9] = 0;

                        hidStream.Write(outputReportBuffer);

                        outputReportBuffer[2] = 0;
                        outputReportBuffer[4] = 0;
                        outputReportBuffer[5] = 0;  //b up
                        outputReportBuffer[6] = 0;  //c up
                        outputReportBuffer[7] = 0;  //d up
                        outputReportBuffer[8] = 0;
                        outputReportBuffer[9] = 0;

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }

        private void BtnJoyreflect_Click(object sender, EventArgs e)
        {
            //Sends native joystick messages
            //Open up the game controller control panel to test these features, after clicking this button
            //go and make active the control panel properties and change will be seen
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 202;    //0xca
                        outputReportBuffer[2] = (byte)Math.Abs((Convert.ToByte(textBox2.Text) ^ 127) - 255);  //X, in raw form 0 to 127 from center to right, 255 to 128 from center to left but I like to use 0-255 where 0 is max left, 255 is max right
                        outputReportBuffer[3] = (byte)(Convert.ToByte(textBox3.Text) ^ 127); //Y, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                        outputReportBuffer[4] = (byte)(Convert.ToByte(textBox12.Text) ^ 127); //Z rotation, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                        outputReportBuffer[5] = (byte)(Convert.ToByte(textBox4.Text) ^ 127); //Z, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
                        outputReportBuffer[6] = (byte)(Convert.ToByte(textBox13.Text) ^ 127); //Slider rotation, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255

                        outputReportBuffer[7] = Convert.ToByte(textBox5.Text); //buttons 1-8, where bit 1 is button 1, bit 1 is button 2, etc.
                        outputReportBuffer[8] = Convert.ToByte(textBox7.Text); //buttons 9-16
                        outputReportBuffer[9] = Convert.ToByte(textBox8.Text); //buttons 17-24
                        outputReportBuffer[10] = Convert.ToByte(textBox9.Text); //buttons 25-32
                        outputReportBuffer[11] = 0;
                        outputReportBuffer[12] = Convert.ToByte(textBox6.Text); //hat, where 0 is straight up, 1 is 45deg cw, etc and 8 is no hat

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }

        private void BtnDescriptor_Click(object sender, EventArgs e)
        {
            //Sending the command will make the device return information about it
            if (selecteddeviceHS != null)
            {
                listBox2.Items.Clear();
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 214; 

                        hidStream.Write(outputReportBuffer);
                        //data returned in read timer
                    }
                }
            }

            
        }

        private void ChkGreenLED_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox thischkbox = (CheckBox)sender;
            byte ledindex = Convert.ToByte(thischkbox.Tag.ToString());
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 179; //0xb3
                        outputReportBuffer[2] = ledindex; //6 for green, 7 for red
                        outputReportBuffer[3] = (byte)thischkbox.CheckState; //0=off, 1=on, 2=flash

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
        }

        private void ChkBLOnOff_CheckedChanged(object sender, EventArgs e)
        {
            //Use the Set Flash Freq to control frequency of blink
            //Key Index for XK-24 (in decimal)
            //Columns-->
            //  0   8   16  24
            //  1   9   17  25
            //  2   10  18  26
            //  3   11  19  27
            //  4   12  20  28
            //  5   13  21  29
            if (selecteddeviceHS != null)
            {
                string sindex = CboBL.Text;
                int iindex;
                if (sindex.IndexOf("-b1") != -1) //bank 1 backlights
                {
                    sindex = sindex.Remove(sindex.IndexOf("-b1"), 3);
                    iindex = Convert.ToInt16(sindex);
                }
                else //bank 2 backlight
                {
                    sindex = sindex.Remove(sindex.IndexOf("-b2"), 3);
                    iindex = Convert.ToInt16(sindex) + 32;  //Add 32 to get corresponding bank 2 index
                }
                //now get state
                byte state = (byte)ChkBLOnOff.CheckState;
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 185; //0xb5
                        outputReportBuffer[2] = (byte)(iindex); //Key Index
                        outputReportBuffer[3] = state; //0=off, 1=on, 2=flash

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }

           
        }

        private void ChkBLOnOff_CheckStateChanged(object sender, EventArgs e)
        {
            //Use the Set Flash Freq to control frequency of blink
            //Key Index for XK-24 (in decimal)
            //Columns-->
            //  0   8   16  24
            //  1   9   17  25
            //  2   10  18  26
            //  3   11  19  27
            //  4   12  20  28
            //  5   13  21  29

            if (selecteddeviceHS != null)
            {
                //first get selected index
                string sindex = CboBL.Text;
                int iindex;
                if (sindex.IndexOf("-b1") != -1) //bank 1 backlights
                {
                    sindex = sindex.Remove(sindex.IndexOf("-b1"), 3);
                    iindex = Convert.ToInt16(sindex);
                }
                else //bank 2 backlight
                {
                    sindex = sindex.Remove(sindex.IndexOf("-b2"), 3);
                    iindex = Convert.ToInt16(sindex) + 32;  //Add 32 to get corresponding bank 2 index
                }
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 181; //0xb5
                        outputReportBuffer[2] = (byte)(iindex); //Key Index
                        outputReportBuffer[3] = (byte)ChkBLOnOff.CheckState; //0=off, 1=on, 2=flash

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
        }

        private void BtnGetDataNow_Click(object sender, EventArgs e)
        {
            //After sending this command a general incoming data report will be given with
            //the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
            //and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
            //or unit id of the device before it sends any data.
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 177; //0xb1
                        
                        hidStream.Write(outputReportBuffer);
                    }
                }
            }
            
        }

        private void BtnMousereflect_Click(object sender, EventArgs e)
        {
            //Mouse reflector - valid for PIDs 1, 2, and 4
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }

                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 203;    //0xcb
                        outputReportBuffer[2] = Convert.ToByte(TxtMouseButton.Text); //Buttons; 1=Left, 2=Right, 4=Center, 8=XButton1, 16=XButton2
                        outputReportBuffer[3] = Convert.ToByte(TxtMouseX.Text); //Mouse X motion. 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129).
                        outputReportBuffer[4] = Convert.ToByte(TxtMouseY.Text); //Mouse Y motion. 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129).
                        outputReportBuffer[5] = 0;//Wheel X. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
                        outputReportBuffer[6] = Convert.ToByte(TxtMouseWheel.Text);//Wheel Y. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).

                        hidStream.Write(outputReportBuffer);

                        //now send all 0s
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 203;    //0xcb
                        outputReportBuffer[2] = 0; //buttons
                        outputReportBuffer[3] = 0; //X
                        outputReportBuffer[4] = 0; //Y
                        outputReportBuffer[5] = 0; //wheel X
                        outputReportBuffer[6] = 0; //wheel Y

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }

        private void BtnPID1_Click(object sender, EventArgs e)
        {

            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 204; //0xcc
                        outputReportBuffer[2] = 0; //0=PID #1 (1027), 1=PID #2 (1028), 2=PID #3 (1029), 3=PID #4 (1249)

                        hidStream.Write(outputReportBuffer);
                    }
                }
            }

            
        }

        private void BtnPID2_Click(object sender, EventArgs e)
        {
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 204; //0xcc
                        outputReportBuffer[2] = 1; //0=PID #1 (1027), 1=PID #2 (1028), 2=PID #3 (1029), 3=PID #4 (1249)

                        hidStream.Write(outputReportBuffer);
                    }
                }
            }


        }

        private void BtnPID3_Click(object sender, EventArgs e)
        {
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 204; //0xcc
                        outputReportBuffer[2] = 2; //0=PID #1 (1027), 1=PID #2 (1028), 2=PID #3 (1029), 3=PID #4 (1249)

                        hidStream.Write(outputReportBuffer);
                    }
                }
            }

            
        }

        private void BtnPID4_Click(object sender, EventArgs e)
        {
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[1] = 204; //0xcc
                        outputReportBuffer[2] = 3; //0=PID #1 (1027), 1=PID #2 (1028), 2=PID #3 (1029), 3=PID #4 (1249)

                        hidStream.Write(outputReportBuffer);
                    }
                }
            }


        }

        private void BtnCustom_Click(object sender, EventArgs e)
        {
            //This report available only on v30 firmware and above
            //After sending this command a custom incoming data report will be given with
            //the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
            //and the following bytes whatever the user wishes.  In this example we are sending 3 bytes; 1, 2, 3
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 224; //0xe0
                        outputReportBuffer[2] = 3; //count of bytes to follow
                        outputReportBuffer[3] = 1; //1st custom byte
                        outputReportBuffer[4] = 2; //2nd custom byte
                        outputReportBuffer[5] = 3; //3rd custom byte

                        hidStream.Write(outputReportBuffer);
                    }
                }
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

            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 0xe1;
                        outputReportBuffer[2] = HexToBin(TxtMMLow.Text); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                        outputReportBuffer[3] = HexToBin(TxtMMHigh.Text); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                        hidStream.Write(outputReportBuffer);

                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 0xe1;
                        outputReportBuffer[2] = 0; //terminate
                        outputReportBuffer[3] = 0; //terminate

                        hidStream.Write(outputReportBuffer);

                        //note when the "terminate" command is sent can sometimes have an effect on the behavior of the command
                        //for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the e1 command it will
                        //decrement the volume one step, if you send the e1 on the press and the terminate on the release the volume will continuously
                        //decrement until the key is released.
                    }
                }
            }

            
        }
        private void BtnMyComputer_Click(object sender, EventArgs e)
        {
            //Multimedia available on v30 firmware or above.
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 0xe1;
                        outputReportBuffer[2] = HexToBin("94"); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
                        outputReportBuffer[3] = HexToBin("01"); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

                        hidStream.Write(outputReportBuffer);

                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 0xe1;
                        outputReportBuffer[2] = 0; //terminate
                        outputReportBuffer[3] = 0; //terminate

                        hidStream.Write(outputReportBuffer);

                        //note when the "terminate" command is sent can sometimes have an effect on the behavior of the command
                        //for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the e1 command it will
                        //decrement the volume one step, if you send the e1 on the press and the terminate on the release the volume will continuously
                        //decrement until the key is released.
                    }
                }
            }
            
        }

        private void BtnSleep_Click(object sender, EventArgs e)
        {
            //Multimedia available on v30 firmware or above.
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 0xe2;
                        outputReportBuffer[2] = 2; //1=power down, 2=sleep, 4=wake up

                        hidStream.Write(outputReportBuffer);

                        //NOTE this needs to be on the release of the key!!

                        System.Threading.Thread.Sleep(1000); //this to simulate press/release

                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 0xe2;
                        outputReportBuffer[2] = 0;

                        hidStream.Write(outputReportBuffer);


                    }
                }
            }
            
        }

        private void BtnVersion_Click(object sender, EventArgs e)
        {
            //This report available only on v30 firmware and above
            //Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
            //newly written version!
            if (selecteddeviceHS != null)
            {
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }
                        
                        outputReportBuffer[0] = 0;
                        outputReportBuffer[1] = 195; //c3
                        outputReportBuffer[2] = (byte)(Convert.ToInt16(TxtVersion.Text));
                        outputReportBuffer[3] = (byte)((Convert.ToInt16(TxtVersion.Text)) >> 8);

                        hidStream.Write(outputReportBuffer);

                    }
                }
            }
            
        }

        

        private void btnEnumerateHS_Click(object sender, EventArgs e)
        {
            CboDevicesHS.Items.Clear();
            cbotodeviceHS = new HidDevice[128]; //128=max # of devices
            int cbocount = 0; //keeps track of how many valid devices were added to the CboDeviceHS box
            selecteddeviceHS = null;
            var list = DeviceList.Local;
            //var hidDeviceList = list.GetHidDevices().ToArray(); //this gets every device connected

            foreach (HidDevice device in HidSharp.DeviceList.Local.GetHidDevices(0x05F3))
            {
                try
                {
                    string path = device.DevicePath;
                    int inputReportLen = device.GetMaxInputReportLength();
                    int outputReportLen = device.GetMaxOutputReportLength();
                    int maxfeatureReportLen = device.GetMaxFeatureReportLength();
                    string manufacturer = device.GetManufacturer();
                    string productname = device.GetProductName();
                    int oemversion = device.ReleaseNumberBcd;
                    int vid = device.VendorID;
                    int pid = device.ProductID;
                    //string serialnumber = device.GetSerialNumber(); //errors for encore devices
                    //HidSharp.Reports.ReportDescriptor thisdescriptor = device.GetReportDescriptor();
                    //in order to get the hidusagepage and hidusage
                    byte[] rawreport = device.GetRawReportDescriptor(); //get the raw report, the 1st 4 bytes give the hid usage and the usage; 05 xx 09 xx
                    int hidusagepage = -1;
                    if (rawreport[0] == 5) hidusagepage = rawreport[1];
                    int hidusage = -1;
                    if (rawreport[2] == 9) hidusage = rawreport[3];

                    //or other way-should be same as above
                    var reportDescriptor = device.GetReportDescriptor();
                    int inputReportLen2 = reportDescriptor.MaxInputReportLength;
                    int outputReportLen2 = reportDescriptor.MaxOutputReportLength;
                    int maxfeatureReportLen2 = reportDescriptor.MaxFeatureReportLength; 

                    if (vid == 0x05F3 && hidusagepage==0x0C && outputReportLen>10) //PI product's consumer page endpoint
                    {

                        switch (pid)
                        {
                            case 1027:
                                //Device 2 Keyboard, Joystick, Input and Output endpoints, PID #3
                                CboDevicesHS.Items.Add(productname + " (" + pid.ToString() + "=PID #1)");
                                cbotodeviceHS[cbocount] = device;
                                cbocount++;
                                break;
                            case 1028:
                                //Device 1 Keyboard, Joystick, Mouse and Output endpoints,. PID #2
                                CboDevicesHS.Items.Add(productname + " (" + pid.ToString() + "=PID #2)");
                                cbotodeviceHS[cbocount] = device;
                                cbocount++;
                                break;
                            case 1029:
                                //Device 0 Keyboard, Mouse, Input and Output endpoints (factory default), PID #1
                                CboDevicesHS.Items.Add(productname + " (" + pid + "=PID #3)");
                                cbotodeviceHS[cbocount] = device;
                                cbocount++;
                                break;
                            case 1249:
                                //Device 3 Keyboard, Multimedia, Mouse and Output endpoints, PID #4
                                CboDevicesHS.Items.Add(productname + " (" + pid + "=PID #4)");
                                cbotodeviceHS[cbocount] = device;
                                cbocount++;
                                break;
                            default:
                                CboDevicesHS.Items.Add("Unknown Device: " + productname + " (" + pid + ")");
                                cbotodeviceHS[cbocount] = device;
                                cbocount++;
                                break;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }

            if (cbocount>0)
            {
                CboDevicesHS.SelectedIndex = 0;
                selecteddeviceHS = cbotodeviceHS[CboDevicesHS.SelectedIndex];
                LblVersion.Text = selecteddeviceHS.ReleaseNumberBcd.ToString();
                lastdata = new byte[selecteddeviceHS.GetMaxInputReportLength()];
            }
            else
            {
                toolStripStatusLabel1.Text = "No P.I. Engineering devices found";
            }
        }

        void WriteDeviceItemInputParserResult(HidSharp.Reports.Input.DeviceItemInputParser parser)
        {
            //#if SHOW_CHANGES_ONLY
            while (parser.HasChanged)
            {
                int changedIndex = parser.GetNextChangedIndex();
                var previousDataValue = parser.GetPreviousValue(changedIndex);
                var dataValue = parser.GetValue(changedIndex);

                c = LblButtons;
                this.SetText(string.Format("  {0}: {1} -> {2}", (HidSharp.Reports.Usage)dataValue.Usages.FirstOrDefault(), previousDataValue.GetPhysicalValue(), dataValue.GetPhysicalValue()).Trim());

                //Console.WriteLine(string.Format("  {0}: {1} -> {2}", (HidSharp.Reports.Usage)dataValue.Usages.FirstOrDefault(), previousDataValue.GetPhysicalValue(), dataValue.GetPhysicalValue()));
            }
        }
        public void ReadInputThreadFunction()
        {
            //Read the selected device
            try
            {
                // do any background work
                var reportDescriptor = selecteddeviceHS.GetReportDescriptor();
                foreach (var deviceItem in reportDescriptor.DeviceItems)
                {
                    //try to open device
                    HidStream hidStream;
                    if (selecteddeviceHS.TryOpen(out hidStream))
                    {
                        hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                        using (hidStream)
                        {
                            var inputReportBuffer = new byte[selecteddeviceHS.GetMaxInputReportLength()]; //for incoming data
                            var inputReceiver = reportDescriptor.CreateHidDeviceInputReceiver();
                            var inputParser = deviceItem.CreateDeviceItemInputParser();

                            //#if SINGLE_THREADED_WAITHANDLE_APPROACH 
                            inputReceiver.Start(hidStream);
                           
                            while (true)
                            {
                               
                                if (!inputReceiver.IsRunning) { break; } // Disconnected?

                                HidSharp.Reports.Report report;
                                while (inputReceiver.TryRead(inputReportBuffer, 0, out report))
                                {
                                    //display the raw bytes received
                                    string hexofbytes = selecteddeviceHS.ProductID.ToString() + ", data=";
                                    for (int i = 0; i < inputReportBuffer.Length; i++)
                                    {
                                        hexofbytes = hexofbytes + BinToHex(inputReportBuffer[i]) + " ";
                                    }
                                    lb = this.listBox1;
                                    this.SetListBox(hexofbytes);

                                    //check the program switch byte 
                                    byte val2 = (byte)(inputReportBuffer[2] & 1);
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
                                    //read the unit ID
                                    c = this.LblUnitID;
                                    this.SetText(inputReportBuffer[1].ToString());

                                    if (inputReportBuffer[2] < 3) //button data
                                    {
                                        // Parse the report if possible.
                                        // This will return false if (for example) the report applies to a different DeviceItem.
                                        if (inputParser.TryParseReport(inputReportBuffer, 0, report))
                                        {
                                            WriteDeviceItemInputParserResult(inputParser);
                                        }

                                        //time stamp info 4 bytes
                                        long absolutetime = 16777216 * inputReportBuffer[7] + 65536 * inputReportBuffer[8] + 256 * inputReportBuffer[9] + inputReportBuffer[10];  //ms
                                        long absolutetime2 = absolutetime / 1000; //seconds
                                        c = this.label19;
                                        this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                                        long deltatime = absolutetime - saveabsolutetime;
                                        c = this.label20;
                                        this.SetText("delta time: " + deltatime + " ms");
                                        saveabsolutetime = absolutetime;
                                    }
                                    else if (inputReportBuffer[2]==214) //descriptor data
                                    {
                                        lb = this.listBox2;

                                        this.SetListBox(hexofbytes);
                                    }
                                }
                            } //end while
                        } //end using
                    } //end TryOpen
                }


            }
            catch (Exception ex)
            {
                // log errors
            }
        }

        private void BtnReadInput_Click(object sender, EventArgs e)
        {
            //Start or Stop the read thread that reads in the input from the selected device
            if (selecteddeviceHS == null) return;

            if (BtnReadInput.Text.Contains("Start"))
            {
                BtnReadInput.Text = "Stop Reading";
                //Create new thread, see https://www.csharp-examples.net/create-new-thread/#:~:text=First%2C%20create%20a%20new%20ThreadStart,Finally%2C%20call%20the%20Thread.
                thread = new Thread(new ThreadStart(ReadInputThreadFunction)); 
                thread.Start();
            }
            else
            {
                BtnReadInput.Text = "Start Reading";
                thread.Abort();
                
            }
        }

        private void CboDevicesHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecteddeviceHS = cbotodeviceHS[CboDevicesHS.SelectedIndex];
            LblVersion.Text = selecteddeviceHS.ReleaseNumberBcd.ToString();
            lastdata = new byte[selecteddeviceHS.GetMaxInputReportLength()];
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

        private void ChkBank1OnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (selecteddeviceHS != null)
            {
                byte sl = 0;
                if (ChkBank1OnOff.Checked == true) sl = 255;
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }

                        outputReportBuffer[1] = 182; //0xb6
                        outputReportBuffer[2] = 0; //0 for bank 1, 1 for bank 2
                        outputReportBuffer[3] = (byte)sl; //OR turn individual rows on or off using bits.  1st bit=row 1, 2nd bit=row 2, 3rd bit =row 3, etc

                        hidStream.Write(outputReportBuffer);
                    }
                }
            }
        }

        private void ChkBank2OnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (selecteddeviceHS != null)
            {
                byte sl = 0;
                if (ChkBank2OnOff.Checked == true) sl = 255;
                HidStream hidStream;
                if (selecteddeviceHS.TryOpen(out hidStream))
                {
                    hidStream.ReadTimeout = System.Threading.Timeout.Infinite;
                    using (hidStream)
                    {
                        var outputReportBuffer = new byte[selecteddeviceHS.GetMaxOutputReportLength()]; //for incoming data
                        for (int j = 0; j < selecteddeviceHS.GetMaxOutputReportLength(); j++)
                        {
                            outputReportBuffer[j] = 0;
                        }

                        outputReportBuffer[1] = 182; //0xb6
                        outputReportBuffer[2] = 1; //0 for bank 1, 1 for bank 2
                        outputReportBuffer[3] = (byte)sl; //OR turn individual rows on or off using bits.  1st bit=row 1, 2nd bit=row 2, 3rd bit =row 3, etc

                        hidStream.Write(outputReportBuffer);
                    }
                }
            }
        }

        //---------------------------------------------------------------------------------------------------

    }
}
