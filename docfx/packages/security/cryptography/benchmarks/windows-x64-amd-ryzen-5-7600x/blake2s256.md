| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128B         |     156.3 ns |     0.94 ns |     0.88 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128B         |     157.7 ns |     0.79 ns |     0.73 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128B         |     161.2 ns |     0.89 ns |     0.75 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128B         |     161.6 ns |     0.70 ns |     0.65 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 137B         |     228.5 ns |     1.02 ns |     0.90 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 137B         |     236.9 ns |     1.57 ns |     1.46 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 137B         |     237.8 ns |     3.38 ns |     3.16 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 137B         |     238.0 ns |     2.10 ns |     1.97 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1KB          |   1,143.1 ns |     6.43 ns |     6.01 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1KB          |   1,206.6 ns |     6.59 ns |     5.84 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1KB          |   1,213.6 ns |     3.24 ns |     3.03 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1KB          |   1,232.5 ns |     5.46 ns |     4.84 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1025B        |   1,213.7 ns |     3.84 ns |     3.00 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1025B        |   1,283.8 ns |     6.71 ns |     5.95 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1025B        |   1,292.2 ns |     2.20 ns |     1.95 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1025B        |   1,307.4 ns |     5.81 ns |     5.44 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 8KB          |   8,999.5 ns |    35.92 ns |    29.99 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 8KB          |   9,587.7 ns |    55.81 ns |    52.20 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 8KB          |   9,684.3 ns |    31.43 ns |    29.40 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 8KB          |   9,737.0 ns |    53.84 ns |    50.36 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128KB        | 144,121.6 ns |   796.95 ns |   706.48 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128KB        | 152,999.3 ns | 1,327.48 ns | 1,241.72 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128KB        | 154,138.9 ns |   605.76 ns |   536.99 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128KB        | 155,087.4 ns |   777.72 ns |   727.48 ns |         - |