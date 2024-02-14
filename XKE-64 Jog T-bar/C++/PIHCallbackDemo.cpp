// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
#include "PIEHid32.h"

#include <string.h>
#include <stdio.h>
#include <math.h> //for use of pow
#include <string>

#define MAXDEVICES  128   //max allowed array size for enumeratepie =128 devices*4 bytes per device


// function declares 
int CALLBACK DialogProc(
  HWND hwndDlg,  // handle to dialog box
  UINT uMsg,     // message
  WPARAM wParam, // first message parameter
  LPARAM lParam  // second message parameter
);
void FindAndStart(HWND hDialog);
void AddEventMsg(HWND hDialog, char *msg);
void AddDevices(HWND hDialog, char *msg);
DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error);
DWORD __stdcall HandleErrorEvent(DWORD deviceID, DWORD status);

BYTE buffer[80];  //used for writing to device
BYTE lastpData[80];  //stores the data of the previous read
int readlength=0; 
HWND hDialog;
long hDevice = -1;
int combotodevice[128];
HWND Pid_Combo;

//---------------------------------------------------------------------

int APIENTRY WinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{
    DWORD result;
	MSG   msg;

	hDialog = CreateDialog(hInstance, (LPCTSTR)IDD_MAIN, NULL, DialogProc);

	ShowWindow(hDialog, SW_NORMAL);

	//put numbers in edit boxes
	HWND hList;
	hList = GetDlgItem(hDialog, IDC_JoyX);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyY);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyZ);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyZr);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoySlider);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyGame1);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyGame2);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyGame3);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyGame4);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JoyHat);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"8");

	hList = GetDlgItem(hDialog, IDC_MouseButtons);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_MouseX);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"15");
	hList = GetDlgItem(hDialog, IDC_MouseY);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"15");
	hList = GetDlgItem(hDialog, IDC_MouseWheel);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");

	hList = GetDlgItem(hDialog, IDC_TxtMultiHi);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"00");
	hList = GetDlgItem(hDialog, IDC_TxtMultiLo);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"E2");

	hList = GetDlgItem(hDialog, IDC_TXTBL);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");

	Pid_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 435, 600, 484, 607, hDialog, NULL, hInstance, NULL); 
	
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 1: Keyboard, Multimedia, PI Consumer, Output (factory default)");
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 2: Keyboard (boot), Multimedia, PI Consumer, Output");
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 3: Keyboard, Joystick, PI Consumer, Output");
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 4: Mouse, Joystick, PI Consumer, Output");
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 5: Keyboard (boot), Mouse (boot), PI Consumer, Output");
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 6: PI Consumer, Output");
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 7: Keyboard, Joystick, Mouse, Multimedia, PI Consumer, Output");
	SendMessage(Pid_Combo, CB_ADDSTRING, 0, (LPARAM)"PID 8: Keyboard (boot) for KVM users");
	//set default
	SendMessage(Pid_Combo, CB_SETCURSEL, 0, 0);

	result = GetMessage( &msg, NULL, 0, 0 );
	while (result != 0)    { 
		if (result == -1)    {
			return 1;
			// handle the error and possibly exit
		}
		else    {
			TranslateMessage(&msg); 
			DispatchMessage(&msg); 
		}
		
		result = GetMessage( &msg, NULL, 0, 0 );
	}

    if (hDevice != -1) CleanupInterface(hDevice);

	


	return 0;
}
//---------------------------------------------------------------------

int CALLBACK DialogProc(
  HWND hwndDlg,  // handle to dialog box
  UINT uMsg,     // message
  WPARAM wParam, // first message parameter
  LPARAM lParam  // second message parameter
)    {

	DWORD result;
//	BYTE buffer[80];  //this globally declared only to keep track of LEDs	
	
	HWND hList;
	
	int K0;    
    int K1;   
    int K2;
	int K3;
	int countout=0;
	int wlen=GetWriteLength(hDevice);
	char *p;
	char errordescription[100]; //used with the GetErrorString call to describe the error


	switch (uMsg)    {
	case WM_INITDIALOG:
		SendMessage(GetDlgItem(hwndDlg, CHK_NONE), BM_SETCHECK, BST_CHECKED, 0);
		// Indicate that events are off to start.
		return FALSE;   // not choosing keyboard focus
	
    case WM_COMMAND:
		switch (LOWORD(wParam))
         {
			 case IDC_LIST1:
             {
				 switch (HIWORD(wParam)) 
                 { 
					case LBN_SELCHANGE:
                    {
                        //user selecting different device
						hList = GetDlgItem(hDialog, IDC_LIST1);
						if (hList == NULL) return TRUE;
						hDevice=combotodevice[SendMessage(hList, LB_GETCURSEL, 0, 0)];
                        return TRUE; 
                    } 
					return TRUE;
                 }
			 }
		 }
		switch (wParam)    {
		case IDCANCEL:
			PostQuitMessage(0);
			return TRUE;

		case IDSTART:
		    if (hDevice != -1) CloseInterface(hDevice);
			// only one at a time in the demo, please

			hDevice = -1;
			SendMessage(GetDlgItem(hwndDlg, CHK_NONE), BM_CLICK, 0, 0);
			FindAndStart(hwndDlg);
			return TRUE;

		case IDHALT:
		    if (hDevice != -1) CloseInterface(hDevice);
			hDevice = -1;
			return TRUE;

        case IDC_CALLBACK:
			if (hDevice == -1) return TRUE;
			//Turn on the data callback
			result = SetDataCallback(hDevice, HandleDataEvent);
			result = SetErrorCallback(hDevice, HandleErrorEvent);
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			SuppressDuplicateReports(hDevice, true);
			DisableDataCallback(hDevice, false); //turn on callback in the case it was turned off by some other command
			return TRUE;
        
		case IDC_CLEAR:
		    
			hList = GetDlgItem(hDialog, ID_EVENTS);
			if (hList == NULL) return TRUE;
			SendMessage(hList, LB_RESETCONTENT, 0, 0);
			return TRUE;

		case IDC_UNITID:
			//this writes the unit ID entered in IDC_EDIT1. 0-255 possible.
			memset(buffer, 0, 80);
			for (int i=0;i<36;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=189;
			
			//get text box text
			hList = GetDlgItem(hDialog, IDC_EDIT1);
			if (hList == NULL) return TRUE;
			char UnitID[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)UnitID);
			buffer[2]= atoi(UnitID);
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

		case IDC_CHECK1:
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=6; //6=green, 7=red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK1);
			if (hList == NULL) return TRUE;
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

		case IDC_CHECK2:
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=7; //6=green, 7=red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK2);
			if (hList == NULL) return TRUE;
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		
		case IDC_CHKBLONOFF:
			//Turn on/off the backlight of the entered key in IDC_EDIT2
			//Use the Set Flash Freq to control frequency of blink
            //Key Index (in decimal)
            //Bank 1
			//Columns-->
            //  0   8   16  24  32  40  48  56  64  72  80  88  96  104 112 120
            //  1   9   17  25  33  41  49  57  65  73  81  89  97  105 113 121
            //  2   10  18  26  34  42  50  58  66  74  82  90  98  106 114 122
            //  3   11  19  27  35  43  51  59  67  75  83  91  99  107 115 123
            //  4   12  20  28  36  44  52  60  68  76  84  92  100 108 116 124
            //  5   13  21  29  37  45  53  61  69  77  85  93  101 109 117 125
            //  6   14  22  30  38  46  54  62  70  78  86  94  102 110 118 126
            //  7   15  23  31  39  47  55  63  71  79  87  95  103 111 119 127

			//Bank 2
			//Columns-->
            //  128 136	144	152	160	168	176	184	192	200 208	216	224	232	240	248	
            //  129	137	145	153	161	169	177	185	193	201	209	217	225	233	241	249
            //  130	138	146	154	162	170	178	186	194	202	210	218	226	234	242	250
            //  131	139	147	155	163	171	179	187	195	203	211	219	227	235	243	251
            //  132	140	148	156	164	172	180	188	196	204	212	220	228	236	244	252
            //  133	141	149	157	165	173	181	189	197	205	213	221	229	237	245	253
			//	134	142	150	158	166	174	182	190	198	206	214	222	230	238	246	254
			//  135 143 151 159	167	175	183	191	199	207	215	223	231	239	247	255

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=181; //0xb5
			//get key index
			//get text box text
			hList = GetDlgItem(hDialog, IDC_TXTBL);
			if (hList == NULL) return TRUE;
			char keyid[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)keyid);
			buffer[2]= atoi(keyid);
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKBLONOFF);
			if (hList == NULL) return TRUE;
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		
        case IDC_CHKBANK1:
			//Turns on or off ALL bank 1 BLs using current intensity
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=182;
			buffer[2]=0; //0 for bank 1, 1 for bank 2
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKBANK1);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=255;
			else buffer[3]=0;  //0=off, 255=on OR use individual bits to turn on rows, bit 1=row 1, bit 2= row 2, etc
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;

		case IDC_CHKBANK2:
			//Turns on or off ALL bank 2 BLs using current intensity
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=182;
			buffer[2]=1; //0 for bank 1, 1 for bank 2
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKBANK2);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=255;
			else buffer[3]=0;  //0=off, 255=on OR use individual bits to turn on rows, bit 1=row 1, bit 2= row 2, etc
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;
		case IDC_BLToggle:
			//Toggle the backlights
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=184;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;
		case IDC_BLIntensity:
			//Sets the bank 1 and bank 2 backlighting intensity, one value for all bank 1 or bank 2
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}

			buffer[0]=0;
			buffer[1]=187;
			buffer[2]=127; //0-255 bank 1 intensity
			buffer[3]=64; //0-255 bank 2 intensity
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;
		
		case IDC_SAVEBACKLIGHTS: //Makes the current backlighting the default
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=199; //0xc7
			buffer[2]=1; //anything other than 0 will save bl state to eeprom
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_TOPID1:
			{
			//Change to selected PID
			int newpid=SendMessage(Pid_Combo, CB_GETCURSEL, 0, 0);
            for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204; //0xcc
			buffer[2]=newpid; //0=PID 1, 1=PID 2, 2=PID 3, 3=PID 4, etc
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
				if (result != 0 && result!=404)    
				{
					AddEventMsg(hwndDlg, "Error:");
					GetErrorString(result, errordescription, 100);
					AddEventMsg(hwndDlg, errordescription);
					break;
				}
			}
			return TRUE;
			}
		
		case IDC_Version:
			//Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
            //newly written version!  Requires piehid32.dll to read back version.
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=195; //0xc3
			char versionval[10];
			hList = GetDlgItem(hDialog, IDC_TxtVersion);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)versionval);
			buffer[2]=(BYTE)atoi(versionval);
			buffer[3]=(BYTE)(atoi(versionval)>>8);
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			
			Sleep(100);
			//reboot device-must re-enumerate
			buffer[0]=0;
			buffer[1]=238; //0xee
			buffer[2]=0;
			buffer[3]=0;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}

			return TRUE;

		case IDC_KEYREFLECT:
			//Sends keyboard commands as a native keyboard to textbox
			hList = GetDlgItem(hDialog, IDC_EDIT2);
			if (hList == NULL) return TRUE;
			SetFocus(hList);
			for(int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=201;
			buffer[2]=2; //modifiers Bit 1=Left Ctrl, bit 2=Left Shift, bit 3=Left Alt, bit 4=Left Gui, bit 5=Right Ctrl, bit 6=Right Shift, bit 7=Right Alt, bit 8=Right Gui.
			buffer[3]=0; //always 0
			buffer[4]=0x04; //1st hid code a, down
			buffer[5]=0; //2nd hid code
			buffer[6]=0; //3rd hid code
			buffer[7]=0; //4th hid code
			buffer[8]=0; //5th hid code
			buffer[9]=0; //6th hid code
			result=404;
			while(result==404)
			{
				result=WriteData(hDevice, buffer);
			}
			//Sleep(100);
			buffer[0]=0;
			buffer[1]=201;
			buffer[2]=0; //modifiers Bit 1=Left Ctrl, bit 2=Left Shift, bit 3=Left Alt, bit 4=Left Gui, bit 5=Right Ctrl, bit 6=Right Shift, bit 7=Right Alt, bit 8=Right Gui.
			buffer[3]=0; //always 0
			buffer[4]=0; //1st hid code a up
			buffer[5]=0x05; //2nd hid code b down
			buffer[6]=0x06; //3rd hid code c down
			buffer[7]=0x07; //4th hid code d down
			buffer[8]=0; //5th hid code
			buffer[9]=0; //6th hid code
			result=404;
			while(result==404)
			{
				result=WriteData(hDevice, buffer);
			}
			//Sleep(100);
			buffer[0]=0;
			buffer[1]=201;
			buffer[2]=0; //modifiers Bit 1=Left Ctrl, bit 2=Left Shift, bit 3=Left Alt, bit 4=Left Gui, bit 5=Right Ctrl, bit 6=Right Shift, bit 7=Right Alt, bit 8=Right Gui.
			buffer[3]=0; //always 0
			buffer[4]=0; //1st hid code 
			buffer[5]=0; //2nd hid code b up
			buffer[6]=0; //3rd hid code c up
			buffer[7]=0; //4th hid code d up
			buffer[8]=0; //5th hid code
			buffer[9]=0; //6th hid code
			result=404;
			while(result==404)
			{
				result=WriteData(hDevice, buffer);
			}
			//Sleep(100);
			return TRUE;

		case IDC_JOYREFLECT:
			//open up the game controller control panel to test these features, after clicking this button
            //go and make active the control panel properties and change will occur
			//only available in PID #1 and PID #3
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=202;
			
			char joyval[10];
			hList = GetDlgItem(hDialog, IDC_JoyX);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[2]=atoi(joyval)^127-255; //X, 0 to 127 from center to right, 255 to 128 from center to left
			hList = GetDlgItem(hDialog, IDC_JoyY);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[3]=atoi(joyval)^127; //Y, 0 to 127 from center down, 255 to 128 from center up
			hList = GetDlgItem(hDialog, IDC_JoyZr);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[4]=atoi(joyval)^127; //Z rotation, 0 to 127 from center down, 255 to 128 from center up
			hList = GetDlgItem(hDialog, IDC_JoyZ);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[5]=atoi(joyval)^127; //Z, 0 to 127 from center down, 255 to 128 from center up
			hList = GetDlgItem(hDialog, IDC_JoySlider);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[6]=atoi(joyval)^127; //Slider, 0 to 127 from center down, 255 to 128 from center up
			
			hList = GetDlgItem(hDialog, IDC_JoyGame1);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[7]=atoi(joyval); //buttons 1-8, where bit 1 is button 1, bit 2 is button 2
			hList = GetDlgItem(hDialog, IDC_JoyGame2);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[8]=atoi(joyval); //buttons 9-16, where bit 1 is button 1, bit 2 is button 2
			hList = GetDlgItem(hDialog, IDC_JoyGame3);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[9]=atoi(joyval); //buttons 17-24, where bit 1 is button 1, bit 2 is button 2
			hList = GetDlgItem(hDialog, IDC_JoyGame4);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[10]=atoi(joyval); //buttons 25-32, where bit 1 is button 1, bit 2 is button 2
			
			buffer[11]=0;

			hList = GetDlgItem(hDialog, IDC_JoyHat);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[12]=atoi(joyval); //hat, where 0 is straight up, 1 is 45deg cw, etc and 8 is no hat
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

	    case IDC_MOUSEREFLECT3:
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=203;
			
			char val[10];
			hList = GetDlgItem(hDialog, IDC_MouseButtons);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[2]=atoi(val); //1=left, 2=right, 4=center, 8=XButton1, 16=XButton2
			hList = GetDlgItem(hDialog, IDC_MouseX);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[3]=atoi(val); //X motion, 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129)
			hList = GetDlgItem(hDialog, IDC_MouseY);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[4]=atoi(val); //Y motion, 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129)
			hList = GetDlgItem(hDialog, IDC_MouseWheel);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[5]=atoi(val); //Wheel Y, 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//now send all 0s
			buffer[2]=0;
			buffer[3]=0;
			buffer[4]=0;
			buffer[5]=0;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_Multimedia:
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
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=225; //0xe1
			
			char val2[10];
			hList = GetDlgItem(hDialog, IDC_TxtMultiLo);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val2);
			//convert the hex strings to number
			
			buffer[2]=strtol(val2, &p, 16); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
			hList = GetDlgItem(hDialog, IDC_TxtMultiHi);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val2);
			buffer[3]=strtol(val2, &p, 16); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}

			buffer[2]=0; //terminate
			buffer[3]=0; //terminate
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//note when the "terminate" command is sent can sometimes have an effect on the behavior of the command
			//for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the e1 command it will
			//decrement the volume one step, if you send the e1 on the press and the terminate on the release the volume will continuously
			//decrement until the key is released.
			return TRUE;
		case IDC_MyComputer:

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=225; //0xe1
			buffer[2]=strtol("94", &p, 16); //Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
			buffer[3]=strtol("01", &p, 16); //Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}

			buffer[2]=0; //terminate
			buffer[3]=0; //terminate
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_GENERATE:
			DisableDataCallback(hDevice, false); //turn on callback in the case it was turned off by some other command
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=177;
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CUSTOM:
			//After sending this command a custom incoming data report will be given with
            //the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
            //and the following bytes whatever the user wishes.  In this example we are send 3 bytes; 1, 2, 3
			DisableDataCallback(hDevice, false); //turn on callback in the case it was turned off by some other command
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=224;
			buffer[2] = 3; //count of bytes to follow
            buffer[3] = 1; //1st custom byte
            buffer[4] = 2; //2nd custom byte
            buffer[5] = 3; //3rd custom byte
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_SETKEY:
			//for users of the dongle feature only, set the dongle key here REMEMBER there 4 numbers, they are needed to check the dongle key
			 //This routine is done once per unit by the developer prior to sale.
			if (hDevice == -1) return TRUE;
			//Pick 4 numbers between 1 and 254.
            K0 = 7;    //pick any number between 1 and 254, 0 and 255 not allowed
            K1 = 58;   //pick any number between 1 and 254, 0 and 255 not allowed
            K2 = 33;   //pick any number between 1 and 254, 0 and 255 not allowed
            K3 = 243;  //pick any number between 1 and 254, 0 and 255 not allowed
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=192; //0xc0 set dongle key command
			buffer[2]=K0;
			buffer[3]=K1;
			buffer[4]=K2;
			buffer[5]=K3;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CHECKKEY:
			{
			//This is done within the developer's application to check for the correct
            //hardware.  The K0-K3 values must be the same as those entered in Set Key.
            if (hDevice == -1) return TRUE;
			//check hardware

			//IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
			DisableDataCallback(hDevice, true);
			
            //randomn numbers
            int N0 = 3;   //pick any number between 1 and 254
            int N1 = 1;   //pick any number between 1 and 254
            int N2 = 4;   //pick any number between 1 and 254
            int N3 = 1;   //pick any number between 1 and 254

            //this is the key from set key
            K0 = 7;
            K1 = 58;
            K2 = 33;
            K3 = 243;
			
			//hash, will use these for comparison later
            int R0;
            int R1;
            int R2;
            int R3;
			DongleCheck2(K0, K1, K2, K3, N0, N1, N2, N3, R0, R1, R2, R3);

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=193;  //0xc1 check dongle key command
			buffer[2]=N0;
			buffer[3]=N1;
			buffer[4]=N2;
			buffer[5]=N3;
			
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//after this write the next read beginning with 3rd byte = 193 will give 4 values which are used below for comparison
			for (int i=0;i<80;i++)
			{buffer[i]=0;}
			
			int countout=0;
			int result = BlockingReadData(hDevice, buffer, 100);
			
			while (result == 304 || (result == 0 && buffer[2] != 193))
			{
				if (result == 304)
				{
					// No data received after 100ms, so increment countout extra
					countout += 99;
				}
				countout++;
				if (countout > 1000) //increase this if have to check more than once
					break;
				result = BlockingReadData(hDevice, buffer, 100);
			}

			if (result ==0 && buffer[2]==193)
			{
				bool fail=false;
				if (R0!=buffer[3]) fail=true;
				if (R1!=buffer[4]) fail=true;
				if (R2!=buffer[5]) fail=true;
				if (R3!=buffer[6]) fail=true;
				hList = GetDlgItem(hDialog, IDC_PASSFAIL);
				if (hList == NULL) return TRUE;
				
				if (fail==false)
				{
					char msg[100]="Pass-Correct hardware found";
					SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
					//MessageBeep(MB_ICONHAND);
				}
				else
				{
					char msg[100]="Fail-Correct not hardware found";
					SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
					//MessageBeep(MB_ICONHAND);
				}
			}
			}

			return TRUE;
		case IDC_STARTCAL:
			//Start calibration
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=172;
			buffer[2]=1;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;
		case IDC_STOPCAL:
			//Stop calibration
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=172;
			buffer[2]=0;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;
		case IDC_DESCRIPTOR:
			if (hDevice == -1) return TRUE;
			//turn off callback
			DisableDataCallback(hDevice, true); //turn off callback so capture data here
		
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=214;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//after this write the next read 3rd byte=214 will give descriptor information
			for (int i=0;i<80;i++)
			{buffer[i]=0;}
			
			
			result = BlockingReadData(hDevice, buffer, 100);
			
			while (result == 304 || (result == 0 && buffer[2] != 214))
			{
				if (result == 304)
				{
					// No data received after 100ms, so increment countout extra
					countout += 99;
				}
				countout++;
				if (countout > 1000) //increase this if have to check more than once
					break;
				result = BlockingReadData(hDevice, buffer, 100);
			}
			
			if (result ==0 && buffer[2]==214)
			{
				char dataStr[256];
				//clear out listbox
				hList = GetDlgItem(hDialog, ID_EVENTS);
				if (hList == NULL) return TRUE;
				SendMessage(hList, LB_RESETCONTENT, 0, 0);

				_itoa_s(buffer[3]+1,dataStr,10);
				char str[80];
				strcpy_s (str,"PID ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
				
				_itoa_s(buffer[4],dataStr,10);
				strcpy_s (str,"Keymapstart ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[5],dataStr,10);
				strcpy_s (str,"Layer2offset=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[6],dataStr,10);
				strcpy_s (str,"Size of EEPROM MSB=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[7],dataStr,10);
				strcpy_s (str,"Size of EEPROM LSB=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
				
				_itoa_s(buffer[8],dataStr,10);
				strcpy_s (str,"MaxCol=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[9],dataStr,10);
				strcpy_s (str,"MaxRow=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (buffer[10]&64) strcpy_s (str,"Green LED ");
				if (buffer[10]&128) strcat_s (str,"Red LED ");
				if (strlen(str)==0) strcpy_s (str,"None ");
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[11],dataStr,10);
				strcpy_s (str,"Firmware Version=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
			
				_itoa_s((buffer[13]*256+buffer[12]),dataStr,10);
				strcpy_s (str, "PID=");
				strcat_s(str, dataStr);
				AddEventMsg(hDialog, str);
			}
			return TRUE;

		
		} 

		break;
	}

	return FALSE;
}



//---------------------------------------------------------------------

void FindAndStart(HWND hDialog)
{
	DWORD result;
	//long  deviceData[MAXDEVICES];  
	TEnumHIDInfo info[128];
	long  hnd;
	long  count;
	int pid;

	//clear out listbox
	HWND hList;
	hList = GetDlgItem(hDialog, ID_EVENTS);
	if (hList == NULL) return;
	SendMessage(hList, LB_RESETCONTENT, 0, 0);

	result = EnumeratePIE(0x5F3, info, count);

	if (result != 0)    
	{
		if (result==102){
			AddDevices(hDialog, "No PI Engineering Devices Found");
		}
		else{
		AddDevices(hDialog, "Error finding PI Engineering Devices");
		}
		return;
	} 
	else if (count == 0)    {
		AddDevices(hDialog, "No PI Engineering Devices Found");
		return;
	}

	for (int i=0;i<128;i++)combotodevice[i]=-1;
	int cbocount=0;
	int pidlist=-1;
	for (long i=0; i<count; i++)    {
		pid=info[i].PID; //get the device pid
		
		int hidusagepage=info[i].UP; //hid usage page
		int version=info[i].Version;
		int writelen=GetWriteLength(info[i].Handle);
		
		if ((hidusagepage == 0xC && writelen==36))    
		{	
			hnd = info[i].Handle; //handle required for piehid.dll calls
			result = SetupInterfaceEx(hnd);
			if (result != 0)    
			{
				AddDevices(hDialog, "Error setting up PI Engineering Device");
			}
			else    
			{
				if (pid==1325)
				{
					AddDevices(hDialog, "Found Device: XKE-64 Jog T-bar, PID=1325 (PID #1)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=0;
				}
				else if (pid==1326)
				{
					AddDevices(hDialog, "Found Device: XKE-64 Jog T-bar, PID=1326 (PID #2)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=1;
				}
				else if (pid==1327)
				{
					AddDevices(hDialog, "Found Device: XKE-64 Jog T-bar, PID=1327 (PID #3)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=2;
				}
				else if (pid==1328)
				{
					AddDevices(hDialog, "Found Device: XKE-64 Jog T-bar, PID=1328 (PID #4)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=3;
				}
				else if (pid==1329)
				{
					AddDevices(hDialog, "Found Device: XKE-64 Jog T-bar, PID=1329 (PID #5)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=4;
				}
				else if (pid==1330)
				{
					AddDevices(hDialog, "Found Device: XKE-64 Jog T-bar, PID=1330 (PID #6)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=5;
				}
				else if (pid==1331)
				{
					AddDevices(hDialog, "Found Device: XKE-64 Jog T-bar, PID=1331 (PID #7)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=6;
				}
				else
				{
					AddDevices(hDialog, "Unknown device found");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
			}
		}
		else
		{
			if (pid==1332)
			{
				AddDevices(hDialog, "Found Device: X-keys XKE-64 Jog T-bar, PID=1332 or PID #8 (KVM).");
				AddDevices(hDialog, "No input or output reports are available.  To change to PID #1");
				AddDevices(hDialog, "hold program switch down and replug the device.");
				SendMessage(Pid_Combo, CB_SETCURSEL, 7, 0);
				return;
			}
		}
	}

	if (cbocount>0)
	{
		hDevice=combotodevice[0]; //which is same as hDevice=info[combotodevice[0]].Handle
		readlength=info[combotodevice[0]].readSize;
		//print version, this is NOT firmware version which is given in the descriptor
		int version=info[combotodevice[0]].Version;
		char dataStr[256];
		_itoa_s(version,dataStr,10);
		
		hList = GetDlgItem(hDialog, IDC_LblVersion);
		SendMessage(hList, WM_SETTEXT,0, (LPARAM)(LPCSTR)dataStr);
		//show first device as selected
		hList = GetDlgItem(hDialog, IDC_LIST1);
		if (hList == NULL) return;
		SendMessage(hList, LB_SETCURSEL, 0, 0);
		SendMessage(Pid_Combo, CB_SETCURSEL, pidlist, 0);
	}
	else
	{
		AddDevices(hDialog, "No X-keys devices found");
	}
}

//------------------------------------------------------------------------

void AddDevices(HWND hDialog, char *msg)
{
	HWND hList;
	int cnt=-1;
	hList = GetDlgItem(hDialog, IDC_LIST1);
	if (hList == NULL) return;
    cnt=SendMessage(hList, LB_GETCOUNT, 0, 0);
	SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)msg);
}
//------------------------------------------------------------------------

void AddEventMsg(HWND hDialog, char *msg)
{
	HWND hList;
 
	int cnt=-1;
 
	hList = GetDlgItem(hDialog, ID_EVENTS);
	if (hList == NULL) return;
    cnt=SendMessage(hList, LB_GETCOUNT, 0, 0);
	SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)msg);
   
	SendMessage(hList, LB_SETCURSEL, cnt, 0);
}
//------------------------------------------------------------------------

DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error)
{
	
	char dataStr[256];
	sprintf_s(dataStr, "%02x : %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x\n", 
		deviceID, pData[0], pData[1], pData[2], pData[3], pData[4], pData[5], pData[6], pData[7], pData[8], pData[9], pData[10], pData[11], pData[12], pData[13], pData[14], pData[15], pData[16], pData[17], pData[18], pData[19], pData[20], pData[21], pData[22], pData[23],pData[24], pData[25], pData[26], pData[27], pData[28], pData[29], pData[30], pData[31], pData[32], pData[33], pData[34], pData[35], pData[36]);

	AddEventMsg(hDialog, dataStr);

	//Read Unit ID
	HWND hList = GetDlgItem(hDialog, IDC_UNITID3);
	if (hList == NULL) return TRUE;
	char dataStr2[256];
	_itoa_s(pData[1],dataStr2,10);
	SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)dataStr2);
	
	//for keyboard state

	hList = GetDlgItem(hDialog, IDC_KEYSTATES);
	if (hList == NULL) return TRUE;
	
	if ((pData[13] & 1)!=0)
	{
		char msg[100]="NumLck on";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}
	else
	{
		char msg[100]="NumLck off";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}

	hList = GetDlgItem(hDialog, IDC_KEYSTATES2);
	if (hList == NULL) return TRUE;
	
	if ((pData[13] & 2)!=0)
	{
		char msg[100]="CapsLck on";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}
	else
	{
		char msg[100]="CapsLck off";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}

	hList = GetDlgItem(hDialog, IDC_KEYSTATES3);
	if (hList == NULL) return TRUE;
	
	if ((pData[13] & 4)!=0)
	{
		char msg[100]="ScrLck on";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}
	else
	{
		char msg[100]="ScrLck off";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}
	//T-bar data
	hList = GetDlgItem(hDialog, IDC_TBar);
	if (hList == NULL) return TRUE;
	char msg[100];
	char str[80];
	_itoa_s(pData[18],msg,10);
	strcpy_s (str,"T-bar: ");
	strcat_s (str,msg);
	SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);
		
    //Shuttle Digital
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 7; j++) //the digital shuttle
        {
            int temp1 = (int)pow(2.0,j);
            int keynum = 8 * i + j;
            
            char printthis[100] = "";
			std::string thisshuttle="";

			int state=0; //0=was up and is up, 1=was up and is down, 2= was down and is down, 3=was down and is up 
			if (((pData[i+14] & temp1)!=0) && ((lastpData[i+14] & temp1)==0))
				state=1;
			else if (((pData[i+14] & temp1)!=0) && ((lastpData[i+14] & temp1)!=0))
				state=2;
			else if (((pData[i+14] & temp1)==0) && ((lastpData[i+14] & temp1)!=0))
				state=3;

            switch (keynum)
            {
                case 0: //shuttle +1
                    thisshuttle = "Shuttle Digital: +1";
                    break;
                case 1: //shuttl +2
                    thisshuttle = "Shuttle Digital: +2";
                    break;
                case 2: //shuttle +3
                    thisshuttle = "Shuttle Digital: +3";
                    break;
                case 3: //shuttle +4
                    thisshuttle = "Shuttle Digital: +4";
                    break;
                case 4: //shuttle +5
                    thisshuttle = "Shuttle Digital: +5";
                    break;
                case 5: //shuttle +6
                    thisshuttle = "Shuttle Digital: +6";
                    break;
                case 6: //shuttle +7
                    thisshuttle = "Shuttle Digital: +7";
                    break;
                case 8: //shuttle -1
                    thisshuttle = "Shuttle Digital: -1";
                    break;
                case 9: //shuttl -2
                    thisshuttle = "Shuttle Digital: -2";
                    break;
                case 10: //shuttle -3
                    thisshuttle = "Shuttle Digital: -3";
                    break;
                case 11: //shuttle -4
                    thisshuttle = "Shuttle Digital: -4";
                    break;
                case 12: //shuttle -5
                    thisshuttle = "Shuttle Digital: -5";
                    break;
                case 13: //shuttle -6
                    thisshuttle = "Shuttle Digital: -6";
                    break;
                case 14: //shuttle -7
                    thisshuttle = "Shuttle Digital: -7";
                    break;
            }
                       
            if (state == 1)
            {
                thisshuttle = thisshuttle + " enter";
				
				hList = GetDlgItem(hDialog, IDC_Shuttle5);
				if (hList == NULL) return TRUE;
				strcpy_s (str,thisshuttle.c_str());
				SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);

            }
            else if (state==3)
            {
               thisshuttle = thisshuttle + " exit";
                //note the -1 exit and +1 exit will be overwritten by the At Rest below
			   hList = GetDlgItem(hDialog, IDC_Shuttle5);
			   if (hList == NULL) return TRUE;
			   strcpy_s (str,thisshuttle.c_str());
			   SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);
            }
        }
    }	

	BYTE val = (pData[13] & 0x20);
    if (val != 0)
    {
        std::string thisshuttle = "Shuttle Digital: At Rest";

		hList = GetDlgItem(hDialog, IDC_Shuttle5);
		if (hList == NULL) return TRUE;
	    strcpy_s (str,thisshuttle.c_str());
	    SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);
    }

	//Shuttle Analog
	hList = GetDlgItem(hDialog, IDC_Shuttle4);
	if (hList == NULL) return TRUE;
	_itoa_s(pData[20],msg,10);
	strcpy_s (str,"Shuttle Analog: ");
	strcat_s (str,msg);
	SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);

	//Jog Digital
    val = (pData[13] & 0x40);
    if (val != 0)
    {
        std::string thisjog = "Jog Digital: Clockwise";

		hList = GetDlgItem(hDialog, IDC_Jog3);
		if (hList == NULL) return TRUE;
		strcpy_s (str,thisjog.c_str());
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);

    }
    val = (pData[13] & 0x80);
    if (val != 0)
    {
        std::string thisjog = "Jog Digital: Counter Clockwise";

		hList = GetDlgItem(hDialog, IDC_Jog3);
		if (hList == NULL) return TRUE;
		strcpy_s (str,thisjog.c_str());
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);
    }
		
	//Jog Analog
	if (pData[19] == 1) //cw
	{
		std::string thisjog = "Jog Analog: Clockwise";

		hList = GetDlgItem(hDialog, IDC_Jog2);
		if (hList == NULL) return TRUE;
		strcpy_s (str,thisjog.c_str());
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);
	}
	else if (pData[19] == 255)
	{
		std::string thisjog = "Jog Analog: Counter Clockwise";

		hList = GetDlgItem(hDialog, IDC_Jog2);
		if (hList == NULL) return TRUE;
		strcpy_s (str,thisjog.c_str());
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);
	}

	for (int i=0;i<33;i++)
	{
		lastpData[i]=pData[i];  //save it for comparison on next read
	}
	//Buttons
	int maxcols=10;
	int maxrows=8;
	for (int i=0;i<maxcols;i++) //loop for each column of button data (Max Cols)
	{
		for (int j=0;j<maxrows;j++) //loop for each row of button data (Max Rows)
		{
			int temp1=pow(2.0,j);
			int keynum=maxrows*i+j; //0 based index

			int state=0; //0=was up and is up, 1=was up and is down, 2= was down and is down, 3=was down and is up 
			if (((pData[i+3] & temp1)!=0) && ((lastpData[i+3] & temp1)==0))
				state=1;
			else if (((pData[i+3] & temp1)!=0) && ((lastpData[i+3] & temp1)!=0))
				state=2;
			else if (((pData[i+3] & temp1)==0) && ((lastpData[i+3] & temp1)!=0))
				state=3;
			
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
                                case 5: //button 5  - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 6: //button 6 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 7: //button 7  - NA on XKE-Jog T-bar
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
                                case 13: //button 13 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 14: //button 14 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 15: //button 15 - NA on XKE-Jog T-bar
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
                                case 21: //button 21 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 22: //button 22 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 23: //button 23 - NA on XKE-Jog T-bar
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
                                case 29: //button 29 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 30: //button 30 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 31: //button 31 - NA on XKE-Jog T-bar
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
                                case 37: //button 37
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 38: //button 38
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 39: //button 39
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
                                case 45: //button 45
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 46: //button 46
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 47: //button 47
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
                                case 53: //button 53
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 54: //button 54
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 55: //button 55
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
                                case 72: //button 72 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 73: //button 73 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 74: //button 74 - NA on XKE-Jog T-bar
                                    if (state == 1) //key was pressed
                                    {
                                        //do press actions
                                    }
                                    else if (state == 3) //key was released
                                    {
                                        //do release action
                                    }
                                    break;
                                case 75: //button 75 - NA on XKE-Jog T-bar
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
                            }
				
		}
	}

	for (int i=0;i<readlength;i++)
	{
		lastpData[i]=pData[i];  //save it for comparison on next read
	}
	//end Buttons
	//error handling
	if (error==307)
	{
		CleanupInterface(hDevice);
		MessageBeep(MB_ICONHAND);
		AddEventMsg(hDialog, "Device Disconnected");
	}
	
	return TRUE;
}
//------------------------------------------------------------------------

DWORD __stdcall HandleErrorEvent(DWORD deviceID, DWORD status)
{
	MessageBeep(MB_ICONHAND);
	AddEventMsg(hDialog, "Error from error callback");
	return TRUE;
}
//------------------------------------------------------------------------
