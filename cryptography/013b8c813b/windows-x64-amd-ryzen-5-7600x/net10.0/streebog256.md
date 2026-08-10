| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.502 μs | 0.0061 μs | 0.0051 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.542 μs | 0.0096 μs | 0.0081 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.390 μs | 0.0182 μs | 0.0152 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.491 μs | 0.0025 μs | 0.0022 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.543 μs | 0.0059 μs | 0.0050 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.400 μs | 0.0120 μs | 0.0113 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     9.409 μs | 0.0217 μs | 0.0170 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    13.122 μs | 0.0704 μs | 0.0658 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    16.714 μs | 0.0604 μs | 0.0565 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     9.529 μs | 0.0245 μs | 0.0205 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    13.038 μs | 0.0312 μs | 0.0243 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    16.693 μs | 0.0607 μs | 0.0538 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    64.699 μs | 0.2760 μs | 0.2582 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    89.830 μs | 0.3487 μs | 0.2912 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   116.900 μs | 0.1225 μs | 0.1086 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,014.976 μs | 1.8029 μs | 1.4076 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,409.612 μs | 4.6834 μs | 4.1517 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,810.280 μs | 7.3854 μs | 6.5470 μs |         - |