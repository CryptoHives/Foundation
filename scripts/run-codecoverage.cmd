@echo off
REM SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
REM SPDX-License-Identifier: MIT

REM run-codecoverage.cmd - Wrapper for run-codecoverage.ps1
REM Usage: scripts\run-codecoverage.cmd [options]
REM Run scripts\run-codecoverage.cmd -? for help

powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0run-codecoverage.ps1" %*
