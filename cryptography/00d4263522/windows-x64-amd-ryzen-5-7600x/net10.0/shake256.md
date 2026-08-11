| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     222.7 ns |     0.34 ns |     0.27 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     297.0 ns |     2.63 ns |     2.33 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     308.9 ns |     1.19 ns |     1.11 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     336.0 ns |     0.67 ns |     0.59 ns |   8,051 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     369.9 ns |     0.90 ns |     0.75 ns |   3,255 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     426.9 ns |     0.93 ns |     0.77 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     558.5 ns |     2.25 ns |     1.99 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     574.2 ns |     1.93 ns |     1.51 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     607.5 ns |     0.97 ns |     0.81 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     646.5 ns |     1.42 ns |     1.19 ns |   9,280 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,671.0 ns |     4.59 ns |     3.84 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,085.3 ns |     3.48 ns |     2.72 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,194.4 ns |     8.44 ns |     7.89 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,240.5 ns |     9.47 ns |     8.40 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,559.4 ns |    10.17 ns |     9.02 ns |   9,339 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,669.8 ns |     6.38 ns |     5.65 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,099.3 ns |     5.99 ns |     5.00 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,191.0 ns |     6.84 ns |     6.07 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,243.0 ns |     6.82 ns |     6.04 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,556.2 ns |     8.12 ns |     7.60 ns |   9,360 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  12,675.5 ns |    73.94 ns |    61.74 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  15,163.8 ns |    31.38 ns |    26.20 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  16,653.8 ns |    87.25 ns |    81.61 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  16,995.0 ns |   120.81 ns |   100.88 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  19,295.0 ns |    50.77 ns |    42.39 ns |   9,292 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 199,747.9 ns |   687.18 ns |   609.16 ns |        NA |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 237,698.4 ns |   787.57 ns |   736.69 ns |   3,253 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 262,600.2 ns | 1,155.14 ns | 1,024.00 ns |        NA |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 268,421.5 ns | 1,632.05 ns | 1,362.83 ns |        NA |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 306,554.0 ns |   784.16 ns |   654.81 ns |   9,335 B |         - |