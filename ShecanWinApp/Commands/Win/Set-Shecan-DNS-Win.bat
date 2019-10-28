:: Written by Mohammad Dayyan, mds.soft@gmail
@echo off
cls
setlocal
set networkName=%1
set preferedDns=%2
set altDns=%3
@echo Set Schean DNS Starting
netsh interface ip set dns %NetworkName% static %preferedDns%
@echo Prefered Dns Set
netsh interface ip add dns name=%NetworkName% addr=%altDns% index=2
@echo Alternative Dns Set
endlocal