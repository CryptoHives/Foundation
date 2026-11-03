| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     247.5 ns |   0.91 ns |   0.80 ns |   5,590 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     319.4 ns |   0.21 ns |   0.19 ns |   5,081 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     328.9 ns |   0.25 ns |   0.22 ns |   4,110 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     377.5 ns |   0.40 ns |   0.34 ns |   5,856 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     422.3 ns |   0.68 ns |   0.63 ns |   1,486 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     246.8 ns |   0.90 ns |   0.84 ns |   5,590 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     317.3 ns |   0.27 ns |   0.26 ns |   5,081 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     329.7 ns |   0.24 ns |   0.22 ns |   4,112 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     379.7 ns |   0.73 ns |   0.69 ns |   5,856 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     416.4 ns |   1.14 ns |   1.01 ns |   1,486 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,625.5 ns |   2.63 ns |   2.46 ns |   5,572 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   2,057.7 ns |   7.22 ns |   6.76 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   2,132.1 ns |   1.09 ns |   1.02 ns |   5,063 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   2,179.6 ns |   1.61 ns |   1.51 ns |   4,076 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,502.6 ns |   5.24 ns |   4.90 ns |   8,173 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,625.1 ns |   4.20 ns |   3.93 ns |   5,574 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   2,057.3 ns |   4.98 ns |   4.66 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   2,126.9 ns |   1.43 ns |   1.34 ns |   5,065 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   2,177.9 ns |   1.62 ns |   1.51 ns |   4,078 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,495.8 ns |   3.92 ns |   3.67 ns |   8,177 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  11,285.8 ns |  23.72 ns |  22.19 ns |   5,578 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  13,536.9 ns |  11.97 ns |  11.20 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  14,800.4 ns |   9.34 ns |   8.74 ns |   5,069 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  15,100.9 ns |  10.59 ns |   9.91 ns |   4,082 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  17,531.0 ns |  33.08 ns |  30.95 ns |   8,166 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 179,642.4 ns | 565.10 ns | 528.59 ns |   5,572 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 214,084.7 ns | 355.54 ns | 332.57 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 235,399.7 ns |  50.26 ns |  44.56 ns |   5,063 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 242,247.0 ns | 310.17 ns | 290.13 ns |   4,076 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 278,437.0 ns | 489.20 ns | 457.59 ns |   8,158 B |         - |