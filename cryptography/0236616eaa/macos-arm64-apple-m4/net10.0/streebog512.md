| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.830 μs |  0.0009 μs |  0.0009 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.955 μs |  0.0028 μs |  0.0027 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.843 μs |  0.0015 μs |  0.0013 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.832 μs |  0.0002 μs |  0.0002 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.069 μs |  0.0248 μs |  0.0194 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.766 μs |  0.0019 μs |  0.0017 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     6.958 μs |  0.0008 μs |  0.0008 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    12.967 μs |  0.2422 μs |  0.4178 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.846 μs |  0.2575 μs |  0.2150 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     7.696 μs |  0.0533 μs |  0.0499 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    13.552 μs |  0.2148 μs |  0.2009 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    16.636 μs |  0.3297 μs |  0.6111 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    54.166 μs |  0.9625 μs |  1.3492 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    93.655 μs |  1.8123 μs |  2.7126 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   112.400 μs |  2.2263 μs |  2.7340 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 3,619.327 μs |  9.8708 μs |  9.2332 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 5,740.045 μs | 10.4631 μs |  9.7872 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 6,933.545 μs | 13.1476 μs | 12.2983 μs |         - |