

// See https://aka.ms/new-console-template for more information, created from tutorial here https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/next
using HidSharp; //https://github.com/IntergatedCircuits/HidSharp, HIDSharp Copyright 2010-2019 James F. Bellinger <http://www.zer7.com/software/hidsharp>
using HidSharp.Reports.Encodings;
using HidSharp.Reports;
using HidSharp.Utility;
using System.Diagnostics;
using System.Text;

HidDevice selecteddeviceHS;
Thread thread; //for reading input 

HidSharpDiagnostics.EnableTracing = true;
HidSharpDiagnostics.PerformStrictChecks = true;

//Console.WriteLine("Beginning discovery.");
selecteddeviceHS = null;
foreach (HidDevice device in HidSharp.DeviceList.Local.GetHidDevices(0x05F3))
{
    string path = device.DevicePath;
    int inputReportLen = device.GetMaxInputReportLength();
    int outputReportLen = device.GetMaxOutputReportLength();
    int maxfeatureReportLen = device.GetMaxFeatureReportLength();
    //or
    //same as above
    var reportDescriptor = device.GetReportDescriptor();
    int inputReportLen2 = reportDescriptor.MaxInputReportLength;
    int outputReportLen2 = reportDescriptor.MaxOutputReportLength;
    int maxfeatureReportLen2 = reportDescriptor.MaxFeatureReportLength;

    string manufacturer = device.GetManufacturer();
    string productname = device.GetProductName();
    int oemversion = device.ReleaseNumberBcd;
    int vid = device.VendorID;
    int pid = device.ProductID;
    //string serialnumber = device.GetSerialNumber(); //errors for devices without serial numbers
    byte[] rawreport = device.GetRawReportDescriptor(); //get the raw report, the 1st 4 bytes give the hid usage and the usage; 05 xx 09 xx
    int hidusagepage = -1;
    if (rawreport[0] == 5) hidusagepage = rawreport[1];
    int hidusage = -1;
    if (rawreport[2] == 9) hidusage = rawreport[3];
    if (vid == 0x05F3 && hidusagepage == 0x0C && outputReportLen > 10) //PI product's consumer page endpoint
    {
        selecteddeviceHS = device;
        Console.WriteLine(productname + " " + pid.ToString() + " from " + manufacturer);
    }
}

//Start reading
if (selecteddeviceHS!=null)
{
    thread = new Thread(new ThreadStart(ReadInputThreadFunction));
    thread.Start();
}

//Writing examples
GreenLED(2); //blink green LED
RGBLED(0, 0, 3, 3, 3, 1); //turn 1st rgb LED white and flash it

void GreenLED(byte state)
{
    //Control green LED
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
                outputReportBuffer[2] = 6; //6 for green, 7 for red
                outputReportBuffer[3] = state; //0=off, 1=on, 2=flash

                hidStream.Write(outputReportBuffer);
            }
        }
    }
}

void RGBLED(byte ledindex, byte bank, byte r, byte g, byte b, byte state)
{
    //Control RGB LED
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
               
                outputReportBuffer[1] = 165; //0xa5
                outputReportBuffer[2] = ledindex; //led index
                outputReportBuffer[3] = bank; //0=top, 1=bottom
                outputReportBuffer[4] = r; //r
                outputReportBuffer[5] = g; //g
                outputReportBuffer[6] = b; //b
                outputReportBuffer[7] = state; //0=no flash, 1=flash
                hidStream.Write(outputReportBuffer);
            }
        }
    }
}
void ReadInputThreadFunction()
{
    //Read the selected device
    try
    {
        // do any background work
        var reportDescriptor = selecteddeviceHS.GetReportDescriptor();
        foreach (var deviceItem in reportDescriptor.DeviceItems)
        {
            if (selecteddeviceHS != null)
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
                                Console.WriteLine(hexofbytes);

                                //check the program switch byte 
                                byte val2 = (byte)(inputReportBuffer[2] & 1);
                                if (val2 == 0)
                                {
                                    Console.WriteLine("Program switch: up");
                                }
                                else
                                {
                                    Console.WriteLine("Program switch: down");

                                }
                                //read the unit ID
                                Console.WriteLine("Unit ID: " + inputReportBuffer[1].ToString());

                                if (inputReportBuffer[2] < 3) //button data
                                {
                                    ////time stamp info 4 bytes - note time stamp is located in different bytes for different products
                                    //long absolutetime = 16777216 * inputReportBuffer[7] + 65536 * inputReportBuffer[8] + 256 * inputReportBuffer[9] + inputReportBuffer[10];  //ms
                                    //long absolutetime2 = absolutetime / 1000; //seconds
                                    //c = this.label19;
                                    //this.SetText("absolute time: " + absolutetime2.ToString() + " s");
                                    //long deltatime = absolutetime - saveabsolutetime;
                                    //c = this.label20;
                                    //this.SetText("delta time: " + deltatime + " ms");
                                    //saveabsolutetime = absolutetime;
                                }
                                else if (inputReportBuffer[2] == 214) //descriptor data
                                {

                                }
                            }
                        } //end while
                    } //end using
                } //end TryOpen
            } //end if selecteddeviceHS!-null
        } //end foreach


    }
    catch (Exception ex)
    {
        // log errors
    }
    
}

static String BinToHex(Byte value)
{
    StringBuilder sb = new StringBuilder("");
    sb.Append(value.ToString("X2"));  //the 2 means 2 digits
    return sb.ToString();
}

    

    
Console.WriteLine("Press X-keys buttons to read data, press a keyboard key to exit...");
Console.ReadKey();
GreenLED(1); //return Green LED to solid
RGBLED(0, 0, 3, 3, 3, 0); //turn 1st rgb LED white not flashing
Environment.Exit(0);