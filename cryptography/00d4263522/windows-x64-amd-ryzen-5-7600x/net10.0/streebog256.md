| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.513 μs | 0.0035 μs | 0.0033 μs |   7,702 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.608 μs | 0.0146 μs | 0.0137 μs |  13,088 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.509 μs | 0.0115 μs | 0.0102 μs |  20,275 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.567 μs | 0.0027 μs | 0.0021 μs |   7,699 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.628 μs | 0.0150 μs | 0.0133 μs |  13,741 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.455 μs | 0.0104 μs | 0.0087 μs |  20,022 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     9.728 μs | 0.0179 μs | 0.0158 μs |   7,699 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    13.353 μs | 0.0679 μs | 0.0635 μs |  13,426 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    17.072 μs | 0.0766 μs | 0.0679 μs |  20,302 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     9.975 μs | 0.0113 μs | 0.0100 μs |   7,701 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    13.362 μs | 0.0717 μs | 0.0671 μs |  14,114 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    17.150 μs | 0.0560 μs | 0.0496 μs |  20,079 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    64.458 μs | 0.0823 μs | 0.0769 μs |   7,697 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    91.010 μs | 0.1190 μs | 0.0994 μs |  13,827 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   117.863 μs | 0.1356 μs | 0.1133 μs |  20,264 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,031.116 μs | 1.8672 μs | 1.6553 μs |   7,727 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,426.490 μs | 2.3965 μs | 2.0012 μs |  13,851 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,828.551 μs | 8.4161 μs | 7.4607 μs |  20,266 B |         - |