| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.810 μs | 0.0058 μs | 0.0054 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.024 μs | 0.0131 μs | 0.0175 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.730 μs | 0.0057 μs | 0.0053 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.827 μs | 0.0049 μs | 0.0044 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.032 μs | 0.0080 μs | 0.0067 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     3.926 μs | 0.0069 μs | 0.0062 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     7.153 μs | 0.1416 μs | 0.1391 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.312 μs | 0.0196 μs | 0.0174 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    14.626 μs | 0.0150 μs | 0.0140 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     6.976 μs | 0.0234 μs | 0.0196 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.304 μs | 0.0727 μs | 0.0607 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    14.221 μs | 0.0326 μs | 0.0255 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    49.363 μs | 0.0455 μs | 0.0355 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    78.745 μs | 0.0610 μs | 0.0541 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    99.160 μs | 0.2279 μs | 0.2132 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   776.413 μs | 1.1489 μs | 0.9594 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,218.974 μs | 4.4100 μs | 3.6826 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,513.091 μs | 1.4135 μs | 1.3222 μs |         - |