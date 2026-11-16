| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.710 μs |  0.0054 μs |  0.0045 μs |   7,211 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.991 μs |  0.0155 μs |  0.0138 μs |  13,552 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.909 μs |  0.0153 μs |  0.0135 μs |  16,925 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.714 μs |  0.0024 μs |  0.0021 μs |   7,207 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.997 μs |  0.0140 μs |  0.0109 μs |  14,274 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.921 μs |  0.0117 μs |  0.0103 μs |  16,310 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    10.399 μs |  0.0163 μs |  0.0136 μs |   7,216 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    14.937 μs |  0.1444 μs |  0.1280 μs |  13,934 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    18.906 μs |  0.0626 μs |  0.0488 μs |  16,934 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    10.340 μs |  0.0373 μs |  0.0349 μs |   7,214 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    14.981 μs |  0.0695 μs |  0.0650 μs |  14,664 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    19.075 μs |  0.0945 μs |  0.0789 μs |  16,369 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    71.262 μs |  0.1342 μs |  0.1121 μs |   7,214 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   102.472 μs |  0.6764 μs |  0.6327 μs |  14,461 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   132.836 μs |  1.2680 μs |  1.1861 μs |  16,945 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,123.821 μs | 12.7820 μs | 11.3309 μs |   7,252 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,602.014 μs | 10.5635 μs |  9.8811 μs |  14,406 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 2,078.561 μs | 14.6799 μs | 13.7316 μs |  16,992 B |         - |