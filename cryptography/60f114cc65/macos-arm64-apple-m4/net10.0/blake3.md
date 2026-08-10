| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE3 · Native        | 128B         |     101.0 ns |     0.06 ns |     0.06 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 128B         |     239.4 ns |     0.04 ns |     0.03 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 128B         |     515.5 ns |     2.59 ns |     2.42 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 128B         |     725.4 ns |     1.80 ns |     1.69 ns |         - |
|                                         |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Native        | 137B         |     147.4 ns |     0.13 ns |     0.11 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 137B         |     362.6 ns |     0.06 ns |     0.05 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 137B         |     761.4 ns |     2.84 ns |     2.65 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 137B         |   1,070.1 ns |     3.78 ns |     3.54 ns |         - |
|                                         |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Native        | 1KB          |     769.9 ns |     1.15 ns |     1.08 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 1KB          |   1,931.2 ns |     0.78 ns |     0.69 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 1KB          |   3,988.8 ns |    46.73 ns |    43.71 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 1KB          |   5,353.3 ns |    21.30 ns |    19.93 ns |         - |
|                                         |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Native        | 1025B        |     881.8 ns |     0.76 ns |     0.71 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 1025B        |   2,190.1 ns |    14.51 ns |    13.57 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 1025B        |   4,580.5 ns |    20.35 ns |    19.03 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 1025B        |   6,125.0 ns |    18.61 ns |    17.41 ns |      56 B |
|                                         |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Native        | 8KB          |   3,321.8 ns |     9.38 ns |     8.78 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 8KB          |  17,043.9 ns |    14.01 ns |    10.94 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 8KB          |  34,468.7 ns |   389.45 ns |   345.24 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 8KB          |  45,271.2 ns |   150.65 ns |   140.92 ns |     392 B |
|                                         |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Native        | 128KB        |  52,902.1 ns |   258.46 ns |   241.76 ns |         - |
| TryComputeHash · BLAKE3 · BLAKE3 (Neon) | 128KB        | 278,207.5 ns |   180.76 ns |   160.24 ns |         - |
| TryComputeHash · BLAKE3 · Managed       | 128KB        | 556,039.0 ns | 2,453.75 ns | 1,915.73 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle  | 128KB        | 727,187.3 ns | 1,475.15 ns | 1,379.86 ns |    7112 B |