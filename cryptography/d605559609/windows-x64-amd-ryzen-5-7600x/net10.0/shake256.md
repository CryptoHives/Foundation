| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     218.1 ns |     0.35 ns |     0.29 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     285.9 ns |     1.34 ns |     1.12 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     297.4 ns |     1.85 ns |     1.54 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     335.0 ns |     0.76 ns |     0.64 ns |   8,041 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     378.3 ns |     1.90 ns |     1.77 ns |   3,255 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     423.3 ns |     1.62 ns |     1.26 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     559.2 ns |     2.44 ns |     2.28 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     576.6 ns |     1.62 ns |     1.27 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     608.6 ns |     2.10 ns |     1.75 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     638.8 ns |     1.92 ns |     1.80 ns |   9,280 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,646.9 ns |     2.35 ns |     1.83 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,092.8 ns |    10.08 ns |     8.42 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,195.8 ns |     8.94 ns |     8.37 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,247.4 ns |    13.59 ns |    11.35 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,540.8 ns |     8.87 ns |     8.30 ns |   9,360 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,654.6 ns |     7.40 ns |     6.18 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,083.5 ns |    17.03 ns |    14.22 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,186.7 ns |     7.14 ns |     6.33 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,244.5 ns |    17.86 ns |    15.83 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,539.2 ns |     3.07 ns |     2.40 ns |   9,350 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  12,503.6 ns |    33.87 ns |    31.68 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  15,043.6 ns |    40.03 ns |    35.49 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  16,583.5 ns |    47.32 ns |    41.95 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  17,190.0 ns |   329.90 ns |   417.22 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  19,260.8 ns |   196.22 ns |   163.85 ns |   9,307 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 197,384.3 ns |   744.40 ns |   696.31 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 235,495.5 ns |   706.80 ns |   661.14 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 262,118.8 ns | 2,416.19 ns | 2,017.63 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 267,250.0 ns |   612.44 ns |   511.42 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 303,241.7 ns | 1,036.25 ns |   918.61 ns |   9,308 B |         - |