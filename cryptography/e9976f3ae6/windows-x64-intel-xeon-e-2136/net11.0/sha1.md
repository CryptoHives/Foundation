| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     475.7 ns |     0.17 ns |     0.16 ns |  13,676 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     946.9 ns |     3.53 ns |     3.30 ns |   5,318 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |   1,084.7 ns |     5.44 ns |     4.82 ns |   5,150 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     474.4 ns |     0.19 ns |     0.17 ns |  13,676 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     936.5 ns |     4.05 ns |     3.79 ns |  11,661 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |   1,037.1 ns |     5.52 ns |     4.89 ns |   5,151 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   2,138.8 ns |     0.86 ns |     0.72 ns |  13,867 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   4,872.9 ns |    55.47 ns |    51.89 ns |  11,655 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   6,024.6 ns |    31.05 ns |    27.53 ns |   5,151 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   2,143.8 ns |     1.26 ns |     1.18 ns |   6,863 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   4,856.3 ns |    35.61 ns |    33.31 ns |  11,663 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   6,078.3 ns |    20.71 ns |    19.37 ns |   5,152 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |  15,113.9 ns |     6.44 ns |     6.02 ns |  13,676 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  35,873.1 ns |   496.10 ns |   464.05 ns |  11,845 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  44,367.3 ns |   254.17 ns |   237.75 ns |   5,163 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 237,347.4 ns |   150.94 ns |   141.19 ns |   6,863 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 567,773.1 ns | 6,866.40 ns | 6,422.84 ns |  11,673 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 692,828.3 ns | 4,847.79 ns | 4,534.63 ns |   5,482 B |         - |