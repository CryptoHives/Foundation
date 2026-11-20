| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     1.254 μs | 0.0125 μs | 0.0117 μs |  12,013 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     1.755 μs | 0.0078 μs | 0.0069 μs |   3,822 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     1.275 μs | 0.0228 μs | 0.0213 μs |  12,001 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     1.758 μs | 0.0104 μs | 0.0098 μs |   3,822 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |     6.876 μs | 0.0053 μs | 0.0045 μs |  11,823 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |     9.285 μs | 0.0965 μs | 0.0856 μs |   3,824 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |     6.958 μs | 0.0183 μs | 0.0153 μs |  11,814 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |     9.704 μs | 0.0138 μs | 0.0108 μs |   3,814 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |    51.965 μs | 0.0442 μs | 0.0369 μs |  11,823 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |    69.231 μs | 0.1027 μs | 0.0858 μs |   4,182 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        |   829.197 μs | 3.5545 μs | 3.3249 μs |   5,498 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 1,097.413 μs | 0.9051 μs | 0.8023 μs |   4,038 B |         - |