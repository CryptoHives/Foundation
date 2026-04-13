| Description                                             | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      90.90 ns |     0.207 ns |   0.184 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     101.73 ns |     0.541 ns |   0.452 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     126.74 ns |     0.372 ns |   0.291 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128B         |     179.82 ns |     0.212 ns |   0.165 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     591.61 ns |     3.247 ns |   3.037 ns |    1120 B |
|                                                         |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     168.83 ns |     0.273 ns |   0.255 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     194.41 ns |     0.373 ns |   0.349 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     232.50 ns |     0.315 ns |   0.279 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 137B         |     367.16 ns |     5.079 ns |   4.751 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |   1,096.63 ns |     5.112 ns |   4.781 ns |    1136 B |
|                                                         |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     652.19 ns |     0.451 ns |   0.422 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |     748.17 ns |     3.101 ns |   2.901 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     870.96 ns |     0.438 ns |   0.365 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1KB          |   1,495.02 ns |    28.773 ns |  28.259 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,806.08 ns |    14.258 ns |  11.906 ns |    2016 B |
|                                                         |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     733.72 ns |     0.350 ns |   0.327 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |     840.34 ns |     1.190 ns |   1.055 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     978.66 ns |     4.261 ns |   3.327 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 1025B        |   1,646.28 ns |     0.190 ns |   0.168 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   4,326.51 ns |    25.883 ns |  22.945 ns |    2024 B |
|                                                         |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,157.42 ns |     2.080 ns |   1.946 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |   5,906.62 ns |    10.009 ns |   8.873 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   6,801.51 ns |     3.021 ns |   2.678 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 8KB          |  11,730.70 ns |     1.449 ns |   1.210 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  29,176.01 ns |    82.221 ns |  76.910 ns |    9184 B |
|                                                         |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  82,468.86 ns |    43.385 ns |  40.582 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        |  94,453.34 ns |   186.377 ns | 174.337 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        | 108,483.67 ns |    35.816 ns |  31.750 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)       | 128KB        | 187,789.85 ns |    19.117 ns |  15.963 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 472,230.04 ns | 1,100.842 ns | 975.867 ns |  132092 B |