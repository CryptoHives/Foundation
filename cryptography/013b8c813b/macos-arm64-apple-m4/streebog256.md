| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.837 μs | 0.0018 μs | 0.0016 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.029 μs | 0.0015 μs | 0.0014 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.804 μs | 0.0025 μs | 0.0022 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.842 μs | 0.0037 μs | 0.0035 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.034 μs | 0.0021 μs | 0.0020 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     3.844 μs | 0.0037 μs | 0.0034 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     7.011 μs | 0.0086 μs | 0.0076 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.313 μs | 0.0088 μs | 0.0083 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    14.488 μs | 0.0124 μs | 0.0116 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     7.001 μs | 0.0097 μs | 0.0091 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.328 μs | 0.0037 μs | 0.0033 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    14.544 μs | 0.0411 μs | 0.0364 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    48.267 μs | 0.0693 μs | 0.0648 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    77.810 μs | 0.0333 μs | 0.0312 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    98.537 μs | 0.0687 μs | 0.0643 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   757.850 μs | 0.9441 μs | 0.8369 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,220.320 μs | 1.6103 μs | 1.5063 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,474.664 μs | 1.8559 μs | 1.7360 μs |         - |