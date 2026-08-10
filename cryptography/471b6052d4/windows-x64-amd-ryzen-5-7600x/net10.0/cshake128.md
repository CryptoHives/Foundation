| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE128 · Managed      | 128B         |     257.6 ns |     5.07 ns |     6.94 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128B         |     328.2 ns |     5.12 ns |     4.79 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128B         |     336.4 ns |     6.59 ns |     6.16 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128B         |     346.5 ns |     6.67 ns |     6.24 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 137B         |     256.5 ns |     5.08 ns |     6.95 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 137B         |     326.4 ns |     6.43 ns |     7.40 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 137B         |     332.0 ns |     5.15 ns |     4.81 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 137B         |     348.1 ns |     6.74 ns |     7.21 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 1KB          |   1,556.4 ns |    29.02 ns |    27.15 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1KB          |   2,023.8 ns |    30.77 ns |    27.28 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1KB          |   2,089.4 ns |    41.56 ns |    46.19 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1KB          |   2,233.7 ns |    44.49 ns |    57.86 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 1025B        |   1,548.1 ns |    30.79 ns |    40.03 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1025B        |   2,025.4 ns |    29.48 ns |    28.95 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1025B        |   2,064.7 ns |    16.17 ns |    13.50 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1025B        |   2,231.9 ns |    43.26 ns |    38.35 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 8KB          |  10,300.2 ns |   204.19 ns |   235.15 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 8KB          |  13,515.4 ns |   148.16 ns |   138.59 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 8KB          |  13,864.5 ns |    85.53 ns |    71.42 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 8KB          |  15,915.0 ns |   287.61 ns |   307.74 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE128 · Managed      | 128KB        | 162,801.0 ns | 3,213.21 ns | 4,809.38 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128KB        | 214,898.5 ns | 2,345.07 ns | 1,958.24 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128KB        | 219,509.7 ns |   951.92 ns |   743.20 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128KB        | 249,286.3 ns | 4,833.24 ns | 5,171.52 ns |         - |