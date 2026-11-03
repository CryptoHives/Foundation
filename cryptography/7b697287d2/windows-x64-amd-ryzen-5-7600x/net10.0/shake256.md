| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     243.3 ns |   1.05 ns |   0.98 ns |   5,585 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     316.2 ns |   0.20 ns |   0.19 ns |   5,076 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     326.5 ns |   0.31 ns |   0.29 ns |   4,089 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     378.3 ns |   0.40 ns |   0.37 ns |   5,856 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     414.4 ns |   0.96 ns |   0.85 ns |   1,515 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     470.6 ns |   0.45 ns |   0.40 ns |   5,565 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     614.6 ns |   0.46 ns |   0.43 ns |   5,056 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     636.7 ns |   0.43 ns |   0.40 ns |   4,069 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     680.6 ns |   1.51 ns |   1.33 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     726.6 ns |   1.38 ns |   1.29 ns |   7,229 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,840.2 ns |   1.50 ns |   1.33 ns |   5,573 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,321.2 ns |   6.70 ns |   5.59 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,413.3 ns |   1.48 ns |   1.38 ns |   5,069 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,475.5 ns |   1.11 ns |   0.98 ns |   4,077 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,838.4 ns |   3.35 ns |   3.13 ns |   7,175 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,841.8 ns |   2.54 ns |   2.25 ns |   5,578 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,325.8 ns |   4.40 ns |   4.11 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,410.7 ns |   0.95 ns |   0.84 ns |   5,064 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,475.1 ns |   1.17 ns |   1.10 ns |   4,077 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,838.0 ns |   3.81 ns |   3.56 ns |   7,194 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  13,923.2 ns |  25.12 ns |  23.49 ns |   5,572 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  16,712.9 ns |  49.65 ns |  46.44 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  18,256.1 ns |  11.45 ns |  10.15 ns |   5,063 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  18,746.6 ns |   6.98 ns |   6.53 ns |   4,076 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  21,465.4 ns |  27.15 ns |  24.07 ns |   7,194 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 219,613.9 ns | 294.02 ns | 245.52 ns |   5,571 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 261,786.4 ns | 721.44 ns | 639.53 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 288,291.0 ns | 134.34 ns | 125.66 ns |   5,062 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 296,040.6 ns | 208.18 ns | 184.55 ns |   4,075 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 337,852.3 ns | 455.09 ns | 403.43 ns |   7,185 B |         - |