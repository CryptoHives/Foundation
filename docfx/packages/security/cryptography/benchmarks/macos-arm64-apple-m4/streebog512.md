| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.864 μs | 0.0009 μs | 0.0008 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.987 μs | 0.0051 μs | 0.0048 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.910 μs | 0.0097 μs | 0.0091 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.864 μs | 0.0009 μs | 0.0008 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.980 μs | 0.0047 μs | 0.0044 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.789 μs | 0.0031 μs | 0.0029 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     7.073 μs | 0.0164 μs | 0.0153 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.343 μs | 0.0328 μs | 0.0307 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.083 μs | 0.0091 μs | 0.0085 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     7.070 μs | 0.0169 μs | 0.0158 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.380 μs | 0.0045 μs | 0.0042 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    14.462 μs | 0.0251 μs | 0.0235 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    49.024 μs | 0.1754 μs | 0.1640 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    78.193 μs | 0.0571 μs | 0.0534 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   102.278 μs | 0.1474 μs | 0.1379 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   770.405 μs | 1.2152 μs | 1.1367 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,228.906 μs | 3.3270 μs | 3.1121 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,409.735 μs | 4.5614 μs | 4.2668 μs |         - |