| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.855 μs |  0.0010 μs |  0.0009 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.208 μs |  0.0631 μs |  0.1216 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.755 μs |  0.0015 μs |  0.0013 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.961 μs |  0.0258 μs |  0.0229 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.514 μs |  0.0563 μs |  0.0499 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.218 μs |  0.0106 μs |  0.0088 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     8.004 μs |  0.1550 μs |  0.3023 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    53.023 μs |  0.0383 μs |  0.0320 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    65.681 μs |  0.1660 μs |  0.1471 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.300 μs |  0.0542 μs |  0.0424 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    14.239 μs |  0.2831 μs |  0.6273 μs |         - |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    33.691 μs |  0.0255 μs |  0.0213 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    48.646 μs |  0.0274 μs |  0.0229 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    77.470 μs |  0.0952 μs |  0.0891 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    90.437 μs |  0.0413 μs |  0.0366 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   768.884 μs |  1.4165 μs |  1.1828 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,329.913 μs | 26.0457 μs | 40.5500 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,393.577 μs |  1.3525 μs |  1.2651 μs |         - |