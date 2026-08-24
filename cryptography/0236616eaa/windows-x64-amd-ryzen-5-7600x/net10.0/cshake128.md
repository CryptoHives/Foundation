| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     219.6 ns |   0.40 ns |   0.37 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     287.7 ns |   1.23 ns |   1.03 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     297.1 ns |   0.52 ns |   0.48 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     333.7 ns |   0.92 ns |   0.81 ns |   9,127 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     219.5 ns |   0.85 ns |   0.75 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     286.5 ns |   1.09 ns |   1.02 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     297.1 ns |   0.92 ns |   0.86 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     335.7 ns |   0.68 ns |   0.57 ns |   9,120 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,452.1 ns |   2.68 ns |   2.38 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   1,920.2 ns |  10.22 ns |   8.54 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   1,966.7 ns |   5.40 ns |   5.06 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,206.4 ns |   5.12 ns |   4.54 ns |   9,681 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,450.9 ns |   2.45 ns |   2.17 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   1,921.4 ns |   8.83 ns |   7.37 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   1,964.2 ns |   5.15 ns |   4.57 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,202.5 ns |   6.33 ns |   5.29 ns |   9,692 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  10,066.6 ns |  15.86 ns |  14.83 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  13,340.0 ns |  22.72 ns |  18.97 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  13,624.6 ns |  28.52 ns |  22.27 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  15,384.2 ns |  33.78 ns |  31.60 ns |   9,695 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 160,104.8 ns | 369.75 ns | 288.68 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 212,392.6 ns | 565.70 ns | 472.39 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 216,908.9 ns | 375.19 ns | 332.60 ns |        NA |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 244,426.0 ns | 321.57 ns | 285.07 ns |   9,683 B |         - |