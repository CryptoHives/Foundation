| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     220.6 ns |     0.46 ns |     0.43 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     289.4 ns |     2.05 ns |     1.71 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     299.5 ns |     1.40 ns |     1.17 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     333.0 ns |     1.08 ns |     0.90 ns |   8,071 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     366.9 ns |     1.03 ns |     0.97 ns |   3,226 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     220.0 ns |     0.97 ns |     0.81 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     287.2 ns |     1.70 ns |     1.59 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     298.8 ns |     1.04 ns |     0.98 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     335.0 ns |     0.77 ns |     0.69 ns |   8,062 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     371.3 ns |     3.14 ns |     2.45 ns |   3,224 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,460.5 ns |     5.27 ns |     4.93 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   1,841.4 ns |     8.86 ns |     7.40 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   1,927.6 ns |    14.68 ns |    14.42 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   1,971.1 ns |    13.52 ns |    11.29 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,222.7 ns |     3.34 ns |     3.12 ns |   9,276 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,462.3 ns |     6.59 ns |     5.50 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   1,848.1 ns |     6.93 ns |     6.14 ns |   3,226 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   1,927.5 ns |    19.29 ns |    16.11 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   1,972.5 ns |     8.08 ns |     7.56 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,212.5 ns |    15.36 ns |    11.99 ns |   9,286 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  10,180.1 ns |   126.69 ns |   105.79 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  12,275.8 ns |    25.15 ns |    21.00 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  13,371.8 ns |    17.06 ns |    14.24 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  13,742.9 ns |    81.77 ns |    63.84 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  15,388.5 ns |    34.73 ns |    29.00 ns |   9,290 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 160,900.7 ns |   412.34 ns |   365.53 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 193,260.1 ns |   964.05 ns |   854.60 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 212,945.8 ns |   541.37 ns |   452.07 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 218,160.0 ns | 2,168.74 ns | 1,693.21 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 245,358.1 ns | 1,538.94 ns | 1,201.51 ns |   9,286 B |         - |