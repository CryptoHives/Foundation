| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.390 μs | 0.0035 μs | 0.0029 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.376 μs | 0.0190 μs | 0.0158 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.256 μs | 0.0256 μs | 0.0227 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.421 μs | 0.0103 μs | 0.0091 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.375 μs | 0.0242 μs | 0.0214 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.289 μs | 0.0171 μs | 0.0143 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     9.164 μs | 0.0256 μs | 0.0227 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    12.747 μs | 0.0955 μs | 0.0798 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    16.172 μs | 0.0685 μs | 0.0572 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     9.142 μs | 0.0206 μs | 0.0182 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    12.743 μs | 0.0854 μs | 0.0799 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    16.312 μs | 0.1198 μs | 0.1121 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    62.810 μs | 0.1245 μs | 0.1040 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    87.574 μs | 0.6647 μs | 0.6217 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   111.897 μs | 0.4154 μs | 0.3682 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   988.685 μs | 4.5749 μs | 3.5718 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,374.754 μs | 7.6146 μs | 7.1227 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,759.552 μs | 8.0487 μs | 7.5287 μs |         - |