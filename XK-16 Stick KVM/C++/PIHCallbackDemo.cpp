// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
#include "PIEHid32.h"

#include <string.h>
#include <stdio.h>
#include <math.h>

#define MAXDEVICES  128   //max number of devices allowed at one time


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

bool lastprogsw=false;

BYTE lastpData[80];  //stores the data of the previous read
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
	hList = GetDlgItem(hDialog, IDC_EDIT1);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_EDIT2);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_EDIT3);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"10");

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

	//...initialize rest of buttons.
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE2);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"1");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE3);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"2");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE4);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"3");

	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE7);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"4");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE8);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"5");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE9);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"6");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE10);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"7");
	
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE13);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"8");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE14);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"9");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE15);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"10");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE16);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"11");
	
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE19);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"12");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE20);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"13");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE21);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"14");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE22);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"15");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE23);
	
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
	
	
	int countout=0;
	int wlen=GetWriteLength(hDevice);
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
			//Writes the unit ID entered in IDC_EDIT1. 0-255 possible.
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
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;

		case IDC_CHKGREENLED:
			//Turns on the green LED.

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=6;  //6 for green, 7 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKGREENLED);
			if (hList == NULL) return TRUE;
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash

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

		case IDC_CHKREDLED:
			//Turns on the red LED.

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=7;  //6 for green, 7 for red
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKREDLED);
			if (hList == NULL) return TRUE;
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash

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

        case IDC_CHKBLONOFF:
			//Turn on/off the backlight of the entered key in IDC_TXTBL
			//Use the Set Flash Freq to control frequency of blink
            //Key Index (in decimal)
            //0, 1, 2, 3, 4, 5, 8, 9, 10, 11, 12, 13, 16, 17, 18, 19

			for (int i=0;i<wlen;i++)
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
			buffer[3]=SendMessage(hList, BM_GETCHECK, 0, 0); //0=off, 1=on, 2=flash

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

		case IDC_FREQ:
			//Set the frequency of the flashing, same one for LEDs and backlights
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=180;
			//get text box text
			hList = GetDlgItem(hDialog, IDC_EDIT3);
			if (hList == NULL) return TRUE;
			char Freq[10];
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)Freq);
			buffer[2]= atoi(Freq);
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

		case IDC_BL2:
			//Sets the bank 1 and bank 2 backlighting intensity, one value for all bank 1 or bank 2
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}

			buffer[0]=0;
			buffer[1]=187;
			buffer[2]=127; //0-255 bank 1 intensity
			buffer[3]=64; //0-255 bank 2 intensity-no bank 2 available on XK-16
			
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
		case IDC_CHKSCROLL:
			//If checked then the Scroll Lock key on the main keyboard will toggle the backlights
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=183;
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKSCROLL);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[2]=128;
			else buffer[2]=0;  //0=disable scroll lock toggle, 128=enable scroll lock toggle
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

		case IDC_CHKBLUE:
			//Turns on or off, depending on value of CHKGREEN, ALL bank 1 BLs using current intensity
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=182;
			buffer[2]=0; //0 for bank 1, 1 for bank 2
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKGREEN);
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
		
		case IDC_SaveBL:
           //Write current state of backlighting to EEPROM.  
            //NOTE: Is it not recommended to do this frequently as there are a finite number of writes to the EEPROM allowed
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=199;
			buffer[2]=1; //anything other than 0 will save bl state to eeprom, default is 0
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

		case IDC_TIMESTAMP:
			//Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
			 for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210;
			buffer[2]=0; //1 to turn on time stamp, 0 to turn off time stamp
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

        case IDC_TIMESTAMP2:
			//Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=210;
			buffer[2]=1; //1 to turn on time stamp, 0 to turn off time stamp
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

		case IDC_KEYREFLECT:
			//Sends keyboard commands as a native keyboard to textbox
			hList = GetDlgItem(hDialog, IDC_EDIT4);
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
		case IDC_VERSION:
			//This report available only on v24 firmware and above
			//Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
            //newly written version!  Requires piehid32.dll to read back version.
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=195; //0xc3
			char versionval[10];
			hList = GetDlgItem(hDialog, IDC_EDIT5);
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

		 case IDC_MouseReflect3:
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
			buffer[5]=0; //Wheel X
			hList = GetDlgItem(hDialog, IDC_MouseWheel);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)val);
			buffer[6]=atoi(val); //Wheel Y, 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		
		case IDC_DESCRIPTOR:
			//turn off callback
			if (hDevice == -1) return TRUE;
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
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
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
				strcpy_s (str,"OutSize ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[7],dataStr,10);
				strcpy_s (str,"ReportSize ");
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
				
			}
			return TRUE;

        case IDC_FORCEDATA:
            //After sending this command a general incoming data report will be given with
            //the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
            //and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
            //or unit id of the device before it sends any data.
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
			if (result != 0)    {
				AddEventMsg(hwndDlg, "Error:");
				GetErrorString(result, errordescription, 100);
				AddEventMsg(hwndDlg, errordescription);
			}
			return TRUE;
		case IDC_Custom:
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
			hnd = info[i].Handle;
			result = SetupInterfaceEx(hnd);
			if (result != 0)    
			{
				AddDevices(hDialog, "Error setting up PI Engineering Device");
			}
			else    
			{
				if (pid==1269)
				{
					AddDevices(hDialog, "Found Device: X-keys XK-16 Stick KVM, PID=1269 (PID #1)");
				}
				else
				{
					AddDevices(hDialog, "Unknown device found");
				}
				combotodevice[cbocount] = i; //this is the handle
				cbocount++;
			}
		}
		else
		{
			if (pid==1270)
			{
				AddDevices(hDialog, "Found Device: X-keys XK-16 Stick KVM, PID=1270 or PID #2 (KVM).");
				AddDevices(hDialog, "No input or output reports are available.  To change to PID #1");
				AddDevices(hDialog, "slide program switch up  and replug the device.");
				return;
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
		sprintf_s(dataStr, "%02x : %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x %02x\n", 
		deviceID, pData[0], pData[1], pData[2], pData[3], pData[4], pData[5], pData[6], pData[7], pData[8], pData[9], pData[10], pData[11], pData[12], pData[13], pData[14], pData[15], pData[16], pData[17], pData[18], pData[19], pData[20], pData[21], pData[22], pData[23],pData[24], pData[25], pData[26], pData[27], pData[28], pData[29], pData[30], pData[31], pData[32]);

		AddEventMsg(hDialog, dataStr);
		if (pData[2]!=0xE0)
		{
		int maxcols=4;
		int maxrows=8;
		for (int i=0;i<maxcols;i++) //loop for each column of button data (Max Cols)
		{
			for (int j=0;j<maxrows;j++) //loop for each row of button data (Max Rows)
			{
				int temp1=pow(2.0,j);
				int keynum=maxrows*i+j;
				//char ctemp[10];
				//_itoa_s(keynum, ctemp, 10);
				//char str[80]; //to string stuff together
				HWND hList;
				

				int state=0; //0=was up and is up, 1=was up and is down, 2= was down and is down, 3=was down and is up 
				if (((pData[i+3] & temp1)!=0) && ((lastpData[i+3] & temp1)==0))
					state=1;
				else if (((pData[i+3] & temp1)!=0) && ((lastpData[i+3] & temp1)!=0))
					state=2;
				else if (((pData[i+3] & temp1)==0) && ((lastpData[i+3] & temp1)!=0))
					state=3;
				switch (keynum)
				{
					case 0 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"0 Up");
						}
						break;
					case 8 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE2);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"1 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE2);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"1 Up");
						}
						break;
					case 16 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE3);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"2 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE3);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"2 Up");
						}
						break;
					case 24 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE4);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"3 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE4);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"3 Up");
						}
						break;
					case 1 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE7);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"4 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE7);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"4 Up");
						}
						break;
					case 9 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE8);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"5 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE8);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"5 Up");
						}
						break;
					case 17 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE9);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"6 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE9);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"6 Up");
						}
						break;
					case 25 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE10);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"7 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE10);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"7 Up");
						}
						break;
					case 2 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE13);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"8 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE13);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"8 Up");
						}
						break;
					case 10 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE14);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"9 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE14);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"9 Up");
						}
						break;
					case 18 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE15);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"10 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE15);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"10 Up");
						}
						break;
					case 26 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE16);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"11 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE16);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"11 Up");
						}
						break;
					case 3 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE19);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"12 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE19);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"12 Up");
						}
						break;
					case 11 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE20);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"13 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE20);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"13 Up");
						}
						break;
					case 19 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE21);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"14 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE21);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"14 Up");
						}
						break;
					case 27 :
						if (state==1) //on press
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE22);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"15 Down");
						}
						else if (state==3) //on release
						{
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE22);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"15 Up");
						}
						break;
					
				}
				
			}
		}
		}

		for (int i=0;i<33;i++)
		{
			lastpData[i]=pData[i];  //save it for comparison on next read
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
