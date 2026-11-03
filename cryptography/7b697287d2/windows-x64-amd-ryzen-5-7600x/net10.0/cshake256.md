| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     242.4 ns |   0.80 ns |   0.74 ns |   5,619 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     316.2 ns |   0.23 ns |   0.21 ns |   5,110 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     326.5 ns |   0.33 ns |   0.31 ns |   4,127 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     379.2 ns |   0.54 ns |   0.48 ns |   7,653 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     471.4 ns |   0.66 ns |   0.62 ns |   5,599 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     615.3 ns |   0.35 ns |   0.31 ns |   5,090 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     637.9 ns |   0.53 ns |   0.50 ns |   4,101 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     723.9 ns |   0.86 ns |   0.81 ns |   8,931 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,840.6 ns |   2.38 ns |   2.11 ns |   5,607 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,410.6 ns |   1.46 ns |   1.36 ns |   5,098 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,478.2 ns |   2.21 ns |   1.96 ns |   4,115 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,825.2 ns |   3.47 ns |   3.08 ns |   8,903 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,841.2 ns |   2.60 ns |   2.43 ns |   5,607 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,415.4 ns |   0.60 ns |   0.56 ns |   5,098 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,479.8 ns |   1.90 ns |   1.68 ns |   4,111 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,846.2 ns |   4.43 ns |   4.14 ns |   8,905 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  13,954.3 ns |  30.28 ns |  28.33 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  18,276.4 ns |  10.65 ns |   9.96 ns |   5,097 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  18,764.4 ns |  14.44 ns |  13.51 ns |   4,110 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  21,479.5 ns |  25.94 ns |  24.26 ns |   8,911 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 220,006.2 ns | 425.60 ns | 355.39 ns |   5,605 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 288,720.4 ns | 145.78 ns | 136.36 ns |   5,096 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 296,378.9 ns | 268.10 ns | 250.78 ns |   4,109 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 338,145.9 ns | 397.22 ns | 371.56 ns |   8,905 B |         - |