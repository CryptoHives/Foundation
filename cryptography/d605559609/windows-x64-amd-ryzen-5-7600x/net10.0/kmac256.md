| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     658.7 ns |     1.98 ns |     1.66 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,035.0 ns |     5.40 ns |     4.51 ns |   8,706 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,071.8 ns |     5.36 ns |     5.02 ns |  18,436 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     862.0 ns |     3.80 ns |     2.96 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,296.4 ns |     5.66 ns |     5.30 ns |   8,528 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,313.4 ns |     5.73 ns |     5.08 ns |  18,512 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,089.0 ns |    17.14 ns |    16.03 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   2,830.7 ns |    13.58 ns |    12.70 ns |   8,691 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,208.0 ns |    18.76 ns |    14.65 ns |  18,488 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,084.1 ns |     9.58 ns |     8.96 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   2,816.9 ns |    20.19 ns |    17.90 ns |   8,525 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,220.4 ns |    57.18 ns |    47.74 ns |  18,479 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  12,938.2 ns |    32.70 ns |    28.99 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  16,346.5 ns |    99.33 ns |    92.91 ns |   8,760 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  20,803.4 ns |    62.41 ns |    52.12 ns |  21,223 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 197,729.5 ns | 1,008.57 ns |   943.42 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 279,201.9 ns | 5,402.53 ns | 6,431.33 ns |   8,990 B |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 303,445.8 ns |   805.79 ns |   753.74 ns |  21,253 B |     256 B |