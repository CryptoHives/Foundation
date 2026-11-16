| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Median       | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128B         |     245.9 ns |     1.96 ns |     1.74 ns |     245.3 ns |   5,619 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128B         |     316.1 ns |     0.32 ns |     0.27 ns |     316.1 ns |   5,114 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128B         |     327.3 ns |     0.49 ns |     0.41 ns |     327.1 ns |   4,127 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128B         |     383.1 ns |     3.07 ns |     2.56 ns |     382.3 ns |   7,653 B |         - |
|                                                  |              |              |             |             |              |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 137B         |     514.8 ns |    11.09 ns |    30.54 ns |     506.1 ns |   5,603 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 137B         |     630.8 ns |    12.42 ns |    11.62 ns |     626.5 ns |   5,090 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 137B         |     650.1 ns |     7.73 ns |     7.23 ns |     651.9 ns |   4,103 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 137B         |     767.4 ns |    15.36 ns |    30.68 ns |     754.0 ns |   8,931 B |         - |
|                                                  |              |              |             |             |              |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1KB          |   1,883.7 ns |    23.38 ns |    20.73 ns |   1,874.9 ns |   5,607 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1KB          |   2,481.0 ns |    27.18 ns |    25.43 ns |   2,489.4 ns |   5,098 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1KB          |   2,539.1 ns |    21.43 ns |    20.04 ns |   2,544.2 ns |   4,111 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1KB          |   2,886.0 ns |    48.56 ns |    45.42 ns |   2,860.6 ns |   8,890 B |         - |
|                                                  |              |              |             |             |              |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 1025B        |   1,893.8 ns |    14.62 ns |    13.67 ns |   1,887.1 ns |   5,607 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 1025B        |   2,451.8 ns |    30.15 ns |    28.20 ns |   2,438.1 ns |   5,098 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 1025B        |   2,481.4 ns |     1.85 ns |     1.54 ns |   2,480.8 ns |   4,116 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 1025B        |   2,899.1 ns |    10.63 ns |     8.88 ns |   2,899.3 ns |   8,914 B |         - |
|                                                  |              |              |             |             |              |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 8KB          |  14,408.6 ns |   251.31 ns |   209.85 ns |  14,429.8 ns |   5,606 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 8KB          |  18,418.9 ns |    32.38 ns |    30.29 ns |  18,422.9 ns |   5,097 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 8KB          |  18,999.2 ns |   249.99 ns |   233.84 ns |  18,837.8 ns |   4,110 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 8KB          |  22,038.4 ns |   108.17 ns |    90.33 ns |  22,007.2 ns |   8,900 B |         - |
|                                                  |              |              |             |             |              |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar  | 128KB        | 222,818.8 ns | 1,619.30 ns | 1,435.47 ns | 222,103.1 ns |   5,605 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2    | 128KB        | 289,715.2 ns |   200.43 ns |   177.68 ns | 289,750.5 ns |   5,096 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX512F | 128KB        | 298,663.6 ns | 1,003.58 ns |   938.75 ns | 298,758.3 ns |   4,109 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle        | 128KB        | 341,000.7 ns | 1,891.25 ns | 1,676.55 ns | 340,704.3 ns |   8,900 B |         - |