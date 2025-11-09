@setlocal EnableExtensions EnableDelayedExpansion
@echo off

set current-path=%~dp0

rem // remove trailing slash
set current-path=%current-path:~0,-1%
set build_root=%current-path%\..
set framework=net8.0
set runtimes=net8.0
set filter=*

cd %build_root%

cd tests\Threading\
dotnet run -v n --configuration Release  --framework %framework% -- --filter %filter% --runtimes %runtimes% --logBuildOutput
cd ..
