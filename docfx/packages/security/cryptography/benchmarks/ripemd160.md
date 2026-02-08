| Description                                | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128B         |     641.1 ns |     2.13 ns |   2.00 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128B         |     716.9 ns |     3.14 ns |   2.63 ns |         - |
|                                            |              |              |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 137B         |     639.0 ns |     2.27 ns |   2.12 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 137B         |     724.2 ns |     3.63 ns |   3.39 ns |         - |
|                                            |              |              |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1KB          |   3,553.5 ns |    10.08 ns |   9.43 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1KB          |   3,994.8 ns |    25.56 ns |  23.91 ns |         - |
|                                            |              |              |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1025B        |   3,564.2 ns |    11.80 ns |  11.04 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1025B        |   4,012.2 ns |    21.89 ns |  18.28 ns |         - |
|                                            |              |              |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 8KB          |  26,890.0 ns |    82.02 ns |  76.73 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 8KB          |  30,152.6 ns |   201.06 ns | 188.07 ns |         - |
|                                            |              |              |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128KB        | 427,114.0 ns |   916.12 ns | 856.94 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128KB        | 476,857.3 ns | 1,152.33 ns | 899.67 ns |         - |