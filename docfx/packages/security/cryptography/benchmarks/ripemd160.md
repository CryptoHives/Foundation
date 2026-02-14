| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128B         |     645.1 ns |     2.34 ns |     2.19 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128B         |     713.1 ns |     2.25 ns |     1.88 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 137B         |     638.2 ns |     1.27 ns |     1.13 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 137B         |     717.4 ns |     1.65 ns |     1.47 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1KB          |   3,548.9 ns |     5.48 ns |     4.85 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1KB          |   3,986.9 ns |    20.03 ns |    17.76 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 1025B        |   3,557.6 ns |     9.50 ns |     8.89 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 1025B        |   4,110.9 ns |    22.77 ns |    19.02 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 8KB          |  26,895.6 ns |    51.95 ns |    46.06 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 8KB          |  30,059.0 ns |    72.77 ns |    68.07 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle | 128KB        | 426,223.2 ns |   852.40 ns |   711.79 ns |         - |
| TryComputeHash · RIPEMD-160 · Managed      | 128KB        | 476,956.2 ns | 2,233.75 ns | 2,089.45 ns |         - |