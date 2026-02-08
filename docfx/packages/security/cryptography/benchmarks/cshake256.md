| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · Managed      | 128B         |     256.9 ns |     1.71 ns |     1.51 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128B         |     326.6 ns |     1.63 ns |     1.36 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128B         |     336.3 ns |     1.22 ns |     1.08 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128B         |     337.4 ns |     1.28 ns |     1.13 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 137B         |     501.4 ns |     3.97 ns |     3.52 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 137B         |     635.0 ns |     3.97 ns |     3.72 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 137B         |     647.7 ns |     2.93 ns |     2.74 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 137B         |     663.3 ns |     2.83 ns |     2.51 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 1KB          |   1,668.1 ns |     9.43 ns |     8.82 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1KB          |   2,243.4 ns |     3.46 ns |     2.89 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1KB          |   2,332.5 ns |    14.72 ns |    13.77 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1KB          |   2,471.4 ns |    16.47 ns |    15.40 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 1025B        |   1,660.8 ns |    11.48 ns |    10.74 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 1025B        |   2,243.4 ns |    11.99 ns |    10.01 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 1025B        |   2,335.4 ns |    10.60 ns |     9.39 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1025B        |   2,485.7 ns |    17.92 ns |    15.89 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 8KB          |  12,167.6 ns |    82.58 ns |    73.20 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 8KB          |  16,644.6 ns |    78.47 ns |    73.40 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 8KB          |  17,311.5 ns |    99.18 ns |    77.44 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 8KB          |  18,652.7 ns |   108.80 ns |   101.77 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · Managed      | 128KB        | 191,500.2 ns | 1,011.90 ns |   897.02 ns |         - |
| TryComputeHash · cSHAKE256 · AVX2         | 128KB        | 262,554.7 ns | 1,605.03 ns | 1,422.82 ns |         - |
| TryComputeHash · cSHAKE256 · AVX512F      | 128KB        | 271,228.3 ns | 1,094.74 ns |   914.16 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128KB        | 295,631.4 ns | 3,060.19 ns | 2,862.51 ns |         - |