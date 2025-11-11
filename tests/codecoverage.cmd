@setlocal EnableExtensions EnableDelayedExpansion
@echo off

set current-path=%~dp0
rem // remove trailing slash
set current-path=%current-path:~0,-1%
set build_root=%current-path%\..
set framework=net8.0

cd %build_root%

rd /s /Q .\CodeCoverage
rd /s /Q .\TestResults
dotnet test "CryptoHives .NET Foundation.sln" -v n --configuration Release  --framework %framework% --collect:"XPlat Code Coverage" --settings ./tests/coverlet.runsettings.xml --results-directory ./TestResults 

REM ensure latest report tool is installed
dotnet tool uninstall -g dotnet-reportgenerator-globaltool
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:./TestResults/**/coverage.cobertura.xml -targetdir:./CodeCoverage  "-title:CryptoHives .NET Foundation Test Coverage" -reporttypes:Badges;Html;HtmlSummary;Cobertura 

REM Display result in browser
.\CodeCoverage\index.html