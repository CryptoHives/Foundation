| Description                                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128B         |     141.6 ns |   0.10 ns |   0.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128B         |     163.0 ns |   0.18 ns |   0.16 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128B         |     197.2 ns |   0.17 ns |   0.15 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 137B         |     211.0 ns |   0.15 ns |   0.14 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 137B         |     240.8 ns |   0.19 ns |   0.18 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 137B         |     286.9 ns |   0.35 ns |   0.33 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1KB          |   1,099.1 ns |   0.93 ns |   0.87 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1KB          |   1,260.3 ns |   1.36 ns |   1.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1KB          |   1,466.1 ns |   7.51 ns |   6.65 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1025B        |   1,167.9 ns |   2.52 ns |   2.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1025B        |   1,337.3 ns |   3.42 ns |   3.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1025B        |   1,555.2 ns |   9.55 ns |   7.98 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 8KB          |   8,752.9 ns |  32.72 ns |  25.55 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 8KB          |  10,038.7 ns |  13.31 ns |  12.45 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 8KB          |  11,606.8 ns |  57.33 ns |  50.82 ns |         - |
|                                                         |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128KB        | 139,323.4 ns | 137.47 ns | 114.80 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128KB        | 160,579.6 ns | 388.04 ns | 324.03 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128KB        | 184,633.6 ns | 747.44 ns | 624.15 ns |         - |