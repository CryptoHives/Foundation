| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     325.4 ns |   1.74 ns |   1.62 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     364.1 ns |   1.50 ns |   1.26 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     407.2 ns |   3.17 ns |   2.96 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     336.6 ns |   1.29 ns |   1.21 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     362.1 ns |   1.15 ns |   1.07 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     396.7 ns |   1.72 ns |   1.60 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,435.7 ns |   2.99 ns |   2.65 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,919.3 ns |  13.88 ns |  12.99 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,124.6 ns |   2.56 ns |   2.39 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,451.5 ns |   3.73 ns |   3.31 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,940.9 ns |  13.38 ns |  12.51 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,129.8 ns |   1.19 ns |   1.06 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,717.8 ns |  30.97 ns |  28.97 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  14,864.4 ns |  50.04 ns |  46.80 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  16,264.0 ns |   9.09 ns |   8.50 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 152,472.0 ns | 742.73 ns | 694.75 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 237,959.5 ns | 358.16 ns | 335.02 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 258,324.3 ns |  80.66 ns |  75.45 ns |         - |