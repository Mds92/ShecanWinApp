:: Written by Mohammad Dayyan, mds.soft@gmail
@echo off
cls
setlocal
set networkName=%1
@echo Remove Schean DNS Starting
netsh interface ip set dnsservers %NetworkName% dhcp
@echo Remove Schean DNS Starting Done
endlocal