| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     648.0 ns |     3.52 ns |     3.12 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,035.3 ns |     4.98 ns |     3.89 ns |   8,531 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,998.1 ns |    13.17 ns |    11.67 ns |  18,108 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     853.4 ns |     5.92 ns |     5.54 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,286.3 ns |    12.55 ns |    10.48 ns |   8,460 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,296.1 ns |    17.21 ns |    13.44 ns |  18,170 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,069.3 ns |    21.14 ns |    19.78 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   2,810.4 ns |    25.07 ns |    22.22 ns |   8,458 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,194.7 ns |    26.09 ns |    23.13 ns |  18,251 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,072.6 ns |    13.38 ns |    12.51 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   2,794.5 ns |    23.64 ns |    22.11 ns |   8,525 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,187.6 ns |    36.47 ns |    30.45 ns |  18,839 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  12,792.4 ns |   108.71 ns |    96.37 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  16,104.3 ns |   226.29 ns |   211.67 ns |   8,760 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  20,819.1 ns |   165.33 ns |   154.65 ns |  19,614 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 196,409.9 ns | 2,556.86 ns | 2,266.59 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 273,779.4 ns | 2,950.57 ns | 2,615.60 ns |   8,815 B |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 301,451.3 ns | 2,657.65 ns | 2,485.96 ns |  19,673 B |     256 B |