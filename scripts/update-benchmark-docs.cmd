@echo off
REM SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
REM SPDX-License-Identifier: MIT

REM update-benchmark-docs.cmd - Wrapper for update-benchmark-docs.ps1
REM Copies BenchmarkDotNet results to docfx benchmark documentation folder
REM Run this after executing benchmarks locally on a quiet machine
REM
REM Usage: scripts\update-benchmark-docs.cmd [options]
REM Run scripts\update-benchmark-docs.cmd -? for help

powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0update-benchmark-docs.ps1" %*
