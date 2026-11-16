| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     739.1 ns |     1.42 ns |     1.19 ns |   8,374 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,156.8 ns |     2.25 ns |     1.88 ns |   7,257 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,319.4 ns |     7.08 ns |     6.28 ns |  16,659 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     741.4 ns |     2.54 ns |     2.25 ns |   8,392 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,161.7 ns |     4.31 ns |     3.82 ns |   7,257 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,319.5 ns |     9.28 ns |     8.68 ns |  16,078 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   2,124.0 ns |     5.89 ns |     5.22 ns |   8,364 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,947.0 ns |    43.88 ns |    36.64 ns |   7,256 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   4,383.5 ns |    20.18 ns |    16.85 ns |  16,718 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   2,134.3 ns |     7.02 ns |     6.22 ns |   8,370 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,908.9 ns |    11.77 ns |    10.43 ns |   7,559 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   4,511.0 ns |    32.61 ns |    27.23 ns |  16,734 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  11,860.7 ns |    62.93 ns |    52.55 ns |   8,380 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  15,149.7 ns |   116.66 ns |    97.42 ns |   7,449 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  19,484.9 ns |   111.98 ns |   104.75 ns |  21,246 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 181,750.1 ns |   829.20 ns |   735.07 ns |   8,368 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 264,704.5 ns | 1,494.17 ns | 1,397.65 ns |   7,811 B |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 282,985.6 ns |   984.78 ns |   872.98 ns |  21,387 B |     256 B |