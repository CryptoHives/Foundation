| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     341.2 ns |     2.01 ns |     1.88 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     366.4 ns |     1.00 ns |     0.88 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     422.2 ns |     1.14 ns |     1.07 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     343.8 ns |     1.56 ns |     1.46 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     365.8 ns |     0.17 ns |     0.14 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     429.4 ns |     1.35 ns |     1.13 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,447.0 ns |     3.88 ns |     3.44 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,916.6 ns |    14.83 ns |    13.14 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,126.6 ns |     4.01 ns |     3.56 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,440.5 ns |     3.41 ns |     3.02 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,910.0 ns |     7.02 ns |     6.22 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,124.6 ns |     3.76 ns |     3.34 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,531.7 ns |    25.43 ns |    21.23 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  14,467.2 ns |    38.36 ns |    34.01 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  16,182.7 ns |    51.29 ns |    47.97 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 148,212.2 ns |   501.62 ns |   469.22 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 230,323.9 ns | 1,242.67 ns | 1,101.59 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 256,963.1 ns |   727.14 ns |   680.17 ns |         - |