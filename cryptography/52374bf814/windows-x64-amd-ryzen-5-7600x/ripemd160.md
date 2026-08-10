| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128B         |     641.7 ns |     1.48 ns |     1.31 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128B         |     703.3 ns |     4.18 ns |     3.91 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 137B         |     638.4 ns |     2.69 ns |     2.39 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 137B         |     704.8 ns |     2.92 ns |     2.73 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1KB          |   3,552.2 ns |     7.05 ns |     6.25 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1KB          |   3,932.4 ns |    28.19 ns |    26.37 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1025B        |   3,559.0 ns |     9.88 ns |     9.24 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1025B        |   3,929.3 ns |    18.79 ns |    16.66 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 8KB          |  26,875.9 ns |    56.46 ns |    50.05 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 8KB          |  29,747.4 ns |   181.94 ns |   151.93 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128KB        | 426,248.4 ns | 1,480.62 ns | 1,384.98 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128KB        | 471,273.7 ns | 2,642.99 ns | 2,472.25 ns |         - |