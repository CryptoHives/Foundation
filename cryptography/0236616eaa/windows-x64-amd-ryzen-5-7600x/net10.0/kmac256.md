| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     650.2 ns |   0.75 ns |   0.59 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,037.3 ns |   2.79 ns |   2.18 ns |   8,532 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,000.9 ns |   3.45 ns |   2.88 ns |  18,426 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     853.6 ns |   1.91 ns |   1.59 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,281.0 ns |   4.32 ns |   3.83 ns |   8,544 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,333.9 ns |   5.32 ns |   4.71 ns |  18,524 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,084.5 ns |   5.02 ns |   4.45 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   2,785.2 ns |   7.76 ns |   6.48 ns |   8,691 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,175.6 ns |   9.06 ns |   7.57 ns |  18,502 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,070.5 ns |   4.38 ns |   3.88 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   2,793.5 ns |  35.10 ns |  29.31 ns |   8,458 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,164.0 ns |   6.51 ns |   5.44 ns |  18,497 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  12,816.1 ns |  22.70 ns |  18.95 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  16,185.7 ns |  76.08 ns |  63.53 ns |   8,760 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  20,523.6 ns |  48.02 ns |  42.57 ns |  21,264 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 195,942.9 ns | 426.18 ns | 377.80 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 273,155.6 ns | 752.15 ns | 628.08 ns |   8,947 B |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 302,578.6 ns | 933.86 ns | 827.84 ns |  21,297 B |     256 B |