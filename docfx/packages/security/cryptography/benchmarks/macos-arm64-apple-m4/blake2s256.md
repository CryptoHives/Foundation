| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128B         |     142.3 ns |   0.34 ns |   0.29 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128B         |     163.2 ns |   0.45 ns |   0.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128B         |     198.9 ns |   0.31 ns |   0.29 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 137B         |     212.0 ns |   0.12 ns |   0.10 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 137B         |     240.8 ns |   0.85 ns |   0.80 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 137B         |     287.6 ns |   0.38 ns |   0.32 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1KB          |   1,098.6 ns |   3.72 ns |   3.48 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1KB          |   1,260.6 ns |   1.24 ns |   1.16 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1KB          |   1,464.2 ns |   2.52 ns |   2.23 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1025B        |   1,168.9 ns |   0.84 ns |   0.78 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1025B        |   1,339.3 ns |   0.86 ns |   0.81 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1025B        |   1,551.3 ns |   1.52 ns |   1.35 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 8KB          |   8,732.3 ns |   4.78 ns |   4.24 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 8KB          |  10,045.6 ns |   6.70 ns |   6.27 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 8KB          |  11,545.8 ns |  21.33 ns |  19.96 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128KB        | 139,297.8 ns | 105.44 ns |  98.63 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128KB        | 160,418.7 ns |  97.95 ns |  91.62 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128KB        | 184,308.0 ns | 255.01 ns | 238.53 ns |         - |