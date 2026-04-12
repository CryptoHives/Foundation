| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128B         |     148.1 ns |     1.80 ns |     1.59 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128B         |     196.6 ns |     1.00 ns |     0.78 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon)       | 128B         |     357.7 ns |     7.19 ns |     5.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128B         |     640.0 ns |     2.87 ns |     2.40 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 137B         |     217.6 ns |     1.28 ns |     1.07 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 137B         |     286.2 ns |     2.49 ns |     2.08 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon)       | 137B         |     529.9 ns |     0.87 ns |     0.68 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 137B         |     961.7 ns |     3.47 ns |     3.24 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1KB          |   1,096.1 ns |     0.70 ns |     0.55 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1KB          |   1,462.9 ns |    17.84 ns |    15.82 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon)       | 1KB          |   2,790.9 ns |    15.10 ns |    12.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1KB          |   5,126.1 ns |    26.15 ns |    21.84 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1025B        |   1,167.6 ns |     6.43 ns |     5.37 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1025B        |   1,542.7 ns |     3.25 ns |     2.54 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon)       | 1025B        |   2,976.0 ns |    11.28 ns |     9.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1025B        |   5,474.6 ns |    20.61 ns |    17.21 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 8KB          |   8,672.9 ns |     4.98 ns |     4.16 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 8KB          |  11,626.8 ns |   191.07 ns |   178.73 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon)       | 8KB          |  22,351.0 ns |   146.99 ns |   130.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 8KB          |  41,197.8 ns |   182.92 ns |   162.15 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128KB        | 138,613.3 ns |   194.97 ns |   162.81 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128KB        | 184,681.9 ns | 1,769.64 ns | 1,477.73 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Neon)       | 128KB        | 357,501.4 ns | 2,267.99 ns | 2,010.52 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128KB        | 662,037.7 ns | 6,215.90 ns | 5,510.24 ns |         - |