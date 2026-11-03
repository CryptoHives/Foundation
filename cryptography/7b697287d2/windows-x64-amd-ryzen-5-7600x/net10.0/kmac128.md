| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     737.1 ns |   1.53 ns |   1.43 ns |   8,392 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,147.6 ns |   3.60 ns |   3.36 ns |   7,257 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,310.5 ns |   7.03 ns |   6.57 ns |  16,644 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     741.0 ns |   1.06 ns |   0.99 ns |   8,374 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,147.3 ns |   3.86 ns |   3.61 ns |   7,258 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,312.1 ns |   4.56 ns |   4.26 ns |  16,070 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   2,115.1 ns |   8.02 ns |   7.50 ns |   8,364 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,856.1 ns |   6.84 ns |   6.06 ns |   7,256 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   4,355.4 ns |  11.57 ns |  10.82 ns |  16,717 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   2,113.6 ns |   4.14 ns |   3.46 ns |   8,370 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,847.2 ns |   7.72 ns |   7.22 ns |   7,253 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   4,357.1 ns |   7.17 ns |   6.70 ns |  16,684 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  11,763.5 ns |  26.82 ns |  25.08 ns |   8,380 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  14,758.2 ns |  23.45 ns |  20.78 ns |   7,445 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  19,469.9 ns |  31.37 ns |  29.35 ns |  21,235 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 179,968.2 ns | 483.54 ns | 452.31 ns |   8,368 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 257,650.6 ns | 980.63 ns | 917.28 ns |   7,806 B |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 282,173.1 ns | 631.43 ns | 590.64 ns |  21,387 B |     256 B |