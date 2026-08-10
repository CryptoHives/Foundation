| Description                               | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · MD5 · OS Native          | 128B         |     271.1 ns |     1.10 ns |   1.03 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     310.8 ns |     2.25 ns |   2.00 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     369.5 ns |     0.94 ns |   0.83 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     267.4 ns |     0.68 ns |   0.64 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     314.9 ns |     2.28 ns |   2.13 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     369.1 ns |     0.86 ns |   0.76 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,370.5 ns |     2.67 ns |   2.50 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,709.8 ns |    11.18 ns |   9.92 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,020.2 ns |     8.50 ns |   7.54 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,370.1 ns |     3.49 ns |   3.26 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,744.0 ns |    30.69 ns |  32.84 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,025.5 ns |    27.79 ns |  21.70 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,167.3 ns |    24.01 ns |  21.28 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  12,935.8 ns |    70.42 ns |  62.42 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,168.1 ns |    56.68 ns |  50.24 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 160,970.5 ns |   362.16 ns | 338.77 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 204,965.4 ns | 1,077.14 ns | 954.86 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 240,281.1 ns |   392.25 ns | 327.55 ns |         - |