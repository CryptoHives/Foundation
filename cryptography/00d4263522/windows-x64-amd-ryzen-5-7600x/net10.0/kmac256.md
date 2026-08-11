| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     659.5 ns |   1.90 ns |   1.69 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,042.6 ns |   2.91 ns |   2.58 ns |   8,544 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,013.1 ns |   5.41 ns |   4.80 ns |  18,466 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     863.9 ns |   2.41 ns |   2.01 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,299.9 ns |   4.98 ns |   4.41 ns |   8,460 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,318.8 ns |   7.90 ns |   6.60 ns |  18,541 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,096.2 ns |   3.09 ns |   2.42 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   2,902.7 ns |   4.98 ns |   3.89 ns |   8,693 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,208.4 ns |   7.79 ns |   6.51 ns |  18,495 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,088.7 ns |   5.41 ns |   4.22 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   2,901.4 ns |  11.71 ns |   9.78 ns |   8,694 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,223.0 ns |  22.09 ns |  20.66 ns |  18,491 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  12,986.4 ns |  27.39 ns |  22.87 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  16,284.7 ns |  59.97 ns |  53.16 ns |   8,596 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  20,835.8 ns |  38.07 ns |  33.75 ns |  21,218 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 197,933.2 ns | 407.73 ns | 318.33 ns |        NA |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 276,616.4 ns | 603.05 ns | 470.82 ns |   8,379 B |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 305,190.7 ns | 338.96 ns | 300.48 ns |  21,282 B |     256 B |