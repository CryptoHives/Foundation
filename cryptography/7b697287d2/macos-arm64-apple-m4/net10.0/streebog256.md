| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.814 μs | 0.0088 μs | 0.0082 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.063 μs | 0.0514 μs | 0.0550 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.748 μs | 0.0136 μs | 0.0127 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.831 μs | 0.0077 μs | 0.0072 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.025 μs | 0.0066 μs | 0.0062 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     3.838 μs | 0.0137 μs | 0.0128 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     6.943 μs | 0.0293 μs | 0.0274 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.319 μs | 0.0314 μs | 0.0293 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    14.931 μs | 0.0692 μs | 0.0647 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     6.953 μs | 0.0329 μs | 0.0308 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.315 μs | 0.0364 μs | 0.0341 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    14.629 μs | 0.0715 μs | 0.0669 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    47.876 μs | 0.2182 μs | 0.2041 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    77.722 μs | 0.2519 μs | 0.2233 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   102.265 μs | 0.4084 μs | 0.3820 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   754.374 μs | 2.6139 μs | 2.3172 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,220.660 μs | 4.4587 μs | 4.1707 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,474.050 μs | 8.0692 μs | 7.5480 μs |         - |