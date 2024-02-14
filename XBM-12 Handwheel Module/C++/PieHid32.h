#pragma once

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>
 /*
typedef enum {
 	piNone = 0,
	piNewData = 1,
        piAllData = 1,
	piDataChange = 2
} EEventPI;  */
typedef struct  _HID_ENUM_INFO  {
    DWORD   PID;
    DWORD   Usage;
    DWORD   UP;
    long    readSize;
    long    writeSize;
    char    DevicePath[256];
    DWORD   Handle;
    DWORD   Version;
    char   ManufacturerString[128];
    char   ProductString[128];
	char   SerialNumberString[128]; //v2001 
} TEnumHIDInfo;

#define MAX_XKEY_DEVICES		128
#define PI_VID					0x5F3

typedef DWORD (__stdcall *PHIDDataEvent)(UCHAR *pData, DWORD deviceID, DWORD error);
typedef DWORD (__stdcall *PHIDErrorEvent)( DWORD deviceID,DWORD status);

extern "C" void _stdcall GetErrorString(int errNumb,char* EString,int size);
extern "C" DWORD __stdcall EnumeratePIE(long VID, TEnumHIDInfo *info, long &count);
extern "C" DWORD __stdcall GetXKeyVersion(long hnd);
extern "C" DWORD __stdcall SetupInterfaceEx(long hnd);
extern "C" VOID  __stdcall CloseInterface(long hnd);
extern "C" VOID  __stdcall CleanupInterface(long hnd);
extern "C" DWORD __stdcall ReadData(long hnd, UCHAR *data);
extern "C" DWORD __stdcall BlockingReadData(long hnd, UCHAR *data, int maxMillis);
extern "C" DWORD __stdcall WriteData(long hnd, UCHAR *data);
extern "C" DWORD __stdcall FastWrite(long hnd, UCHAR *data);
extern "C" DWORD __stdcall ReadLast(long hnd, UCHAR *data);
extern "C" DWORD __stdcall ClearBuffer(long hnd);
extern "C" DWORD __stdcall GetReadLength(long hnd);
extern "C" DWORD __stdcall GetWriteLength(long hnd);
extern "C" DWORD __stdcall SetDataCallback(long hnd, PHIDDataEvent pDataEvent);
extern "C" DWORD __stdcall SetErrorCallback(long hnd, PHIDErrorEvent pErrorCall);
extern "C" void __stdcall DongleCheck2(int k0, int k1, int k2, int k3, int n0, int n1, int n2, int n3, int &r0, int &r1, int &r2, int &r3);
extern "C" void __stdcall SuppressDuplicateReports(long hnd,bool supp);
extern "C" void __stdcall DisableDataCallback(long hnd,bool disable);
extern "C" bool __stdcall IsDataCallbackDisabled(long hnd);
extern "C" bool __stdcall GetSuppressDuplicateReports(long hnd);

