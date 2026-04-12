| Description                                             | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |     103.3 ns |     0.19 ns |   0.16 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     129.1 ns |     0.15 ns |   0.14 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128B         |     201.0 ns |     0.92 ns |   0.86 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     398.8 ns |     0.79 ns |   0.74 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     621.9 ns |     1.66 ns |   1.55 ns |    1216 B |
|                                                         |              |              |             |           |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     181.9 ns |     0.83 ns |   0.65 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     237.6 ns |     4.12 ns |   3.86 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 137B         |     401.2 ns |     3.62 ns |   3.39 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     792.3 ns |     6.65 ns |   5.90 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |   1,143.1 ns |     8.99 ns |   7.51 ns |    1232 B |
|                                                         |              |              |             |           |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     664.9 ns |     0.35 ns |   0.28 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     876.5 ns |     3.29 ns |   2.74 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1KB          |   1,581.1 ns |     3.42 ns |   2.67 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |   3,139.1 ns |     5.74 ns |   5.09 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,887.7 ns |    36.47 ns |  34.11 ns |    2112 B |
|                                                         |              |              |             |           |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     747.4 ns |     0.35 ns |   0.29 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     979.1 ns |     1.39 ns |   1.16 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1025B        |   1,780.9 ns |     5.52 ns |   4.89 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |   3,535.2 ns |     6.27 ns |   5.24 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   4,397.5 ns |    25.85 ns |  21.58 ns |    2120 B |
|                                                         |              |              |             |           |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,190.8 ns |     5.38 ns |   4.20 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   6,814.9 ns |     2.41 ns |   2.01 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 8KB          |  12,689.2 ns |    45.73 ns |  40.54 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |  25,154.3 ns |   150.92 ns | 133.79 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  29,905.9 ns |   187.56 ns | 166.27 ns |    9280 B |
|                                                         |              |              |             |           |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  82,685.1 ns |    98.54 ns |  76.94 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        | 108,638.9 ns |    45.51 ns |  38.00 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128KB        | 202,336.3 ns | 1,066.66 ns | 997.76 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        | 401,503.6 ns |   700.29 ns | 584.77 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 483,081.5 ns |   868.35 ns | 769.77 ns |  132188 B |