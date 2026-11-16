| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     3.585 μs | 0.0024 μs | 0.0020 μs |   7,459 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     6.636 μs | 0.0070 μs | 0.0065 μs |  13,160 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     9.489 μs | 0.0143 μs | 0.0134 μs |  11,970 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     3.647 μs | 0.0024 μs | 0.0022 μs |   7,455 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     6.969 μs | 0.0078 μs | 0.0073 μs |  14,033 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     9.438 μs | 0.0066 μs | 0.0062 μs |  13,763 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    13.964 μs | 0.1019 μs | 0.0953 μs |   7,464 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    25.439 μs | 0.0528 μs | 0.0494 μs |  13,238 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    36.256 μs | 0.0452 μs | 0.0423 μs |  11,991 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    13.887 μs | 0.0832 μs | 0.0778 μs |   7,462 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    25.169 μs | 0.0453 μs | 0.0424 μs |  14,434 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    36.227 μs | 0.0313 μs | 0.0293 μs |  13,785 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    95.199 μs | 0.3319 μs | 0.2591 μs |   7,462 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   199.160 μs | 0.1314 μs | 0.1229 μs |  13,606 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   251.550 μs | 0.4638 μs | 0.3873 μs |  11,993 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,519.823 μs | 0.9305 μs | 0.8704 μs |   7,500 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 2,691.310 μs | 4.8915 μs | 4.5755 μs |  13,609 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 3,900.601 μs | 4.4705 μs | 3.9630 μs |  12,007 B |         - |