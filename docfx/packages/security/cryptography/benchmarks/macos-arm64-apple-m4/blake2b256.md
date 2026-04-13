| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      90.54 ns |     0.129 ns |     0.115 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     100.16 ns |     0.286 ns |     0.239 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     126.74 ns |     0.141 ns |     0.132 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128B         |     199.10 ns |     0.024 ns |     0.020 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     579.72 ns |     2.870 ns |     2.685 ns |    1120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     168.18 ns |     0.296 ns |     0.277 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     191.67 ns |     0.612 ns |     0.573 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     232.10 ns |     0.171 ns |     0.160 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 137B         |     396.95 ns |     0.057 ns |     0.054 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |   1,081.79 ns |     7.000 ns |     6.547 ns |    1136 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     647.12 ns |     0.889 ns |     0.831 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |     738.60 ns |     2.757 ns |     2.579 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     870.66 ns |     0.513 ns |     0.455 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1KB          |   1,574.03 ns |     0.538 ns |     0.449 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,733.44 ns |    12.863 ns |    12.032 ns |    2016 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     732.90 ns |     0.242 ns |     0.202 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |     834.94 ns |     2.764 ns |     2.585 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     974.82 ns |     0.973 ns |     0.760 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1025B        |   1,776.75 ns |     3.835 ns |     3.587 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   4,562.50 ns |    77.601 ns |    60.586 ns |    2024 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,153.23 ns |     7.491 ns |     7.007 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |   5,902.34 ns |    18.288 ns |    16.212 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   6,798.92 ns |     5.093 ns |     4.764 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 8KB          |  12,553.19 ns |     1.524 ns |     1.351 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  29,089.84 ns |    80.900 ns |    67.556 ns |    9184 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  82,453.09 ns |    64.655 ns |    60.479 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        |  94,219.24 ns |   248.982 ns |   232.898 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        | 108,461.29 ns |    43.033 ns |    40.253 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128KB        | 200,854.82 ns |    27.419 ns |    24.306 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 470,320.69 ns | 1,518.969 ns | 1,420.844 ns |  132092 B |