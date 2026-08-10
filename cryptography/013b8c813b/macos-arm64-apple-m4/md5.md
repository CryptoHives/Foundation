| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     337.6 ns |     0.87 ns |     0.81 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     363.7 ns |     0.39 ns |     0.36 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     420.1 ns |     0.74 ns |     0.65 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     337.5 ns |     0.88 ns |     0.82 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     363.1 ns |     0.85 ns |     0.80 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     406.5 ns |     3.20 ns |     2.99 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,423.6 ns |     4.52 ns |     4.23 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,894.2 ns |     6.36 ns |     5.95 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,101.7 ns |     9.52 ns |     8.90 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,420.0 ns |     6.87 ns |     6.43 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,899.5 ns |    11.99 ns |    11.22 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,115.8 ns |    29.74 ns |    24.84 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,414.2 ns |    43.88 ns |    41.04 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  14,340.0 ns |    29.13 ns |    25.83 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  16,019.7 ns |    83.02 ns |    77.66 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 146,074.5 ns |   632.20 ns |   591.36 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 227,696.3 ns |   925.76 ns |   865.96 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 253,979.9 ns | 1,081.91 ns | 1,012.01 ns |         - |