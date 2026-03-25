#!/usr/bin/env bash
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# Helper shell script to run the PowerShell benchmark runner on Unix-like systems.
# Usage: ./scripts/run-benchmarks.sh [options]
# For full parameter list, run without arguments to print the concise help forwarded from the PowerShell script.

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PS_SCRIPT="$SCRIPT_DIR/run-benchmarks.ps1"

if [ ! -f "$PS_SCRIPT" ]; then
  echo "Error: PowerShell script not found: $PS_SCRIPT" >&2
  exit 2
fi

# Choose an available PowerShell executable
if command -v pwsh >/dev/null 2>&1; then
  PWSH_CMD="pwsh"
elif command -v powershell >/dev/null 2>&1; then
  PWSH_CMD="powershell"
else
  echo "Error: PowerShell Core (pwsh) or Windows PowerShell (powershell) is required but not found in PATH." >&2
  echo "Please install PowerShell Core (https://aka.ms/powershell) or run the .ps1 file directly with an appropriate shell." >&2
  exit 3
fi

# Forward all arguments to the PowerShell script using -File which preserves argument separation.
# Do not pass a literal "--" sentinel - pwsh/powershell may interpret it as an empty parameter name.
# Simply place script arguments after the script path; PowerShell will forward them to the script.
exec "$PWSH_CMD" -NoProfile -ExecutionPolicy Bypass -File "$PS_SCRIPT" "$@"
