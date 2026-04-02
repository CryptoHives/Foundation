| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · Managed      | 128B         |     250.4 ns |     1.64 ns |     1.46 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128B         |     325.4 ns |     0.91 ns |     0.85 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128B         |     330.1 ns |     1.96 ns |     1.83 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128B         |     331.7 ns |     1.01 ns |     0.89 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 137B         |     502.0 ns |     3.86 ns |     3.61 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 137B         |     629.8 ns |     2.69 ns |     2.38 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 137B         |     653.0 ns |     1.38 ns |     1.22 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 137B         |     671.7 ns |     1.09 ns |     0.85 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 1KB          |   1,649.1 ns |     7.90 ns |     7.39 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1KB          |   2,237.4 ns |     4.41 ns |     3.68 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1KB          |   2,297.2 ns |     7.20 ns |     6.73 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1KB          |   2,455.3 ns |    15.41 ns |    14.42 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 1025B        |   1,654.9 ns |     6.05 ns |     5.36 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1025B        |   2,239.4 ns |     7.12 ns |     6.66 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1025B        |   2,300.2 ns |     7.05 ns |     5.89 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1025B        |   2,447.7 ns |     6.97 ns |     6.18 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 8KB          |  12,115.2 ns |    38.90 ns |    36.39 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 8KB          |  16,502.7 ns |    40.67 ns |    33.96 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 8KB          |  16,949.2 ns |    76.67 ns |    71.72 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 8KB          |  18,567.2 ns |    60.53 ns |    53.66 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 128KB        | 189,923.9 ns | 1,437.78 ns | 1,344.90 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128KB        | 259,461.3 ns |   746.12 ns |   697.92 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128KB        | 265,726.3 ns |   732.81 ns |   649.61 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128KB        | 292,811.5 ns | 1,825.53 ns | 1,707.61 ns |         - |