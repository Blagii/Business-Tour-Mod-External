@echo off
setlocal
cd /d "%~dp0"
echo ==================================================
echo  Business Tour Mod - diagnostic launcher
echo ==================================================
echo.
echo [1] Required files:
for %%F in (BusinessTourMod.exe BusinessTourMod.exe.config AutoUpdater.NET.dll Memory.dll ProcessMemoryScanner.dll) do (
  if exist "%%F" (echo     OK      %%F) else (echo     MISSING %%F)
)
echo.
echo [2] .NET Framework 4.x registry (Release 461808 or higher means 4.7.2+):
reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Release 2>nul
if errorlevel 1 echo     NOT FOUND - install .NET Framework 4.7.2 runtime
echo.
echo [3] Game process:
tasklist /FI "IMAGENAME eq BusinessTour.exe" 2>nul | find /I "BusinessTour.exe" >nul
if errorlevel 1 (echo     BusinessTour.exe is NOT running - start the game first) else (echo     BusinessTour.exe is running)
echo.
echo [4] Removing the downloaded-file block flag...
powershell -NoProfile -ExecutionPolicy Bypass -Command "Get-ChildItem -File | Unblock-File" >nul 2>&1
echo.
echo [5] Starting BusinessTourMod.exe ...
echo.
"BusinessTourMod.exe"
echo.
echo Exit code: %ERRORLEVEL%
echo.
if exist "startup-error.log" (
  echo --- startup-error.log ---
  type "startup-error.log"
) else (
  echo No startup-error.log was written.
)
echo.
pause
