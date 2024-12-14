@ECHO off
SETLOCAL

set MODEL_NAME=HarnessMachine
set MODELCOMPILER=D:\GitHub\opcua\UA-ModelCompiler\build\bin\Release\net8.0\Opc.Ua.ModelCompiler.exe
set MODEL=MachineModel
set MODEL_DI=..\DI\Opc.Ua.Di.NodeSet2
set MODEL_MA=..\Machinery\Opc.Ua.Machinery.NodeSet2
set VERSION=v105
set EXCLUDE=Draft
set INPUT=.
set CSVINPUT=%MODEL_NAME%
set OUTPUT=%MODEL_NAME%
set USEALLOWSUBTYPES=-useAllowSubtypes

ECHO Building Model %MODEL%
ECHO %MODELCOMPILER% compile 
ECHO    -version %VERSION% 
ECHO    -exclude %EXCLUDE% 
ECHO    -d2 "%INPUT%\%MODEL%.xml" -d2 "%INPUT%\%MODEL_DI%.xml" -d2 "%INPUT%\%MODEL_MA%.xml" 
ECHO    -cg "%CSVINPUT%\%MODEL_NAME%.csv" 
ECHO    -o2 "%OUTPUT%" %USEALLOWSUBTYPES%

%MODELCOMPILER% compile ^
    -version %VERSION% ^
    -exclude %EXCLUDE% ^
    -d2 "%INPUT%\%MODEL%.xml" -d2 "%INPUT%\%MODEL_DI%.xml" -d2 "%INPUT%\%MODEL_MA%.xml" ^
    -cg "%CSVINPUT%\%MODEL_NAME%.csv" ^
    -o2 "%OUTPUT%" %USEALLOWSUBTYPES%

IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %MODEL% & EXIT /B 3 )
