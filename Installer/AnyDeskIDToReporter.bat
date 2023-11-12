@echo off
chcp 1251 > nul

setlocal enabledelayedexpansion 

SET "ReporterFile=%~1"
SET "AnydeskDir=%PROGRAMDATA%\Anydesk"
SET "AnydeskSystemConf=%AnydeskDir%\system.conf"
SET "AnyId="

IF EXIST "%AnydeskSystemConf%" (
  for /F "usebackq tokens=2 delims==" %%i in (`findstr "ad.anynet.id" "%AnydeskSystemConf%"`) do set AnyId=%%i
) ELSE (
  set "AnyId=Not found"
)

IF EXIST "%ReporterFile%" (
  "%ReporterFile%" -pushkeyvalue="AnyDeskId|%AnyId%"
) ELSE (
  echo ReporterFile not found
)

@echo on