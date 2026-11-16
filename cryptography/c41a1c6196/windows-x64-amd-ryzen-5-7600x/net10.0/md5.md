| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     306.7 ns |   0.19 ns |   0.16 ns |   2,775 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     321.6 ns |   0.58 ns |   0.51 ns |   4,441 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     431.2 ns |   0.69 ns |   0.57 ns |   5,112 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     312.4 ns |   0.49 ns |   0.43 ns |   2,761 B |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     313.3 ns |   0.23 ns |   0.20 ns |   4,441 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     430.8 ns |   0.46 ns |   0.38 ns |   5,113 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,602.3 ns |   1.25 ns |   1.17 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,688.6 ns |  12.23 ns |   9.55 ns |   2,773 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,353.0 ns |   3.18 ns |   2.65 ns |   5,128 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,604.9 ns |   2.05 ns |   1.91 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,695.8 ns |   3.48 ns |   3.08 ns |   2,766 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,354.2 ns |   3.80 ns |   3.37 ns |   5,132 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  11,895.8 ns |  14.27 ns |  12.65 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  12,694.2 ns |  18.43 ns |  16.33 ns |   2,773 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  17,706.9 ns |  20.97 ns |  17.51 ns |   4,965 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 188,293.6 ns | 161.54 ns | 151.11 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 201,566.3 ns | 516.35 ns | 457.73 ns |   2,773 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 280,764.3 ns | 175.19 ns | 155.30 ns |   5,087 B |         - |