@echo off
del %CD%\..\..\..\..\Binaries\*.exe
robocopy *.exe %CD% %CD%\..\..\..\..\Binaries\ /XF *vshost*
pause
exit