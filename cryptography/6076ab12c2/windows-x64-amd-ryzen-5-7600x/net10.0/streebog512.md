| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.890 μs | 0.0032 μs | 0.0026 μs |   7,248 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.911 μs | 0.0063 μs | 0.0056 μs |  13,092 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.882 μs | 0.0036 μs | 0.0032 μs |  11,876 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.667 μs | 0.0019 μs | 0.0018 μs |   7,244 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.901 μs | 0.0082 μs | 0.0077 μs |  13,937 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.982 μs | 0.0182 μs | 0.0142 μs |  13,652 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    10.107 μs | 0.0127 μs | 0.0119 μs |   7,253 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    14.701 μs | 0.0141 μs | 0.0118 μs |  13,181 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    18.922 μs | 0.0527 μs | 0.0493 μs |  11,885 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    10.254 μs | 0.0096 μs | 0.0085 μs |   7,251 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    14.737 μs | 0.0495 μs | 0.0463 μs |  14,348 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    18.888 μs | 0.0388 μs | 0.0363 μs |  13,682 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    69.664 μs | 0.0793 μs | 0.0703 μs |   7,251 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   100.997 μs | 0.1230 μs | 0.1151 μs |  13,551 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   131.005 μs | 0.3695 μs | 0.3456 μs |  11,885 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,107.761 μs | 1.8804 μs | 1.7590 μs |   7,289 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,583.658 μs | 2.3747 μs | 2.1051 μs |  13,554 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 2,051.088 μs | 4.8424 μs | 4.5296 μs |  11,900 B |         - |