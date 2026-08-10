| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.466 μs | 0.0056 μs | 0.0050 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.362 μs | 0.0197 μs | 0.0175 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.258 μs | 0.0115 μs | 0.0102 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.420 μs | 0.0055 μs | 0.0048 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.375 μs | 0.0112 μs | 0.0099 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.250 μs | 0.0240 μs | 0.0212 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     9.159 μs | 0.0214 μs | 0.0167 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    12.683 μs | 0.0842 μs | 0.0788 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    16.248 μs | 0.0586 μs | 0.0520 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     8.915 μs | 0.0264 μs | 0.0234 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    12.711 μs | 0.0733 μs | 0.0612 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    16.725 μs | 0.0491 μs | 0.0383 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    62.599 μs | 0.1031 μs | 0.0914 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    87.086 μs | 0.3249 μs | 0.2881 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   112.003 μs | 0.3082 μs | 0.2574 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   989.583 μs | 3.2331 μs | 3.0242 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,371.227 μs | 6.6644 μs | 6.2339 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,752.479 μs | 7.1976 μs | 6.3805 μs |         - |