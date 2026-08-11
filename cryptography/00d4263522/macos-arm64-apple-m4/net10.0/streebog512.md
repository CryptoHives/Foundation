| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.854 μs | 0.0034 μs | 0.0032 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.985 μs | 0.0087 μs | 0.0081 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.817 μs | 0.0026 μs | 0.0025 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.852 μs | 0.0050 μs | 0.0047 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.985 μs | 0.0097 μs | 0.0090 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.825 μs | 0.0031 μs | 0.0029 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     7.035 μs | 0.0094 μs | 0.0088 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.322 μs | 0.0292 μs | 0.0273 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    13.972 μs | 0.0100 μs | 0.0094 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     7.026 μs | 0.0085 μs | 0.0079 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.295 μs | 0.0195 μs | 0.0183 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    14.168 μs | 0.0291 μs | 0.0272 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    48.528 μs | 0.0592 μs | 0.0554 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    78.131 μs | 0.1733 μs | 0.1621 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |    91.641 μs | 0.0810 μs | 0.0758 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   764.325 μs | 0.7823 μs | 0.6533 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,230.049 μs | 3.7814 μs | 3.5371 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,497.676 μs | 4.8649 μs | 4.5506 μs |         - |