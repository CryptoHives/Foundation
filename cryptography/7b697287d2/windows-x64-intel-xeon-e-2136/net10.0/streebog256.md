| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     3.591 μs |  0.0026 μs |  0.0021 μs |   7,459 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     6.842 μs |  0.0065 μs |  0.0058 μs |  13,622 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     9.467 μs |  0.0084 μs |  0.0075 μs |  17,115 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     3.569 μs |  0.0020 μs |  0.0019 μs |   7,455 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     6.838 μs |  0.0035 μs |  0.0031 μs |  14,002 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     9.317 μs |  0.0126 μs |  0.0105 μs |  16,485 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    13.376 μs |  0.0327 μs |  0.0306 μs |   7,464 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    25.277 μs |  0.0157 μs |  0.0131 μs |  14,010 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    37.247 μs |  0.0289 μs |  0.0271 μs |  17,128 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    13.519 μs |  0.0259 μs |  0.0216 μs |   7,462 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    25.273 μs |  0.0474 μs |  0.0443 μs |  14,736 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    36.378 μs |  0.0607 μs |  0.0568 μs |  16,519 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    93.872 μs |  0.5813 μs |  0.5153 μs |   7,462 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   171.808 μs |  0.1536 μs |  0.1362 μs |  14,557 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   251.881 μs |  0.2152 μs |  0.2013 μs |  17,131 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,522.416 μs |  0.8587 μs |  0.8032 μs |   7,500 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 2,680.763 μs |  5.8807 μs |  5.2131 μs |  14,487 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 4,734.009 μs | 24.7580 μs | 23.1587 μs |  17,146 B |         - |