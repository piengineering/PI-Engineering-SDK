// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
#include "PIEHid32.h"

#include <string.h>
#include <stdio.h>

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
DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error);
DWORD __stdcall HandleErrorEvent(DWORD deviceID, DWORD status);
void AddDevices(HWND hDialog, char *msg);

BYTE buffer[80];  //used for writing to device

HWND hDialog;
long hDevice = -1;
int combotodevice[128];
HWND Pin_Combo; //digital output pins
HWND PinState_Combo; //digital output pin states

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

	//Digital outputs combobox
	Pin_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 10, 790, 80, 607, hDialog, NULL, hInstance, NULL); 
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 1");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 2");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 3");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 4");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 5");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 6");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 7");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 8");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 11");
	SendMessage(Pin_Combo, CB_ADDSTRING, 0, (LPARAM)"Pin 12");
	//set default
	SendMessage(Pin_Combo, CB_SETCURSEL, 0, 0);
	PinState_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 100, 790, 60, 607, hDialog, NULL, hInstance, NULL); 
	SendMessage(PinState_Combo, CB_ADDSTRING, 0, (LPARAM)"Off");
	SendMessage(PinState_Combo, CB_ADDSTRING, 0, (LPARAM)"On");
	SendMessage(PinState_Combo, CB_ADDSTRING, 0, (LPARAM)"Flash");
	SendMessage(PinState_Combo, CB_SETCURSEL, 0, 0);

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
			//Turn off the data callback
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
			buffer[2]=6; //6=green, 7=red, 0=pin 13, 1=pin 14
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
			buffer[2]=7; //6=green, 7=red, 0=pin 13, 1=pin 14
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
		case IDC_CHECK5:
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=0; //6=green, 7=red, 0=pin 13, 1=pin 14
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK5);
			if (hList == NULL) return TRUE;
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

		case IDC_CHECK6:
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=1; //6=green, 7=red, 0=out1, 1=out2
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK6);
			if (hList == NULL) return TRUE;
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

		case IDC_TOPID1:
			//Change to PID 1
            for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204; //0xcc
			buffer[2]=0; //0=PID 1, 1=PID 2, 2=PID 3, 3=PID 4
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

		case IDC_TOPID2:
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204; //0xcc
			buffer[2]=1;   //0=PID 1, 1=PID 2, 2=PID 3, 3=PID 4
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_TOPID3:
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204; //0xcc
			buffer[2]=2;   //0=PID 1, 1=PID 2, 2=PID 3, 3=PID 4
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_TOPID4:
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204; //0xcc
			buffer[2]=3;   //0=PID 1, 1=PID 2, 2=PID 3, 3=PID 4
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
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
		case IDC_TIMESTAMP:
			//Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210;
			buffer[2]=0; //0 to turn off time stamp, 1 to turn on time stamp
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

		case IDC_TIMESTAMP2:
			//Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210;
			buffer[2]=1; //0 to turn off time stamp, 1 to turn on time stamp
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
			WriteData(hDevice, buffer);
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
			WriteData(hDevice, buffer);
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
			WriteData(hDevice, buffer);
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

				if (buffer[3]==0) AddEventMsg(hDialog, "PID #1");
				else if (buffer[3]==2) AddEventMsg(hDialog, "PID #2");
				
				_itoa_s(buffer[4],dataStr,10);
				char str[80];
				strcpy_s (str,"Keymapstart ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[5],dataStr,10);
				strcpy_s (str,"Layer2offset ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[6],dataStr,10);
				strcpy_s (str,"Size of EEPROM MSB ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[7],dataStr,10);
				strcpy_s (str,"Size of EEPROM LSB ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
				
				_itoa_s(buffer[8],dataStr,10);
				strcpy_s (str,"MaxCol ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[9],dataStr,10);
				strcpy_s (str,"MaxRow ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (buffer[10]&64) strcpy_s (str,"Green LED ");
				if (buffer[10]&128) strcat_s (str,"Red LED ");
				if (buffer[10]&1) strcat_s (str,"Out 1 ");
				if (buffer[10]&2) strcat_s (str,"Out 2 ");
				if (strlen(str)==0) strcpy_s (str,"None ");
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[11],dataStr,10);
				strcpy_s (str,"Firmware Version ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
			
				_itoa_s((buffer[13]*256+buffer[12]),dataStr,10);
				strcpy_s (str, "PID=");
				strcat_s(str, dataStr);
				AddEventMsg(hDialog, str);
			}
			return TRUE;
		case IDC_SETCONFIG:

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=160; //0xa0
			buffer[2]=0; //pins 1, 2, 3, 4 MSB 0-0-0-0-4-3-2-1 LSB 0=output, 1=input
			buffer[3]=0; //pins 5, 6, 7, 8, 11, 12 MSB 0-0-12-11-8-7-6-5 LSB 0=output, 1=input
			buffer[4]=0x0f; //pins 1, 2, 3, 4 MSB 0-0-0-0-4-3-2-1 LSB 0=resistive pull up (short to ground), 1=resistive pull down (drive high)
			buffer[5]=0x3f; //pins 5, 6, 7, 8, 11, 12 MSB 0-0-12-11-8-7-6-5 LSB  0=resistive pull up (short to ground), 1=resistive pull down (drive high)
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_SAVECONFIG:
			//save the input/output configurations to the memory
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=162; //0xa2
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_GETCONFIG:
			//after this is sent, response will be sent with the information, in the HandleDataEvent
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=161; //0xa1
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_GETSTATES:
			//after this is sent, response will be sent with the information, in the HandleDataEvent
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=174; //0xae
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//after this is sent, response will be sent with the information, in the HandleDataEvent
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=175; //0xaf
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_SETOUT:
			//set the state of the output
			int selection=SendMessage(Pin_Combo, CB_GETCURSEL, 0, 0);
			int pin=selection+1;
			if (selection==9) pin=11;
			if (selection==10) pin=12;
			int state=SendMessage(PinState_Combo, CB_GETCURSEL, 0, 0);

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=181; //0xb5
			buffer[2]=pin;
			buffer[3]=state;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
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
				if (pid==1351)
				{
					AddDevices(hDialog, "Found Device: HD15 GPIO, PID=1351 (PID #1)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
				else if (pid==1352)
				{
					AddDevices(hDialog, "Found Device: HD15 GPIO, PID=1352 (PID #2)");
					combotodevice[cbocount] = i;
					cbocount++;
				}
				else if (pid==1353)
				{
					AddDevices(hDialog, "Found Device: HD15 GPIO, PID=1353 (PID #3)");
					combotodevice[cbocount] = i;
					cbocount++;
				}
				else if (pid==1354)
				{
					AddDevices(hDialog, "Found Device: HD15 GPIO, PID=1354 (PID #4)");
					combotodevice[cbocount] = i;
					cbocount++;
				}
				else
				{
					AddDevices(hDialog, "Unknown device found");
					combotodevice[cbocount] = i;
					cbocount++;
				}
			}
		}
	}

	if (cbocount>0)
	{
		hDevice=combotodevice[0]; //which is same as hDevice=info[combotodevice[0]].Handle

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
	
	if ((pData[7] & 1)!=0)
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
	
	if ((pData[7] & 2)!=0)
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
	
	if ((pData[7] & 4)!=0)
	{
		char msg[100]="ScrLck on";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}
	else
	{
		char msg[100]="ScrLck off";
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
	}

    if (pData[2]==0xa1) //configuration state being returned
	{
		//pData[3] : 0
		//pData[4] : 0
		//pData[5] : 0
		//pData[6] gives Pins 1, 2, 3, 4 where pin 1 is lsb, 0 is output, 1 is input
		//pData[7] gives Pins 5, 6, 7, 8, 11, 12 where pin 5 is lsb, 0 is output, 1 is input
		//pData[8] gives Pins 1, 2, 3, 4 where pin 1 is lsb, for inputs only 0 for resistive pull up (short to ground), 1 for resistive pull down (drive high)
		//pData[9] gives Pins 5, 6, 7, 8, 11, 12 where pin 1 is lsb, for inputs only 0 for resistive pull up (short to ground), 1 for resistive pull down (drive high)
	}

	if (pData[2]==0xae) //output states being returned
	{
		//pData[3] : 0
		//pData[4] : 0
		//pData[5] : Pins 13, 14 and green and red leds. Pin 13=bit 1, pin 14=bit 2, green=bit 7, red=bit 8, 0=off, 1=on
        //pData[6] : Pins 1, 2, 3, 4, where pin 1=bit 1, pin 2=bit 2, pin 3=bit 3, pin 4=bit 4, 0=off, 1=on
        //pData[7] : Pins 5, 6, 7, 8, 11, 12, where pin 5=bit 1, pin 6=bit 2, pin 7=bit 3, pin 8=bit 4, pin 11=bit 5, pin 12=bit 6, 0=off, 1=on
	}

	if (pData[2]==0xaf) //output flash states being returned
	{
		//pData[3] : Pins 13, 14 and green and red leds. Pin 13=bit 1, pin 14=bit 2, green=bit 7, red=bit 8, 0=off, 1=flash
        //pData[4] : Flash frequency
		//pData[5] : Pins 13, 14 and green and red leds. Pin 13=bit 1, pin 14=bit 2, green=bit 7, red=bit 8, 0=off, 1=flash
        //pData[6] : Pins 1, 2, 3, 4, where pin 1=bit 1, pin 2=bit 2, pin 3=bit 3, pin 4=bit 4, 0=off, 1=flash
        //pData[7] : Pins 5, 6, 7, 8, 11, 12, where pin 5=bit 1, pin 6=bit 2, pin 7=bit 3, pin 8=bit 4, pin 11=bit 5, pin 12=bit 6, 0=off, 1=flash
	}

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
