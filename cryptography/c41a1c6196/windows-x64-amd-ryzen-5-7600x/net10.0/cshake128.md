| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128B         |     245.1 ns |   0.64 ns |   0.54 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128B         |     318.4 ns |   0.47 ns |   0.44 ns |   5,115 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128B         |     328.5 ns |   0.37 ns |   0.33 ns |   4,144 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128B         |     379.5 ns |   0.63 ns |   0.56 ns |   7,656 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 137B         |     245.6 ns |   1.03 ns |   0.91 ns |   5,624 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 137B         |     316.9 ns |   0.66 ns |   0.61 ns |   5,115 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 137B         |     329.9 ns |   0.44 ns |   0.42 ns |   4,128 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 137B         |     381.1 ns |   1.13 ns |   0.94 ns |   7,656 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1KB          |   1,629.3 ns |   5.28 ns |   4.68 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1KB          |   2,132.4 ns |   2.94 ns |   2.75 ns |   5,097 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1KB          |   2,179.4 ns |   3.02 ns |   2.82 ns |   4,112 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1KB          |   2,506.7 ns |   5.80 ns |   5.14 ns |   8,248 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 1025B        |   1,632.1 ns |   5.07 ns |   4.49 ns |   5,608 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 1025B        |   2,131.7 ns |   2.28 ns |   2.13 ns |   5,099 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 1025B        |   2,187.4 ns |   3.18 ns |   2.97 ns |   4,112 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 1025B        |   2,517.8 ns |   5.69 ns |   5.05 ns |   8,243 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 8KB          |  11,301.1 ns |  25.77 ns |  22.84 ns |   5,612 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 8KB          |  14,860.1 ns |  14.29 ns |  13.36 ns |   5,103 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 8KB          |  15,112.7 ns |  20.43 ns |  19.11 ns |   4,116 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 8KB          |  17,495.1 ns |  29.15 ns |  24.34 ns |   8,253 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar  | 128KB        | 179,608.8 ns | 429.93 ns | 381.12 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2    | 128KB        | 235,970.2 ns | 276.46 ns | 258.60 ns |   5,097 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX512F | 128KB        | 240,799.0 ns | 302.15 ns | 282.63 ns |   4,110 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle        | 128KB        | 278,687.9 ns | 867.54 ns | 769.05 ns |   8,241 B |         - |