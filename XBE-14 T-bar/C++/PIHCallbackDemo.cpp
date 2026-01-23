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
HWND Color_Combo;
HWND Bank_Combo;
long saveabsolutetime;  //for timestamp demo

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

	hList = GetDlgItem(hDialog, IDC_TXTBL2);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");

	hList = GetDlgItem(hDialog, IDC_TXTBL3);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"255");

	hList = GetDlgItem(hDialog, IDC_TXTBL4);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"255");

	hList = GetDlgItem(hDialog, IDC_TXTBL5);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"255");

	hList = GetDlgItem(hDialog, IDC_TXTBL6);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"255");

	hList = GetDlgItem(hDialog, IDC_TXTBL7);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"10");

	hList = GetDlgItem(hDialog, IDC_TxtVersion);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"100");

	hList = GetDlgItem(hDialog, IDC_Buttons);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"Buttons:");

	Color_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 9, 426, 100, 500, hDialog, NULL, hInstance, NULL); 
	
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Off");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Red");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Orange");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Yellow");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Green");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Turquoise");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Blue");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Pink");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"Purple");
	SendMessage(Color_Combo, CB_ADDSTRING, 0, (LPARAM)"White");
	//set default
	SendMessage(Color_Combo, CB_SETCURSEL, 1, 0);

	Bank_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 186, 425, 100, 100, hDialog, NULL, hInstance, NULL); 
	
	SendMessage(Bank_Combo, CB_ADDSTRING, 0, (LPARAM)"bank 1 (upper)");
	SendMessage(Bank_Combo, CB_ADDSTRING, 0, (LPARAM)"bank 2 (lower)");
	//set default
	SendMessage(Bank_Combo, CB_SETCURSEL, 0, 0);

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
			buffer[2]=1; //1=Pin 1, 2=Pin 2, 3=Pin 3, 4=Pin 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK1);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
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
			buffer[2]=2; //1=Pin 1, 2=Pin 2, 3=Pin 3, 4=Pin 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK2);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

		case IDC_CHECK3:
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=3; //1=Pin 1, 2=Pin 2, 3=Pin 3, 4=Pin 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK3);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CHECK4:
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=4; //1=Pin 1, 2=Pin 2, 3=Pin 3, 4=Pin 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHECK4);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
        //RGB Backlight Features
		case IDC_CHKBLONOFF2:
			{
			//Control single RGB LED
			
			//Use the Set Flash Freq to control frequency of blink
            //Index (in decimal)
            //Columns-->
            //  0   -  8
            //  1   -  9
            //  2   -  10 
            //  3   -  11  
            //  4   6  12 
            //  5   7  13 

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=165; //0xa5
			//get key index
			hList = GetDlgItem(hDialog, IDC_TXTBL2);
			if (hList == NULL) return TRUE;
			char keyid[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)keyid);
			buffer[2]= atoi(keyid);
			//get bank
			int bank=SendMessage(Bank_Combo, CB_GETCURSEL, 0, 0);
			buffer[3]=bank;
			//get color and from selected color, the rgb values OR enter desired RGB values
			//note both color and intensity are controlled here. The brightest red is 255, 0, 0 with dimmer reds lowering the value of 255
			int color=SendMessage(Color_Combo, CB_GETCURSEL, 0, 0);
			switch (color)
			{
			case 0: //off
				buffer[4] = 0; //r
				buffer[5] = 0; //g
				buffer[6] = 0; //b
				break;
			case 1: //red
				buffer[4] = 255; //r
				buffer[5] = 0; //g
				buffer[6] = 0; //b
				break;
			case 2: //orange
				buffer[4] = 255; //r
				buffer[5] = 20; //g
				buffer[6] = 0; //b
				break;
			case 3: //yellow
				buffer[4] = 255; //r
				buffer[5] = 129; //g
				buffer[6] = 0; //b
				break;
			case 4: //green
				buffer[4] = 0; //r
				buffer[5] = 255; //g
				buffer[6] = 0; //b
				break;
			case 5: //turquoise
				buffer[4] = 0; //r
				buffer[5] = 255; //g
				buffer[6] = 129; //b
				break;
			case 6: //blue
				buffer[4] = 0; //r
				buffer[5] = 0; //g
				buffer[6] = 255; //b
				break;
			case 7: //pink
				buffer[4] = 255; //r
				buffer[5] = 8; //g
				buffer[6] = 40; //b
				break;
			case 8: //purple
				buffer[4] = 150; //r
				buffer[5] = 0; //g
				buffer[6] = 255; //b
				break;
			case 9: //white
				buffer[4] = 255; //r
				buffer[5] = 255; //g
				buffer[6] = 255; //b
				break;
			}
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKBLONOFF2);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_UNCHECKED) //turn off the led
			{
				buffer[4] = 0; //r
				buffer[5] = 0; //g
				buffer[6] = 0; //b
			}
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[7]=1; //0=no flash, 1=flash
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
			}
		case IDC_BUTTON2:
			{
			//Turn all Bank 1 (upper bank) LEDs to the selected color
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=166; //0xa6
			buffer[2]=0;  //0=Bank 1 (upper LEDs), 1=Bank 2 (lower LEDs)
			//get color or enter desired rgb values
			int color=SendMessage(Color_Combo, CB_GETCURSEL, 0, 0);
			switch (color)
			{
			case 0: //off
				buffer[3] = 0; //r
				buffer[4] = 0; //g
				buffer[5] = 0; //b
				break;
			case 1: //red
				buffer[3] = 255; //r
				buffer[4] = 0; //g
				buffer[5] = 0; //b
				break;
			case 2: //orange
				buffer[3] = 255; //r
				buffer[4] = 20; //g
				buffer[5] = 0; //b
				break;
			case 3: //yellow
				buffer[3] = 255; //r
				buffer[4] = 129; //g
				buffer[5] = 0; //b
				break;
			case 4: //green
				buffer[3] = 0; //r
				buffer[4] = 255; //g
				buffer[5] = 0; //b
				break;
			case 5: //turquoise
				buffer[3] = 0; //r
				buffer[4] = 255; //g
				buffer[5] = 129; //b
				break;
			case 6: //blue
				buffer[3] = 0; //r
				buffer[4] = 0; //g
				buffer[5] = 255; //b
				break;
			case 7: //pink
				buffer[3] = 255; //r
				buffer[4] = 8; //g
				buffer[5] = 40; //b
				break;
			case 8: //purple
				buffer[3] = 150; //r
				buffer[4] = 0; //g
				buffer[5] = 255; //b
				break;
			case 9: //white
				buffer[3] = 255; //r
				buffer[4] = 255; //g
				buffer[5] = 255; //b
				break;
			}
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
			}
		case IDC_BUTTON3:
			{
			//Turn all Bank 1 (upper bank) LEDs to the selected color
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=166; //0xa6
			buffer[2]=1;  //0=Bank 1 (upper LEDs), 1=Bank 2 (lower LEDs)
			//get color or enter desired rgb values
			int color=SendMessage(Color_Combo, CB_GETCURSEL, 0, 0);
			switch (color)
			{
			case 0: //off
				buffer[3] = 0; //r
				buffer[4] = 0; //g
				buffer[5] = 0; //b
				break;
			case 1: //red
				buffer[3] = 255; //r
				buffer[4] = 0; //g
				buffer[5] = 0; //b
				break;
			case 2: //orange
				buffer[3] = 255; //r
				buffer[4] = 20; //g
				buffer[5] = 0; //b
				break;
			case 3: //yellow
				buffer[3] = 255; //r
				buffer[4] = 129; //g
				buffer[5] = 0; //b
				break;
			case 4: //green
				buffer[3] = 0; //r
				buffer[4] = 255; //g
				buffer[5] = 0; //b
				break;
			case 5: //turquoise
				buffer[3] = 0; //r
				buffer[4] = 255; //g
				buffer[5] = 129; //b
				break;
			case 6: //blue
				buffer[3] = 0; //r
				buffer[4] = 0; //g
				buffer[5] = 255; //b
				break;
			case 7: //pink
				buffer[3] = 255; //r
				buffer[4] = 8; //g
				buffer[5] = 40; //b
				break;
			case 8: //purple
				buffer[3] = 150; //r
				buffer[4] = 0; //g
				buffer[5] = 255; //b
				break;
			case 9: //white
				buffer[3] = 255; //r
				buffer[4] = 255; //g
				buffer[5] = 255; //b
				break;
			}
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
			}
		case IDC_BUTTON4:
			{
				//RGB global (per bank) dimming control - this command is meant to be used once the banks of LEDs have been configured to the desired colors. 255 is the brightest or 100% on and 0 is the dimmest.
                //Use caution if set a dim factor to 0, LEDs will be off and will not be able to be turned on without changing the dim factor to a non-0 value.
                for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[1]=164; //0xa4
				
				//get intensities
			    char intensity[10];
			    SendMessage(GetDlgItem(hDialog, IDC_TXTBL3), WM_GETTEXT, 8, (LPARAM)intensity);
				buffer[2]= atoi(intensity);
				SendMessage(GetDlgItem(hDialog, IDC_TXTBL4), WM_GETTEXT, 8, (LPARAM)intensity);
				buffer[3]= atoi(intensity);
				result=404;
				while (result==404)
				{
					result = WriteData(hDevice, buffer);
				}
				return TRUE;
			}
		//Legacy Backlight Features
		case IDC_CHKBLONOFF:
			//This command is a legacy command meant to mimick the Set Individual Backlight command on non-RGB LED X-keys devices.
            //Using the legacy backlight commands will force the upper bank of LEDs to be blue and the lower to be red
			
			//Use the Set Flash Freq to control frequency of blink
            //Key Index (in decimal)
            //Columns-->
            //Upper LEDs (ie Bank 1)
            //  0   -  8
            //  1   -  9
            //  2   -  10 
            //  3   -  11  
            //  4   6  12 
            //  5   7  13 
            //Lower LEDs (ie Bank 2)
            //  14   -   22
            //  15   -   23
            //  16   -   24 
            //  17   -   25  
            //  18   20  26 
            //  19   21  27

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=181; //0xb5
			//get key index
			hList = GetDlgItem(hDialog, IDC_TXTBL);
			if (hList == NULL) return TRUE;
			char keyid[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)keyid);
			buffer[2]= atoi(keyid);
			buffer[3]=0;
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKBLONOFF);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; //on
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; //flash
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
			{
			//Sets the Bank 1 and Bank 2 backlight intensity, one value for entire bank, same as Dim Factors
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}

			buffer[0]=0;
			buffer[1]=187; //0xbb
			char intensity[10];
			SendMessage(GetDlgItem(hDialog, IDC_TXTBL5), WM_GETTEXT, 8, (LPARAM)intensity);
			buffer[2]= atoi(intensity);  //0-255 bank 1 intensity
			SendMessage(GetDlgItem(hDialog, IDC_TXTBL6), WM_GETTEXT, 8, (LPARAM)intensity);
			buffer[3]= atoi(intensity); //0-255 bank 2 intensity
			
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
			}
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
		case IDC_BUTTON5: //Set the flash frequency
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=180; //0xb4
			//get the desired value, lower the values the faster the flash
			char frequency[10];
			SendMessage(GetDlgItem(hDialog, IDC_TXTBL7), WM_GETTEXT, 8, (LPARAM)frequency);
			buffer[2]= atoi(frequency); 
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_GETBLSTATE: 
			//Get the backlight state (both banks) by given button, results in callback
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=167; //0xa7
			//get index
			hList = GetDlgItem(hDialog, IDC_TXTBL2);
			if (hList == NULL) return TRUE;
			char keyid2[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)keyid2);
			buffer[2]= atoi(keyid2);
			
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
		case IDC_TIMESTAMPOFF:
			//Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210; //0xd2
			buffer[2]=0; //0=disable, 1=enable (factory default)
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_TIMESTAMPON:
			//Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210; //0xd2
			buffer[2]=1; //0=disable, 1=enable (factory default)
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
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
			case IDC_ConfigureGPIO:
		{
			//Configure each GPIO pin as output (factory default) or input and if input, which type of input
			//Current configuration can be read in the Descriptor
			//Note, to save this configuration to device memory so on boot up it is in this configuration, user must send a "Save GPIO Configuration" command (IDC_SaveGPIO)
			BYTE gpioconfig=0; //pins 1, 2, 3, 4   MSB 0-0-0-0-4-3-2-1 LSB   0=output, 1=input, factory default=0
			BYTE inputconfig=0; //pins 1, 2, 3, 4  MSB 0-0-0-0-4-3-2-1 LSB   0=resistive pull up (factory default), 1=resistive pull down, note: if a bit is configured as output in gpioconfig, then its bit setting here doesn't matter, factory default=0
            //examples:
			//gpioinput=15 is all pins configured as input
			//gpioinput=1 is only pin 1 configured as input, pins 2-4 as outputs
			//gpioinput=5 is pin 1 and pin 3 configured as input, pin 2 and pin 4 as output
			gpioconfig=15;
			inputconfig=0; 
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=147; //0x93
			buffer[2]=gpioconfig;
			buffer[3]=inputconfig;

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
		case IDC_SaveGPIO:
		{
			//Saves the GPIO configuration set using the above command to the device memory
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=148; //0x94
			
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

				strcpy_s (str,"LEDs/Outputs=");
				if (buffer[10]&1) strcat_s (str,"NumLock, ");
				if (buffer[10]&2) strcat_s (str,"CapsLock, ");
				if (buffer[10]&4) strcat_s (str,"ScrLock, ");
				if (buffer[10]&16) strcat_s (str,"GPIO Pin 1, ");
				if (buffer[10]&32) strcat_s (str,"GPIO Pin 2, ");
				if (buffer[10]&64) strcat_s (str,"GPIO Pin 3, ");
				if (buffer[10]&128) strcat_s (str,"GPIO Pin 4, ");
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[11],dataStr,10);
				strcpy_s (str,"Firmware Version=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
			
				_itoa_s((buffer[13]*256+buffer[12]),dataStr,10);
				strcpy_s (str, "PID=");
				strcat_s(str, dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[17],dataStr,10);
				strcpy_s (str,"Dim Factor Bank 1=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[18],dataStr,10);
				strcpy_s (str,"Dim Factor Bank 2=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[19],dataStr,10);
				strcpy_s (str,"GPIO Configuration=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[20],dataStr,10);
				strcpy_s (str,"GPIO Input Configuration=");
				strcat_s (str,dataStr);
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
		if (result==102)
		{
			AddDevices(hDialog, "No PI Engineering Devices Found");
		}
		else
		{
			AddDevices(hDialog, "Error finding PI Engineering Devices");
		}
		return;
	} 
	else if (count == 0)    
	{
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
		long long pid=info[i].PID; //int is fine but using long long for string conversion
		std::string pidstring;
		pidstring=std::to_string(pid);
		
		//read ProductString
		std::string productstring;
		for (int j=0;j<128;j++)
		{
			if (info[i].ProductString[j]!=0)
			{
				productstring=productstring+info[i].ProductString[j];
			}
		}
		productstring=productstring+", PID="+pidstring;
		
		//read SerialNumberString
		std::string serialnumberstring;
		for (int j=0;j<128;j++)
		{
			if (info[i].SerialNumberString[j]!=0)
			{
				serialnumberstring=serialnumberstring+info[i].SerialNumberString[j];
			}
		}
		//char *snsstr = new char[serialnumberstring.length()+1];
		//strcpy(snsstr, serialnumberstring.c_str());

		char *xstr=new char[256];
		strcpy(xstr, (productstring+", SN="+serialnumberstring).c_str());
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
				if (pid==1396)
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=0;
				}
				else if (pid==1397)
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=1;
				}
				else if (pid==1398)
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=2;
				}
				else if (pid==1399)
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=3;
				}
				else if (pid==1400)
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=4;
				}
				else if (pid==1401)
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=5;
				}
				else if (pid==1402)
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
					pidlist=6;
				}
				else
				{
					AddDevices(hDialog, xstr);
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
			}
		}
		else
		{
			if (pid==1403)
			{
				AddDevices(hDialog, xstr);
				AddDevices(hDialog, "KVM mode, no input or output reports are available.");
				AddDevices(hDialog, "To exit KVM mode unplug device and replug it, immediately toggle the Scroll Lock key 5-10 times.");
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
	if (pData[2]<4) //General Incoming Data
	{
		hList = GetDlgItem(hDialog, IDC_KEYSTATES);
		if (hList == NULL) return TRUE;
	
		if ((pData[6] & 1)!=0)
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
	
		if ((pData[6] & 2)!=0)
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
	
		if ((pData[6] & 4)!=0)
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
		_itoa_s(pData[9],msg,10);
		strcpy_s (str,"T-bar: ");
		strcat_s (str,msg);
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)str);

		//Buttons
		char strb[80];
		strcpy_s (strb,"Buttons: ");
		hList = GetDlgItem(hDialog, IDC_Buttons);
		SendMessage(hList, WM_SETTEXT, 0 , (LPARAM)strb);
		int maxcols=3; //number of columns of Xkeys digital button data, labeled "Keys" in P.I. Engineering SDK - General Incoming Data Input Report
		int maxrows=8; //constant, 8 bits per byte
		for (int i=0;i<maxcols;i++) //loop for each column of button data (Max Cols)
		{
			for (int j=0;j<maxrows;j++) //loop for each row of button data (Max Rows)
			{
				int temp1=pow(2.0,j);
				int bitkeynum=maxrows*i+j; //0 based index
				BYTE temp2=(pData[i + 3] & temp1); //check using bitwise AND the current value of this bit. The + 3 is because the 1st button byte starts 3 bytes in at data[3]
				BYTE temp3 = (lastpData[i + 3] & temp1); //check using bitwise AND the previous value of this bit
				int state=0; //0=was up and is up, 1=was up and is down, 2= was down and is down, 3=was down and is up 
				if (temp2 != 0 && temp3 == 0) state = 1; //press
				else if (temp2 != 0 && temp3 != 0) state = 2; //held down
				else if (temp2 == 0 && temp3 != 0) state = 3; //release
				int keynumbermap[24]; //map the bitwise keynum to index given in SDK documentation
				//Column 1
				keynumbermap[0] = 0; keynumbermap[1] = 1; keynumbermap[2] = 2; keynumbermap[3] = 3; keynumbermap[4] = 4; keynumbermap[5] = 5;
				//Column 2
				keynumbermap[12] = 6; keynumbermap[13] = 7;
				//Column 3
				keynumbermap[16] = 8; keynumbermap[17] = 9; keynumbermap[18] = 10; keynumbermap[19] = 11; keynumbermap[20] = 12; keynumbermap[21] = 13;

				int keynum = keynumbermap[bitkeynum];
				if ((state==1) || (state==2)) //these buttons are down
				{
					char msgt[100];
						hList = GetDlgItem(hDialog, IDC_Buttons);
						if (hList == NULL) return TRUE;
						_itoa_s(keynum,msgt,10);
						strcat_s (strb,msgt);
						strcat_s (strb,", ");
						//strcat_s (str,thisbutton.c_str());
						SendMessage(hList, WM_SETTEXT, 0 , (LPARAM)strb);
				}
				
				
				//Perform action based on key number, consult P.I. Engineering SDK documentation for the key numbers
				switch (keynum)
				{
					//Column 1
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
					//Column 2
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
					//Column 3
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
				}
				
			}
		}

		for (int i=0;i<readlength;i++)
		{
			lastpData[i]=pData[i];  //save it for comparison on next read
		}
		//end Buttons

		//GPIO inputs
		char gpio[80];
		strcpy_s(gpio, "GPIO Inputs: ");
		hList = GetDlgItem(hDialog, IDC_GPIOInput);
		SendMessage(hList, WM_SETTEXT, 0 , (LPARAM)gpio);
		
		if ((pData[6] & 16)!=0)
		{
			char msg[100]="Pin 1 on, ";
			strcat_s(gpio, msg);
		}
		else
		{
			//char msg[100]="Pin 1 off";
			//strcat_s(gpio, msg);
		}
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)gpio);

		if ((pData[6] & 32)!=0)
		{
			char msg[100]="Pin 2 on, ";
			strcat_s(gpio, msg);
		}
		else
		{
			//char msg[100]="Pin 2 off";
			//strcat_s(gpio, msg);
		}
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)gpio);

		if ((pData[6] & 64)!=0)
		{
			char msg[100]="Pin 3 on, ";
			strcat_s(gpio, msg);
		}
		else
		{
			//char msg[100]="Pin 3 off";
			//strcat_s(gpio, msg);
		}
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)gpio);

		if ((pData[6] & 128)!=0)
		{
			char msg[100]="Pin 4 on, ";
			strcat_s(gpio, msg);
		}
		else
		{
			//char msg[100]="Pin 4 off";
			//strcat_s(gpio, msg);
		}
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)gpio);

		//time stamp info 4 bytes
        long absolutetime = 16777216 * pData[32] + 65536 * pData[33] + 256 * pData[34] + pData[35];  //ms
        long absolutetime2 = absolutetime / 1000; //seconds
        long deltatime = absolutetime - saveabsolutetime; //ms
        saveabsolutetime = absolutetime;
	}
	else if (pData[2] == 167) //0xA7 backlight LED state request
    {
		//pData[3]=button index
		//pData[4]=bank 1 red
		//pData[5]=bank 1 green
		//pData[6]=bank 1 blue
		//pData[7]=bank 2 red
		//pData[8]=bank 2 green
		//pData[9]=bank 2 blue
		//pData[10]=flash bank 1 // 0=no flash, 1=flash
		//pData[11]=flash bank 2 // 0=no flash, 1=flash
		//pData[12]=indicator flash
		//pData[13]=flash frequency
		//pData[14]=bank 1 dim factor //255=100%
		//pData[15]=bank 2 dim factor //255=100%
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
