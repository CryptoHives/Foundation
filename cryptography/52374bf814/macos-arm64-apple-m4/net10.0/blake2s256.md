| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     197.0 ns |     0.32 ns |     0.28 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 128B         |     352.9 ns |     1.23 ns |     0.96 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 128B         |     629.2 ns |     3.92 ns |     3.47 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     285.7 ns |     0.61 ns |     0.57 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 137B         |     529.8 ns |     0.88 ns |     0.78 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 137B         |     941.5 ns |     4.14 ns |     3.67 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,449.8 ns |     1.28 ns |     1.20 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 1KB          |   2,791.0 ns |    11.21 ns |     9.94 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 1KB          |   4,969.1 ns |    25.39 ns |    23.75 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,538.1 ns |     2.69 ns |     2.38 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 1025B        |   2,957.3 ns |     2.52 ns |     2.23 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 1025B        |   5,268.1 ns |    22.24 ns |    20.80 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,454.4 ns |    10.12 ns |     8.97 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 8KB          |  22,208.3 ns |     9.78 ns |     9.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 8KB          |  39,507.8 ns |   198.24 ns |   185.44 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 183,111.0 ns |   170.96 ns |   159.91 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 128KB        | 355,336.3 ns |   217.66 ns |   192.95 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 128KB        | 632,199.8 ns | 2,492.04 ns | 2,331.06 ns |         - |