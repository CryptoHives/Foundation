| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     663.9 ns |   1.44 ns |   1.27 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |     992.3 ns |   5.65 ns |   5.28 ns |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,985.0 ns |   9.48 ns |   8.86 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     661.9 ns |   2.32 ns |   2.17 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,010.5 ns |   4.93 ns |   4.61 ns |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,975.6 ns |   5.81 ns |   4.85 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,896.1 ns |   5.62 ns |   4.99 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,469.1 ns |  12.45 ns |  11.65 ns |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   3,800.3 ns |  11.24 ns |   9.96 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,892.1 ns |   4.95 ns |   4.63 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,471.4 ns |   7.34 ns |   6.13 ns |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   3,793.2 ns |  15.75 ns |  14.73 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  10,216.7 ns |  24.79 ns |  21.97 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  12,841.6 ns |  88.38 ns |  82.67 ns |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  16,717.3 ns |  27.52 ns |  24.40 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 155,580.2 ns | 378.44 ns | 354.00 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 222,272.4 ns | 486.38 ns | 454.96 ns |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 241,623.2 ns | 268.95 ns | 238.42 ns |     256 B |