| Description                                        | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.862 μs |  0.0161 μs | 0.0143 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.964 μs |  0.0038 μs | 0.0032 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.832 μs |  0.0024 μs | 0.0023 μs |         - |
|                                                    |              |              |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.843 μs |  0.0042 μs | 0.0037 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.963 μs |  0.0026 μs | 0.0022 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.777 μs |  0.0035 μs | 0.0030 μs |         - |
|                                                    |              |              |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     6.979 μs |  0.0193 μs | 0.0181 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.207 μs |  0.0071 μs | 0.0059 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.217 μs |  0.0076 μs | 0.0068 μs |         - |
|                                                    |              |              |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     6.950 μs |  0.0192 μs | 0.0170 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.218 μs |  0.0083 μs | 0.0070 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    14.693 μs |  0.0123 μs | 0.0109 μs |         - |
|                                                    |              |              |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    47.994 μs |  0.0978 μs | 0.0915 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    77.263 μs |  0.1334 μs | 0.1042 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |    99.586 μs |  0.4273 μs | 0.3997 μs |         - |
|                                                    |              |              |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   760.123 μs | 11.7868 μs | 9.8425 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,217.249 μs |  1.8561 μs | 1.5499 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,479.721 μs |  4.2742 μs | 3.3370 μs |         - |