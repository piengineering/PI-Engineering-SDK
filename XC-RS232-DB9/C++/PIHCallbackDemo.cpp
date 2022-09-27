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
void AddDevices(HWND hDialog, char *msg);
DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error);
DWORD __stdcall HandleErrorEvent(DWORD deviceID, DWORD status);

BYTE buffer[80];  //used for writing to device

HWND hDialog;
long hDevice = -1;
int combotodevice[128];

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

	//hList = GetDlgItem(hDialog, IDC_BAUDRATE);
	//if (hList == NULL) return 0;
	//SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"9600");
	//hList = GetDlgItem(hDialog, IDC_PARITY2);
	//if (hList == NULL) return 0;
	//SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");

	hList = GetDlgItem(hDialog, IDC_RS232);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"");

	
	hList = GetDlgItem(hDialog, IDC_CTS);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"CTS Clear");
	
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
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; //0=off, 1=on, 2=flash
			
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
		case IDC_BAUD:
			{
				//Sending this command will change the baud rate of the XC-RS232-DB9, it must match that of the connected serial device
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0]=0;
				buffer[1]=217; //0xd9

				char baudrate[10];
				hList = GetDlgItem(hDialog, IDC_BAUDRATE);
				SendMessage(hList, WM_GETTEXT, 8, (LPARAM)baudrate);
				int temp=(int)atoi(baudrate);
				if (temp==1200)
				{
					buffer[2]=0;   //0=1200, 1=2400, 2=4800, 3=9600, 4=19200, 5=38400, 6=57600, 7=115400
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				else if (temp==2400)
				{
					buffer[2]=1;
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				else if (temp==4800)
				{
					buffer[2]=2;
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				else if (temp==9600)
				{
					buffer[2]=3;
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				else if (temp==19200)
				{
					buffer[2]=4;
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				else if (temp==38400)
				{
					buffer[2]=5;
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				else if (temp==57600)
				{
					buffer[2]=6;
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				else if (temp==115400)
				{
					buffer[2]=7;
					result=404;
					while (result==404)
					{
						result = WriteData(hDevice, buffer);
					}
				}
				//result = WriteData(hDevice, buffer); //do nothing if not one of the above baud rates
			}
			return TRUE;

		case IDC_PARITY:
			{
				//Sending this command will change the parity of the XC-RS232-DB9, it must match that of the connected serial device
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0]=0;
				buffer[1]=219;  //0xdb
				char parity[10];
				hList = GetDlgItem(hDialog, IDC_PARITY2);
				SendMessage(hList, WM_GETTEXT, 8, (LPARAM)parity);
				int temp=(int)atoi(parity); 
				if (temp==0 || temp==2 || temp==6)
				{
					buffer[2]=(BYTE)atoi(parity);  //0=None, 2=Even, 6=Odd
					result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
				}
			}
			return TRUE;
		case IDC_SERIALCOMMAND:
			{
				//Sends commands to the connected serial device, you must know the command structure of the serial device
				//in this example the serial device will accept the command "\nB8;" where\n designates linefeed
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0]=0;
				buffer[1]=209;  //0xd1
				buffer[2]=4;  //number of bytes to follow
				buffer[3]=0x0A; //1st byte, ascii for linefeed
				buffer[4]=0x42; //2nd byte, ascii for B
				buffer[5]=0x38; //3rd byte, ascii for 8
				buffer[6]=0x3B; //4th byte ascii for ;
				result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}

				//other example, send ABC;
                //wData[2] = 04; // this is the number of bytes to follow
                //wData[3] = 0x41; //A
                //wData[4] = 0x42; //B
                //wData[5] = 0x43; //C
                //wData[6] = 0x3b; //;
				
			}
			return TRUE;
		case IDC_SETRTS:
			{
				//If check then not ready to send, if unchecked then ready to send
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0]=0;
				buffer[1]=218;  //0xda
				hList = GetDlgItem(hDialog, IDC_SETRTS);
				if (hList == NULL) return TRUE;
				if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[2]=1; 
				else buffer[2]=0;
				result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			}
			return TRUE;
			case IDC_KEYBOARD:
			{
				//If checked then incoming ascii data from the connected serial device will be translated to keystrokes
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0]=0;
				buffer[1]=208;  //0xd0
				hList = GetDlgItem(hDialog, IDC_KEYBOARD);
				if (hList == NULL) return TRUE;
				if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[2]=1; 
				else buffer[2]=0;
				result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
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

				_itoa_s((buffer[16]*256+buffer[15]),dataStr,10);
				strcpy_s (str, "MaxAddressToRead=");
				strcat_s(str, dataStr);
				AddEventMsg(hDialog, str);

				double baudrate=(231.0/buffer[26])*1000;
				_itoa_s((baudrate),dataStr,10);
				strcpy_s (str, "Baud rate=");
				strcat_s(str, dataStr);
				AddEventMsg(hDialog, str);

				if (buffer[28]==0)
				{
					strcpy_s (str, "Parity=None");
					AddEventMsg(hDialog, str);
				}
				else if (buffer[28]==2)
				{
					strcpy_s (str, "Parity=Even");
					AddEventMsg(hDialog, str);
				}
				else if (buffer[28]==6)
				{
					strcpy_s (str, "Parity=Odd");
					AddEventMsg(hDialog, str);
				}
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
				
				if (pid==1257)
				{
					AddDevices(hDialog, "Found Device: XC-RS232-DB9, PID=1257 (PID #1)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
				else if (pid==1258)
				{
					AddDevices(hDialog, "Found Device: XC-RS232-DB9, PID=1258 (PID #2)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
				else if (pid==1259)
				{
					AddDevices(hDialog, "Found Device: XC-RS232-DB9, PID=1259 (PID #3)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
				else if (pid==1260)
				{
					AddDevices(hDialog, "Found Device: XC-RS232-DB9, PID=1260 (PID #4)");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
				else
				{
					AddDevices(hDialog, "Unknown device found");
					combotodevice[cbocount] = i; //this is the handle
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

	hList = GetDlgItem(hDialog, IDC_RS232);
	if (hList == NULL) return 0;
	if (pData[2]==0xd8) //this is RS232 data
	{
		SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"RS232 incoming data");
	}
	else if (pData[2]==0 || pData[2]==2)
	{
		SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"Switches incoming data");
	}
	else
	{
		SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"");
	}
	
	//CTS
	if (pData[2]==0xd9 && pData[3]==1) //received message from connected serial device to wait
	{
		hList = GetDlgItem(hDialog, IDC_CTS);
		if (hList == NULL) return 0;
		SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"CTS Wait");
	}
	else if (pData[2]==0xd9 && pData[3]==0)
	{
		hList = GetDlgItem(hDialog, IDC_CTS);
		if (hList == NULL) return 0;
		SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"CTS Clear");
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
