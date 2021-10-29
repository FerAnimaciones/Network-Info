@echo off
cd ..
for %%I in (.) do set systemname=%%~nxI
set a=%cd%
cd ..
::echo %a%
For /f "tokens=1-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a%%b)
set datetoday=%mydate%_%mytime%
if not exist "backups" mkdir backups
if exist %systemname%.rar copy %systemname%.rar "backups/%systemname% %datetoday%".rar
if exist "%systemname%.rar" del "%systemname%.rar"
"%ProgramFiles%\WinRAR\Rar.exe" a -ep1 -idq -r -y -rr100p "%systemname%" "%a%"  -x*\node_modules
::pause
