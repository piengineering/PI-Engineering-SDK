// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
#include "PIEHid32.h"

#include <string.h>
#include <stdio.h>
#include <math.h> //for use of pow
#define MAXDEVICES  512   //max allowed array size for enumeratepie =128 devices*4 bytes per device


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

BYTE buffer[80];  //used for writing to device
BYTE lastpData[80];  //stores the data of the previous read
int readlength=0; 

HWND hDialog;
long hDevice = -1;
int combotodevice[128];
bool lastprogsw=false;

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

	//put default numbers in edit boxes
	HWND hList;
	hList = GetDlgItem(hDialog, IDC_EDIT1);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_EDIT2);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_EDIT5);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"10");
	hList = GetDlgItem(hDialog, IDC_EDITKEY);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"");
	//Joystick
	hList = GetDlgItem(hDialog, IDC_JOYX);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYY);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYZ);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYZR);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYS);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYB1);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYB2);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYB3);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYB4);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_JOYH);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"8");
	//Mouse
	hList = GetDlgItem(hDialog, IDC_MOUSEB);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_MOUSEX);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_MOUSEY);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_MOUSEW);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	//Write Version
	hList = GetDlgItem(hDialog, IDC_EDIT6);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"100");

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
	int i=0;
	HWND hList;
	int saveled;
	int K0;    
    int K1;   
    int K2;
	int K3;
	int countout=0;
	int wlen=GetWriteLength(hDevice);
	char errordescription[100]; //used with the GetErrorString call to describe the error

	
	switch (uMsg)    {
	case WM_INITDIALOG:
		SendMessage(GetDlgItem(hwndDlg, CHK_NONE), BM_SETCHECK, BST_CHECKED, 0);
		// Indicate that events are off to start.
		return FALSE;   // not choosing keyboard focus

    case WM_COMMAND:
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
			//Writes the unit ID entered in IDC_EDIT1. 0-255 possible.
			memset(buffer, 0, 80);
			for ( i=0;i<36;i++)
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
			
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_CHKGREENLED:
			//Turns on the green LED.

			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=6;  //6 for green, 7 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKGREENLED);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; //0=off, 1=on, 2=flash
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_CHKREDLED:
			//Turns on the red LED.

			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=7;  //6 for green, 7 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKREDLED);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; ////0=off, 1=on, 2=flash
			result = WriteData(hDevice, buffer);
			return TRUE;
		
		case IDC_CHKFGREENLED:
			//Flash the green LED, set flash frequency with Set Freq

			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=6;  //6 for green, 7 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKFGREENLED);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=2; ////0=off, 1=on, 2=flash
			else
			{
				hList = GetDlgItem(hDialog, IDC_CHKGREENLED);
				if (hList == NULL) return TRUE;
				if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; ////0=off, 1=on, 2=flash
			}
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_CHKFREDLED:
			//Flash the green LED, set flash frequency with Set Freq

			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=7;  //6 for green, 7 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKFREDLED);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=2; ////0=off, 1=on, 2=flash
			else
			{
				hList = GetDlgItem(hDialog, IDC_CHKREDLED);
				if (hList == NULL) return TRUE;
				if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; ////0=off, 1=on, 2=flash
			}
			result = WriteData(hDevice, buffer);
			return TRUE;

        case IDC_CHKBLONOFF:
			//Turn on/off the backlight of the entered key in IDC_EDIT2
			//Use the Set Flash Freq to control frequency of blink
            //Key Index (in decimal)
            //Bank 1
			//Columns-->
            //  0   8   16  24
            //  1   9   17  25
            //  2   10  18  26
            //  3   11  19  27
            //  4   12  20  28
            //  5   13  21  29

			//Bank 2
			//Columns-->
            //  32   40   48  56
            //  33   41   49  57
            //  34   42   50  58
            //  35   43   51  59
            //  36   44   52  60
            //  37   45   53  61

			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=181; //0xb5
			//get key index
			//get text box text
			hList = GetDlgItem(hDialog, IDC_EDIT2);
			if (hList == NULL) return TRUE;
			char keyid[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)keyid);
			buffer[2]= atoi(keyid);
			
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKBLONOFF);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) 
			{
				hList = GetDlgItem(hDialog, IDC_CHKBLFLASH);
				if (hList == NULL) return TRUE;
				if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=2; ////0=off, 1=on, 2=flash
				else buffer[3]=1;
			}
			result = WriteData(hDevice, buffer);
			return TRUE;

	    case IDC_CHKBLFLASH:
			//Turn on/off the backlight of the entered key in IDC_EDIT2
			//Use the Set Flash Freq to control frequency of blink
            //Key Index for(in decimal)
			//Bank 1
            //Columns-->
            //  0   8   16  24
            //  1   9   17  25
            //  2   10  18  26

			//Bank 2
			//Columns-->
            //  32   40   48  56
            //  33   41   49  57
            //  34   42   50  58

			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=181; //0xb5
			//get key index
			//get text box text
			hList = GetDlgItem(hDialog, IDC_EDIT2);
			if (hList == NULL) return TRUE;
			char keyidf[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)keyidf);
			buffer[2]= atoi(keyidf);
			
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKBLFLASH);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) 
			{
				buffer[3]=2;
			}
			else
			{
				hList = GetDlgItem(hDialog, IDC_CHKBLONOFF);
				if (hList == NULL) return TRUE;
				if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; //0=off, 1=on, 2=flash
			}
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_FREQ:
			//Set the frequency of the flashing, same one for LEDs and backlights
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=180;
			//get text box text
			hList = GetDlgItem(hDialog, IDC_EDIT5);
			if (hList == NULL) return TRUE;
			char Freq[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)Freq);
			buffer[2]= atoi(Freq);
			result = WriteData(hDevice, buffer);

			return TRUE;

		case IDC_BL2:
			//Sets the backlighting intensities, one value for all bank 1 and all bank 2
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}

			buffer[0]=0;
			buffer[1]=187;
			buffer[2]=127; //0-255 bank 1 intensity
			buffer[3]=64; //0-255 bank 2 intensity
			
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_BLToggle:
			//Toggle the backlights
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=184;
			result = WriteData(hDevice, buffer);
			
			return TRUE;
		

		case IDC_CHKGREEN:
			//Turns on or off, depending on value of CHKGREEN, ALL bank 1 BLs using current intensity
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=182;
			buffer[2]=0; //0 for green, 1 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKGREEN);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=255;
			else buffer[3]=0;  //0=off, 255=on OR use individual bits to turn on rows, bit 1=row 1, bit 2= row 2, etc
			result = WriteData(hDevice, buffer);
			
			return TRUE;

		case IDC_CHKRED:
			//Turns on or off, depending on value of CHKRED, ALL bank 2 BLs using current intensity
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=182;
			buffer[2]=1; //0 for green, 1 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKRED);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=255;
			else buffer[3]=0;  //0=off, 255=on OR use individual bits to turn on rows, bit 1=row 1, bit 2= row 2, etc
			result = WriteData(hDevice, buffer);
			
			return TRUE;
		
		case IDC_SaveBL:
           //Write current state of backlighting to EEPROM.  
            //NOTE: Is it not recommended to do this frequently as there are a finite number of writes to the EEPROM allowed
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=199;
			buffer[2]=1; //anything other than 0 will save bl state to eeprom, default is 0
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_TOREFLECT:
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204;
			buffer[2]=2; //0=PID #1, 2=PID #2
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_TOSPLAT:
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204;
			buffer[2]=0; //0=PID #1, 2=PID #2
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_TIMESTAMP:
			//Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210;
			buffer[2]=0; //1 to turn on time stamp, 0 to turn off time stamp
			result = WriteData(hDevice, buffer);
			return TRUE;

        case IDC_TIMESTAMP2:
			//Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210;
			buffer[2]=1; //1 to turn on time stamp, 0 to turn off time stamp
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_ENABLE:
			//Sending this command will turn on the native joystick
            for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=216;
			buffer[2]=1; //1 to turn on, 0 to turn off
			result = WriteData(hDevice, buffer);
			return TRUE;

        case IDC_DISABLE:
			//Sending this command will turn off native joystick
            for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=216;
			buffer[2]=0; //1 to turn on, 0 to turn off
			result = WriteData(hDevice, buffer);
			return TRUE;

		case IDC_KEYREFLECT:
			//Sends keyboard commands as a native keyboard to textbox
			hList = GetDlgItem(hDialog, IDC_EDITKEY);
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
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=202;
			
			char joyval[10];
			hList = GetDlgItem(hDialog, IDC_JOYX);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[2]=atoi(joyval)^127-255; //X, 0 to 127 from center to right, 255 to 128 from center to left
			hList = GetDlgItem(hDialog, IDC_JOYY);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[3]=atoi(joyval)^127; //Y, 0 to 127 from center down, 255 to 128 from center up
			hList = GetDlgItem(hDialog, IDC_JOYZR);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[4]=atoi(joyval)^127; //Z rotation, 0 to 127 from center down, 255 to 128 from center up
			hList = GetDlgItem(hDialog, IDC_JOYZ);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[5]=atoi(joyval)^127; //Z, 0 to 127 from center down, 255 to 128 from center up
			hList = GetDlgItem(hDialog, IDC_JOYS);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[6]=atoi(joyval)^127; //Slider, 0 to 127 from center down, 255 to 128 from center up
			
			hList = GetDlgItem(hDialog, IDC_JOYB1);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[7]=atoi(joyval); //buttons 1-8, where bit 1 is button 1, bit 2 is button 2
			hList = GetDlgItem(hDialog, IDC_JOYB2);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[8]=atoi(joyval); //buttons 9-16, where bit 1 is button 1, bit 2 is button 2
			hList = GetDlgItem(hDialog, IDC_JOYB3);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[9]=atoi(joyval); //buttons 17-24, where bit 1 is button 1, bit 2 is button 2
			hList = GetDlgItem(hDialog, IDC_JOYB4);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[10]=atoi(joyval); //buttons 25-32, where bit 1 is button 1, bit 2 is button 2
			
			buffer[11]=0;

			hList = GetDlgItem(hDialog, IDC_JOYH);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)joyval);
			buffer[12]=atoi(joyval); //hat, where 0 is straight up, 1 is 45deg cw, etc and 8 is no hat
			
			result = WriteData(hDevice, buffer);
			return TRUE;
		case IDC_MOUSEREFLECT3:
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=203;
			
			char val[10];
			hList = GetDlgItem(hDialog, IDC_MOUSEB);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[2]=atoi(val); //1=left, 2=right, 4=center, 8=XButton1, 16=XButton2
			hList = GetDlgItem(hDialog, IDC_MOUSEX);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[3]=atoi(val); //X motion, 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129)
			hList = GetDlgItem(hDialog, IDC_MOUSEY);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[4]=atoi(val); //Y motion, 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129)
			buffer[5]=0; //Wheel X
			hList = GetDlgItem(hDialog, IDC_MOUSEW);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[6]=atoi(val); //Wheel Y, 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
			result = WriteData(hDevice, buffer);
			return TRUE;
		case IDC_DESCRIPTOR:
			//turn off callback
			DisableDataCallback(hDevice, true); //turn off callback so capture data here
		
			for (i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=214;
			result = WriteData(hDevice, buffer);
			//after this write the next read 3rd byte=214 will give descriptor information
			for (i=0;i<80;i++)
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
				
				_itoa(buffer[4],dataStr,10);
				char str[80];
				strcpy (str,"Keymapstart ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa(buffer[5],dataStr,10);
				strcpy (str,"Layer2offset ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);

				if (buffer[11]>23)
				{
				_itoa(buffer[6],dataStr,10);
				strcpy (str,"Size of EEPROM LSB ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa(buffer[7],dataStr,10);
				strcpy (str,"Size of EEPROM MSB ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);
				}
				else
				{
				_itoa(buffer[6],dataStr,10);
				strcpy (str,"OutSize ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa(buffer[7],dataStr,10);
				strcpy (str,"ReportSize ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);
				}
				
				_itoa(buffer[8],dataStr,10);
				strcpy (str,"MaxCol ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa(buffer[9],dataStr,10);
				strcpy (str,"MaxRow ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);

				strcpy (str,"");
				if (buffer[10]&64) strcpy (str,"Green LED ");
				if (buffer[10]&128) strcat (str,"Red LED ");
				if (strlen(str)==0) strcpy (str,"None ");
				AddEventMsg(hDialog, str);

				_itoa(buffer[11],dataStr,10);
				strcpy (str,"Version ");
				strcat (str,dataStr);
				AddEventMsg(hDialog, str);
			
				_itoa((buffer[13]*256+buffer[12]),dataStr,10);
				strcpy (str, "PID=");
				strcat(str, dataStr);
				AddEventMsg(hDialog, str);
			}
			return TRUE;

        case IDC_FORCEDATA:
            //After sending this command a general incoming data report will be given with
            //the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
            //and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
            //or unit id of the device before it sends any data.
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=177;
			
			result = WriteData(hDevice, buffer);
			return TRUE;
		case IDC_CUSTOMDATA2:
			//This report available only on v10 firmware and above
			//After sending this command a custom incoming data report will be given with
            //the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
            //and the following bytes whatever the user wishes.  In this example we are send 3 bytes; 1, 2, 3
			DisableDataCallback(hDevice, false); //turn on callback in the case it was turned off by some other command
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=224;
			buffer[2] = 3; //count of bytes to follow
            buffer[3] = 1; //1st custom byte
            buffer[4] = 2; //2nd custom byte
            buffer[5] = 3; //3rd custom byte
			result = WriteData(hDevice, buffer);
			return TRUE;
		case IDC_BUTTON4: //Set Dongle
			//for users of the dongle feature only, set the dongle key here REMEMBER there 4 numbers, they are needed to check the dongle key
			 //This routine is done once per unit by the developer prior to sale.
			if (hDevice == -1) return TRUE;
			//Pick 4 numbers between 1 and 254.
            K0 = 7;    //pick any number between 1 and 254, 0 and 255 not allowed
            K1 = 58;   //pick any number between 1 and 254, 0 and 255 not allowed
            K2 = 33;   //pick any number between 1 and 254, 0 and 255 not allowed
            K3 = 243;  //pick any number between 1 and 254, 0 and 255 not allowed
			for (i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=192; //0xc0 set dongle key command
			buffer[2]=K0;
			buffer[3]=K1;
			buffer[4]=K2;
			buffer[5]=K3;
			result = WriteData(hDevice, buffer);
			return TRUE;
		case IDC_CHECKDONGLE2:
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

			for (i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=193;  //0xc1 check dongle key command
			buffer[2]=N0;
			buffer[3]=N1;
			buffer[4]=N2;
			buffer[5]=N3;
			
			
			result = WriteData(hDevice, buffer);
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
				hList = GetDlgItem(hDialog, IDC_PASSFAIL2);
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
		case IDC_VERSION:
			//This report available only on v24 firmware and above
			//Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
            //newly written version!  Requires piehid32.dll to read back version.
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=195; //0xc3
			char versionval[10];
			hList = GetDlgItem(hDialog, IDC_EDIT6);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)versionval);
			buffer[2]=(BYTE)atoi(versionval);
			buffer[3]=(BYTE)(atoi(versionval)>>8);
			result = WriteData(hDevice, buffer);
			
			Sleep(100);
			//reboot device-must re-enumerate
			buffer[0]=0;
			buffer[1]=238; //0xee
			buffer[2]=0;
			buffer[3]=0;
			//result = WriteData(hDevice, buffer); //uncomment line to reboot the device

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
	TEnumHIDInfo info[128];
	long  hnd;
	long  count;
	int pid;
	readlength=info[combotodevice[0]].readSize;
	result = EnumeratePIE(0x5F3, info, count);

	if (result != 0)    {
		AddEventMsg(hDialog, "Error finding PI Engineering Devices");
		return;
	} else if (count == 0)    {
		AddEventMsg(hDialog, "No PI Engineering Devices Found");
		return;
	}

	for (long i=0; i<count; i++)    {
		pid=info[i].PID; //get the device pid
		
		int hidusagepage=info[i].UP; //hid usage page
		int version=info[i].Version;
		int writelen=GetWriteLength(info[i].Handle);
		
		if ((hidusagepage == 0xC && writelen==36))  
		{
			hnd = info[i].Handle; //handle required for piehid32.dll calls
			
			result = SetupInterfaceEx(hnd);
			if (result != 0)    
			{
				AddEventMsg(hDialog, "Error setting up PI Engineering Device");
			}
			else    
			{
				hDevice = hnd;
				
				if (pid==1065)
				{
					AddEventMsg(hDialog, "Found Device: XK-12 Joystick, PID=1065 (PID #1)");
				}
				else if (pid==1066)
				{
					AddEventMsg(hDialog, "Found Device: XK-12 Joystick, PID=1066");
				}
				else if (pid==1067)
				{
					AddEventMsg(hDialog, "Found Device: XK-12 Joystick, PID=1067 (PID #2)");
				}
				else
				{
					AddEventMsg(hDialog, "Unknown device found");
				}
				//print version, this is NOT firmware version which is given in the descriptor
				char dataStr[256];
				_itoa(version,dataStr,10);
				HWND hList;
				hList = GetDlgItem(hDialog, IDC_VERSIONLBL);
				SendMessage(hList, WM_SETTEXT,0, (LPARAM)(LPCSTR)dataStr);
			}
		}
	}

	
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
		sprintf(dataStr, "%02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x\n", 
			pData[0], pData[1], pData[2], pData[3], pData[4], pData[5], pData[6], pData[7], pData[8], pData[9], pData[10], pData[11], pData[12], pData[13], pData[14], pData[15], pData[16], pData[17], pData[18], pData[19], pData[20], pData[21], pData[22], pData[23],pData[24], pData[25], pData[26], pData[27], pData[28], pData[29], pData[30], pData[31], pData[32], pData[33], pData[34], pData[35], pData[36]);

		AddEventMsg(hDialog, dataStr);

		//Read Unit ID
		HWND hList = GetDlgItem(hDialog, IDC_UNITIDLBL);
		if (hList == NULL) return TRUE;
		char dataStr2[256];
		_itoa(pData[1],dataStr2,10);
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)dataStr2);	
		
		//Buttons 
	int maxcols=4;
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
