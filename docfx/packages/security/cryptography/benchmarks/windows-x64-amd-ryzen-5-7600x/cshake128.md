| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     245.9 ns |   0.84 ns |   0.79 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     314.8 ns |   1.45 ns |   1.28 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     321.1 ns |   1.25 ns |   0.98 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     334.1 ns |   1.19 ns |   1.12 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     240.9 ns |   0.85 ns |   0.76 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     309.7 ns |   0.66 ns |   0.62 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     318.5 ns |   0.86 ns |   0.81 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     333.7 ns |   1.39 ns |   1.30 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,485.5 ns |   3.32 ns |   3.11 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   1,980.8 ns |   9.00 ns |   8.41 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   2,027.2 ns |   5.51 ns |   5.15 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,170.8 ns |   9.75 ns |   9.12 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,485.6 ns |   5.72 ns |   5.35 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   1,979.7 ns |   6.91 ns |   6.12 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   2,024.5 ns |   5.26 ns |   4.66 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,172.7 ns |   9.65 ns |   9.02 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |   9,787.9 ns |  29.97 ns |  28.04 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  13,200.1 ns |  19.47 ns |  17.26 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  13,510.5 ns |  39.72 ns |  33.16 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  15,063.7 ns |  63.39 ns |  59.29 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 155,292.5 ns | 658.05 ns | 615.54 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 209,713.7 ns | 354.10 ns | 313.90 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 214,699.5 ns | 341.21 ns | 319.17 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 239,585.2 ns | 530.12 ns | 495.87 ns |         - |