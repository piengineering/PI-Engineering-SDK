// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
#include "PIEHid32.h"

#include <string.h>
#include <stdio.h>

#include <iostream>
#include <ctime>
#include <cstdlib>

#include "Windows.h"
#include <math.h> //for pow function

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
	
	hList = GetDlgItem(hDialog, IDC_EDITStartAddr);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"1");

	hList = GetDlgItem(hDialog, IDC_EDITSpan);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"3");
	
	hList = GetDlgItem(hDialog, IDC_EDITData1);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"0");

	hList = GetDlgItem(hDialog, IDC_EDITData2);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"0");

	hList = GetDlgItem(hDialog, IDC_EDITData3);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"0");

	hList = GetDlgItem(hDialog, IDC_EDITReadStartAddr);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"0");

	hList = GetDlgItem(hDialog, IDC_EDITDMXLength);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"10");

	hList = GetDlgItem(hDialog, IDC_LBLDMXLength);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"length");

	hList = GetDlgItem(hDialog, IDC_LBLDMXReadLength);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"length");

	hList = GetDlgItem(hDialog, IDC_LBL1L);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"1L");

	hList = GetDlgItem(hDialog, IDC_LBL1R);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"1R");

	hList = GetDlgItem(hDialog, IDC_LBL2L);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"2L");

	hList = GetDlgItem(hDialog, IDC_LBL2R);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"2R");

	hList = GetDlgItem(hDialog, IDC_LBL3L);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"3L");

	hList = GetDlgItem(hDialog, IDC_LBL3R);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"3R");

	hList = GetDlgItem(hDialog, IDC_LBL4L);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"4L");

	hList = GetDlgItem(hDialog, IDC_LBL4R);
	if (hList == NULL) return TRUE;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"4R");

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

//------------------------------------------------------------------------
void CALLBACK DlgTimerProc(HWND hwnd, UINT a, UINT b, DWORD c)
{
	//MessageBeep(MB_ICONHAND);

	

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
			//KillTimer(hwndDlg,0);
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
			if (hDevice == -1) return TRUE;
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

		case IDC_CHKGREEN:
			if (hDevice == -1) return TRUE;
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=6; //6=green, 7=red
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKGREEN);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CHKRed:
			if (hDevice == -1) return TRUE;
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=7; //6=green, 7=red
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKRed);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CHKOUT1:
			if (hDevice == -1) return TRUE;
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=1; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKOUT1);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CHKOUT2:
			if (hDevice == -1) return TRUE;
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=2; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKOUT2);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CHKOUT3:
			if (hDevice == -1) return TRUE;
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=3; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKOUT3);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_CHKOUT4:
			if (hDevice == -1) return TRUE;
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=179; //0xb3
			buffer[2]=4; //1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
			buffer[3]=0; //state, 0=off, 1=on, 2=flash
			//get checked state
			hList = GetDlgItem(hDialog, IDC_CHKOUT4);
			if (hList == NULL) return TRUE;
			if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_CHECKED) buffer[3]=1; 
			else if (SendMessage(hList, BM_GETCHECK, 0, 0)==BST_INDETERMINATE) buffer[3]=2; 
			
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;

			//DMX Commands
			case IDC_ModeTransmit:
			{
				//Configure device to transmit. Factory default is configured in transmit mode. This command only used if changing between transmit and read modes.
				if (hDevice == -1) return TRUE;
				
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0] = 0;
				buffer[1] = 169; //0xA9
				buffer[2] = 0; //0=transmit, 1=receive
				
				result=404;
				while (result==404)
				{
					result = WriteData(hDevice, buffer);
				}
			}
			return TRUE;

			case IDC_ModeReceive:
			{
				//Configure device to receive. Factory default is configured in transmit mode. This command only used if changing between transmit and read modes.
				if (hDevice == -1) return TRUE;
				
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0] = 0;
				buffer[1] = 169; //0xA9
				buffer[2] = 1; //0=transmit, 1=receive
				
				result=404;
				while (result==404)
				{
					result = WriteData(hDevice, buffer);
				}
			}
			return TRUE;

			case IDC_SaveModeTrans:
			{
				//Note: Command writes to EEPROM, do not perform this command excessively.
                //Save to device the default bootup mode (transmit or receive). Does not change mode.
				if (hDevice == -1) return TRUE;
				
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0] = 0;
				buffer[1] = 172; //0xAC
				buffer[2] = 0; //0=transmit, 1=receive
				
				result=404;
				while (result==404)
				{
					result = WriteData(hDevice, buffer);
				}
			}
			return TRUE;

			case IDC_SaveModeReceive:
			{
				//Note: Command writes to EEPROM, do not perform this command excessively.
                //Save to device the default bootup mode (transmit or receive). Does not change mode.
				if (hDevice == -1) return TRUE;
				
				for (int i=0;i<wlen;i++)
				{
					buffer[i]=0;
				}
				buffer[0] = 0;
				buffer[1] = 172; //0xAC
				buffer[2] = 1; //0=transmit, 1=receive
				
				result=404;
				while (result==404)
				{
					result = WriteData(hDevice, buffer);
				}
			}
			return TRUE;
		    //DMX Transmit
			case IDC_BTNLoadDMX:
			{
				//Loads the DMX buffer
				//Due to the size of the output report, only 31 addresses can be loaded at a time. 
				//Thus if one wanted to change all 512 addresses, it would require 17 (512/31 rounded up)Load DMX Buffer commands.
				//The X-keys XC-DMX512T however is designed to only call the Load DMX Buffer command when required and only change
				//an address or subset of addresses that need updating.
				//The X-keys XC-DMX512T is continuously transmitting the desired addresses up to the DMX Length.
				if (hDevice == -1) return TRUE;
				char values[10];
				hList = GetDlgItem(hDialog, IDC_EDITStartAddr);
				if (hList == NULL) return TRUE;
				SendMessage(hList, WM_GETTEXT, 8, (LPARAM)values);
				int startaddress= atoi(values);

				hList = GetDlgItem(hDialog, IDC_EDITSpan);
				if (hList == NULL) return TRUE;
				SendMessage(hList, WM_GETTEXT, 8, (LPARAM)values);
				int span= atoi(values);

				hList = GetDlgItem(hDialog, IDC_EDITData1);
				if (hList == NULL) return TRUE;
				SendMessage(hList, WM_GETTEXT, 8, (LPARAM)values);
				int data1= atoi(values);

				hList = GetDlgItem(hDialog, IDC_EDITData2);
				if (hList == NULL) return TRUE;
				SendMessage(hList, WM_GETTEXT, 8, (LPARAM)values);
				int data2= atoi(values);

				hList = GetDlgItem(hDialog, IDC_EDITData3);
				if (hList == NULL) return TRUE;
				SendMessage(hList, WM_GETTEXT, 8, (LPARAM)values);
				int data3= atoi(values);
				//if desire more than 3 addresses, increase span and add data to match

				for (int j = 0; j < wlen; j++)
				{
					buffer[j] = 0;
				}
				buffer[0] = 0;
				buffer[1] = 161; //0xA1 Load DMX Buffer
				buffer[2] = (BYTE)startaddress; //start addr lo
				buffer[3] = (BYTE)(startaddress>>8); //start addr hi
				buffer[4] = (BYTE)span; //span, max value 30 per WriteData
				buffer[5] = (BYTE) data1;
				buffer[6] = (BYTE) data2;
				buffer[7] = (BYTE) data3;
				//add more data bytes up ot 31 
				result=404;
				while (result==404)
				{
					result = WriteData(hDevice, buffer);
				}
			}
			return TRUE;

		case IDC_BTNSetDMXLength:
		//Set DMX Length manually. This may be desireable of the DMX Length was set to something higher than is currently desired.
        //Otherwise the Load DMX Buffer command will automatically increase the DMX Length based on the start address and span it 
        //receives.
		{
			if (hDevice == -1) return TRUE;
			char values[10];
			hList = GetDlgItem(hDialog, IDC_EDITDMXLength);
			if (hList == NULL) return TRUE;
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)values);
			int length= atoi(values);

			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=162; //0xA2
			buffer[2] = (BYTE)length; //length lo
			buffer[3] = (BYTE)(length>>8); //length hi
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
		}
		return TRUE;

		case IDC_BTNGetDMXLength:
		//Get DMX length, result in callback
		{
			if (hDevice == -1) return TRUE;
				
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=163; //0xA3
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//results in callback
		}
		return TRUE;

		case IDC_BTNClearDMX:
		{
			if (hDevice == -1) return TRUE;
				
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=164; //0xA4
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
		}
		return TRUE;
		//DMX Receive
		case IDC_DMXConfigRead:
		{
			//Send this command to setup the XC-DMX512T to receive DMX data instead of transmit. This is the same as clicking Set mode - Receive (IDC_ModeReceive) button.
            //If the default mode of the XC-DMX512T has been previously set to receive then this is not necessary.
            //Data can be read in 2 ways; reading 20 bytes from a specified start address (Read Once) or registering to receive notification of any changes (Start Notification).
			if (hDevice == -1) return TRUE;
				
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=171; //0xAB
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
		}
		return TRUE;

		case IDC_DMXReadOnce:
		{
			//Sending this command will return the current values for 20 bytes of DMX data, starting at the desired start address
            //In this sample, the results will return in the callback (HandleDataEvent), however the data can be read directly back without using the 
			//callback by following the same BlockingReadData method demonstarted in IDC_DESCRIPTOR
			if (hDevice == -1) return TRUE;
				
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=165; //0xA5
			char startaddr[10];
			hList = GetDlgItem(hDialog, IDC_EDITReadStartAddr);
			SendMessage(hList, WM_GETTEXT, 8, (LPARAM)startaddr);
			buffer[2]=(BYTE)atoi(startaddr); //lsb
			buffer[3]=(BYTE)(atoi(startaddr)>>8); //msb

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//results in callback
		}
		return TRUE;

		case IDC_DMXNotification:
		{
			//Setup to receive notification of DMX changes in desired range. This sample is looking for changes at addresses 1 to 8. 
			//If want to be notified of all DMX changes then use 0 to 511.    
			if (hDevice == -1) return TRUE;
			
			int startaddress = 1;
			int endaddress = 8;
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=147; //0x93
			buffer[2] = 1; //1=notification on, 0=notification off
			buffer[3]=(BYTE)(startaddress); //lsb
			buffer[4]=(BYTE)((startaddress)>>8); //msb
			buffer[5]=(BYTE)(endaddress); //lsb
			buffer[6]=(BYTE)((endaddress)>>8); //msb

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//if DMX data changes in one or more of the addresses in the above range, data in callback.
		}
		return TRUE;

		case IDC_BTNGetDMXReadLength:
		{
			//Get DMX read length, result will return in callback in this sample but could also read them using BlockingReadData as demonstrated in IDC_DESCRIPTOR
			if (hDevice == -1) return TRUE;
				
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=146; //0x92
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//data in callback
		}
		return TRUE;

		case IDC_Version:
			//Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
            //newly written version!  Requires piehid32.dll to read back version.
			
			if (hDevice == -1) return TRUE;
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

		case IDC_KEYREFLECT:
			//Sends keyboard commands as a native keyboard to textbox
			if (hDevice == -1) return TRUE;
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
		
		case IDC_GENERATE:
			if (hDevice == -1) return TRUE;
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
			if (hDevice == -1) return TRUE;
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
			//after this write, the next read 3rd byte=214 will give descriptor information
			//for (int i=0;i<80;i++)
			//{buffer[i]=0;}
            
			int nRes, nErr, nCnt = 0;
			BYTE pBuff[255];
			memset(pBuff, 0, sizeof(pBuff));
			do
			{
				// Here is where it times out (returns 311).
				// For maxMilis I have also tried 1000. 
				nRes = BlockingReadData(hDevice, pBuff, 100); 

				if (++nCnt == 10)
					  break;
			}
			while (nRes == 304 || (nRes == 0 && pBuff[2] != 214));
			if (nCnt >= 10)
				return FALSE;
	  
			if (nRes ==0 && pBuff[2]==214)
			{
				char dataStr[256];
				//clear out listbox
				hList = GetDlgItem(hDialog, ID_EVENTS);
				if (hList == NULL) return TRUE;
				SendMessage(hList, LB_RESETCONTENT, 0, 0);

				if (pBuff[3]==0) AddEventMsg(hDialog, "PID #1"); //this device only has 1 pid
				
				_itoa_s(pBuff[4],dataStr,10);
				char str[80];
				strcpy_s (str,"Keymapstart ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(pBuff[5],dataStr,10);
				strcpy_s (str,"Layer2offset ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(pBuff[6],dataStr,10);
				strcpy_s (str,"Size of EEPROM MSB ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(pBuff[7],dataStr,10);
				strcpy_s (str,"Size of EEPROM LSB ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
				
				_itoa_s(pBuff[8],dataStr,10);
				strcpy_s (str,"MaxCol ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(pBuff[9],dataStr,10);
				strcpy_s (str,"MaxRow ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (pBuff[10]&64) strcpy_s (str,"Green LED On");
				else strcpy_s (str,"Green LED Off");
				if (pBuff[10]&128) strcat_s (str,"Red LED On");
				else strcat_s (str,"Red LED Off");
				AddEventMsg(hDialog, str);

				_itoa_s(pBuff[11],dataStr,10);
				strcpy_s (str,"Firmware Version ");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
			
				_itoa_s((pBuff[13]*256+pBuff[12]),dataStr,10);
				strcpy_s (str, "PID=");
				strcat_s(str, dataStr);
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (pBuff[17]&1) strcpy_s (str,"Output 1 On ");
				else strcpy_s (str,"Output 1 Off ");
				if (pBuff[17]&2) strcat_s (str,"Output 2 On ");
				else strcat_s (str,"Output 2 Off ");
				if (pBuff[17]&4) strcat_s (str,"Output 3 On ");
				else strcat_s (str,"Output 3 Off ");
				if (pBuff[17]&8) strcat_s (str,"Output 4 On ");
				else strcat_s (str,"Output 4 Off ");
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
				
				if (pid==1225)
				{
					AddDevices(hDialog, "Found Device: XC-DMX512T, PID=1225");
					combotodevice[cbocount] = i; //this is the handle
					cbocount++;
				}
				else if (pid==1324)
				{
					AddDevices(hDialog, "Found Device: XC-DMX512T, PID=1324");
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
	
	if (pData[2] < 3)
	{
		//for keyboard state
		hList = GetDlgItem(hDialog, IDC_KEYSTATES);
		if (hList == NULL) return TRUE;
	
		if ((pData[5] & 1)!=0)
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
	
		if ((pData[5] & 2)!=0)
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
	
		if ((pData[5] & 4)!=0)
		{
			char msg[100]="ScrLck on";
			SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
		}
		else
		{
			char msg[100]="ScrLck off";
			SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)msg);
		}
		//buttons
		int maxcols = 2;
        int maxrows = 8;
        for (int i = 0; i < maxcols; i++)
        {
            int temp1=1;
			for (int j = 0; j < maxrows; j++)
            {
				int keynum=maxrows*i+j; 
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
					case 0:
					if (state == 1)
					{
						hList = GetDlgItem(hDialog, IDC_LBL1L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"1L-dn");            
					}
					else if (state == 3)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL1L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"1L-up");                   
					}
					break;
				case 1:
					if (state == 1)
					{
                         hList = GetDlgItem(hDialog, IDC_LBL1R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"1R-dn");                  
					}
					else if (state == 3)
					{
						hList = GetDlgItem(hDialog, IDC_LBL1R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"1R-up");                      
					}
					break;
				case 2:
					if (state == 1)
					{              
						hList = GetDlgItem(hDialog, IDC_LBL2L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"2L-dn");   
					}
					else if (state == 3)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL2L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"2L-up");                  
					}
					break;
				case 3:
					if (state == 1)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL2R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"2R-dn");             
					}
					else if (state == 3)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL2R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"2R-up");                   
					}
					break;
				case 4:
					if (state == 1)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL3L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"3L-dn");                
					}
					else if (state == 3)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL3L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"3L-up");                 
					}
					break;
				case 5:
					if (state == 1)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL3R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"3R-dn");                
					}
					else if (state == 3)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL3R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"3R-up");                   
					}
					break;
				case 6:
					if (state == 1)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL4L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"4L-dn");                   
					}
					else if (state == 3)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL4L);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"4L-up");                 
					}
					break;
				case 7:
					if (state == 1)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL4R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"4R-dn");               
					}
					else if (state == 3)
					{
                        hList = GetDlgItem(hDialog, IDC_LBL4R);
						if (hList == NULL) return TRUE;
						SendMessage(hList, WM_SETTEXT, 0, (LPARAM)"4R-up");                   
					}
					break;
				}

				temp1=(temp1<<1);
			}
		}
		for (int i=0;i<37;i++)
		{
			lastpData[i]=pData[i];  //save it for comparison on next read
		}
		//time stamp info 4 bytes
        long absolutetime = 16777216 * pData[32] + 65536 * pData[33] + 256 * pData[34] + pData[35];  //ms
	}
	else if (pData[2] == 165) //0xA5 Incoming DMX Data via Read Once
	{
		int count = pData[5]; //number bytes (addresses) to follow
        int thisstartaddress = pData[4] * 256 + pData[3]; //start address
		for (int i = 0; i < count; i++)
        {
            //address = thisstartaddress + i
			//value = pData[6 + i]
        }
		//time stamp info 4 bytes
        long absolutetime = 16777216 * pData[32] + 65536 * pData[33] + 256 * pData[34] + pData[35];  //ms
	}
	else if (pData[2] == 147) //0x93 Incoming DMX Data via Notification
	{
		int count = pData[5]; //number addresses to follow, always 1 in this case
        int address = pData[4] * 256 + pData[3]; //address of changed DMX data
		int value = pData[6]; //DMX data for address
		//time stamp info 4 bytes - Note if the time stamp is the same, change in DMX value occurred simultaneously
        long absolutetime = 16777216 * pData[32] + 65536 * pData[33] + 256 * pData[34] + pData[35];  //ms
	}
	else if (pData[2] == 163) //0xA3 DMX Length requested
	{
		int length=pData[3]+(pData[4]*256);
		_itoa_s(length,dataStr2,10);
		HWND hList = GetDlgItem(hDialog, IDC_LBLDMXLength);
		if (hList == NULL) return TRUE;
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)dataStr2);
	}
	else if (pData[2] == 146) //0x92 DMX Read Length requested
	{
		int length=pData[3]+(pData[4]*256);
		_itoa_s(length,dataStr2,10);
		HWND hList = GetDlgItem(hDialog, IDC_LBLDMXReadLength);
		if (hList == NULL) return TRUE;
		SendMessage(hList, WM_SETTEXT,NULL , (LPARAM)dataStr2);
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
