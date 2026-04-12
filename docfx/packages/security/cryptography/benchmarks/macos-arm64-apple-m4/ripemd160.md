| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128B         |     502.0 ns |     2.45 ns |     2.29 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128B         |     511.0 ns |     0.25 ns |     0.23 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 137B         |     501.8 ns |     2.38 ns |     2.23 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 137B         |     516.0 ns |     0.27 ns |     0.25 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1KB          |   2,838.1 ns |    13.12 ns |    12.27 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1KB          |   2,870.8 ns |     0.91 ns |     0.86 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1025B        |   2,834.0 ns |     7.00 ns |     6.21 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1025B        |   2,880.0 ns |     0.95 ns |     0.89 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 8KB          |  21,408.0 ns |    71.49 ns |    66.87 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 8KB          |  21,738.7 ns |     4.55 ns |     4.03 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128KB        | 342,002.5 ns | 1,338.92 ns | 1,252.43 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128KB        | 345,226.1 ns |    63.91 ns |    59.78 ns |         - |