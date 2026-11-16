| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.846 μs | 0.0058 μs | 0.0054 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.033 μs | 0.0093 μs | 0.0087 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.791 μs | 0.0062 μs | 0.0058 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.846 μs | 0.0037 μs | 0.0034 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.037 μs | 0.0038 μs | 0.0033 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     3.850 μs | 0.0135 μs | 0.0127 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     7.045 μs | 0.0113 μs | 0.0106 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.382 μs | 0.0159 μs | 0.0148 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    14.777 μs | 0.0356 μs | 0.0315 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     7.055 μs | 0.0266 μs | 0.0249 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.388 μs | 0.0694 μs | 0.0649 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    14.328 μs | 0.0496 μs | 0.0464 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    48.784 μs | 0.1370 μs | 0.1282 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    78.022 μs | 0.3081 μs | 0.2882 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   101.424 μs | 0.2583 μs | 0.2416 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   765.312 μs | 3.1866 μs | 2.9808 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,227.706 μs | 4.1734 μs | 3.9038 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,494.974 μs | 5.9175 μs | 5.5352 μs |         - |