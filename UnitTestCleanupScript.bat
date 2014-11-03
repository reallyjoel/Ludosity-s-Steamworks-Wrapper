@echo off

REM Set the working directory
cd %1

REM Remove the unit test folder and all contents
if exist TestResults del TestResults /S /Q
if exist TestResults rmdir TestResults /S /Q
