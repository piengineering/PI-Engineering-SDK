package com.piengineering.piusbsamplebroadcastreceiver;

import java.nio.ByteBuffer;
import java.util.HashMap;

import com.piengineering.piusbsamplebroadcastreceiver.R;

import android.hardware.usb.UsbConstants;
import android.hardware.usb.UsbDevice;
import android.hardware.usb.UsbDeviceConnection;
import android.hardware.usb.UsbEndpoint;
import android.hardware.usb.UsbInterface;
import android.hardware.usb.UsbManager;
import android.hardware.usb.UsbRequest;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.app.Activity;
import android.app.PendingIntent;
//import android.view.Menu;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;

public class MainActivity extends Activity implements OnClickListener{

	Button btnEnumerate;
	Button btnGreenLED; //writes to green led
	Button btnDescriptor; //requests descriptor
	String output="";
	String buttons="";
	boolean once=false;
	int maxinterfaces=10; //10 is plenty
	byte LEDstate=1; //default to on
	int[] lastdata=new int[36]; //keeps track of last read button state

	//Usb stuff
	UsbManager mUsbManager;
	private UsbDevice mDevice;
	private UsbDeviceConnection mConnection;
	private UsbInterface mInterface; //patti add for method 1 - can't get working??
	private UsbEndpoint mEndpointIntr; //in
	private UsbEndpoint mEndpointIntrOut; //out 
	private UsbInterface[] allInterfaces=null; //for method 2 -not in use in this sample

	private static final String ACTION_USB_PERMISSION = "com.piengineering.piusbsample.USB_PERMISSION";


	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		btnEnumerate=(Button)findViewById(R.id.button1);
		btnGreenLED=(Button)findViewById(R.id.button2);
		btnDescriptor=(Button)findViewById(R.id.button3);
		// Set Click Listener
		btnEnumerate.setOnClickListener(this); //requires the implements OnClickListener
		btnGreenLED.setOnClickListener(this);  
		btnDescriptor.setOnClickListener(this);

		Enumerate();
	}

	@Override 
	public void onPause() {
		super.onPause();

		//you can keep hold of device here and still read it in background or this code will release it.    	
		//NOT reliable, causes device to freeze
		/*if (mDevice!=null) //disconnect from device for other apps
		{

			if (mConnection!=null) 
			{

				//release all interfaces
				for (int i=0;i<maxinterfaces;i++)
				{
					if (allInterfaces[i]!=null)
					{
						mConnection.releaseInterface(allInterfaces[i]);
						allInterfaces[i]=null;
					}
				}

				mConnection=null;
				mInterface=null;
				mEndpointIntr=null;
				mEndpointIntrOut=null;
			}
			once=false;
		}*/


	}

	@Override
	public void onResume() {
		super.onResume();
		//if you released it in onPause, reconnect
		//NOT RELIABLE, cause device to freeze
		/*if (mDevice!=null)
		{
			setDevice(mDevice);
		}*/
	}

	@Override
	public void onClick(View arg0) {
		switch(arg0.getId())
		{
		case R.id.button1: //enumerate
			Enumerate();
			break;
		case R.id.button2: //write
			writeData(); //send output report to device
			break;
		case R.id.button3: //read
			requestDescriptor();
			break;
		}
	}

	public void postStatus(String status){
		try {
			TextView statusText = (TextView) findViewById(R.id.textView1);
			statusText.setText(status); 
		}
		catch (Exception e) {
			// Log.e("beep", "error: " + e.getMessage(), e);
		}
	}

	public void postStatusButtons(String status){
		try {
			TextView statusText = (TextView) findViewById(R.id.textView2);
			statusText.setText(status); 
		}
		catch (Exception e) {
			// Log.e("beep", "error: " + e.getMessage(), e);
		}
	}
	
	public void postStatusDevice(String status){
		try {
			TextView statusText = (TextView) findViewById(R.id.textView3);
			statusText.setText(status); 
		}
		catch (Exception e) {
			// Log.e("beep", "error: " + e.getMessage(), e);
		}
	}

	private final BroadcastReceiver mUsbReceiver = new BroadcastReceiver() 
	{
		public void onReceive(Context context, Intent intent) 
		{
			String action = intent.getAction();
			if (ACTION_USB_PERMISSION.equals(action)) 
			{
				synchronized (this) 
				{
					final UsbDevice device = (UsbDevice) intent.getParcelableExtra(UsbManager.EXTRA_DEVICE);
					if (intent.getBooleanExtra(UsbManager.EXTRA_PERMISSION_GRANTED, false)) 
					{
						setDevice(device);
					}
				}
			}
		}
	};

	public void Enumerate(){ 
		mUsbManager = (UsbManager)getSystemService(Context.USB_SERVICE);

		PendingIntent permissionIntent = PendingIntent.getBroadcast(this, 0,
				new Intent(ACTION_USB_PERMISSION), 0);
		IntentFilter filter = new IntentFilter(ACTION_USB_PERMISSION);
		registerReceiver(mUsbReceiver, filter);
		UsbManager manager = (UsbManager) getSystemService(Context.USB_SERVICE);
		HashMap<String, UsbDevice> deviceList = manager.getDeviceList();

		for (UsbDevice device : deviceList.values()) {
			if (device.getVendorId() == 1523) //only want PI devices (remove for testing logitech, etc)
			{
				mUsbManager.requestPermission(device, permissionIntent);
			}
		}
		once=false;
	}

	public void writeData() {

		if (mDevice!=null)
		{
			//int pid=mDevice.getProductId();
			//send a write command
			if (mConnection != null) 
			{
				int length=mEndpointIntrOut.getMaxPacketSize();
				byte[] message = new byte[length];
				//toggle the green led
				if (LEDstate==1)LEDstate=0;
				else LEDstate=1;
				//fill in the message array-see XK-24 Android Output Report for other possible values
				//Note: no report id on Android
				message[0] = (byte)179; //set led
				message[1] = 6; //6=green led, 7=red led
				message[2] = LEDstate; //0=off, 1=on, 2=flash
				mConnection.bulkTransfer(mEndpointIntrOut, message, message.length, 0);
			}
		}

	}

	public void requestDescriptor() {

		if (mDevice!=null)
		{
			//send a write command
			if (mConnection != null) 
			{
				int length=mEndpointIntrOut.getMaxPacketSize();
				byte[] message = new byte[length];
				//request descriptor

				//fill in the message array-see XK-24 Android Output Report for possible values
				message[0] = (byte)214; 
				mConnection.bulkTransfer(mEndpointIntrOut, message, message.length, 0);
				//an input report with the descriptor data is sent immediately following this command, see setDevice
			}
		}

	}

	private void setDevice(UsbDevice device) 
	{ 
		if (device!=null)
		{
			mDevice = device;
			final UsbDeviceConnection connection = mUsbManager.openDevice(device); //the final makes connection accessible inside the run
			if (connection!=null)
			{
				mConnection=connection;

				int icount=device.getInterfaceCount(); //for SE and MWII only one, but pi3 has more so will need to sort it out
				int pid=device.getProductId();
				String total="pid="+pid+", interface count="+icount;

				allInterfaces=new UsbInterface[maxinterfaces];

				boolean startread=false;
				for (int i=0;i<device.getInterfaceCount();i++)
				{
					boolean releaseit=false;

					UsbInterface intf = device.getInterface(i);

					//Claim all interfaces so that while app is open any keys with stuff on them are ignored-NOTE: if hardware mode programming present on keys sluggish response may
					//result.  If you desire only to read the input report then do not put macros on the keys.
					//Need to store all of the claimed interfaces so can release them onPause
					allInterfaces[i]=intf; //save to array so can release onPause
					connection.claimInterface(intf, true);

					total=total+"\tinterface no.="+i+", endpoint count="+intf.getEndpointCount()+"\n";
					for (int j=0;j<intf.getEndpointCount();j++)
					{
						UsbEndpoint ep = intf.getEndpoint(j);

						if (ep.getDirection()==UsbConstants.USB_DIR_IN)
						{
							total=total+"\t\tusb in:"+j+", maxpsizein="+ep.getMaxPacketSize()+"\n";
							if (device.getInterfaceCount()==1) //SE and MWII
							{
								mEndpointIntr = ep;
								startread=true;
								mInterface=intf;
							}
							else //more specific, at this point I assume anything coming thru here is pi3 (3 interfaces)
							{
								if (ep.getMaxPacketSize()>31) //pi3
								{
									mEndpointIntr = ep;
									startread=true;
									mInterface=intf;

								}
								else
								{
									//release this interface, this will allow the interface to "work" while in this app, ex MM keys will still send out
									//if you don't release the interface they won't work until they are released.
									releaseit=true;  //but not at this point
								}
								//another set of ifs-not in use, packetsize can tell which endpoint it is
								if (ep.getMaxPacketSize()==11) //joystick
								{

								}
								else if (ep.getMaxPacketSize()==8) //keyboard
								{

								}
							}
							total=total+", usb in:"+j+", maxpsizein="+ep.getMaxPacketSize();

						}
						else if (ep.getDirection()==UsbConstants.USB_DIR_OUT)
						{
							//this endpoint is on the same interface as an IN so no need to claim it again and IN always found first (?? is this always the case??)
							mEndpointIntrOut = ep; //this ok if only ONE out ep
							mInterface=intf; //for pi3 this is always the same intf as the IN endpoint, no need to do this again

							total=total+"\t\tusb out:"+j+", maxpsizeout="+ep.getMaxPacketSize()+"\n";

						}
					} //end of endpoints

					if (releaseit==true)
					{
						mConnection.releaseInterface(intf);
						allInterfaces[i]=null;
					}
				} //end of interfaces
				postStatusDevice(total);
				//start thread here
				//STARTING THE READ THREAD IS NOT REQUIRED

				if (startread==true && once==false) 
				{
					once=true;
					//UsbHelloWorld method of threading (http://www.jraf.org/static/tmp/UsbHelloWorldActivity.java)
					new Thread( new Runnable() 
					{
						public void run() {

							int readsize=mEndpointIntr.getMaxPacketSize(); 
							ByteBuffer buffer = ByteBuffer.allocate(readsize);
							UsbRequest request = new UsbRequest();
							request.initialize(mConnection, mEndpointIntr); //use the IN endpoint
							while (true) 
							{
								// queue a request on the interrupt endpoint
								request.queue(buffer, readsize); //if true result returned via requestWait
								try 
								{
									if (mConnection.requestWait() == request) 
									{
										output="";
										int[] tempdata=new int[readsize]; //use this to get UNSIGNED bytes
										for (int i=0;i<readsize;i++)
										{
											//NOTE: in java ALL bytes are signed thus anything greater that 127 will show up as a negative number, ex -42 is 214						    			 tempdata[i]=(int)(buffer.get(i)&0xff); //convert to unsigned
											tempdata[i]=(int)(buffer.get(i)&0xff);
											output=output+String.format("%02x", tempdata[i])+", ";
										}

										int datatype=(int)(buffer.get(1)&0xff); //note: no report id on android

										switch (datatype)
										{
										case 214: //descriptor
										{
											if (tempdata[2]==0) output="PID #1, ";
											else if (tempdata[2]==1) output="PID #2, ";
											else if (tempdata[2]==2) output="PID #3, ";
											else if (tempdata[2]==2) output="PID #4, ";
											output=output+"Keymapstart="+String.valueOf(tempdata[3])+", ";
											output=output+"Layer2Offset="+String.valueOf(tempdata[4])+", ";
											output=output+"SizeofEeprom="+String.valueOf(256*tempdata[5]+tempdata[6])+", ";
											output=output+"MaxCol="+String.valueOf(tempdata[7])+", ";
											output=output+"MaxRow="+String.valueOf(tempdata[8])+", ";
											output=output+"LEDs/Digital Outs="+String.valueOf(tempdata[9])+", "; //see help doc for detail, 7th bit=green LED, 8th bit=red LED
											output=output+"Version="+String.valueOf(tempdata[10])+", ";
											output=output+"PID="+String.valueOf(256*tempdata[12]+tempdata[11]);
										}
										break;
										case 224: //custom generated input report, generated by sending a Generate Custom Data output report 0xE0, count, b1, b2, b3...bcount
										{
											buttons="Custom Data: ";
											for (int i=0;i<tempdata[2];i++){ //tempdata[2] is the number of bytes to follow
												buttons=buttons+String.valueOf(tempdata[i])+", ";
											}
											
										}
										break;
										default: //if not descriptor or custom generated input report then general incoming data (buttons)
										{
											//determine buttons down NOTE: this for XK-24 Android, adjust maxcols to appropriate vals for other devices
											int maxcols=4;
								            int maxrows=8; //really 6 but using the numbering from the SDK so need to use 8
											buttons="Buttons down: ";
								            for (int i=0;i<maxcols;i++){ 
												for (int j=0;j<maxrows;j++){ 
													int temp1=(int) Math.pow(2, j);
													int keynum=maxrows*i+j;
													byte temp2 = (byte)(tempdata[i + 2] & temp1); //this time 
							                        byte temp3 = (byte)(lastdata[i + 2] & temp1);  //last time
							                        int state = 0; //0=was up, now up, 1=was up, now down, 2= was down, now down, 3= was down, now up
							                        if (temp2 != 0 && temp3 == 0) state = 1; //just pressed
							                        else if (temp2 != 0 && temp3 != 0) state = 2; //held down
							                        else if (temp2 == 0 && temp3 != 0) state = 3; //just released
							                        if (state==1 || state==2){ //these buttons are down
							                        	buttons=buttons+String.valueOf(keynum)+", ";
							                        }
												}
											}
										}
										break;
										}
										
							            //set lastdata to tempdata
							            for (int i = 0; i < readsize; i++)
						                {
						                    lastdata[i] = tempdata[i];
						                }
									}
									else
									{
										break;
									}
									runOnUiThread(new Runnable(){

										@Override
										public void run() {

											postStatus(output);
											postStatusButtons(buttons);
										}});
								}
								catch(Exception e){

								}
							} //end while


						}
					}).start();

				}



			} //end of connection != null


		} //end of device != null
		else
		{

			return;
		}


	} //end of setDevice()



}
