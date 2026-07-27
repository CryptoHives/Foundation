| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     218.7 ns |     0.86 ns |     0.76 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     288.7 ns |     2.92 ns |     2.59 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     299.5 ns |     3.11 ns |     2.91 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     343.1 ns |     2.30 ns |     2.04 ns |   8,464 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     363.2 ns |     2.69 ns |     2.38 ns |   3,224 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     218.3 ns |     1.02 ns |     0.96 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     289.0 ns |     2.41 ns |     2.14 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     298.1 ns |     2.92 ns |     2.73 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     341.8 ns |     1.47 ns |     1.37 ns |   8,457 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     365.7 ns |     3.57 ns |     3.16 ns |   3,224 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,440.2 ns |     6.07 ns |     5.07 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   1,823.5 ns |     8.94 ns |     7.93 ns |   3,226 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   1,932.6 ns |    25.77 ns |    22.84 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   1,974.5 ns |    20.00 ns |    18.71 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,234.3 ns |    16.02 ns |    13.38 ns |   8,912 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,442.8 ns |    10.90 ns |    10.20 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   1,820.4 ns |    16.40 ns |    15.34 ns |   3,226 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   1,930.6 ns |    27.30 ns |    24.20 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   1,975.4 ns |    26.45 ns |    24.75 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,302.7 ns |    26.00 ns |    23.05 ns |   8,914 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  10,034.1 ns |    60.00 ns |    50.10 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  12,020.4 ns |    88.31 ns |    82.60 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  13,441.8 ns |   111.19 ns |    98.57 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  13,705.9 ns |   125.92 ns |   111.63 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  15,444.3 ns |   120.57 ns |   112.78 ns |   8,935 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 158,852.0 ns | 1,113.32 ns |   986.93 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 189,888.3 ns | 1,052.90 ns |   933.37 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 214,684.1 ns | 2,431.88 ns | 2,030.73 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 217,764.7 ns | 1,695.49 ns | 1,585.96 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 244,939.7 ns | 1,144.46 ns | 1,014.54 ns |   8,930 B |         - |