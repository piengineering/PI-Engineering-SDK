// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
#include "PIEHid32.h"

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

HWND hDialog;
long hDevice = -1;

int mouseport;

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
		case IDC_SLOW:
			//This code is for slowing down the mouse messages if there is too much "lag" .
			for ( i=0;i<9;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=mouseport;
			buffer[2]=0xf3;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			Sleep(50);
			buffer[1]=mouseport;
			buffer[2]=0x14;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			return TRUE;
		case IDC_DEFAULT:
			//set default mouse message speed
			for ( i=0;i<9;i++)
			{
				buffer[i]=0;
			}
			buffer[1]=mouseport;
			buffer[2]=0xf3;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			Sleep(50);
			buffer[1]=mouseport;
			buffer[2]=0x3C;
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
		if ((hidusagepage == 0xC) && (pid==525 || pid==514 ||pid==515))    {	
			hnd = info[i].Handle; //handle required for piehid32.dll calls
			result = SetupInterfaceEx(hnd);
			if (result != 0)    {
				AddEventMsg(hDialog, "Error setting up PI Engineering Device");
			}
			else    {
				hDevice = hnd;
			    AddEventMsg(hDialog, "Found Device: PS2 Host Emulator");
				return;
			}
		}
	}

	AddEventMsg(hDialog, "No device found");
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
		sprintf_s(dataStr, "%02x %02x %02x %02x %02x %02x\n", 
		pData[0], pData[1], pData[2], pData[3], pData[4], pData[5]);

		AddEventMsg(hDialog, dataStr);
		//mouse messages start with 4 or 8 (depending on port) in 2nd byte, 3rd byte is buttons (bit 1=left, bit 2=right, bit 3=center)
		//4th byte is mouse position X, 5th byte is mouse position y, 6th byte is scroll(1=up, 255=down)
		//keyboard messages start with 1 or 5 (depending on port) in 2nd byte, 3rd, 4th, 5th and 6th are keys pressed.  The hid code for the
		//pressed key is shown in the byte or 0 for no key pressed.  Modifier keys are an exception, their hid codes are not shown, instead
		//the following codes are given:
		//160 = Left Control
        //161 = Left Shift
        //162 = Left Alt
        //163 = Left GUI
        //164 = Right Control
        //165 = Right Shift
        //166 = Right Alt
        //167 = Right GUI
		if (pData[1] == 4 || pData[1] == 8) //mouse data
        {
			//fill in mouseport
            switch (pData[1])
            {
				case 4:
					mouseport = 0;  //mouse on Device 2
                    break;
                case 8:
					mouseport = 1;  //mouse on Device 1
                    break;
             }
			
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
