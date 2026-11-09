| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.734 μs |  0.0357 μs |  0.0334 μs |   7,459 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     4.994 μs |  0.0568 μs |  0.0531 μs |  13,160 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     7.259 μs |  0.1059 μs |  0.0991 μs |  11,984 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.752 μs |  0.0475 μs |  0.0444 μs |   7,455 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     5.001 μs |  0.0553 μs |  0.0518 μs |  14,033 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     7.190 μs |  0.1146 μs |  0.1072 μs |  13,781 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    10.277 μs |  0.1836 μs |  0.1717 μs |   7,464 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    19.254 μs |  0.3406 μs |  0.3186 μs |  13,238 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    27.750 μs |  0.1764 μs |  0.1650 μs |  11,993 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    10.657 μs |  0.1038 μs |  0.0971 μs |   7,462 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    19.163 μs |  0.3187 μs |  0.2981 μs |  14,434 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    28.070 μs |  0.2771 μs |  0.2592 μs |  13,811 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    70.908 μs |  1.2459 μs |  1.1654 μs |   7,462 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   129.274 μs |  2.2212 μs |  2.0777 μs |  13,606 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   189.897 μs |  3.0884 μs |  2.8888 μs |  11,994 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,175.175 μs | 23.1773 μs | 21.6801 μs |   7,500 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 2,034.600 μs | 34.3415 μs | 32.1231 μs |  13,609 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 2,927.989 μs | 42.0024 μs | 39.2891 μs |  12,008 B |         - |