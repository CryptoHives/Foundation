| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SM3 · CryptoHives-Scalar | 128B         |     1.257 μs | 0.0122 μs | 0.0114 μs |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128B         |     1.689 μs | 0.0170 μs | 0.0159 μs |   3,608 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 137B         |     1.254 μs | 0.0090 μs | 0.0080 μs |   2,982 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 137B         |     1.683 μs | 0.0128 μs | 0.0113 μs |   3,597 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1KB          |     6.975 μs | 0.0503 μs | 0.0470 μs |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1KB          |     9.169 μs | 0.1060 μs | 0.0992 μs |   3,588 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 1025B        |     6.963 μs | 0.0456 μs | 0.0427 μs |   2,985 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 1025B        |     9.210 μs | 0.0806 μs | 0.0673 μs |   3,601 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 8KB          |    52.271 μs | 0.3936 μs | 0.3681 μs |   2,995 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 8KB          |    68.169 μs | 0.4229 μs | 0.3956 μs |   3,487 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · SM3 · CryptoHives-Scalar | 128KB        |   831.270 μs | 9.3911 μs | 8.7845 μs |   3,005 B |         - |
| TryComputeHash · SM3 · BouncyCastle       | 128KB        | 1,085.618 μs | 3.2394 μs | 3.0302 μs |   3,580 B |         - |