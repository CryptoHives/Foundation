| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     232.7 ns |     2.23 ns |     2.09 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     439.8 ns |     3.02 ns |     2.83 ns |   7,069 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     464.5 ns |     2.96 ns |     2.63 ns |   4,716 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     233.3 ns |     1.26 ns |     1.05 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     444.9 ns |     1.90 ns |     1.78 ns |   7,059 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     460.5 ns |     2.22 ns |     2.08 ns |   4,724 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,118.5 ns |     9.51 ns |     8.90 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,461.4 ns |    19.86 ns |    18.57 ns |   7,066 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,500.1 ns |    16.08 ns |    15.04 ns |   4,713 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,121.3 ns |     7.30 ns |     6.47 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,474.8 ns |    22.39 ns |    20.94 ns |   7,061 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,502.1 ns |    12.40 ns |    11.60 ns |   4,721 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   8,148.6 ns |    65.83 ns |    54.97 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  18,589.9 ns |   118.27 ns |   110.63 ns |   7,078 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  18,679.9 ns |   108.02 ns |    95.76 ns |   4,713 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 128,826.4 ns |   807.68 ns |   715.98 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 295,528.9 ns | 3,550.71 ns | 3,321.34 ns |   7,019 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 295,878.0 ns | 2,712.42 ns | 2,537.20 ns |   4,734 B |         - |