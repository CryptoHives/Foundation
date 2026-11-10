| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     1.160 μs | 0.0030 μs | 0.0028 μs |   4,006 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     1.430 μs | 0.0006 μs | 0.0005 μs |   5,085 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     1.222 μs | 0.0013 μs | 0.0012 μs |   4,018 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     1.505 μs | 0.0011 μs | 0.0009 μs |   5,085 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |     7.667 μs | 0.0071 μs | 0.0059 μs |   4,006 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |     9.401 μs | 0.0117 μs | 0.0098 μs |   5,072 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |     7.674 μs | 0.0099 μs | 0.0088 μs |   4,018 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |     9.402 μs | 0.0108 μs | 0.0096 μs |   5,085 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |    59.278 μs | 0.0266 μs | 0.0236 μs |   4,022 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |    72.723 μs | 0.0643 μs | 0.0570 μs |   5,080 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        |   948.597 μs | 0.6794 μs | 0.5673 μs |   3,973 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 1,165.818 μs | 1.6518 μs | 1.5451 μs |   5,092 B |         - |