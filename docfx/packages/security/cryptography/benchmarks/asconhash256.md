| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-Hash256 · Managed      | 128B         |     584.1 ns |    10.65 ns |     9.96 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128B         |     765.1 ns |     2.38 ns |     1.99 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 137B         |     605.7 ns |     5.54 ns |     5.18 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 137B         |     805.8 ns |     9.06 ns |     8.48 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1KB          |   3,705.6 ns |    31.76 ns |    29.71 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1KB          |   4,971.4 ns |    25.85 ns |    24.18 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 1025B        |   3,720.5 ns |    24.74 ns |    23.14 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 1025B        |   4,963.2 ns |    25.97 ns |    23.03 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 8KB          |  28,710.2 ns |    75.32 ns |    58.80 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 8KB          |  38,676.0 ns |   352.20 ns |   329.45 ns |         - |
|                                               |              |              |             |             |           |
| TryComputeHash · Ascon-Hash256 · Managed      | 128KB        | 459,274.1 ns | 2,816.20 ns | 2,634.27 ns |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle | 128KB        | 615,646.2 ns | 3,620.44 ns | 3,386.56 ns |         - |