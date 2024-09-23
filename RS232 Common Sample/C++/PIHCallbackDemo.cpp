// PIHCallbackDemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "resource.h"
#include <stdlib.h>
#include "PIEHid32.h"  //used only for dongle check
#include <WinUser.h>
#include <string.h>
#include <stdio.h>

//for serial
//#define STRICT
#include <tchar.h>
#include <windows.h>
#include "Serial.h"
//http://www.codeproject.com/KB/system/serial.aspx for full project of Serial_demo from Ramon de Klein

//for base64
#include <math.h> //for use of pow
#include <stdint.h> //base64
#include <stdlib.h> //base64
//https://stackoverflow.com/questions/342409/how-do-i-base64-encode-decode-in-c
static char encoding_table[] = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                                'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                                'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
                                'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                                'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                                'w', 'x', 'y', 'z', '0', '1', '2', '3',
                                '4', '5', '6', '7', '8', '9', '+', '/'};

static char *decoding_table = NULL;
static int mod_table[] = {0, 2, 1};

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
void AddEventMsgCOM(HWND hDialog, char *msg);
void AddDevices(HWND hDialog, char *msg);
DWORD __stdcall HandleDataEvent(UCHAR *pData, DWORD deviceID, DWORD error);
DWORD __stdcall HandleErrorEvent(DWORD deviceID, DWORD status);


BYTE buffer[80];  //used for writing to device
int readlength=0; 
HWND hDialog;
long hDevice = -1;
int combotodevice[128];
//COM port settings
HWND BaudRatePort_Combo;
HWND ParityPort_Combo;
//Xkeys settings
HWND BaudRate_Combo;
HWND Parity_Combo;
bool pidata=false;

bool readcts=false;
char ctsdcddsr[40];

//serial stuff
CSerial serial;
LONG    lLastError = ERROR_SUCCESS;
enum { EOF_Char = 27 };

//base64
char *base64_encode(const unsigned char *data, size_t input_length, int* outputlength);
char *base64_decode(const unsigned char *data, size_t input_length, int* outputlength);

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

	
	hList = GetDlgItem(hDialog, IDC_EDIT4);
	if (hList == NULL) return 0;
	SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"COM4");
	
	//create and fill in the combo boxes
	BaudRatePort_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 787, 210, 100, 250, hDialog, NULL, hInstance, NULL); 
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"300");
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"1200");
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"2400");
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"4800");
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"9600");
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"19200");
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"38400");
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"57600"); 
	SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"115200"); 
	//SendMessage(BaudRatePort_Combo, CB_ADDSTRING, 0, (LPARAM)"230400"); //can't use in this sample

	ParityPort_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 935, 210, 100, 150, hDialog, NULL, hInstance, NULL); 
	SendMessage(ParityPort_Combo, CB_ADDSTRING, 0, (LPARAM)"Even");
	SendMessage(ParityPort_Combo, CB_ADDSTRING, 0, (LPARAM)"Odd");
	SendMessage(ParityPort_Combo, CB_ADDSTRING, 0, (LPARAM)"None");
	
	BaudRate_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 360, 568, 100, 250, hDialog, NULL, hInstance, NULL); 
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"300");
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"1200");
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"2400");
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"4800");
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"9600");
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"19200");
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"38400");
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"57600"); 
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"115200"); 
	SendMessage(BaudRate_Combo, CB_ADDSTRING, 0, (LPARAM)"230400");  

	Parity_Combo = CreateWindowEx(0, "ComboBox", NULL, WS_VISIBLE | WS_CHILD | CBS_DROPDOWNLIST, 518, 568, 100, 150, hDialog, NULL, hInstance, NULL); 
	SendMessage(Parity_Combo, CB_ADDSTRING, 0, (LPARAM)"Even");
	SendMessage(Parity_Combo, CB_ADDSTRING, 0, (LPARAM)"Odd");
	SendMessage(Parity_Combo, CB_ADDSTRING, 0, (LPARAM)"None");

	//set default
	SendMessage(BaudRatePort_Combo, CB_SETCURSEL, 8, 0);
	SendMessage(ParityPort_Combo, CB_SETCURSEL, 2, 0);
	//SendMessage(BaudRate_Combo, CB_SETCURSEL, 8, 0);
	//SendMessage(Parity_Combo, CB_SETCURSEL, 2, 0);
	
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

	return 0;
}
//---------------------------------------------------------------------

void CALLBACK DlgTimerProc(HWND hwnd, UINT a, UINT b, DWORD c)
{
		
	//Read data
	DWORD dwBytesRead = 0;
	char szBuffer[101];
	
	do
	{
		// Read data from the COM-port
		lLastError = serial.Read(szBuffer,sizeof(szBuffer)-1,&dwBytesRead);
		if (lLastError != ERROR_SUCCESS)
		{
			AddEventMsg(hDialog, "Unable to read from COM-port.");
		}

		if (dwBytesRead > 0)
		{
			// Finalize the data, so it is a valid string
			szBuffer[dwBytesRead] = '\0';

			//if (pidata==false)
			//{
			//	//This converts the read character data to the RAW BYTES and prints them in HEX, for example the echo
			//	//from a backlight toggle command would be 0a42383b which is in characters is \nB8;
			//	char dataStr[256];
			//	char str[256];
			//	strcpy(str, "");
			//	for (int i=0;i<dwBytesRead;i++)
			//	{
			//		int code=(int)szBuffer[i];
			//		if (code<0)
			//		{
			//			code=256+code;
			//		}
			//		sprintf(dataStr, "%02x", code);
			//		strcat(str,dataStr);
			//
			//	}
			//	//add the characters too for readability
			//	strcat(str," (");
			//	strcat(str,szBuffer);
			//	strcat(str,")");
			//	AddEventMsgCOM(hDialog, str);
			//}
			//else
			//{
				//Display the data in characters as received but
				//note codes greater than 128 are displayed as Unicode not extended ASCII
				AddEventMsgCOM(hDialog, szBuffer);
				
				//reading the lines
				if (readcts==true) //look for the reply
				{
					
					strcat(ctsdcddsr,szBuffer);

					for (int i=0;i<strlen(ctsdcddsr);i++)
					{
						if (ctsdcddsr[i]==13)
						{
							//end was reached
							//convert to decimal
							char str[1];
							str[0]=ctsdcddsr[10];
							int finalvalue=16*atoi(str);
							str[0]=ctsdcddsr[11];
							finalvalue=finalvalue+atoi(str);
							
							char str2[100];
							strcpy(str2, "");
							//DCD 4th bit
							BYTE val=finalvalue&8;
							if (val!=0) strcat(str2,"DCD=asserted\n");
							else strcat(str2,"DCD=not asserted\n");
							//DSR 5th bit
							val=finalvalue&16;
							if (val!=0) strcat(str2, "DSR=asserted\n");
							else  strcat(str2, "DSR=not asserted\n");
							//CTS 7th bit
							val=finalvalue&64;
							if (val!=0) strcat(str2, "CTS=asserted\n");
							else  strcat(str2, "CTS=not asserted\n");
							HWND hList = GetDlgItem(hDialog, IDC_DCDDSRCTC);
							if (hList == NULL) return;
							SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)str2);
							int stop=0;
						}
					}
					
				}
				
			//}
			
		}
	}
	while (dwBytesRead == sizeof(szBuffer)-1);
		
	
}
//---------------------------------------------------------------------


int CALLBACK DialogProc(
  HWND hwndDlg,  // handle to dialog box
  UINT uMsg,     // message
  WPARAM wParam, // first message parameter
  LPARAM lParam  // second message parameter
)    {

	DWORD result;
	int i=0;
	HWND hList;
	char errordescription[100]; //used with the GetErrorString call to describe the error
	int countout=0;
	int wlen=GetWriteLength(hDevice);

	
	switch (uMsg)    {
	case WM_INITDIALOG:
		
		
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
			KillTimer(hwndDlg,0);
			serial.Close();
			PostQuitMessage(0);
			return TRUE;

		case IDSTART:
		    if (hDevice != -1) CloseInterface(hDevice);
			hDevice = -1;
			SendMessage(GetDlgItem(hwndDlg, CHK_NONE), BM_CLICK, 0, 0);
			FindAndStart(hwndDlg);
				
			return TRUE;

		case IDC_OPENCOMPORT:
			//Open serial port and setup for read and write
			hList = GetDlgItem(hwndDlg, IDC_EDIT4);
			if (hList == NULL) return TRUE;
			char ComPort[10];
			SendMessage(hList, WM_GETTEXT, 10, (LPARAM)ComPort);

			//char str[80];
		    //strcpy_s (str,"\\\\.\\"); //add this at beginning https://stackoverflow.com/questions/15794422/serial-port-rs-232-connection-in-c, this needed for 2 digit com port like COM10
			//strcat_s (str,ComPort);
			//lLastError = serial.Open(_T(str),0,0,false); 

			lLastError = serial.Open(_T(ComPort),0,0,false); //doesn't seem to work for 2 digit comports, for example COM10 requires \\\\.\\COM10
			if (lLastError != ERROR_SUCCESS)
			{
				AddEventMsgCOM(hwndDlg, "Error opening COM Port");
				return TRUE;
			}
			
			// Setup the serial port (115200,8N1)
			CSerial::EBaudrate mybaudrate;
			if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 0) mybaudrate=CSerial::EBaud300; //the CSerial class does not support baud rate 230400
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 1) mybaudrate=CSerial::EBaud1200;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 2) mybaudrate=CSerial::EBaud2400;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 3) mybaudrate=CSerial::EBaud4800;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 4) mybaudrate=CSerial::EBaud9600;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 5) mybaudrate=CSerial::EBaud19200;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 6) mybaudrate=CSerial::EBaud38400;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 7) mybaudrate=CSerial::EBaud57600;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 8) 
			{
					mybaudrate=CSerial::EBaud115200; //max common baud rate between X-keys and CSerial
			}

			CSerial::EParity myparity;
			
			if (SendMessage(ParityPort_Combo, CB_GETCURSEL, 0, 0) == 0) myparity=CSerial::EParEven;
			else if (SendMessage(ParityPort_Combo, CB_GETCURSEL, 0, 0) == 1) myparity=CSerial::EParOdd;
			else if (SendMessage(ParityPort_Combo, CB_GETCURSEL, 0, 0) == 2) 
			{
					myparity=CSerial::EParNone;
			}
			
			lLastError = serial.Setup(mybaudrate,CSerial::EData8, myparity, CSerial::EStop1); //leave default data bits=8 and stop bit=1
			
			///lLastError = serial.Setup(CSerial::EBaud9600,CSerial::EData8,CSerial::EParNone,CSerial::EStop1);
			if (lLastError != ERROR_SUCCESS)
			{
				AddEventMsg(hwndDlg, "Error setting the settings on COM Port");
				return TRUE;
			}
			// Setup handshaking
			lLastError = serial.SetupHandshaking(CSerial::EHandshakeOff);
			if (lLastError != ERROR_SUCCESS)
			{
				AddEventMsg(hwndDlg, "Error setting the handshaking on COM Port");
				return TRUE;
			}
			// Register only for the receive event
			lLastError = serial.SetMask(CSerial::EEventBreak |
								CSerial::EEventCTS   |
								CSerial::EEventDSR   |
								CSerial::EEventError |
								CSerial::EEventRing  |
								CSerial::EEventRLSD  |
								CSerial::EEventRecv);
			if (lLastError != ERROR_SUCCESS)
			{
				AddEventMsg(hwndDlg, "Error registering for data receive");
				return TRUE;
			}
			// Use 'non-blocking' reads, because we don't know how many bytes
			// will be received. This is normally the most convenient mode
			// (and also the default mode for reading data).
			lLastError = serial.SetupReadTimeouts(CSerial::EReadTimeoutNonblocking);
			if (lLastError != ERROR_SUCCESS)
			{
				AddEventMsg(hwndDlg, "Unable to set COM port read timeout");
				return TRUE;
			}
			
			//Start the polling timer to read incoming data from port
			SetTimer(hwndDlg, 0, 100, DlgTimerProc); 
			SendMessage(GetDlgItem(hwndDlg, IDC_RDKEYS), BM_SETCHECK, BST_CHECKED, 0);
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
			SuppressDuplicateReports(hDevice, false);
			DisableDataCallback(hDevice, false); //turn on callback in the case it was turned off by some other command
			return TRUE;

		case IDC_CLEAR:
		    
			hList = GetDlgItem(hwndDlg, ID_EVENTS);
			if (hList == NULL) return TRUE;
			SendMessage(hList, LB_RESETCONTENT, 0, 0);
			
			return TRUE;

		case IDC_CLEAR2:
		    
			hList = GetDlgItem(hwndDlg, ID_EVENTS2);
			if (hList == NULL) return TRUE;
			SendMessage(hList, LB_RESETCONTENT, 0, 0);
			return TRUE;
	
		case IDC_BLToggle:
			//Toggle the backlights
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=0xB8;

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
				strcpy_s (str,"PID# ");
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

				//uart stuff
				strcpy_s (str,"");
				if (buffer[21]&1) strcpy_s (str,"UART PI Base64 Input Report Transmit Messages=enabled");
				else strcpy_s (str,"UART PI Base64 Input Report Transmit Messages=disabled");
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (buffer[21]&2) strcat_s (str,"echo op code=enabled ");
				else strcat_s (str,"echo op code=disabled ");
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (buffer[21]&4) strcat_s (str,"USB sleep=enabled ");
				else strcat_s (str,"USB sleep=disabled ");
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (buffer[21]&8) strcat_s (str,"USB check=enabled ");
				else strcat_s (str,"USB check=disabled ");
				AddEventMsg(hDialog, str);

				strcpy_s (str,"");
				if (buffer[21]&16) 
				{
					strcat_s (str,"UART=enabled ");
					hList = GetDlgItem(hDialog, IDC_LBLUARTENABLED);
					if (hList == NULL) return 0;
					SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"enabled");
				}
				else 
				{
					strcat_s (str,"UART=disabled ");
					hList = GetDlgItem(hDialog, IDC_LBLUARTENABLED);
					if (hList == NULL) return 0;
					SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"disabled");
				}
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[23],dataStr,10);
				strcpy_s (str,"start byte opcode=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[24],dataStr,10);
				strcpy_s (str,"stop byte opcode=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[25],dataStr,10);
				strcpy_s (str,"start byte PI Base64=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);

				_itoa_s(buffer[25],dataStr,10);
				strcpy_s (str,"stop byte PI Base64=");
				strcat_s (str,dataStr);
				AddEventMsg(hDialog, str);
				
			}
			return TRUE;
		
		case IDC_CHANGERS232:
			//Changes the X-keys RS232 settings
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=142; //0x8E
			buffer[2]=SendMessage(BaudRate_Combo, CB_GETCURSEL, 0, 0); //baud rate index; 0=300, 1=1200, 2=2400, 3=4800, 4=9600, 5=19200, 6=38400, 7=57600, 8=115200, 9=230400
			buffer[3]=SendMessage(Parity_Combo, CB_GETCURSEL, 0, 0); //parity index; 0=even, 1=odd, 2=none
			buffer[4]=8; //5, 6, 7, 8
			buffer[5]=2; //2=1, 3=1.5, 4=2

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;

		case IDC_READRS232:
			//Reads the X-keys RS232 settings
			if (hDevice == -1) return TRUE;
			//turn off callback
			DisableDataCallback(hDevice, true); //turn off callback so capture data here
		
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=141;
			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
			//after this write the next read 3rd byte=214 will give descriptor information
			for (int i=0;i<80;i++)
			{buffer[i]=0;}
			
			result = BlockingReadData(hDevice, buffer, 100);
			
			while (result == 304 || (result == 0 && buffer[2] != 141))
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
			
			if (result ==0 && buffer[2]==141)
			{
				int xkeysbaudrateindex=buffer[3]; //baud rate index; 0=300, 1=1200, 2=2400, 3=4800, 4=9600, 5=19200, 6=38400, 7=57600, 8=115200, 9=230400
				int xkeysparityindex=buffer[4]; //parity index; 0=even, 1=odd, 2=none
				int xkeysdatabits=buffer[5]; //5, 6, 7, 8
				int xkeysstopbits=buffer[6]; //2=1, 3=1.5, 4=2
				int xkeysuartenabled=buffer[7]; //0=uart off, 1=uart on
				
				hList = GetDlgItem(hDialog, IDC_EDIT4);

				SendMessage(BaudRate_Combo, CB_SETCURSEL, buffer[3], 0);
				SendMessage(Parity_Combo, CB_SETCURSEL, buffer[4], 0);

				if (xkeysuartenabled==0)
				{
					hList = GetDlgItem(hDialog, IDC_LBLUARTENABLED);
					if (hList == NULL) return 0;
					SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"disabled");
				}
				else if (xkeysuartenabled ==1)
				{
					hList = GetDlgItem(hDialog, IDC_LBLUARTENABLED);
					if (hList == NULL) return 0;
					SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"enabled");
				}
			}
			
			return TRUE;
		case IDC_WRITETX:

			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=216; //0xD8
			buffer[2]=3; //number of bytes to follow
			buffer[3]=97; //1st byte 'a'
			buffer[4]=98; //2nd byte 'b'
			buffer[5]=99; //3rd byte 'c'

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;

		case IDC_ECHOON:
			 //If echo is on then when a UART Output Report Received Message is received an Incoming UART Data - Echo UART input report will be generated 
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=217; //0xd9
			buffer[2]=1; //echo on

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;
		case IDC_ECHOOFF:
			 //If echo is on then when a UART Output Report Received Message is received an Incoming UART Data - Echo UART input report will be generated 
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=217; //0xd9
			buffer[2]=1; //echo off (factory default)

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;
		case IDC_JSONON:
			//If enabled then any standard input report will be accompanied by a corresponding UART PI Base64 Input Report Transmit Message sent out on the X-keys TX
            //The message is in a special format, see the UART Port Information section of the documentation for details
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=215; //0xd7
			buffer[2]=1; //0=off (factory default, 1=on)

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;
		case IDC_JSONOFF:
			//If enabled then any standard input report will be accompanied by a corresponding UART PI Base64 Input Report Transmit Message sent out on the X-keys TX
            //The message is in a special format, see the UART Port Information section of the documentation for details
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=215; //0xd7
			buffer[2]=0; //0=off (factory default, 1=on)

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;
		case IDC_SLEEPEN:
			//If sleep enabled  the X-keys will turn off its LEDs and any GPIO output pins when a USB suspend condition occurs. To override this behavior set sleep disable
            //UART users may want to disable the sleep feature by setting this to 1
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=218; //0xda
			buffer[2]=1; //0=enabled (factory default), 1=disabled

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;
		case IDC_SLEEPDIS:
			//If sleep enabled  the X-keys will turn off its LEDs and any GPIO output pins when a USB suspend condition occurs. To override this behavior set sleep disable
            //UART users may want to disable the sleep feature by setting this to 1
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=218; //0xda
			buffer[2]=0;  //0=enabled (factory default), 1=disabled

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;
		case IDC_USBCHECKEN:
			//If no USB detected and this is 0 then device will periodically check to see if USB has been connected. If this is 1 then it will not check to see if the USB was connected.
            //Set to 1 if using the USB connection for power only.
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=143; //0x8f
			buffer[2]=1;  //0=enabled (factory default), 1=disabled

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;
		case IDC_USBCHECKDIS:
			//If no USB detected and this is 0 then device will periodically check to see if USB has been connected. If this is 1 then it will not check to see if the USB was connected.
            //Set to 1 if using the USB connection for power only.
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=143; //0x8f
			buffer[2]=0;   //0=enabled (factory default), 1=disabled

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}
         
			return TRUE;

		case IDC_UARTENABLED:
			//Sending this enables the UART port for RS232 communications. The port should not be enabled without something connected to it.
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=150; //0x96
			buffer[2]=1;   //0=disabled (factory default), 1=enabled

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}

			hList = GetDlgItem(hDialog, IDC_LBLUARTENABLED);
			if (hList == NULL) return 0;
			SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"enabled");
         
			return TRUE;

		case IDC_UARTDISABLED:
			 //Sending this disables the UART port for RS232 communications. The port should be disabled if nothing is connected to the it.
			if (hDevice == -1) return TRUE;
			
			for (int i=0;i<wlen;i++)
			{
				buffer[i]=0;
			}
			buffer[0]=0;
			buffer[1]=150; //0x96
			buffer[2]=0;   //0=disabled (factory default), 1=enabled

			result=404;
			while (result==404)
			{
				result = WriteData(hDevice, buffer);
			}

			hList = GetDlgItem(hDialog, IDC_LBLUARTENABLED);
			if (hList == NULL) return 0;
			SendMessage(hList, WM_SETTEXT, 0, (LPARAM)(LPCTSTR)"disabled");
         
			return TRUE;
		case IDC_CHANGECOMRS232:
			//Set the COM port's RS232 settings. Must match those of the X-keys
			
			// Setup the serial port
			//CSerial::EBaudrate mybaudrate;
			if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 0) mybaudrate=CSerial::EBaud300; //the CSerial class does not support baud rate 230400
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 1) mybaudrate=CSerial::EBaud1200;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 2) mybaudrate=CSerial::EBaud2400;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 3) mybaudrate=CSerial::EBaud4800;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 4) mybaudrate=CSerial::EBaud9600;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 5) mybaudrate=CSerial::EBaud19200;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 6) mybaudrate=CSerial::EBaud38400;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 7) mybaudrate=CSerial::EBaud57600;
			else if (SendMessage(BaudRatePort_Combo, CB_GETCURSEL, 0, 0) == 8) mybaudrate=CSerial::EBaud115200; //max common baud rate between X-keys and CSerial
			
			//CSerial::EParity myparity;
			if (SendMessage(ParityPort_Combo, CB_GETCURSEL, 0, 0) == 0) myparity=CSerial::EParEven;
			else if (SendMessage(ParityPort_Combo, CB_GETCURSEL, 0, 0) == 1) myparity=CSerial::EParOdd;
			else if (SendMessage(ParityPort_Combo, CB_GETCURSEL, 0, 0) == 2) myparity=CSerial::EParNone;
			
			lLastError = serial.Setup(mybaudrate,CSerial::EData8,myparity,CSerial::EStop1); //leave default data bits=8 and stop bit=1
         
			return TRUE;
		case IDC_WRITECOMTX:
			//Serial messages received by the X-keys in this format will cause the X-keys to generate an Incoming UART Data - UART Custom Received Message input report
            //This is an input report with 00 UID 0xD8 02 Byte1 Byte2 ... 03 00 00 00 ...
			
			//Must add start and stop bytes of 2 and 3, respectively to send message to USB
			serial.Write("\2"); //start byte is 2
			serial.Write("d"); //d
			serial.Write("e"); //e
			serial.Write("f"); //f
			serial.Write("\3"); //stop byte is 3

			//resulting input report will be 00 UID D8 02 64 65 66 03 00 00 00 ...
            
			return TRUE;
		case IDC_WRITECOMTX2:
			//Serial messages received by the X-keys in this format will cause the X-keys to execute output reports
            //In this example we want to toggle the backlights which has a command byte of 0xB8, the trailing 0s are included only for format demonstration for longer reports
            //Encode the output report bytes to base64, in this example 0xB8, 00, 00 encodes to UAAA
            //Add start and stop bytes for 4 and 5, respectively
            //If Echo UART messages is on then an Incoming UART Data - Echo of UART Output Report Received Message input report will also be generated
            
			char strin[80];
		    strin[0]=0xB8;
			//base64 encode sample
			char* encoded_data;
			int outputlen;
			encoded_data=base64_encode((const unsigned char*) strin, 1, &outputlen); //1 byte (0xB8) 
			//add \4 to beginning and \5 to ending of the encoded string
			//uA== is the base64 encoded string for 0xB8
			
			lLastError=serial.Write("\4uA==\5"); //start byte=4, stop byte=5
         
			return TRUE;
			//--------------------------
		
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
	for (long i=0; i<count; i++)    
	{
		pid=info[i].PID; //get the device pid
		
		int hidusagepage=info[i].UP; //hid usage page
		int version=info[i].Version;
		int writelen=GetWriteLength(info[i].Handle);
		
		if ((hidusagepage == 0xC && writelen>0))    
		{	
			hnd = info[i].Handle; //handle required for piehid32.dll calls
			result = SetupInterfaceEx(hnd);
			
			if (result != 0)    
			{
				AddDevices(hDialog, "Error setting up PI Engineering Device");
			}
			else    
			{
				AddDevices(hDialog, "X-keys device found");
				combotodevice[cbocount] = i; //this is the handle
				cbocount++;
			}

		}
		else
		{
			
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
void AddEventMsgCOM(HWND hDialog, char *msg)
{
	HWND hList;
 
	int cnt=-1;
 
	hList = GetDlgItem(hDialog, ID_EVENTS2);
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
char *base64_encode(const unsigned char *data, size_t input_length, int* outputlength) 
{

    *outputlength = (4 * ((input_length + 2) / 3));

    char *encoded_data = (char*)malloc(*outputlength);
    if (encoded_data == NULL) return NULL;

	size_t ii;
	size_t jj;

    for (ii = 0, jj = 0; ii < input_length;) {

        uint32_t octet_a = ii < input_length ? (unsigned char)data[ii++] : 0;
        uint32_t octet_b = ii < input_length ? (unsigned char)data[ii++] : 0;
        uint32_t octet_c = ii < input_length ? (unsigned char)data[ii++] : 0;

        uint32_t triple = (octet_a << 0x10) + (octet_b << 0x08) + octet_c;

        encoded_data[jj++] = encoding_table[(triple >> 3 * 6) & 0x3F];
        encoded_data[jj++] = encoding_table[(triple >> 2 * 6) & 0x3F];
        encoded_data[jj++] = encoding_table[(triple >> 1 * 6) & 0x3F];
        encoded_data[jj++] = encoding_table[(triple >> 0 * 6) & 0x3F];
    }

    for (int i = 0; i < mod_table[input_length % 3]; i++)
        encoded_data[*outputlength - 1 - i] = '=';

    return encoded_data;
}

//------------------------------------------------------------------------

char *base64_decode(const unsigned char *data, size_t input_length, int* output_length) 
{

    if (decoding_table == NULL)
	{
		decoding_table = (char*)malloc(256);

		for (int i = 0; i < 64; i++)
			decoding_table[(unsigned char) encoding_table[i]] = i;	
	}//build_decoding_table();

    if (input_length % 4 != 0) return NULL;

    *output_length = input_length / 4 * 3;
    if (data[input_length - 1] == '=') (*output_length)--;
    if (data[input_length - 2] == '=') (*output_length)--;

    char *decoded_data = (char*)malloc(*output_length);
    if (decoded_data == NULL) return NULL;

    size_t ii;
	size_t jj;
	for (ii = 0, jj = 0; ii < input_length;) {

        uint32_t sextet_a = data[ii] == '=' ? 0 & ii++ : decoding_table[data[ii++]];
        uint32_t sextet_b = data[ii] == '=' ? 0 & ii++ : decoding_table[data[ii++]];
        uint32_t sextet_c = data[ii] == '=' ? 0 & ii++ : decoding_table[data[ii++]];
        uint32_t sextet_d = data[ii] == '=' ? 0 & ii++ : decoding_table[data[ii++]];

        uint32_t triple = (sextet_a << 3 * 6)
        + (sextet_b << 2 * 6)
        + (sextet_c << 1 * 6)
        + (sextet_d << 0 * 6);

        if (jj < *output_length) decoded_data[jj++] = (triple >> 2 * 8) & 0xFF;
        if (jj < *output_length) decoded_data[jj++] = (triple >> 1 * 8) & 0xFF;
        if (jj < *output_length) decoded_data[jj++] = (triple >> 0 * 8) & 0xFF;
    }

    return decoded_data;
}
//------------------------------------------------------------------------