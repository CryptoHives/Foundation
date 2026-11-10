| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     471.1 ns |   0.58 ns |   0.52 ns |   2,791 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     503.3 ns |   0.29 ns |   0.27 ns |   4,450 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     628.2 ns |   1.32 ns |   1.23 ns |   5,118 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     474.0 ns |   1.65 ns |   1.54 ns |   2,779 B |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     503.7 ns |   0.24 ns |   0.23 ns |   4,450 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     642.1 ns |   0.89 ns |   0.74 ns |   5,117 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   2,360.8 ns |   0.85 ns |   0.80 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,689.7 ns |   2.91 ns |   2.72 ns |   2,791 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   3,496.2 ns |   2.89 ns |   2.57 ns |   5,134 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   2,365.5 ns |   1.63 ns |   1.52 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,682.1 ns |   3.69 ns |   3.27 ns |   2,784 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   3,496.2 ns |   7.56 ns |   6.70 ns |   5,122 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  16,915.4 ns |   4.54 ns |   3.79 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  19,858.3 ns |  19.04 ns |  16.88 ns |   2,791 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  26,079.1 ns |  29.00 ns |  25.71 ns |   5,144 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 266,377.2 ns | 131.24 ns | 122.76 ns |   4,527 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 316,000.6 ns | 265.01 ns | 247.89 ns |   2,801 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 411,965.8 ns | 460.20 ns | 430.47 ns |   5,093 B |         - |