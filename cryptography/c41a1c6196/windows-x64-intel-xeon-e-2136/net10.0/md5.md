| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     477.2 ns |     3.32 ns |     3.11 ns |   2,791 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     503.5 ns |     0.29 ns |     0.27 ns |   4,450 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     633.6 ns |     7.17 ns |     6.70 ns |   5,118 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     480.1 ns |     2.84 ns |     2.37 ns |   2,779 B |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     500.4 ns |     0.17 ns |     0.16 ns |   4,450 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     644.4 ns |     4.58 ns |     3.82 ns |   5,119 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   2,363.5 ns |     2.01 ns |     1.88 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,704.4 ns |     7.71 ns |     6.44 ns |   2,791 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   3,528.6 ns |    12.81 ns |    11.36 ns |   5,118 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   2,365.8 ns |     2.65 ns |     2.48 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,692.2 ns |     5.91 ns |     5.24 ns |   2,784 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   3,499.6 ns |    13.41 ns |    12.55 ns |   5,123 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  16,906.9 ns |     1.48 ns |     1.31 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  19,931.4 ns |    28.91 ns |    27.04 ns |   2,791 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  26,179.5 ns |   160.63 ns |   150.25 ns |   5,144 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 266,342.8 ns |   124.46 ns |   116.42 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 318,139.8 ns |   326.15 ns |   305.08 ns |   2,801 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 412,492.9 ns | 1,979.26 ns | 1,754.56 ns |   5,093 B |         - |