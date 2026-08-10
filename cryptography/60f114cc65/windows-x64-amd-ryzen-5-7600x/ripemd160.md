| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128B         |     647.0 ns |     4.00 ns |     3.54 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128B         |     711.6 ns |     7.16 ns |     6.69 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 137B         |     644.0 ns |     3.73 ns |     3.31 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 137B         |     713.5 ns |     3.95 ns |     3.30 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1KB          |   3,569.0 ns |    11.68 ns |    10.36 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1KB          |   3,978.8 ns |    29.22 ns |    27.33 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1025B        |   3,577.2 ns |    23.81 ns |    22.27 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1025B        |   3,984.6 ns |    48.01 ns |    42.56 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 8KB          |  27,031.8 ns |   151.91 ns |   142.10 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 8KB          |  30,220.7 ns |   110.38 ns |   103.25 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128KB        | 428,073.3 ns | 1,776.72 ns | 1,575.02 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128KB        | 478,752.8 ns | 2,533.80 ns | 2,246.15 ns |         - |