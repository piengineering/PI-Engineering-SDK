PIUsbSampleBroadcastReceiver
7/23/13

PIUsbSampleBroadcastReceiver demonstrates how to connect to, write to and read from an X-keys Plus series device.  It is written in Java using Eclipse from the Android Development Tools Build: v21.0.0-519525.

To run an sdk sample in Eclipse right click in the Package Explorer window.

Select New -> Other
Under the Android folder select Android Sample Project
Choose the build target and then the sample project

The XK-24 Plus and other X-keys Plus series products are capable of being configured in several ways, each with a different Product Identification (PID) number.  In order to be able to use this sample the X-keys must be in PID #1, #2 or #3.  PID #4 contains a boot keyboard and will be seen by the Android OS as an external keyboard thus the sample will be unable to get a "handle" to the device in this mode and unable to read or write to it.  A PC would be required to convert it back.
  
This sample is specifically designed to work with PID #1 which has both an input report and output report.  Please review the Data Reports in the accompanying help files.  The sample demonstrates how to turn on and off the green indicator LED but any of the output reports could be used in the same manner.

If using this sample it is assumed the user is not using the X-keys Android app utility* to program the X-keys.  Programming macros onto the buttons may result in sluggish performance or missing of input reports due to too much data flow.  For the best response we recommend keeping all buttons clean of internally stored macros or turning off the automatic playback of these macros.

Android OS has many ways of dealing with USB.  This sample uses a "broadcast receiver" method.  Please refer to http://www.piengineering.com/developer/androidsamples.php for other Android sample projects.

*this utility internally stores macros to buttons which are played back automatically on press or release of the button and can be downloaded at the Google Play Store: https://play.google.com/store/apps/details?id=com.piengineering.pimacroworks&hl=en.


