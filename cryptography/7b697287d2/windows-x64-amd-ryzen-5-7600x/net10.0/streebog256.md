| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.651 μs | 0.0027 μs | 0.0023 μs |   7,211 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.976 μs | 0.0095 μs | 0.0089 μs |  13,552 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.909 μs | 0.0115 μs | 0.0108 μs |  16,941 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.704 μs | 0.0032 μs | 0.0030 μs |   7,207 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.981 μs | 0.0121 μs | 0.0107 μs |  14,274 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.928 μs | 0.0084 μs | 0.0075 μs |  16,310 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    10.040 μs | 0.0092 μs | 0.0086 μs |   7,216 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    14.789 μs | 0.0309 μs | 0.0289 μs |  13,941 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    18.889 μs | 0.0424 μs | 0.0396 μs |  16,950 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    10.340 μs | 0.0128 μs | 0.0120 μs |   7,214 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    14.745 μs | 0.0208 μs | 0.0195 μs |  14,664 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    18.887 μs | 0.0499 μs | 0.0467 μs |  16,369 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    69.302 μs | 0.0476 μs | 0.0445 μs |   7,214 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   100.888 μs | 0.1800 μs | 0.1596 μs |  14,461 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   130.555 μs | 0.2700 μs | 0.2394 μs |  16,948 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,108.301 μs | 1.4695 μs | 1.3745 μs |   7,252 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,863.532 μs | 2.5653 μs | 2.3996 μs |  14,406 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 2,035.709 μs | 8.1315 μs | 7.6062 μs |  16,954 B |         - |