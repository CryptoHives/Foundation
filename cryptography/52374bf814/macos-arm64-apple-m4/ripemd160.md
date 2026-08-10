| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · Managed      | 128B         |     511.5 ns |     0.80 ns |     0.71 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128B         |     529.5 ns |     1.75 ns |     1.64 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · Managed      | 137B         |     516.5 ns |     0.75 ns |     0.58 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 137B         |     532.5 ns |     3.56 ns |     2.78 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · Managed      | 1KB          |   2,875.0 ns |     2.82 ns |     2.35 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1KB          |   2,962.9 ns |     5.71 ns |     5.07 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · Managed      | 1025B        |   2,883.9 ns |     2.82 ns |     2.35 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1025B        |   2,946.2 ns |    10.69 ns |     9.47 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · Managed      | 8KB          |  21,756.1 ns |    10.99 ns |     9.18 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 8KB          |  22,089.5 ns |    98.26 ns |    91.91 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · Managed      | 128KB        | 345,787.8 ns |   348.57 ns |   309.00 ns |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128KB        | 350,639.2 ns | 1,319.31 ns | 1,169.54 ns |         - |