@echo off
title Building Launcher...
C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe /verbosity:n /p:Configuration=Release %CD%\Launcher\Launcher.sln
MD LauncherBin
MD LauncherBin\de-DE
xcopy "%CD%\Launcher\Launcher\bin\Release\*.dll" "%CD%\LauncherBin" /y
xcopy "%CD%\Launcher\Launcher\bin\Release\*.exe" "%CD%\LauncherBin" /y
xcopy "%CD%\Launcher\Launcher\bin\Release\de-DE\OpenRCT2 Launcher.resources.dll" "%CD%\LauncherBin\de-DE" /y
start explorer.exe "%CD%\LauncherBin"
pause
