@echo off
title Building Launcher...
C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe /verbosity:n /p:Configuration=Release %CD%\Launcher\Launcher.sln
MD LauncherBin
xcopy "%CD%\Launcher\Launcher\bin\Release\*.dll" "%CD%\LauncherBin" /y
xcopy "%CD%\Launcher\Launcher\bin\Release\*.exe" "%CD%\LauncherBin" /y
start explorer.exe "%CD%\LauncherBin"
pause
