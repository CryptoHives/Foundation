| Description                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SM3 · Managed      | 128B         |     695.1 ns |     3.22 ns |     3.02 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128B         |     789.5 ns |     2.53 ns |     2.37 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 137B         |     698.3 ns |     4.28 ns |     4.00 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 137B         |     784.1 ns |     3.92 ns |     3.67 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1KB          |   3,894.9 ns |    20.04 ns |    18.74 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1KB          |   4,377.7 ns |    37.57 ns |    33.31 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 1025B        |   3,888.7 ns |    18.66 ns |    16.54 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 1025B        |   4,433.6 ns |    36.70 ns |    34.33 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 8KB          |  29,273.6 ns |   120.08 ns |   106.45 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 8KB          |  33,550.4 ns |   211.56 ns |   197.89 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · SM3 · Managed      | 128KB        | 463,355.4 ns | 1,495.30 ns | 1,248.64 ns |         - |
| TryComputeHash · SM3 · BouncyCastle | 128KB        | 533,243.6 ns | 3,809.45 ns | 3,563.37 ns |         - |