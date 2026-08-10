| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     196.2 ns |     0.16 ns |     0.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 128B         |     355.4 ns |     2.65 ns |     2.35 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 128B         |     631.7 ns |     2.46 ns |     2.18 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     285.0 ns |     0.68 ns |     0.57 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 137B         |     529.6 ns |     0.65 ns |     0.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 137B         |     941.2 ns |     4.30 ns |     3.35 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,450.3 ns |     4.49 ns |     3.50 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 1KB          |   2,795.6 ns |     5.73 ns |     5.08 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 1KB          |   4,999.6 ns |    36.27 ns |    35.62 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,539.9 ns |     1.46 ns |     1.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 1025B        |   2,967.6 ns |     1.33 ns |     1.04 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 1025B        |   5,303.7 ns |    35.66 ns |    27.84 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,460.3 ns |     9.59 ns |     8.97 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 8KB          |  22,297.2 ns |    15.85 ns |    14.83 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 8KB          |  39,627.8 ns |   225.81 ns |   200.17 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 182,969.4 ns |   589.31 ns |   551.24 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon) | 128KB        | 356,389.5 ns |    56.26 ns |    49.87 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed            | 128KB        | 633,907.8 ns | 3,289.33 ns | 2,746.74 ns |         - |