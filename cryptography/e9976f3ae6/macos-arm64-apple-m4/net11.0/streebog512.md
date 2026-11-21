| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.914 μs | 0.0077 μs | 0.0072 μs |         - |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     2.958 μs | 0.0040 μs | 0.0035 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.965 μs | 0.0041 μs | 0.0038 μs |     176 B |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.946 μs | 0.0083 μs | 0.0078 μs |         - |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     2.976 μs | 0.0111 μs | 0.0104 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.996 μs | 0.0096 μs | 0.0090 μs |     176 B |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     7.318 μs | 0.0196 μs | 0.0183 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.268 μs | 0.0227 μs | 0.0201 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    11.370 μs | 0.0357 μs | 0.0334 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     7.298 μs | 0.0110 μs | 0.0098 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.287 μs | 0.0298 μs | 0.0279 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    11.470 μs | 0.0187 μs | 0.0166 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    50.474 μs | 0.2196 μs | 0.2054 μs |         - |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |    79.061 μs | 0.2118 μs | 0.1981 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    80.291 μs | 0.2118 μs | 0.1981 μs |     176 B |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   793.301 μs | 3.4964 μs | 3.2705 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,214.027 μs | 1.7665 μs | 1.5659 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,229.029 μs | 3.2041 μs | 2.9971 μs |         - |