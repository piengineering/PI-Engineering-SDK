


using System.Diagnostics;
using System.Text;

using PIEHidNetCore;

//Declarations
PIEDevice[] devices;
byte[]? wData = null; //writedata buffer
byte[]? lastdata = null; //store the last read results for comparison
int selecteddevice=-1;

//Main Code
devices = PIEDevice.EnumeratePIE();
if (devices.Length == 0)
{
    Console.Out.WriteLine("No Devices Found");
}
else
{
    for (int i = 0; i < devices.Length; i++)
    {
        //information about device
        //PID = devices[i].Pid);
        //HID Usage = devices[i].HidUsage);
        //HID Usage Page = devices[i].HidUsagePage);
        //HID Version = devices[i].Version); //NOTE: this is NOT the firmware version which is given in the descriptor
        int hidusagepg = devices[i].HidUsagePage;
        int hidusage = devices[i].HidUsage;
        string serialnumber = devices[i].SerialNumberString;
        if (devices[i].HidUsagePage == 0xc && devices[i].WriteLength == 36) //use last one found with proper hidusage and writelength, only using 1 device in this sample
        {
            selecteddevice = i;
            Console.Out.WriteLine("PID=" + devices[i].Pid.ToString() + ", " + devices[i].ProductString);

            devices[i].SetupInterface();

        }
    }
}
if (selecteddevice != -1)
{
    lastdata = new byte[devices[selecteddevice].ReadLength];
    wData = new byte[devices[selecteddevice].WriteLength];

    //create polling timer
    Timer? _timer = null;
    _timer = new Timer(TimerCallback, null, 0, 50); //50ms timer 

    //blink red LED -example of writing to device
    if (selecteddevice != -1 && wData != null)
    {
        byte LED = 7; //6=green, 7=red
        byte state = 2; //0=off, 1=on, 2=flash

        for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
        {
            wData[j] = 0;
        }
        wData[0] = 0;
        wData[1] = 179; //b3
        wData[2] = LED;
        wData[3] = state; //0=off, 1=on, 2=flash

        int result = 404;

        while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
        if (result != 0)
        {
            //toolStripStatusLabel1.Text = "Write Fail: " + result;

        }
        else
        {
            //toolStripStatusLabel1.Text = "Write Success - LEDs and Outputs";
        }
    }
}



//end of enumeration

void TimerCallback(Object? o)
{
    //read data
    byte[]? data = null;
    while (0 == devices[selecteddevice].ReadData(ref data))
    {
        //now handle data

        byte val2 = (byte)(data[2] & 1);
        if (val2 == 0)
        {
            // LblSwitchPos.Text = "Switch down";
        }
        else
        {
            // LblSwitchPos.Text = "Switch up";
        }
        //LblUnitID.Text = data[1].ToString();

        //list out data
        String output = "Polling: " + devices[selecteddevice].Pid + ", ID: 0 , data=";
        for (int i = 0; i < devices[selecteddevice].ReadLength; i++)
        {
            output = output + BinToHex(data[i]) + " ";
        }

        Console.Out.WriteLine(output);
        if ((data[2] == 0) || (data[2] == 1)) //general incoming data
        {
            //buttons
            //this routine is for separating out the individual button presses/releases from the data byte array.
            int maxcols = 4;// 10; //number of columns of Xkeys digital button data, labeled "Keys" in P.I. Engineering SDK - General Incoming Data Input Report
            int maxrows = 8; //constant, 8 bits per byte
                             // = this.LblButtons;
            string buttonsdown = "Buttons: "; //for demonstration, reset this every time a new input report received
                                              //this.SetText(buttonsdown);
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
                            buttonsdown = keynum.ToString() + " down";
                            Console.Out.WriteLine(buttonsdown);
                            break;
                        case 2: //key was pressed and still is pressed
                            buttonsdown = keynum.ToString() + " still down";
                            Console.Out.WriteLine(buttonsdown);
                            break;
                        case 3: //key was pressed and now released
                            buttonsdown = keynum.ToString() + " released";
                            Console.Out.WriteLine(buttonsdown);
                            break;
                    } //end of state switch
                    //Perform action based on key number, consult P.I. Engineering SDK documentation for the key numbers
                    
                }
            }

            for (int i = 0; i < devices[selecteddevice].ReadLength; i++)
            {
                lastdata[i] = data[i];
            }
            //end buttons
        } //end of general incoming data
        
    } //end of while
   
}

String BinToHex(Byte value)
{
    System.Text.StringBuilder sb = new System.Text.StringBuilder("");
    sb.Append(value.ToString("X2"));  //the 2 means 2 digits
    return sb.ToString();
}

void QuitXkeys()
{
    //Do this stuff on exit of app
    //Turn off the flashing red led, for this sample
    if (selecteddevice != -1 && wData!=null)
    {
        byte LED = 7; //6=green, 7=red
        byte state = 0; //0=off, 1=on, 2=flash

        for (int j = 0; j < devices[selecteddevice].WriteLength; j++)
        {
            wData[j] = 0;
        }
        wData[0] = 0;
        wData[1] = 179; //b3
        wData[2] = LED;
        wData[3] = state; //0=off, 1=on, 2=flash

        int result = 404;

        while (result == 404) { result = devices[selecteddevice].WriteData(wData); }
        if (result != 0)
        {
            //toolStripStatusLabel1.Text = "Write Fail: " + result;

        }
        else
        {
            //toolStripStatusLabel1.Text = "Write Success - LEDs and Outputs";
        }
    }

    //closeinterfaces on all devices that have been setup (SetupInterface called)
    for (int i = 0; i < devices.Length; i++)
    {
        if (i == selecteddevice) //note this sample is assuming only 1 connected device (selecteddevice), if more than 1 then must manage them in an array
        {
            devices[i].CloseInterface();
        }
    }
    System.Environment.Exit(0); //??not sure if needed for console app

}
Console.WriteLine("Press X-keys buttons to read data, press a keyboard key to exit...");
Console.ReadKey();
QuitXkeys(); //turn red LED off and exit



