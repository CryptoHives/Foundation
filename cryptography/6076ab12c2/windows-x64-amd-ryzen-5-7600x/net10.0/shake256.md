| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     254.4 ns |     1.47 ns |     1.30 ns |   5,583 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     317.9 ns |     1.13 ns |     1.06 ns |   5,094 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     328.1 ns |     0.57 ns |     0.51 ns |   4,089 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     385.6 ns |     0.85 ns |     0.75 ns |   5,847 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     426.2 ns |     1.27 ns |     1.13 ns |   1,515 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     478.2 ns |     1.96 ns |     1.83 ns |   5,565 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     619.7 ns |     2.12 ns |     1.99 ns |   5,074 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     638.5 ns |     1.91 ns |     1.79 ns |   4,069 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     691.7 ns |     3.11 ns |     2.91 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     733.9 ns |     1.97 ns |     1.85 ns |   7,225 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,875.3 ns |     4.69 ns |     4.39 ns |   5,577 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,346.6 ns |    11.97 ns |    10.61 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,424.7 ns |     4.98 ns |     4.66 ns |   5,082 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,490.6 ns |     7.58 ns |     7.09 ns |   4,077 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,878.3 ns |     9.96 ns |     9.31 ns |   7,185 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,890.9 ns |    23.57 ns |    22.05 ns |   5,573 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,434.0 ns |     7.85 ns |     7.34 ns |   5,082 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,491.0 ns |     5.05 ns |     4.72 ns |   4,077 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,566.9 ns |    19.63 ns |    18.36 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,894.0 ns |    28.50 ns |    26.65 ns |   7,195 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  14,287.9 ns |   171.98 ns |   160.87 ns |   5,572 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  17,185.9 ns |   200.62 ns |   187.66 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  18,422.5 ns |    87.37 ns |    81.72 ns |   5,081 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  18,864.6 ns |    50.21 ns |    44.51 ns |   4,076 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  22,074.2 ns |   182.98 ns |   162.20 ns |   7,191 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 221,910.5 ns | 1,259.98 ns | 1,178.59 ns |   5,571 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 265,327.3 ns | 3,618.55 ns | 3,384.79 ns |   1,515 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 289,227.4 ns |   268.27 ns |   250.94 ns |   5,080 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 296,815.0 ns |   764.93 ns |   715.51 ns |   4,075 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 342,109.7 ns | 2,454.04 ns | 2,295.51 ns |   7,185 B |         - |