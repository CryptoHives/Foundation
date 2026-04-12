| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128B         |     150.6 ns |     2.61 ns |     2.44 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128B         |     198.7 ns |     1.61 ns |     1.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon)       | 128B         |     356.2 ns |     2.90 ns |     2.43 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128B         |     656.7 ns |     5.51 ns |     4.88 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 137B         |     219.0 ns |     3.01 ns |     2.81 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 137B         |     293.7 ns |     5.30 ns |     4.96 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon)       | 137B         |     537.7 ns |     4.36 ns |     3.64 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 137B         |     984.0 ns |    14.47 ns |    13.53 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1KB          |   1,102.1 ns |    12.04 ns |    10.06 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1KB          |   1,460.1 ns |     8.25 ns |     6.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon)       | 1KB          |   2,832.8 ns |    27.87 ns |    23.27 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1KB          |   5,210.9 ns |    19.78 ns |    15.44 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1025B        |   1,170.4 ns |    12.37 ns |    10.97 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1025B        |   1,551.0 ns |    17.03 ns |    15.10 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon)       | 1025B        |   2,975.8 ns |    12.84 ns |    11.38 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1025B        |   5,507.0 ns |    13.90 ns |    10.85 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 8KB          |   8,724.2 ns |    79.14 ns |    70.16 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 8KB          |  11,581.6 ns |   128.31 ns |   120.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon)       | 8KB          |  22,450.9 ns |   106.74 ns |    99.84 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 8KB          |  41,586.7 ns |   363.94 ns |   322.62 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128KB        | 139,020.1 ns | 1,211.47 ns | 1,011.63 ns |     136 B |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128KB        | 183,546.6 ns |   870.67 ns |   727.05 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon)       | 128KB        | 359,547.7 ns | 3,576.85 ns | 3,170.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128KB        | 662,539.2 ns | 1,192.36 ns |   995.68 ns |         - |