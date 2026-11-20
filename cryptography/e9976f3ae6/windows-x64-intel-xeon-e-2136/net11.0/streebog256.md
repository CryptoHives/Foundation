| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     3.559 μs | 0.0019 μs | 0.0018 μs |  10,127 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     6.935 μs | 0.0038 μs | 0.0036 μs |  24,498 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     8.906 μs | 0.0155 μs | 0.0137 μs |  20,411 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     3.606 μs | 0.0015 μs | 0.0014 μs |  10,132 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     6.834 μs | 0.0041 μs | 0.0039 μs |  18,398 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     8.994 μs | 0.0177 μs | 0.0166 μs |  28,781 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    13.573 μs | 0.0780 μs | 0.0730 μs |  16,467 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    25.422 μs | 0.0166 μs | 0.0147 μs |  24,461 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    34.655 μs | 0.0498 μs | 0.0442 μs |  26,968 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    13.519 μs | 0.0450 μs | 0.0376 μs |  16,472 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    25.443 μs | 0.0117 μs | 0.0103 μs |  19,486 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    34.681 μs | 0.0351 μs | 0.0293 μs |  28,621 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    96.014 μs | 0.5107 μs | 0.4264 μs |  16,657 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   176.787 μs | 0.2098 μs | 0.1860 μs |  18,513 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   241.227 μs | 0.2351 μs | 0.2199 μs |  20,408 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,535.088 μs | 0.7759 μs | 0.6479 μs |  10,162 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 2,733.378 μs | 2.1822 μs | 2.0412 μs |  17,925 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 3,782.088 μs | 5.7848 μs | 5.4112 μs |  26,772 B |         - |