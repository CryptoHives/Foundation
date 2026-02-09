| Description                               | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · Managed      | 128B         |     253.9 ns |     1.49 ns |   1.39 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128B         |     326.5 ns |     0.63 ns |   0.59 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128B         |     332.4 ns |     1.41 ns |   1.32 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128B         |     334.5 ns |     0.80 ns |   0.75 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE256 · Managed      | 137B         |     501.0 ns |     1.52 ns |   1.34 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 137B         |     630.3 ns |     2.25 ns |   2.10 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 137B         |     645.3 ns |     2.19 ns |   1.94 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 137B         |     661.3 ns |     2.25 ns |   2.11 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE256 · Managed      | 1KB          |   1,658.1 ns |     5.28 ns |   4.94 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1KB          |   2,238.2 ns |     7.01 ns |   6.56 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1KB          |   2,325.7 ns |     4.90 ns |   4.34 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1KB          |   2,464.9 ns |     5.69 ns |   5.32 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE256 · Managed      | 1025B        |   1,653.3 ns |     8.19 ns |   7.66 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1025B        |   2,237.0 ns |     5.48 ns |   4.86 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1025B        |   2,333.7 ns |     6.06 ns |   5.67 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1025B        |   2,453.7 ns |     4.52 ns |   3.78 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE256 · Managed      | 8KB          |  12,241.1 ns |   132.24 ns | 110.43 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 8KB          |  16,575.0 ns |    43.03 ns |  40.25 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 8KB          |  17,241.0 ns |    49.78 ns |  46.56 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 8KB          |  18,537.4 ns |    72.34 ns |  64.13 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE256 · Managed      | 128KB        | 189,916.8 ns |   398.58 ns | 332.84 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128KB        | 259,795.3 ns | 1,014.98 ns | 949.41 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128KB        | 271,097.8 ns |   859.74 ns | 762.14 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128KB        | 292,560.7 ns |   356.06 ns | 297.33 ns |         - |