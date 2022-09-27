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

       
        byte[] lastdata = null;
        
       
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
                   //check the switch byte 
                    byte val2 = (byte)(data[2] & 1);
                    if (val2 == 0)
                    {
                        c = this.LblSwitchPos;
                        this.SetText("Switch up");

                    }
                    else
                    {
                        c = this.LblSwitchPos;
                        this.SetText("Switch down");

                    }
                    //read the unit ID
                    c = this.LblUnitID;
                    this.SetText(data[1].ToString());

                    //write raw data to listbox1
                    String output = "Callback: " + sourceDevice.Pid + ", ID: " + selecteddevice.ToString() + ", data=";
                    for (int i = 0; i < sourceDevice.ReadLength; i++)
                    {
                        output = output + BinToHex(data[i]) + " ";
                    }
                    this.SetListBox(output);

                    //buttons
                    if (data[2] < 3)
                    {
                        int maxcols = 10;
                        int maxrows = 8;
                        c = this.LblButtons;
                        string buttonsdown = "Buttons: ";
                        this.SetText(buttonsdown);

                        for (int i = 0; i < maxcols; i++)
                        {
                            if (i == 3 || i == 4 || i == 5 || i == 6) maxrows = 5;
                            else maxrows = 8;
                            for (int j = 0; j < maxrows; j++)
                            {
                                int temp1 = (int)Math.Pow(2, j);
                                int keynum = 8 * i + j; //using key numbering in sdk; C1=0,1,2 C2=8,8,10 C3=16,17,18 C4=24,25,26
                                byte temp2 = (byte)(data[i + 3] & temp1); //this time
                                byte temp3 = (byte)(lastdata[i + 3] & temp1);  //last time
                                int state = 0; //0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                                if (temp2 != 0 && temp3 == 0) state = 1; //press
                                else if (temp2 != 0 && temp3 != 0) state = 2; //held down
                                else if (temp2 == 0 && temp3 != 0) state = 3; //release
                                switch (state)
                                {
                                    case 1:
                                        buttonsdown = buttonsdown + keynum.ToString() + " ";
                                        c = this.LblButtons;
                                        SetText(buttonsdown);
                                        break;
                                    case 2:
                                        buttonsdown = buttonsdown + keynum.ToString() + " ";
                                        c = this.LblButtons;
                                        SetText(buttonsdown);
                                        break;
                                    case 3:
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
                                    //Next column of buttons
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
                                    //Next column of buttons
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
                                    //Next column of buttons
                                    case 24: //button 24
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 25: //button 25
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 26: //button 26
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 27: //button 27
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 28: //button 28
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
                                    //Buttons 29-31 covered by Jog and Shuttle.                                
                                    case 32: //button 32
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 33: //button 33
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 34: //button 34
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 35: //button 35
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 36: //button 36
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
                                    //Buttons 37-39 covered by Jog and Shuttle.
                                    case 40: //button 40
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 41: //button 41
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 42: //button 42
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 43: //button 43
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 44: //button 44
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
                                    //Buttons 45-47 covered by Jog and Shuttle.			     

                                    case 48: //button 48
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 49: //button 49
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 50: //button 50
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 51: //button 51
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;

                                    case 52: //button 52
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
                                    //Buttons 53-55 covered by Jog and Shuttle.			     
                                    case 56: //button 56
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 57: //button 57
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 58: //button 58
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 59: //button 59
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 60: //button 60
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 61: //button 61
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 62: //button 62
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 63: //button 63
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
                                    case 64: //button 64
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 65: //button 65
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 66: //button 66
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 67: //button 67
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;


                                    case 68: //button 68
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 69: //button 69
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 70: //button 70
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 71: //button 71
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
                                    case 72: //button 72
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 73: //button 73
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 74: //button 74
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 75: //button 75
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 76: //button 76
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 77: //button 77
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 78: //button 78
                                        if (state == 1) //key was pressed
                                        {
                                            //do press actions
                                        }
                                        else if (state == 3) //key was released
                                        {
                                            //do release action
                                        }
                                        break;
                                    case 79: //button 79
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
			     

                                }
                            }
                        }

                        //states of the numlock, capslock and scrlock

                        byte temp = (byte)(data[15] & 4);
                        string keystate = "State: ";
                        if (temp != 0)
                        {
                            keystate = keystate + "NumLk";
                        }
                        temp = (byte)(data[15] & 8);
                        if (temp != 0)
                        {
                            keystate = keystate + " CapsLk";
                        }
                        temp = (byte)(data[15] & 16);
                        if (temp != 0)
                        {
                            keystate = keystate + " ScrLk";
                        }
                        c = this.LblSpecialKeys;
                        this.SetText(keystate);

                        //shuttle
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 7; j++) //the digital shuttle
                            {
                                int temp1 = (int)Math.Pow(2, j);
                                int keynum = 8 * i + j;
                                byte temp2 = (byte)(data[i + 13] & temp1); //this time
                                byte temp3 = (byte)(lastdata[i + 13] & temp1);  //last time
                                int state = 0; //0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                                if (temp2 != 0 && temp3 == 0) state = 1; //press
                                else if (temp2 != 0 && temp3 != 0) state = 2; //held down
                                else if (temp2 == 0 && temp3 != 0) state = 3; //release
                                string printthis = "";
                                switch (keynum)
                                {

                                    case 0: //shuttle +1
                                        printthis = "Shuttle Digital: +1";
                                        break;
                                    case 1: //shuttl +2
                                        printthis = "Shuttle Digital: +2";
                                        break;
                                    case 2: //shuttle +3
                                        printthis = "Shuttle Digital: +3";
                                        break;
                                    case 3: //shuttle +4
                                        printthis = "Shuttle Digital: +4";
                                        break;
                                    case 4: //shuttle +5
                                        printthis = "Shuttle Digital: +5";
                                        break;
                                    case 5: //shuttle +6
                                        printthis = "Shuttle Digital: +6";
                                        break;
                                    case 6: //shuttle +7
                                        printthis = "Shuttle Digital: +7";
                                        break;
                                    case 8: //shuttle -1
                                        printthis = "Shuttle Digital: -1";
                                        break;
                                    case 9: //shuttl -2
                                        printthis = "Shuttle Digital: -2";
                                        break;
                                    case 10: //shuttle -3
                                        printthis = "Shuttle Digital: -3";
                                        break;
                                    case 11: //shuttle -4
                                        printthis = "Shuttle Digital: -4";
                                        break;
                                    case 12: //shuttle -5
                                        printthis = "Shuttle Digital: -5";
                                        break;
                                    case 13: //shuttle -6
                                        printthis = "Shuttle Digital: -6";
                                        break;
                                    case 14: //shuttle -7
                                        printthis = "Shuttle Digital: -7";
                                        break;
                                }

                                if (state == 1)
                                {
                                    c = this.LblShuttleD;
                                    SetText(printthis);
                                }
                            }
                        }

                        //Jog and Shuttle Digital
                        byte val = (byte)(data[8] & 0x80);
                        if (val != 0)
                        {
                            c = LblShuttleD;
                            SetText("Shuttle Digital: At rest");
                        }
                        val = (byte)(data[6] & 0x80);
                        if (val != 0)
                        {
                            c = LblJogD;
                            SetText("Jog Digital: Clockwise");
                        }
                        val = (byte)(data[7] & 0x80);
                        if (val != 0)
                        {
                            c = LblJogD;
                            SetText("Jog Digital: Counter Clockwise");
                        }

                        //jog analog
                        if (data[17] == 1) //cw
                        {
                            c = this.LblJog;
                            this.SetText("Jog Analog: Clockwise");
                        }
                        else if (data[17] == 255)
                        {
                            c = this.LblJog;
                            this.SetText("Jog Analog: Counter Clockwise");
                        }
                        c = this.label4;
                        this.SetText(data[17].ToString());

                        //shuttle analog
                        c = this.LblShuttle;
                        this.SetText("Shuttle Analog: " + (data[18]).ToString());

                        //time stamp info 4 bytes
                        long absolutetime = 16777216 * data[19] + 65536 * data[20] + 256 * data[21] + data[22];  //ms
                        long absolutetime2 = absolutetime / 1000; //seconds
                        c = this.label19;
                        this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                        long deltatime = absolutetime - saveabsolutetime;
                        c = this.label20;
                        this.SetText("delta time: " + deltatime + " ms");
                        saveabsolutetime = absolutetime;

                        
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
            lastdata = new byte[devices[selecteddevice].ReadLength];
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
                    //HID Version = devices[i].Version);
                    int hidusagepg = devices[i].HidUsagePage;
                    int hidusage = devices[i].HidUsage;
                    if (devices[i].HidUsagePage == 0xc)
                    {
                        switch (devices[i].Pid)
                        {
                            case 0x45A:
                                //Device 0 Keyboard, Mouse, Input and Output endpoints
                                CboDevices.Items.Add("XK-68 Jog & Shuttle ("+devices[i].Pid+"=PID #1), ID: " + i);
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 0x45B:
                                //Device 1 Keyboard, Joystick, Mouse and Output endpoints
                                CboDevices.Items.Add("XK-68 Jog & Shuttle (" + devices[i].Pid + "), ID: " + i);
                                cbotodevice[cbocount] = i;
                                cbocount++;
                                break;
                            case 0x45C:
                                //Device 2 Keyboard, Joystick, Input and Output endpoints
                                CboDevices.Items.Add("XK-68 Jog & Shuttle (" + devices[i].Pid + "=PID #2), ID: " + i);
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
                        devices[i].suppressDuplicateReports = false;
                    }
                }
            }
            if (CboDevices.Items.Count > 0)
            {
                CboDevices.SelectedIndex = 0;
                selecteddevice = cbotodevice[CboDevices.SelectedIndex];
                wData = new byte[devices[selecteddevice].WriteLength];//go ahead and setup for write
                lastdata = new byte[devices[selecteddevice].ReadLength];
                //fill in version
                LblVersion.Text = devices[selecteddevice].Version.ToString();
            }
           
        }
       
        private void BtnRed_Click(object sender, EventArgs e)
        {
            //Turn on the red LED
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte saveled = wData[2]; //save the current value of the LED byte
                for (int j = 0; j <devices[selecteddevice].WriteLength; j++) 
                {
                    wData[j] = 0;
                }
                wData[1] = 186;
                wData[2] = (byte)(saveled | 128);

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-Red LED";
                }
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

        private void BtnBL_Click(object sender, EventArgs e)
        {

            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 187;
                wData[2] = System.Convert.ToByte(textBox17.Text); //0-255 for brightness of bank 1 backlights
                wData[3] = System.Convert.ToByte(textBox18.Text); //0-255 for brightness of bank 2 backlights


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
        private void BtnBLToggle_Click(object sender, EventArgs e)
        {
            //Sending this command toggles the backlights
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 184;

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

        private void ChkGreenOnOff_CheckedChanged(object sender, EventArgs e)
        {
            //Turns on or off, depending on value of ChkGreenOnOff, ALL bank 1 BLs using current intensity
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte sl = 0;
                
                if (ChkGreenOnOff.Checked == true) sl = 255;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 182; //0xb6
                wData[2] = 0;  //0 for bank 1, 1 for bank 2
                wData[3] = (byte)sl; //OR turn individual rows on or off using bits.  1st bit=row 1, 2nd bit=row 2, 3rd bit =row 3, etc

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-All bank 1 BL on/off";
                }
            }
        }

        private void ChkRedOnOff_CheckedChanged(object sender, EventArgs e)
        {
            //Turns on or off, depending on value of ChkRedOnOff, ALL bank 2 BLs using current intensity
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                byte sl = 0;
              
                if (ChkRedOnOff.Checked == true) sl = 255;
                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                wData[0] = 0;
                wData[1] = 182; //0xb6
                wData[2] = 1;  //0 for bank 1, 1 for bank 2
                wData[3] = (byte)sl; //OR turn individual rows on or off using bits.  1st bit=row 1, 2nd bit=row 2, 3rd bit =row 3, etc

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success-All bank 2 BL on/off";
                }
            }
        }

        private void BtnSetFlash_Click(object sender, EventArgs e)
        {
            //Sets the frequency of flashing for both the LEDs and backlighting
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
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

       

        private void BtnSaveBL_Click(object sender, EventArgs e)
        {
            //Write current state of backlighting to EEPROM.  
            //NOTE: Is it not recommended to do this frequently as there are a finite number of writes to the EEPROM allowed
            if (CboDevices.SelectedIndex != -1)
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[0] = 0;
                wData[1] = 199;
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
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
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
                    toolStripStatusLabel1.Text = "Write Success-Time Stamp";
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
                    toolStripStatusLabel1.Text = "Write Success-Time Stamp";
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

                //using this method in real application if want to exactly duplicate down and up strokes would
                //probably do one key at a time.
                //response seems good but maybe some machines may need a sleep between writes??

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
                
                result = 404;
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

        private void BtnDescriptor_Click(object sender, EventArgs e)
        {
            //Sending the command will make the device return information about it
            if (CboDevices.SelectedIndex != -1)
            {
                //IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
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
                        break;
                    ret = devices[selecteddevice].BlockingReadData(ref data, 100);
                }
                listBox2.Items.Clear();
                if (data[3] == 0) listBox2.Items.Add("PID #1");
                else if (data[3] == 2) listBox2.Items.Add("PID #2"); //0=PID #2, 1=HW Mode PID, 2=PID #1
                listBox2.Items.Add("Keymapstart=" + data[4].ToString());
                listBox2.Items.Add("Layer2offset=" + data[5].ToString());
                listBox2.Items.Add("SizeOfEEProm=" + (data[7] * 256 + data[6]).ToString());
                listBox2.Items.Add("MaxCol=" + data[8].ToString());
                listBox2.Items.Add("MaxRow=" + data[9].ToString());
                String ledon = "";
                if ((byte)(data[10] & 64) != 0) ledon = "Green LED ";
                if ((byte)(data[10] & 128) != 0) ledon = ledon + "Red LED ";
                if (ledon == "") ledon = "None";
                listBox2.Items.Add("LEDs=" + ledon);
                listBox2.Items.Add("Version=" + data[11].ToString());

                string temp = "PID=" + (data[13] * 256 + data[12]).ToString();
                listBox2.Items.Add(temp);
            }
        }

        private void BtnSetKey_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCheckKey_Click(object sender, EventArgs e)
        {
            

        }

       

        private void ChkGreenLED_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1)
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = 6; //6 for green, 7 for red


                if (ChkGreenLED.Checked == true)
                {
                    wData[3] = 1; //0=off, 1=on, 2=flash
                    if (ChkFGreenLED.Checked == true) wData[3] = 2;
                }
                else
                {
                    wData[3] = 0; //0=off, 1=on, 2=flash
                }

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

        private void ChkRedLED_CheckedChanged(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1)
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = 7; //6 for green, 7 for red


                if (ChkRedLED.Checked == true)
                {
                    wData[3] = 1; //0=off, 1=on, 2=flash
                    if (ChkFRedLED.Checked == true) wData[3] = 2;
                }
                else
                {
                    wData[3] = 0; //0=off, 1=on, 2=flash
                }

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

        private void ChkFGreenLED_CheckedChanged(object sender, EventArgs e)
        {
            //use the Set Flash Freq to control frequency of blink
            if (CboDevices.SelectedIndex != -1)
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = 6; //6 for green, 7 for red

                if (ChkFGreenLED.Checked == true)
                {
                    wData[3] = 2; //0=off, 1=on, 2=flash
                }
                else
                {
                    if (ChkGreenLED.Checked == true)
                    {
                        wData[3] = 1; //0=off, 1=on, 2=flash
                    }
                    else
                    {
                        wData[3] = 0; //0=off, 1=on, 2=flash
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
                    toolStripStatusLabel1.Text = "Write Success - Flash LEDs";
                }
            }
        }

        private void ChkFRedLED_CheckedChanged(object sender, EventArgs e)
        {
            //use the Set Flash Freq to control frequency of blink
            if (CboDevices.SelectedIndex != -1)
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                wData[1] = 179; //0xb3
                wData[2] = 7; //6 for green, 7 for red

                if (ChkFRedLED.Checked == true)
                {
                    wData[3] = 2; //0=off, 1=on, 2=flash
                }
                else
                {
                    if (ChkRedLED.Checked == true)
                    {
                        wData[3] = 1; //0=off, 1=on, 2=flash
                    }
                    else
                    {
                        wData[3] = 0; //0=off, 1=on, 2=flash
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
                    toolStripStatusLabel1.Text = "Write Success - Flash LEDs";
                }
            }
        }

        private void ChkBLOnOff_CheckedChanged(object sender, EventArgs e)
        {
            //Use the Set Flash Freq to control frequency of blink
            //Key Index (in decimal)
            //Columns-->
            // 0  8 16 24 32 40 48 56 64 72
            // 1  9 17 25 33 41 49 57 65 73
            // 2 10 18 26 34 42 50 58 66 74
            // 3 11 19 27 35 43 51 59 67 75
            // 4 12 20 28 36 44 52 60 68 76
            // 5 13 21 -- -- -- -- 61 69 77
            // 6 14 22 -- -- -- -- 62 70 78
            // 7 15 23 -- -- -- -- 63 71 79

            if (CboDevices.SelectedIndex != -1)
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
                    iindex = Convert.ToInt16(sindex) + 80;  //Add 80 to get corresponding bank 2 index
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                //now get state
                int state = 0;
                if (ChkBLOnOff.Checked == true)
                {
                    if (ChkFlash.Checked == true) state = 2;
                    else state = 1;
                }

                wData[1] = 181; //b5
                wData[2] = (byte)(iindex); //Key Index
                wData[3] = (byte)state; //0=off, 1=on, 2=flash

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); } 
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Flash BL";
                }
            }
        }

        private void ChkFlash_CheckedChanged(object sender, EventArgs e)
        {
            //Use the Set Flash Freq to control frequency of blink
            //Key Index (in decimal)
            //Columns-->
            //  0   8   16  24
            //  1   9   17  25
            //  2   10  18  26

            if (CboDevices.SelectedIndex != -1)
            {
                //first get selected index
                string sindex = CboBL.Text;
                int iindex;
                if (sindex.IndexOf("b1") != -1) //bank 1 backlight
                {
                    sindex = sindex.Remove(sindex.IndexOf("-b1"), 3);
                    iindex = Convert.ToInt16(sindex);
                }
                else //bank 2 backlight
                {
                    sindex = sindex.Remove(sindex.IndexOf("-b2"), 3);
                    iindex = Convert.ToInt16(sindex) + 32;  //Add 32 to get corresponding bank 2 backlight
                }

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }
                //now get state
                int state = 0;
                if (ChkFlash.Checked == true)
                {
                    state = 2;
                }
                else
                {
                    if (ChkBLOnOff.Checked == true)
                    {
                        state = 1;
                    }
                }

                wData[1] = 181; //b5
                wData[2] = (byte)(iindex); //Key Index
                wData[3] = (byte)state; //0=off, 1=on, 2=flash

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Flash BL";
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

        private void BtnMousereflect_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {
                wData[0] = 0;
                wData[1] = 203;    //0xcb
                wData[2] = Convert.ToByte(textBox14.Text); //Buttons; 1=Left, 2=Right, 4=Center, 8=XButton1, 16=XButton2
                wData[3] = Convert.ToByte(textBox16.Text); //Mouse X motion. 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129).
                wData[4] = Convert.ToByte(textBox15.Text); //Mouse Y motion. 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129).
                wData[5] = Convert.ToByte(textBox10.Text);//Wheel X. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
                wData[6] = Convert.ToByte(textBox11.Text);//Wheel Y. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                //now send all 0s
                wData[0] = 0;
                wData[1] = 203;    //0xcb
                wData[2] = 0; //buttons
                wData[3] = 0; //X
                wData[4] = 0; //Y
                wData[5] = 0; //wheel X
                wData[6] = 0; //wheel Y
                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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
                wData[2] = 0;

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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
                wData[2] = 2;

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
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
        public static String BinToHex(Byte value)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append(value.ToString("X2"));  //the 2 means 2 digits
            return sb.ToString();
        }

        private void BtnIncIntesity_Click(object sender, EventArgs e)
        {
            if (CboDevices.SelectedIndex != -1) //do nothing if not enumerated
            {

                for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
                {
                    wData[j] = 0;
                }

                //first turn ON all of the bank 1 backlights
                wData[0] = 0;
                wData[1] = 182; //0xB6
                wData[2] = 0;  //bank, 0=bank 1, 1=bank 2
                wData[3] = 255;  //all on

                int result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); };

                wData[0] = 0;
                wData[1] = 173; //0xAD
                wData[2] = 0;  //bank, 0=bank 1, 1=bank 2
                wData[3] = 1;  //increase=1, decrease=0;
                wData[4] = 0;  //wrap =0, no wrap=1

                result = 404;
                while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
                if (result != 0)
                {
                    toolStripStatusLabel1.Text = "Write Fail: " + result;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Write Success - Incremental Intensity";
                }

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
                wData[1] = 238; //0xee
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

     

       
        

        
 
       
    }
    
    
}
