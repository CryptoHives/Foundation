| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     215.8 ns |   0.45 ns |   0.42 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     286.3 ns |   1.57 ns |   1.39 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     295.3 ns |   1.14 ns |   1.01 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     342.7 ns |   1.05 ns |   0.88 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     363.7 ns |   1.45 ns |   1.28 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     420.2 ns |   2.53 ns |   2.11 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     558.8 ns |   4.35 ns |   3.85 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     574.4 ns |   2.37 ns |   2.10 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     604.9 ns |   3.00 ns |   2.66 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     647.8 ns |   1.37 ns |   1.21 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,646.8 ns |   6.47 ns |   5.40 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,060.2 ns |  10.08 ns |   8.94 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,244.8 ns |  20.46 ns |  15.98 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,245.0 ns |  44.11 ns |  68.67 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,548.5 ns |  18.50 ns |  17.31 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,636.7 ns |   4.04 ns |   3.78 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,064.8 ns |   6.26 ns |   5.55 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,192.8 ns |  40.94 ns |  34.19 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,237.1 ns |  10.39 ns |   8.68 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,533.8 ns |   8.59 ns |   8.04 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  12,387.3 ns |  25.28 ns |  23.65 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  14,869.0 ns |  38.25 ns |  33.90 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  16,498.7 ns |  34.98 ns |  29.21 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  16,931.1 ns |  49.48 ns |  43.86 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  19,090.4 ns |  33.29 ns |  31.14 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 195,802.8 ns | 364.09 ns | 304.03 ns |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 233,177.1 ns | 578.34 ns | 482.94 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 261,033.4 ns | 802.70 ns | 670.29 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 267,174.2 ns | 733.11 ns | 685.75 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 303,270.5 ns | 726.13 ns | 643.70 ns |         - |