Starting with MyApp which was created using command line process as described in https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/next. 

Used HidSharp-master from https://github.com/IntergatedCircuits/HidSharp. Opened the HidSharp.NETStandard.sln file and compiled it. This created dlls in the folders ...\HidSharp-master\HidSharp-master\bin\netcoreapp2.0 and ...\HidSharp-master\HidSharp-master\bin\netstandard2.0. This sample uses the dll from the netcoreapp2.0 folder.

After opening the MyApp.sln file (in vs2022) go to Dependencies and Add Project Reference and browse to the HidSharp.dll file.

