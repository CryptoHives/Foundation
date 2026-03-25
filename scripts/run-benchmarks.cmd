@echo off
REM SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
REM SPDX-License-Identifier: MIT

REM run-benchmarks.cmd - Wrapper for run-benchmarks.ps1
REM Usage: scripts\run-benchmarks.cmd [options]
REM Run scripts\run-benchmarks.cmd -? for help
REM
REM Examples:
REM   scripts\run-benchmarks.cmd                                     - Run Threading benchmarks
REM   scripts\run-benchmarks.cmd -Project Cryptography               - Run Cryptography benchmarks
REM   scripts\run-benchmarks.cmd -Project Cryptography -Family SHA2  - Run SHA-2 family benchmarks
REM   scripts\run-benchmarks.cmd -Project Cryptography -Family BLAKE - Run all BLAKE benchmarks
REM   scripts\run-benchmarks.cmd -Project Cryptography -Family Core  - Run core comparison benchmarks
REM   scripts\run-benchmarks.cmd -Filter "*SHA256*"                  - Run specific benchmarks
REM   scripts\run-benchmarks.cmd -Project Cryptography -List         - List available Cryptography benchmarks

where pwsh.exe >nul 2>&1
if %ERRORLEVEL% EQU 0 (
    pwsh.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0run-benchmarks.ps1" %*
) else (
    REM Windows PowerShell -File treats script args as positional in some cases.
    REM Use -Command + @args to preserve named parameter binding.
    powershell.exe -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0run-benchmarks.ps1' @args" -- %*
)

exit /b %ERRORLEVEL%
