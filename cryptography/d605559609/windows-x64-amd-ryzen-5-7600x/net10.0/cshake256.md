| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     219.5 ns |     1.10 ns |     1.03 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     286.6 ns |     1.29 ns |     1.20 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     296.5 ns |     1.03 ns |     0.92 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     335.3 ns |     1.05 ns |     0.93 ns |   9,099 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     429.5 ns |     7.67 ns |     6.40 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     560.0 ns |     4.29 ns |     3.58 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     574.2 ns |     1.84 ns |     1.63 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     640.1 ns |     2.80 ns |     2.48 ns |   9,740 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,665.4 ns |     3.89 ns |     3.64 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,188.5 ns |    22.32 ns |    17.42 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,242.6 ns |    12.27 ns |    10.24 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,536.5 ns |    11.01 ns |     9.76 ns |   9,713 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,658.7 ns |     7.53 ns |     7.05 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,196.7 ns |    11.75 ns |     9.81 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,241.6 ns |    13.96 ns |    11.66 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,537.4 ns |    12.53 ns |    11.11 ns |   9,698 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  12,515.8 ns |    48.42 ns |    42.92 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  16,651.0 ns |   136.38 ns |   113.89 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  16,967.3 ns |    68.35 ns |    57.07 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  19,294.0 ns |   122.90 ns |   102.63 ns |   9,712 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 198,547.7 ns | 1,377.91 ns | 1,221.48 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 261,814.3 ns | 1,664.47 ns | 1,556.94 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 268,024.6 ns | 1,542.74 ns | 1,288.26 ns |        NA |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 303,452.8 ns | 1,735.25 ns | 1,354.77 ns |   9,713 B |         - |