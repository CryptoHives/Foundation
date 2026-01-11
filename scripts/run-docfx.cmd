@echo off
REM SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
REM SPDX-License-Identifier: MIT

REM run-docfx.cmd - Wrapper for run-docfx.ps1
REM Usage: scripts\run-docfx.cmd [options]
REM Run scripts\run-docfx.cmd -? for help
REM
REM Examples:
REM   scripts\run-docfx.cmd              - Build documentation
REM   scripts\run-docfx.cmd -Serve       - Build and serve documentation
REM   scripts\run-docfx.cmd -Serve -Port 9000 - Serve on custom port

powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0run-docfx.ps1" %*
