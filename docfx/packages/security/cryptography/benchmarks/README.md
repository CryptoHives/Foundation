# Benchmark Results

This directory stores the published BenchmarkDotNet results for the cryptography hash suites.

## File Structure

| File | Description |
|------|-------------|
| `machine-spec.md` | Captured hardware/software profile for the latest run |
| `allhashers-all-sizes.md` | Full output of `AllHashersAllSizesBenchmark` with every algorithm and payload size |

## Updating Benchmark Results

1. Run the cryptography benchmarks from the repository root:
   ```powershell
   .\scripts\run-benchmarks.ps1 -Project Cryptography
   ```
   or execute the test harness directly:
   ```powershell
   cd tests/Security/Cryptography
   dotnet run -c Release --framework net10.0 -- --filter "*AllHashersAllSizesBenchmark*"
   ```

2. Copy the latest BenchmarkDotNet artifacts into this folder:
   ```powershell
   .\scripts\update-benchmark-docs.ps1 -Package Cryptography
   ```

The helper script:
- Reads the generated markdown under `tests/Security/Cryptography/BenchmarkDotNet.Artifacts/results/`
- Extracts the machine specification into `machine-spec.md`
- Removes the duplicated machine header from the benchmark table and saves it as `allhashers-all-sizes.md`

Keep in mind that the measurements are machine-dependent. Re-run the suite on your own hardware to compare against these reference numbers.
