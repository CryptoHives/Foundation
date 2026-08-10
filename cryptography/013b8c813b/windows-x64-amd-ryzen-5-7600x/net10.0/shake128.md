| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     218.8 ns |     1.93 ns |     1.81 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     289.0 ns |     2.00 ns |     1.56 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     302.2 ns |     4.67 ns |     4.36 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     342.0 ns |     4.59 ns |     4.07 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     367.9 ns |     5.57 ns |     5.21 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     219.1 ns |     2.32 ns |     2.06 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     289.1 ns |     2.77 ns |     2.59 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     307.5 ns |     6.03 ns |     5.64 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     348.6 ns |     3.75 ns |     3.51 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     382.3 ns |     7.14 ns |     7.01 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,465.3 ns |    12.43 ns |    11.63 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   1,859.0 ns |    35.35 ns |    31.34 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   1,929.9 ns |    13.16 ns |    12.31 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   1,986.9 ns |    21.06 ns |    17.59 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,272.6 ns |    44.38 ns |    49.33 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,458.9 ns |    23.36 ns |    24.99 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   1,914.7 ns |    38.04 ns |    61.43 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   1,931.4 ns |    16.62 ns |    14.73 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   1,982.7 ns |    17.17 ns |    15.22 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,262.0 ns |    40.27 ns |    37.67 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  10,108.0 ns |   135.95 ns |   120.51 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  12,177.7 ns |   140.01 ns |   130.96 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  13,497.1 ns |   165.36 ns |   129.10 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  13,730.6 ns |   138.45 ns |   115.61 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  15,602.7 ns |   195.16 ns |   224.75 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 161,810.2 ns | 3,173.12 ns | 3,395.20 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 191,751.2 ns | 2,562.60 ns | 2,000.71 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 219,213.5 ns | 3,549.53 ns | 3,320.23 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 219,374.1 ns | 4,060.03 ns | 3,599.11 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 251,756.7 ns | 4,944.94 ns | 6,072.84 ns |         - |