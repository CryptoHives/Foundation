| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.824 μs | 0.0065 μs | 0.0061 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.968 μs | 0.0097 μs | 0.0091 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.811 μs | 0.0132 μs | 0.0123 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.831 μs | 0.0077 μs | 0.0072 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.967 μs | 0.0088 μs | 0.0082 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.773 μs | 0.0105 μs | 0.0098 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     6.938 μs | 0.0194 μs | 0.0181 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.239 μs | 0.0257 μs | 0.0228 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.552 μs | 0.0469 μs | 0.0439 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     6.950 μs | 0.0254 μs | 0.0238 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.264 μs | 0.0384 μs | 0.0359 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    14.577 μs | 0.0399 μs | 0.0354 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    47.731 μs | 0.1269 μs | 0.1187 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    77.046 μs | 0.1767 μs | 0.1652 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |    98.199 μs | 0.1504 μs | 0.1407 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   752.731 μs | 2.7541 μs | 2.5761 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,214.051 μs | 2.9377 μs | 2.7479 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,475.232 μs | 1.9807 μs | 1.8528 μs |         - |