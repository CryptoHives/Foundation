| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     196.3 ns |     0.11 ns |     0.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 128B         |     351.6 ns |     0.06 ns |     0.05 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 128B         |     638.4 ns |     2.20 ns |     2.06 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     284.9 ns |     0.41 ns |     0.38 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 137B         |     529.2 ns |     0.65 ns |     0.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 137B         |     954.6 ns |     5.61 ns |     5.24 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,450.7 ns |     1.67 ns |     1.56 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 1KB          |   2,782.0 ns |     0.46 ns |     0.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 1KB          |   5,046.4 ns |    17.74 ns |    16.59 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,542.9 ns |     2.03 ns |     1.90 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 1025B        |   2,955.0 ns |     0.56 ns |     0.50 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 1025B        |   5,370.2 ns |    12.82 ns |    11.99 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,482.9 ns |    11.26 ns |    10.53 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 8KB          |  22,202.1 ns |     5.10 ns |     4.26 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 8KB          |  40,334.1 ns |   128.89 ns |   120.56 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 183,323.1 ns |   183.99 ns |   172.11 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 128KB        | 355,162.0 ns |    44.43 ns |    39.38 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 128KB        | 645,318.7 ns | 3,331.70 ns | 3,116.48 ns |         - |