| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Median       | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|-------------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.497 μs |  0.0064 μs |  0.0057 μs |     2.497 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.469 μs |  0.0053 μs |  0.0044 μs |     3.467 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.481 μs |  0.0114 μs |  0.0101 μs |     4.478 μs |         - |
|                                                    |              |              |            |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.507 μs |  0.0079 μs |  0.0074 μs |     2.505 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.476 μs |  0.0107 μs |  0.0095 μs |     3.476 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.393 μs |  0.0110 μs |  0.0098 μs |     4.390 μs |         - |
|                                                    |              |              |            |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     9.363 μs |  0.0157 μs |  0.0139 μs |     9.367 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    13.320 μs |  0.2660 μs |  0.3551 μs |    13.189 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    16.748 μs |  0.0746 μs |  0.0662 μs |    16.723 μs |         - |
|                                                    |              |              |            |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     9.313 μs |  0.0100 μs |  0.0088 μs |     9.312 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    13.304 μs |  0.2573 μs |  0.2860 μs |    13.238 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    17.014 μs |  0.1797 μs |  0.1681 μs |    17.044 μs |         - |
|                                                    |              |              |            |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    67.945 μs |  1.1843 μs |  3.1407 μs |    66.111 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    89.496 μs |  0.3150 μs |  0.2947 μs |    89.426 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   115.352 μs |  0.2026 μs |  0.1796 μs |   115.353 μs |         - |
|                                                    |              |              |            |            |              |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,031.233 μs |  2.7370 μs |  2.4263 μs | 1,030.920 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,405.726 μs |  5.1120 μs |  4.7818 μs | 1,405.256 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,828.692 μs | 24.8648 μs | 23.2585 μs | 1,817.249 μs |         - |