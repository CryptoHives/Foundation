| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.843 μs | 0.0062 μs | 0.0058 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.041 μs | 0.0053 μs | 0.0049 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.792 μs | 0.0077 μs | 0.0072 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.850 μs | 0.0024 μs | 0.0022 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.047 μs | 0.0080 μs | 0.0074 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     3.874 μs | 0.0051 μs | 0.0048 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     7.024 μs | 0.0185 μs | 0.0173 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.373 μs | 0.0181 μs | 0.0170 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    14.029 μs | 0.0150 μs | 0.0133 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     7.034 μs | 0.0108 μs | 0.0101 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.428 μs | 0.0326 μs | 0.0305 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    14.000 μs | 0.0345 μs | 0.0323 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    48.158 μs | 0.0570 μs | 0.0534 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    77.728 μs | 0.0472 μs | 0.0441 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    90.754 μs | 0.0485 μs | 0.0454 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   762.209 μs | 1.6391 μs | 1.5332 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,227.080 μs | 3.8456 μs | 3.4090 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,393.279 μs | 1.1562 μs | 1.0249 μs |         - |