| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     222.4 ns |   0.84 ns |   0.79 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     289.2 ns |   1.35 ns |   1.19 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     297.6 ns |   1.63 ns |   1.52 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     335.6 ns |   0.68 ns |   0.56 ns |   8,062 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     372.2 ns |   1.45 ns |   1.35 ns |   3,224 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     222.2 ns |   0.37 ns |   0.29 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     287.5 ns |   1.13 ns |   1.06 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     297.6 ns |   1.15 ns |   0.90 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     335.9 ns |   1.04 ns |   0.87 ns |   8,071 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     375.4 ns |   1.98 ns |   1.75 ns |   3,224 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,474.0 ns |   2.82 ns |   2.21 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   1,857.1 ns |   3.57 ns |   2.98 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   1,924.8 ns |   8.39 ns |   7.44 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   1,971.3 ns |  12.10 ns |  10.10 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,235.8 ns |   8.67 ns |   7.69 ns |   9,284 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,472.6 ns |   3.78 ns |   3.16 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   1,870.2 ns |  11.52 ns |   9.62 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   1,928.1 ns |  14.30 ns |  12.67 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   1,966.7 ns |   5.77 ns |   4.82 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,240.2 ns |   7.12 ns |   5.95 ns |   9,286 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  10,217.6 ns |  29.35 ns |  26.02 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  12,248.1 ns |  15.82 ns |  12.35 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  13,452.8 ns |  71.97 ns |  60.10 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  13,679.4 ns |  76.62 ns |  71.67 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  15,564.1 ns |  29.34 ns |  24.50 ns |   9,338 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 163,038.2 ns | 330.14 ns | 292.66 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 193,182.1 ns | 302.82 ns | 236.42 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 213,593.0 ns | 480.90 ns | 426.30 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 217,181.3 ns | 712.40 ns | 631.52 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 247,288.3 ns | 943.29 ns | 836.20 ns |   9,278 B |         - |