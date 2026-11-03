| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     732.7 ns |   1.99 ns |   1.86 ns |   8,374 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,154.2 ns |   3.89 ns |   3.64 ns |   7,257 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,287.1 ns |   8.63 ns |   8.08 ns |  16,518 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     961.0 ns |   2.01 ns |   1.88 ns |   8,358 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,438.2 ns |   4.12 ns |   3.85 ns |   7,257 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,633.7 ns |   5.82 ns |   5.44 ns |  16,644 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,327.9 ns |   5.72 ns |   5.35 ns |   8,376 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   3,111.5 ns |   8.73 ns |   7.74 ns |   7,256 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,679.3 ns |   9.46 ns |   8.85 ns |  16,635 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,329.9 ns |   5.13 ns |   4.80 ns |   8,376 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   3,123.8 ns |   7.16 ns |   6.35 ns |   7,270 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,868.0 ns |   7.17 ns |   6.71 ns |  16,626 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  14,406.7 ns |  21.66 ns |  20.26 ns |   8,362 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  18,001.7 ns |  65.39 ns |  61.17 ns |   7,459 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  23,227.8 ns |  31.27 ns |  29.25 ns |  19,910 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 220,468.3 ns | 390.71 ns | 305.04 ns |   8,362 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 305,772.0 ns | 835.89 ns | 781.89 ns |   7,814 B |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 339,536.8 ns | 429.39 ns | 380.64 ns |  20,033 B |     256 B |