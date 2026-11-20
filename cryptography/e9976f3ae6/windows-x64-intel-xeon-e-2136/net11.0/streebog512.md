| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     3.594 μs | 0.0025 μs | 0.0023 μs |  16,462 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     6.635 μs | 0.0030 μs | 0.0028 μs |  22,249 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     8.985 μs | 0.0138 μs | 0.0129 μs |  26,657 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     3.678 μs | 0.0012 μs | 0.0010 μs |  16,657 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     6.844 μs | 0.0100 μs | 0.0093 μs |  17,011 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     8.972 μs | 0.0133 μs | 0.0118 μs |  22,034 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    13.801 μs | 0.0164 μs | 0.0146 μs |  16,467 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    25.193 μs | 0.0148 μs | 0.0131 μs |  16,075 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    34.691 μs | 0.0515 μs | 0.0457 μs |  20,339 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    13.798 μs | 0.0366 μs | 0.0306 μs |  16,472 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    25.730 μs | 0.0480 μs | 0.0449 μs |  23,620 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    34.533 μs | 0.0518 μs | 0.0484 μs |  28,365 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    94.759 μs | 0.1966 μs | 0.1642 μs |  16,657 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   176.241 μs | 0.3588 μs | 0.3356 μs |  16,492 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   239.837 μs | 0.1053 μs | 0.0985 μs |  26,644 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,522.017 μs | 0.3026 μs | 0.2682 μs |  16,448 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 2,730.518 μs | 1.1721 μs | 1.0390 μs |  22,685 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 3,748.863 μs | 2.8838 μs | 2.5564 μs |  20,311 B |         - |