| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     1.158 μs | 0.0011 μs | 0.0010 μs |   4,006 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     1.426 μs | 0.0033 μs | 0.0031 μs |   5,085 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     1.220 μs | 0.0011 μs | 0.0010 μs |   4,018 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     1.501 μs | 0.0031 μs | 0.0029 μs |   5,085 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |     7.660 μs | 0.0041 μs | 0.0035 μs |   4,006 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |     9.372 μs | 0.0186 μs | 0.0174 μs |   5,085 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |     7.669 μs | 0.0075 μs | 0.0063 μs |   4,018 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |     9.360 μs | 0.0103 μs | 0.0086 μs |   5,085 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |    59.273 μs | 0.0604 μs | 0.0565 μs |   4,022 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |    72.549 μs | 0.1570 μs | 0.1469 μs |   5,080 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        |   965.565 μs | 0.5169 μs | 0.4582 μs |   3,973 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 1,162.420 μs | 0.6615 μs | 0.5864 μs |   5,092 B |         - |