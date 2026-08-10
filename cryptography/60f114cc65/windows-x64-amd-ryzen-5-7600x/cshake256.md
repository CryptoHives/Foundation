| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · Managed      | 128B         |     258.2 ns |     4.88 ns |     4.32 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128B         |     324.6 ns |     1.11 ns |     1.04 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128B         |     333.9 ns |     0.85 ns |     0.76 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128B         |     336.1 ns |     2.14 ns |     2.01 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 137B         |     509.7 ns |     5.14 ns |     4.55 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 137B         |     637.1 ns |     4.91 ns |     4.60 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 137B         |     655.6 ns |     2.10 ns |     1.97 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 137B         |     673.7 ns |     1.74 ns |     1.54 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 1KB          |   1,678.6 ns |     8.02 ns |     7.50 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1KB          |   2,252.2 ns |     5.55 ns |     4.92 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1KB          |   2,302.5 ns |     7.57 ns |     7.08 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1KB          |   2,487.7 ns |    14.21 ns |    12.60 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 1025B        |   1,678.0 ns |    11.37 ns |    10.64 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1025B        |   2,241.6 ns |     8.28 ns |     7.74 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1025B        |   2,301.1 ns |     5.84 ns |     5.46 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1025B        |   2,483.6 ns |    11.32 ns |    10.04 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 8KB          |  12,267.4 ns |   100.82 ns |    89.38 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 8KB          |  16,525.7 ns |    33.80 ns |    31.62 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 8KB          |  16,931.3 ns |    69.13 ns |    57.72 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 8KB          |  18,775.3 ns |   127.14 ns |   118.92 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 128KB        | 191,936.4 ns |   912.46 ns |   761.94 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128KB        | 260,026.8 ns |   779.17 ns |   690.71 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128KB        | 265,955.4 ns | 1,015.81 ns |   950.19 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128KB        | 296,191.1 ns | 1,942.60 ns | 1,722.07 ns |         - |