| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |     103.0 ns |     1.16 ns |     0.97 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     126.8 ns |     0.28 ns |     0.23 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128B         |     199.6 ns |     0.86 ns |     0.76 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     392.1 ns |     5.81 ns |     4.85 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     593.0 ns |     3.02 ns |     2.67 ns |    1120 B |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     181.9 ns |     0.40 ns |     0.31 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     235.7 ns |     4.70 ns |     4.83 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 137B         |     397.6 ns |     0.38 ns |     0.29 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     782.1 ns |     5.77 ns |     4.50 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |   1,109.6 ns |     5.79 ns |     4.84 ns |    1136 B |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     667.5 ns |     6.27 ns |     5.56 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     876.0 ns |     8.01 ns |     7.10 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1KB          |   1,588.9 ns |    19.28 ns |    16.10 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |   3,163.7 ns |    41.05 ns |    38.40 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,836.7 ns |    25.79 ns |    22.87 ns |    2016 B |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     746.1 ns |     0.53 ns |     0.41 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     981.0 ns |     7.13 ns |     5.57 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1025B        |   1,776.3 ns |     4.71 ns |     3.67 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |   3,522.7 ns |     9.16 ns |     7.15 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   4,367.5 ns |    22.16 ns |    17.30 ns |    2024 B |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,180.7 ns |     1.47 ns |     1.23 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   6,824.1 ns |    22.94 ns |    17.91 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 8KB          |  12,594.0 ns |    40.08 ns |    35.53 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |  24,981.7 ns |    71.58 ns |    59.77 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  29,598.6 ns |    93.78 ns |    83.14 ns |    9184 B |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  82,728.5 ns |   143.32 ns |   111.89 ns |     248 B |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        | 108,753.0 ns |   392.36 ns |   306.33 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128KB        | 201,168.1 ns |   245.54 ns |   217.67 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        | 399,233.6 ns | 1,129.07 ns |   942.83 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 481,868.6 ns | 2,136.43 ns | 1,784.01 ns |  132092 B |