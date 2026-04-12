| Description                               | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · Managed      | 128B         |     248.8 ns |     2.00 ns |   1.77 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128B         |     317.3 ns |     1.75 ns |   1.56 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128B         |     323.7 ns |     1.25 ns |   1.17 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128B         |     337.4 ns |     2.05 ns |   1.82 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 137B         |     244.0 ns |     1.92 ns |   1.80 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 137B         |     313.6 ns |     1.61 ns |   1.50 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 137B         |     320.5 ns |     1.11 ns |   0.98 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 137B         |     337.8 ns |     1.45 ns |   1.36 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 1KB          |   1,508.6 ns |    11.07 ns |  10.36 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1KB          |   2,002.8 ns |     5.00 ns |   4.68 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1KB          |   2,060.6 ns |     9.39 ns |   8.32 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1KB          |   2,186.2 ns |    16.09 ns |  14.26 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 1025B        |   1,505.7 ns |     7.84 ns |   7.33 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1025B        |   1,999.1 ns |     5.40 ns |   5.05 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1025B        |   2,048.7 ns |     5.53 ns |   5.17 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1025B        |   2,193.2 ns |    16.51 ns |  15.45 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 8KB          |   9,926.9 ns |    63.53 ns |  59.42 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 8KB          |  13,335.1 ns |    34.82 ns |  29.08 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 8KB          |  13,641.7 ns |    16.39 ns |  15.33 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 8KB          |  15,212.3 ns |    79.40 ns |  74.27 ns |         - |
|                                           |              |              |             |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 128KB        | 157,339.9 ns |   683.71 ns | 606.09 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128KB        | 211,181.4 ns |   374.94 ns | 292.73 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128KB        | 216,104.8 ns |   645.90 ns | 572.58 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128KB        | 241,888.8 ns | 1,044.95 ns | 977.44 ns |         - |