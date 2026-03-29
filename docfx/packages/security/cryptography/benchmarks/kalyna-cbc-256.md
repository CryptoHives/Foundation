| Description                             | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     3.441 μs |  0.0242 μs |  0.0226 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128B         |     7.685 μs |  0.1218 μs |  0.1140 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     1.920 μs |  0.0202 μs |  0.0198 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128B         |     5.574 μs |  0.1082 μs |  0.1329 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |    21.364 μs |  0.2080 μs |  0.1946 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 1KB          |    55.111 μs |  0.7494 μs |  0.6643 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |    10.527 μs |  0.2020 μs |  0.2161 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 1KB          |    39.531 μs |  0.7392 μs |  0.6914 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |   164.495 μs |  2.2862 μs |  2.1385 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 8KB          |   434.009 μs |  4.4246 μs |  4.1388 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |    77.893 μs |  1.0695 μs |  0.9481 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 8KB          |   312.485 μs |  4.2075 μs |  3.9357 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 2,757.859 μs | 54.7015 μs | 91.3939 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128KB        | 6,880.976 μs | 69.0414 μs | 53.9030 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 1,233.525 μs | 12.7220 μs | 11.2778 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128KB        | 4,933.731 μs | 86.4517 μs | 76.6371 μs |         - |