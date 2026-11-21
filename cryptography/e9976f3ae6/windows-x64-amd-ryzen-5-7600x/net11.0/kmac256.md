| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     734.3 ns |     2.53 ns |     2.25 ns |  18,749 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,156.1 ns |     2.73 ns |     2.42 ns |  16,843 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,250.6 ns |    10.10 ns |     9.45 ns |  25,084 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     965.3 ns |     6.43 ns |     5.70 ns |  12,401 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,445.5 ns |     8.78 ns |     8.22 ns |  17,239 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,584.6 ns |     4.74 ns |     3.96 ns |  25,278 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,340.8 ns |     5.89 ns |     4.92 ns |  18,736 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   3,138.6 ns |    15.87 ns |    14.07 ns |  17,255 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,699.0 ns |     9.92 ns |     9.28 ns |  25,294 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,339.7 ns |     7.60 ns |     6.74 ns |  18,745 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   3,138.5 ns |    16.49 ns |    14.62 ns |  17,046 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,712.2 ns |    25.22 ns |    23.59 ns |  25,487 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  14,971.6 ns |    60.40 ns |    50.43 ns |  18,743 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  18,156.1 ns |    78.02 ns |    65.15 ns |  10,709 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  23,113.5 ns |    34.64 ns |    28.93 ns |  23,218 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 222,875.7 ns | 1,553.39 ns | 1,297.15 ns |  18,745 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 319,969.2 ns | 1,042.21 ns |   870.29 ns |  18,235 B |  131191 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 340,249.8 ns | 1,400.34 ns | 1,241.36 ns |  29,753 B |     256 B |