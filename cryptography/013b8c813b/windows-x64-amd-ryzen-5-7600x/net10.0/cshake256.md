| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     217.0 ns |     0.31 ns |     0.25 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     287.1 ns |     1.75 ns |     1.46 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     295.8 ns |     1.82 ns |     1.52 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     343.4 ns |     0.30 ns |     0.25 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     420.8 ns |     0.56 ns |     0.53 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     558.0 ns |     1.51 ns |     1.26 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     576.5 ns |     3.88 ns |     3.44 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     653.6 ns |     2.77 ns |     2.31 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,649.9 ns |     2.54 ns |     2.26 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,179.2 ns |     7.05 ns |     6.60 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,236.5 ns |     9.32 ns |     8.26 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,650.3 ns |     2.97 ns |     2.48 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,647.3 ns |     3.68 ns |     2.87 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,181.4 ns |     7.57 ns |     7.08 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,239.2 ns |     4.58 ns |     3.83 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,547.2 ns |     2.05 ns |     1.92 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  12,422.4 ns |    31.25 ns |    27.70 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  16,531.3 ns |    92.97 ns |    77.63 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  16,936.2 ns |    39.71 ns |    33.16 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  19,176.3 ns |    25.71 ns |    21.47 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 196,478.9 ns |   323.60 ns |   302.69 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 261,632.8 ns | 1,402.61 ns | 1,243.38 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 267,381.8 ns | 1,176.32 ns |   918.39 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 303,375.5 ns |   424.20 ns |   376.04 ns |         - |