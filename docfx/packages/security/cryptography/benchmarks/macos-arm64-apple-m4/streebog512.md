| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.839 μs | 0.0027 μs | 0.0026 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.985 μs | 0.0242 μs | 0.0202 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.749 μs | 0.0044 μs | 0.0034 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.844 μs | 0.0037 μs | 0.0029 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.970 μs | 0.0015 μs | 0.0014 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.781 μs | 0.0037 μs | 0.0033 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     6.985 μs | 0.0099 μs | 0.0093 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.271 μs | 0.0057 μs | 0.0051 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.416 μs | 0.0069 μs | 0.0065 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     6.975 μs | 0.0124 μs | 0.0116 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.280 μs | 0.0065 μs | 0.0060 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    14.491 μs | 0.0371 μs | 0.0347 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    48.079 μs | 0.1239 μs | 0.1159 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    77.780 μs | 0.0528 μs | 0.0494 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |    96.388 μs | 0.1456 μs | 0.1291 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   759.183 μs | 1.5654 μs | 1.3877 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,222.793 μs | 1.5618 μs | 1.4609 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,466.465 μs | 1.1029 μs | 1.0317 μs |         - |