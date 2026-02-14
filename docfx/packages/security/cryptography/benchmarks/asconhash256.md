| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · Managed      | 128B         |     579.8 ns |    11.36 ns |    12.63 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128B         |     768.4 ns |    12.44 ns |    11.64 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 137B         |     606.2 ns |     4.96 ns |     4.40 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 137B         |     807.3 ns |     9.84 ns |     9.21 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1KB          |   3,756.6 ns |    61.14 ns |    57.19 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1KB          |   4,999.4 ns |    64.27 ns |    60.12 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1025B        |   3,747.6 ns |    67.41 ns |    63.05 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1025B        |   5,006.1 ns |    92.76 ns |    86.77 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 8KB          |  29,138.6 ns |   449.13 ns |   420.12 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 8KB          |  38,854.5 ns |   681.25 ns |   637.24 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 128KB        | 462,274.4 ns | 8,182.51 ns | 7,653.93 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128KB        | 615,387.2 ns | 9,071.26 ns | 8,041.44 ns |         - |