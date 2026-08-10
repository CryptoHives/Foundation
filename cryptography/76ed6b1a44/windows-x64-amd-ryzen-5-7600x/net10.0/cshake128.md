| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     211.6 ns |     1.47 ns |     1.31 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     283.3 ns |     0.67 ns |     0.63 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     294.2 ns |     1.13 ns |     1.06 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     335.8 ns |     1.91 ns |     1.60 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     211.3 ns |     1.88 ns |     1.57 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     283.1 ns |     0.27 ns |     0.24 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     294.4 ns |     0.86 ns |     0.81 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     336.2 ns |     1.75 ns |     1.46 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,409.3 ns |     7.17 ns |     6.71 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   1,904.3 ns |     3.85 ns |     3.21 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   1,955.7 ns |     6.22 ns |     5.20 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,186.8 ns |    12.46 ns |    11.66 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,405.4 ns |     5.10 ns |     4.26 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   1,906.6 ns |     5.31 ns |     4.44 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   1,957.2 ns |     9.93 ns |     9.29 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,178.2 ns |     8.29 ns |     6.92 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |   9,778.7 ns |    48.74 ns |    43.20 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  13,249.0 ns |    24.35 ns |    21.59 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  13,579.4 ns |    21.48 ns |    20.09 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  15,101.7 ns |    48.35 ns |    37.75 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 156,207.9 ns | 1,016.70 ns |   848.99 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 210,981.7 ns |   334.86 ns |   313.22 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 216,154.9 ns |   389.36 ns |   345.16 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 239,817.8 ns | 1,081.52 ns | 1,011.66 ns |         - |