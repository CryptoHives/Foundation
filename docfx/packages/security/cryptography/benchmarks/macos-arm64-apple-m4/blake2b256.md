| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      90.96 ns |     0.143 ns |     0.127 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     100.12 ns |     0.206 ns |     0.183 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     126.66 ns |     0.199 ns |     0.166 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128B         |     179.52 ns |     0.150 ns |     0.133 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     588.01 ns |     2.687 ns |     2.382 ns |    1120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     169.56 ns |     0.185 ns |     0.164 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     189.56 ns |     0.536 ns |     0.447 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     232.34 ns |     0.183 ns |     0.162 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 137B         |     363.24 ns |     0.357 ns |     0.316 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |   1,093.35 ns |     4.095 ns |     3.831 ns |    1136 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     658.28 ns |     9.849 ns |     8.731 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |     734.46 ns |     2.547 ns |     2.258 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     871.98 ns |     0.738 ns |     0.616 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1KB          |   1,463.59 ns |     0.947 ns |     0.840 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,808.96 ns |    25.041 ns |    22.198 ns |    2016 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     735.37 ns |     2.306 ns |     2.044 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |     833.66 ns |     1.851 ns |     1.545 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     976.85 ns |     0.923 ns |     0.770 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1025B        |   1,649.24 ns |     2.762 ns |     2.156 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   4,319.33 ns |    37.199 ns |    31.063 ns |    2024 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,156.92 ns |     3.900 ns |     3.458 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |   5,904.21 ns |    33.923 ns |    30.072 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   6,816.14 ns |    18.407 ns |    14.371 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 8KB          |  11,755.03 ns |    42.104 ns |    32.872 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  29,391.40 ns |    81.526 ns |    76.259 ns |    9184 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  82,852.38 ns | 1,010.721 ns |   843.998 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        |  93,993.86 ns |   192.576 ns |   170.713 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        | 108,499.08 ns |    63.177 ns |    52.756 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128KB        | 187,858.44 ns |   111.401 ns |    93.025 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 474,934.19 ns | 1,809.229 ns | 1,412.527 ns |  132092 B |