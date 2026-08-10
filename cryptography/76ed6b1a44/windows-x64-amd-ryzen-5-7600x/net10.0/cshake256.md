| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     210.6 ns |     1.84 ns |     1.72 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     282.2 ns |     0.66 ns |     0.61 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     293.1 ns |     2.26 ns |     1.89 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     334.1 ns |     1.90 ns |     1.68 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     407.2 ns |     1.97 ns |     1.75 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     551.6 ns |     1.37 ns |     1.29 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     574.2 ns |     2.45 ns |     2.29 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     631.3 ns |     2.01 ns |     1.78 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,591.7 ns |     7.99 ns |     7.09 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,163.6 ns |     9.04 ns |     8.46 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,227.5 ns |     7.80 ns |     7.30 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,473.7 ns |    11.22 ns |    10.49 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,592.1 ns |     9.00 ns |     8.42 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,163.4 ns |     8.64 ns |     7.66 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,228.8 ns |     5.32 ns |     4.71 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,470.1 ns |    14.35 ns |    12.72 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  12,087.1 ns |    54.27 ns |    50.76 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  16,412.3 ns |    65.03 ns |    60.83 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  16,836.6 ns |    57.92 ns |    54.18 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  18,640.7 ns |    68.80 ns |    60.99 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 190,313.7 ns |   674.97 ns |   631.37 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 259,853.9 ns | 1,113.65 ns | 1,041.71 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 266,000.8 ns | 1,088.10 ns | 1,017.81 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 292,749.3 ns | 1,572.09 ns | 1,393.61 ns |         - |