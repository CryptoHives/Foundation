| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |   1,002.0 ns |     2.34 ns |     2.19 ns |   8,401 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,789.1 ns |     7.02 ns |     6.56 ns |   7,284 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,706.8 ns |     6.36 ns |     5.31 ns |  16,161 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     999.8 ns |     2.27 ns |     2.02 ns |   8,401 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,788.8 ns |     5.74 ns |     5.37 ns |   7,281 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,718.1 ns |     6.16 ns |     5.76 ns |  16,769 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   2,845.8 ns |     4.59 ns |     4.30 ns |   8,390 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   4,330.0 ns |     7.43 ns |     6.21 ns |   7,557 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   5,179.4 ns |    11.54 ns |    10.79 ns |  16,834 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   2,845.4 ns |     7.95 ns |     7.04 ns |   8,390 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   4,304.7 ns |    16.91 ns |    15.81 ns |   7,555 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   5,170.2 ns |    15.13 ns |    13.41 ns |  16,242 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  15,464.8 ns |    63.61 ns |    56.39 ns |   8,400 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  22,755.1 ns |    47.86 ns |    39.97 ns |  21,322 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  22,940.4 ns |    64.58 ns |    57.25 ns |   7,464 B |    8248 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 234,580.1 ns |   381.03 ns |   356.41 ns |   8,388 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 327,769.0 ns |   932.27 ns |   872.05 ns |  21,479 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 393,717.3 ns | 7,454.11 ns | 5,819.68 ns |   7,859 B |  131151 B |