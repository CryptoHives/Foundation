| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     220.0 ns |   0.29 ns |   0.28 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     290.9 ns |   0.80 ns |   0.71 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     298.8 ns |   1.56 ns |   1.53 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     346.6 ns |   0.46 ns |   0.40 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     219.5 ns |   0.41 ns |   0.36 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     287.8 ns |   0.84 ns |   0.78 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     298.0 ns |   1.69 ns |   1.50 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     347.1 ns |   0.43 ns |   0.38 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,451.7 ns |   2.69 ns |   2.24 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   1,925.6 ns |   4.25 ns |   3.77 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   1,974.2 ns |   8.46 ns |   7.06 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,246.3 ns |   3.18 ns |   2.66 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,456.2 ns |   2.81 ns |   2.49 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   1,921.8 ns |   6.38 ns |   5.96 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   1,971.2 ns |   5.53 ns |   4.62 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,245.0 ns |   4.02 ns |   3.76 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  10,061.4 ns |  12.91 ns |  10.78 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  13,365.6 ns |  27.93 ns |  24.76 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  13,661.0 ns |  36.62 ns |  34.26 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  15,618.8 ns |  23.81 ns |  22.27 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 160,558.3 ns | 368.92 ns | 288.03 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 213,050.1 ns | 748.64 ns | 663.65 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 217,378.2 ns | 541.89 ns | 452.50 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 247,866.7 ns | 577.16 ns | 511.64 ns |         - |