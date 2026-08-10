| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     347.5 ns |   1.18 ns |   1.11 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     367.4 ns |   0.53 ns |   0.49 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     431.7 ns |   2.29 ns |   2.14 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     347.4 ns |   1.43 ns |   1.34 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     367.4 ns |   0.41 ns |   0.39 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     419.2 ns |   1.14 ns |   1.07 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,463.5 ns |   4.73 ns |   4.42 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,942.6 ns |   7.77 ns |   6.89 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,141.1 ns |   3.94 ns |   3.68 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,458.2 ns |   3.70 ns |   3.46 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,940.8 ns |   8.59 ns |   8.03 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,138.0 ns |   5.43 ns |   5.08 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,639.8 ns |  40.90 ns |  38.26 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  14,700.7 ns |  57.43 ns |  53.72 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  16,298.7 ns |  62.69 ns |  58.64 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 149,614.4 ns | 689.86 ns | 645.29 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 233,415.8 ns | 825.00 ns | 771.71 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 259,051.0 ns | 479.99 ns | 448.98 ns |         - |