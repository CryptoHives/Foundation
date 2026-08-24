| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     218.9 ns |   0.39 ns |   0.33 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     287.1 ns |   0.79 ns |   0.66 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     298.4 ns |   0.94 ns |   0.78 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     331.1 ns |   0.31 ns |   0.27 ns |   8,053 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     383.0 ns |   0.94 ns |   0.84 ns |   3,224 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     217.6 ns |   0.35 ns |   0.29 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     286.4 ns |   0.78 ns |   0.69 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     296.8 ns |   1.15 ns |   0.96 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     331.3 ns |   0.42 ns |   0.39 ns |   8,053 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     368.3 ns |   0.60 ns |   0.47 ns |   3,224 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,447.2 ns |   2.72 ns |   2.41 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   1,826.2 ns |   3.21 ns |   3.00 ns |   3,226 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   1,919.8 ns |   4.47 ns |   3.73 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   1,968.1 ns |   5.16 ns |   4.31 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,198.0 ns |   5.25 ns |   4.65 ns |   9,276 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,446.3 ns |   3.15 ns |   2.46 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   1,827.4 ns |   2.61 ns |   2.44 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   1,921.5 ns |   6.75 ns |   6.32 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   1,980.7 ns |   5.71 ns |   5.06 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,196.9 ns |   3.01 ns |   2.35 ns |   9,278 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  10,058.1 ns |  18.51 ns |  17.31 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  12,068.0 ns |  20.45 ns |  19.13 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  13,396.7 ns |  23.11 ns |  20.49 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  13,630.9 ns |  24.96 ns |  23.35 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  15,249.2 ns |  20.95 ns |  18.57 ns |   9,290 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 159,717.5 ns | 303.19 ns | 253.18 ns |        NA |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 190,805.3 ns | 250.72 ns | 195.75 ns |   3,224 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 212,789.8 ns | 599.71 ns | 500.79 ns |        NA |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 217,178.7 ns | 396.95 ns | 351.88 ns |        NA |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 243,463.8 ns | 581.12 ns | 515.15 ns |   9,286 B |         - |