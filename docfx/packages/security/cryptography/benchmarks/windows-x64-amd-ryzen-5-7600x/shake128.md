| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     244.3 ns |     1.43 ns |     1.34 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     313.1 ns |     0.83 ns |     0.78 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     321.7 ns |     0.80 ns |     0.71 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     333.4 ns |     1.08 ns |     0.90 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     357.8 ns |     1.36 ns |     1.14 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     240.9 ns |     1.30 ns |     1.15 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     311.8 ns |     0.95 ns |     0.84 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     318.6 ns |     1.25 ns |     1.17 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     335.1 ns |     2.11 ns |     1.87 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     358.1 ns |     1.59 ns |     1.49 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,491.5 ns |     8.63 ns |     8.07 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   1,782.0 ns |     3.48 ns |     2.72 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   1,983.3 ns |     4.91 ns |     4.35 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   2,031.8 ns |     7.21 ns |     6.75 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,173.6 ns |     7.79 ns |     6.08 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,486.2 ns |     5.87 ns |     5.49 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   1,789.8 ns |     9.10 ns |     8.07 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   1,985.1 ns |    10.65 ns |     9.96 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   2,031.5 ns |     7.15 ns |     6.69 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,178.6 ns |     6.74 ns |     5.97 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |   9,813.7 ns |    46.52 ns |    43.51 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  11,775.1 ns |    66.56 ns |    59.01 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  13,225.3 ns |    25.39 ns |    22.51 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  13,614.0 ns |    17.24 ns |    13.46 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  15,107.7 ns |    54.40 ns |    45.42 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 155,994.3 ns |   751.81 ns |   703.24 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 186,054.0 ns | 1,249.99 ns | 1,169.24 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 209,970.5 ns |   358.27 ns |   335.12 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 214,489.9 ns |   235.51 ns |   196.66 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 240,833.7 ns |   599.23 ns |   500.39 ns |         - |