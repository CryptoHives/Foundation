| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     250.8 ns |     1.30 ns |     1.21 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     322.6 ns |     1.06 ns |     0.94 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     329.3 ns |     0.84 ns |     0.65 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     331.9 ns |     0.71 ns |     0.63 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     355.6 ns |     1.48 ns |     1.31 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     505.8 ns |     3.29 ns |     3.08 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     589.7 ns |     2.95 ns |     2.76 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     631.5 ns |     2.13 ns |     1.89 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     649.0 ns |     1.96 ns |     1.73 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     666.2 ns |     2.16 ns |     1.92 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,662.4 ns |     8.24 ns |     7.71 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,015.4 ns |    13.69 ns |    12.13 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,225.8 ns |     4.11 ns |     3.84 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,285.7 ns |     5.37 ns |     5.03 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,469.9 ns |    10.41 ns |     9.74 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,657.8 ns |     5.78 ns |     4.83 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,018.5 ns |    28.19 ns |    24.99 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,225.6 ns |     6.81 ns |     6.04 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,283.6 ns |     5.12 ns |     4.54 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,468.2 ns |     8.75 ns |     7.76 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  12,134.8 ns |    51.88 ns |    48.53 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  14,468.6 ns |    29.52 ns |    24.65 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  16,456.5 ns |    97.00 ns |    85.99 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  16,829.1 ns |    36.37 ns |    32.24 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  18,620.0 ns |   115.57 ns |   102.45 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 190,275.0 ns |   764.58 ns |   715.18 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 227,408.5 ns | 1,409.07 ns | 1,176.64 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 258,405.2 ns |   916.83 ns |   715.80 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 264,475.1 ns |   774.73 ns |   724.68 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 294,377.0 ns | 1,238.14 ns | 1,158.16 ns |         - |