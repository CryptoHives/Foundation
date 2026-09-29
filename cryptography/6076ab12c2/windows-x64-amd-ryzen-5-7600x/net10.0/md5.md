| Description                               | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     308.7 ns |     0.43 ns |     0.36 ns |   2,752 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     315.4 ns |     0.30 ns |     0.28 ns |   4,441 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     429.6 ns |     0.38 ns |     0.36 ns |   5,128 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     313.4 ns |     0.33 ns |     0.31 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     314.2 ns |     0.66 ns |     0.55 ns |   2,740 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     429.6 ns |     0.46 ns |     0.41 ns |   5,113 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,600.8 ns |     0.71 ns |     0.63 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,686.3 ns |     1.81 ns |     1.60 ns |   2,752 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,359.0 ns |     5.41 ns |     5.06 ns |   5,112 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,615.0 ns |     4.94 ns |     4.38 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,695.8 ns |     3.33 ns |     3.11 ns |   2,745 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,361.4 ns |     7.41 ns |     6.93 ns |   5,117 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  11,935.0 ns |    30.86 ns |    27.36 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  12,768.6 ns |    43.78 ns |    40.95 ns |   2,752 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  17,821.8 ns |   114.29 ns |   106.91 ns |   5,138 B |         - |
|                                           |              |              |             |             |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 189,344.3 ns |   576.06 ns |   538.85 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 202,395.7 ns |   381.22 ns |   356.59 ns |   2,752 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 282,868.9 ns | 1,137.93 ns | 1,064.42 ns |   5,087 B |         - |