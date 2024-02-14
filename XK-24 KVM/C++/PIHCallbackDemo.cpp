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
DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error);
DWORD __stdcall HandleErrorEvent(DWORD deviceID, DWORD status);

BYTE buffer[80];  //used for writing to device

HWND hDialog;
long hDevice = -1;
bool keyboard=false; //for keyboard reflect sample
bool mouseon=false;
bool lastprogsw=false;

BYTE lastpData[80];  //stores the data of the previous read
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

	//...initialize rest of buttons.
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"1");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE2);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"2");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE3);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"3");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE4);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"4");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE5);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"5");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE6);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"6");

	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE7);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"7");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE8);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"8");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE9);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"9");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE10);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"10");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE11);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"11");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE12);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"12");

	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE13);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"13");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE14);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"14");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE15);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"15");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE16);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"16");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE17);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"17");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE18);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"18");

	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE19);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"19");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE20);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"20");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE21);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"21");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE22);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"22");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE23);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"23");
	hList = GetDlgItem(hDialog, IDC_BUTTONSTATE24);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"24");


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

			for ( i=0;i<wlen;i++)
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

			for ( i=0;i<wlen;i++)
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
			for ( i=0;i<wlen;i++)
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
			for ( i=0;i<wlen;i++)
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

		case IDC_BLToggle:
			//Toggle the backlights
			for ( i=0;i<wlen;i++)
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
			for ( i=0;i<wlen;i++)
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
			for ( i=0;i<wlen;i++)
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

		case IDC_CHKRED:
			//Turns on or off, depending on value of CHKRED, ALL bank 2 BLs using current intensity
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=182;
			buffer[2]=1; //0 for bank 1, 1 for bank 2
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKRED);
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
			for ( i=0;i<wlen;i++)
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

		case IDC_TOREFLECT:
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204;
			buffer[2]=0; //0=PID #1, 1=PID #2
			
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

		case IDC_TOSPLAT:
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=204;
			buffer[2]=1; //0=PID #1, 1=PID #2
			
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
		
            for ( i=0;i<wlen;i++)
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
			//Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
			
            for ( i=0;i<wlen;i++)
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
			//Sends keyboard commands as a native keyboard when the 1st key is pressed (see HandleDataEvent for code)
			keyboard=true;
			return TRUE;

		case IDC_JOYREFLECT:
			//open up the game controller control panel to test these features, after clicking this button
            //go and make active the control panel properties and change will occur
			//available for PID #2 only.
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=202;
			buffer[2]=128; //X, 0 to 127 from center to right, 255 to 128 from center to left
			buffer[3]=128; //Y, 0 to 127 from center down, 255 to 128 from center up
			buffer[4]=128; //Z rot, 0 to 127 from center down, 255 to 128 from center up
			buffer[5]=128; //Z, 0 to 127 from center down, 255 to 128 from center up
			buffer[6]=128; //Slider, 0 to 127 from center down, 255 to 128 from center up
			
			buffer[7]=255; //Game buttons as bitmap, bit 1= game button 1, bit 2=game button 2, etc., all buttons on
			buffer[8]=255; //Game buttons as bitmap, bit 1= game button 1, bit 2=game button 2, etc., all buttons on
			buffer[9]=255; //Game buttons as bitmap, bit 1= game button 1, bit 2=game button 2, etc., all buttons on
			buffer[10]=255; //Game buttons as bitmap, bit 1= game button 1, bit 2=game button 2, etc., all buttons on
			
			buffer[11]=0;

			buffer[12]=1; //Hat, 0 to 7 clockwise, 8=no hat
			
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
			//turn off callback
			if (hDevice == -1) return TRUE;
			DisableDataCallback(hDevice, true); //turn off callback so capture data here

			for (i=0;i<wlen;i++)
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
			for ( i=0;i<wlen;i++)
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
		 case IDC_SETKEY:
            //Do not change PID on reboot
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=196; //0xc4
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
		case IDC_CHECKKEY:
            //Always revert to PID #2 (KVM mode) on reboot of device, factory default
			for ( i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=196; //0xc4
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

	result = EnumeratePIE(0x5F3, info, count);

	if (result != 0)    
	{
		if (result==102){
			AddEventMsg(hDialog, "No PI Engineering Devices Found");
		}
		else{
		AddEventMsg(hDialog, "Error finding PI Engineering Devices");
		}
		return;
		} 
	else if (count == 0)    {
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
			hnd = info[i].Handle;
			result = SetupInterfaceEx(hnd);
			if (result != 0)    
			{
				AddEventMsg(hDialog, "Error setting up PI Engineering Device");
			}
			else    
			{
				hDevice = hnd;
				if (pid==1235)
				{
					AddEventMsg(hDialog, "Found Device: X-keys XK-24 KVM, PID=1235 or PID #1");
				}
				else
				{
					AddEventMsg(hDialog, "Unknown device found");
				}
				return;
			}
		}
		else
		{
				if (pid==1236)
				{
					AddEventMsg(hDialog, "Found Device: X-keys XK-24 KVM, PID=1236 or PID #2 (KVM).");
					AddEventMsg(hDialog, "No input or output reports are available.  To change to PID #1 press and hold the program switch");
					AddEventMsg(hDialog, "while plugging the device into usb port.");
					return;
				}
		}
	}

	AddEventMsg(hDialog, "No X-keys XK-24 KVM device found");
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
		sprintf_s(dataStr, "%02x %02x %02x %02x -- %02x %02x %02x %02x -- %02x %02x %02x %02x\n", 
			pData[0], pData[1], pData[2], pData[3], pData[4], pData[5], pData[6], pData[7], pData[8], pData[9], pData[10], pData[11]);

		AddEventMsg(hDialog, dataStr);

		int maxcols=4;
		int maxrows=6;
		for (int i=0;i<maxcols;i++) //loop for each column of button data (Max Cols)
		{
			for (int j=0;j<maxrows;j++) //loop for each row of button data (Max Rows)
			{
				int temp1=pow(2.0,j);
				int keynum=maxrows*i+j+1; //add 1 to make 1 based indexing instead of 0
				char ctemp[10];
				_itoa_s(keynum, ctemp, 10);
				char str[80]; //to string stuff together
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
					case 1 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 2 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE2);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE2);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 3 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE3);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE3);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 4 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE4);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE4);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 5 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE5);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE5);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 6 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE6);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE6);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 7 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE7);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE7);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 8 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE8);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE8);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 9 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE9);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE9);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 10 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE10);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE10);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 11 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE11);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE11);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 12 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE12);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE12);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 13 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE13);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE13);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 14 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE14);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE14);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 15 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE15);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE15);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 16 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE16);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE16);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 17 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE17);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE17);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 18 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE18);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE18);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 19 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE19);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE19);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 20 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE20);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE20);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 21 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE21);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE21);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 22 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE22);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE22);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 23 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE23);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE23);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					case 24 :
						if (state==1) //on press
						{
							strcpy_s (str," Down");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE24);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						else if (state==3) //on release
						{
							strcpy_s (str," Up");
							strcat_s (ctemp, str);
							hList = GetDlgItem(hDialog, IDC_BUTTONSTATE24);
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)ctemp);
						}
						break;
					
				}
				
			}
		}

		for (int i=0;i<33;i++)
		{
			lastpData[i]=pData[i];  //save it for comparison on next read
		}

		//for Keyboard Reflect,
		if ((pData[3]&1) && keyboard==true)
		{
			//Sends keyboard commands as a native keyboard
			//Before pressing 1st key activate a Notepad or other text capturing application to see the results: Abcd
			int wlen=GetWriteLength(hDevice);
			for(int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			//MessageBeep(MB_ICONHAND);
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
			//for successive writes make sure the buffer is empty before moving on to next write, use 404
			int result=404;
			while (result==404)
			{
				result=WriteData(hDevice, buffer);
			}
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
			while (result==404)
			{
				result=WriteData(hDevice, buffer);
			}
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
			while (result==404)
			{
				result=WriteData(hDevice, buffer);
			}
			keyboard=false;
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
