| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     248.2 ns |     2.18 ns |     1.93 ns |   5,589 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     321.2 ns |     3.21 ns |     3.01 ns |   5,076 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     326.6 ns |     0.41 ns |     0.38 ns |   4,089 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     385.7 ns |     2.65 ns |     2.48 ns |   5,847 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     419.6 ns |     3.59 ns |     2.80 ns |   1,515 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     475.2 ns |     2.58 ns |     2.15 ns |   5,565 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     616.7 ns |     0.96 ns |     0.85 ns |   5,056 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     637.2 ns |     0.62 ns |     0.55 ns |   4,073 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     696.6 ns |    11.30 ns |    10.02 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     729.7 ns |     2.57 ns |     2.15 ns |   7,216 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,852.6 ns |    11.10 ns |     9.84 ns |   5,578 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,332.0 ns |    12.25 ns |    11.46 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,416.7 ns |     2.22 ns |     2.08 ns |   5,064 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,479.6 ns |     1.99 ns |     1.76 ns |   4,077 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,865.9 ns |    21.08 ns |    19.71 ns |   7,175 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,850.7 ns |     9.87 ns |     8.24 ns |   5,577 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,339.2 ns |     4.40 ns |     3.44 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,433.4 ns |    25.69 ns |    24.03 ns |   5,064 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,478.2 ns |     2.09 ns |     1.95 ns |   4,077 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,852.3 ns |    27.65 ns |    24.51 ns |   7,190 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  13,912.8 ns |    32.14 ns |    26.84 ns |   5,572 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  16,757.4 ns |   121.92 ns |    95.18 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  18,529.8 ns |    88.33 ns |    73.76 ns |   5,063 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  19,070.6 ns |   280.70 ns |   262.57 ns |   4,076 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  21,527.9 ns |   110.65 ns |    98.09 ns |   7,189 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 220,933.6 ns | 1,105.76 ns |   980.23 ns |   5,571 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 261,897.1 ns | 1,150.37 ns | 1,076.05 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 288,699.3 ns |   276.86 ns |   216.15 ns |   5,062 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 296,607.8 ns |   260.09 ns |   203.06 ns |   4,075 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 339,445.1 ns |   806.29 ns |   629.50 ns |   7,172 B |         - |