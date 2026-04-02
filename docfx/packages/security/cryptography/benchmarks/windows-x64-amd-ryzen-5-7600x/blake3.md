| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE3 · Native       | 128B         |       101.4 ns |     1.43 ns |     1.33 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128B         |       143.9 ns |     1.93 ns |     1.81 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128B         |       542.1 ns |     0.99 ns |     0.78 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128B         |     1,268.0 ns |     4.94 ns |     4.62 ns |         - |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 137B         |       150.5 ns |     0.31 ns |     0.29 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 137B         |       221.8 ns |     1.05 ns |     0.98 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 137B         |       800.4 ns |     3.44 ns |     3.21 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 137B         |     1,876.7 ns |     4.64 ns |     4.11 ns |         - |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 1KB          |       745.5 ns |     1.46 ns |     1.36 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1KB          |     1,073.6 ns |     3.03 ns |     2.84 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1KB          |     4,212.7 ns |    19.71 ns |    17.47 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1KB          |     9,458.4 ns |    32.20 ns |    30.12 ns |         - |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 1025B        |       849.1 ns |     1.93 ns |     1.71 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1025B        |     1,225.7 ns |     2.72 ns |     2.27 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1025B        |     4,714.9 ns |    10.05 ns |     8.91 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1025B        |    10,585.0 ns |    32.92 ns |    30.79 ns |      56 B |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 8KB          |     1,166.5 ns |     2.57 ns |     2.28 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 8KB          |    10,208.8 ns |    50.20 ns |    44.50 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 8KB          |    35,299.8 ns |   150.17 ns |   133.12 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 8KB          |    81,207.4 ns |   171.09 ns |   151.67 ns |     392 B |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 128KB        |    14,276.1 ns |    29.44 ns |    22.99 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128KB        |   163,229.8 ns |   553.37 ns |   462.09 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128KB        |   564,676.6 ns | 1,373.35 ns | 1,146.81 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128KB        | 1,281,956.7 ns | 1,637.00 ns | 1,366.97 ns |    7112 B |