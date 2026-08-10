| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.846 μs | 0.0024 μs | 0.0022 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.967 μs | 0.0020 μs | 0.0018 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.795 μs | 0.0018 μs | 0.0016 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.843 μs | 0.0021 μs | 0.0019 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.974 μs | 0.0014 μs | 0.0011 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.809 μs | 0.0071 μs | 0.0066 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     7.011 μs | 0.0094 μs | 0.0088 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.291 μs | 0.0083 μs | 0.0077 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.633 μs | 0.0104 μs | 0.0098 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     6.998 μs | 0.0095 μs | 0.0088 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.289 μs | 0.0102 μs | 0.0095 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    14.365 μs | 0.0344 μs | 0.0305 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    49.672 μs | 0.0527 μs | 0.0493 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    77.674 μs | 0.0503 μs | 0.0446 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |    97.561 μs | 0.0511 μs | 0.0453 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   758.309 μs | 0.9431 μs | 0.8822 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,222.457 μs | 0.7549 μs | 0.7062 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,483.771 μs | 1.5793 μs | 1.4773 μs |         - |