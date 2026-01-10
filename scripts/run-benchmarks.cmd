@echo off
REM SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
REM SPDX-License-Identifier: MIT

REM run-benchmarks.cmd - Wrapper for run-benchmarks.ps1
REM Usage: scripts\run-benchmarks.cmd [options]
REM Run scripts\run-benchmarks.cmd -? for help

powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0run-benchmarks.ps1" %*
