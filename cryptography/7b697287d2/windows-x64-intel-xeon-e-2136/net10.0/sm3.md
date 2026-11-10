| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     1.248 μs | 0.0092 μs | 0.0082 μs |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     1.652 μs | 0.0101 μs | 0.0095 μs |   3,590 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     1.253 μs | 0.0042 μs | 0.0037 μs |   2,982 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     1.672 μs | 0.0045 μs | 0.0040 μs |   3,607 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |     6.934 μs | 0.0167 μs | 0.0148 μs |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |     9.175 μs | 0.0435 μs | 0.0363 μs |   3,599 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |     6.928 μs | 0.0135 μs | 0.0105 μs |   2,985 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |     8.966 μs | 0.0585 μs | 0.0548 μs |   3,605 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |    51.947 μs | 0.0877 μs | 0.0685 μs |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |    67.166 μs | 0.1337 μs | 0.1251 μs |   3,450 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        |   824.795 μs | 2.8654 μs | 2.6803 μs |   3,005 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 1,086.402 μs | 1.2039 μs | 1.0053 μs |   3,580 B |         - |