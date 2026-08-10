| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     266.6 ns |   0.36 ns |   0.32 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     269.4 ns |   0.43 ns |   0.36 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     370.2 ns |   0.64 ns |   0.54 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     267.1 ns |   0.57 ns |   0.53 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     271.8 ns |   0.37 ns |   0.31 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     368.7 ns |   0.69 ns |   0.58 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,370.1 ns |   1.76 ns |   1.65 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,463.8 ns |   2.35 ns |   2.20 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,017.8 ns |   3.39 ns |   2.83 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,371.7 ns |   1.76 ns |   1.65 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,471.9 ns |   3.84 ns |   3.59 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,010.0 ns |   2.50 ns |   2.22 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,165.6 ns |   9.21 ns |   8.61 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  11,050.3 ns |  20.02 ns |  18.72 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,175.6 ns |  20.60 ns |  18.26 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 161,012.2 ns | 256.75 ns | 240.17 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 175,407.5 ns | 351.37 ns | 328.67 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 240,811.9 ns | 113.98 ns |  95.18 ns |         - |