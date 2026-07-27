| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     217.6 ns |     0.83 ns |     0.74 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     285.6 ns |     3.03 ns |     2.83 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     297.0 ns |     2.87 ns |     2.68 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     340.1 ns |     1.68 ns |     1.58 ns |   8,437 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     369.5 ns |     3.06 ns |     2.86 ns |   3,253 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     420.9 ns |     3.10 ns |     2.90 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     559.9 ns |     6.35 ns |     5.94 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     577.7 ns |     4.94 ns |     4.62 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     601.5 ns |     4.84 ns |     4.53 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     647.3 ns |     3.92 ns |     3.47 ns |   8,935 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,641.0 ns |     9.70 ns |     9.07 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,066.1 ns |     9.60 ns |     8.02 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,186.2 ns |    20.05 ns |    16.74 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,241.0 ns |    21.34 ns |    19.96 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,542.6 ns |    28.44 ns |    26.60 ns |   8,897 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,631.2 ns |    12.59 ns |    11.16 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,068.8 ns |    15.81 ns |    14.79 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,189.0 ns |    20.67 ns |    17.26 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,241.2 ns |    23.47 ns |    21.95 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,524.1 ns |    21.39 ns |    20.00 ns |   8,897 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  12,407.0 ns |    94.02 ns |    83.35 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  14,804.5 ns |    76.30 ns |    63.71 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  16,644.3 ns |   201.78 ns |   178.87 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  16,944.0 ns |   132.73 ns |   110.84 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  19,038.8 ns |   115.94 ns |   102.78 ns |   8,913 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 194,951.7 ns |   919.56 ns |   815.17 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 233,914.7 ns | 1,937.91 ns | 1,812.72 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 263,310.4 ns | 4,985.25 ns | 4,419.30 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 268,028.2 ns | 3,098.02 ns | 2,897.89 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 299,699.6 ns | 1,020.60 ns |   796.82 ns |   8,913 B |         - |