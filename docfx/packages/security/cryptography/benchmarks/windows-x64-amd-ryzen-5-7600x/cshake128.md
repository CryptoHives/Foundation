| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · Managed      | 128B         |     243.2 ns |   1.59 ns |   1.41 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128B         |     316.5 ns |   1.23 ns |   1.09 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128B         |     323.8 ns |   1.85 ns |   1.54 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128B         |     333.7 ns |   0.99 ns |   0.93 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 137B         |     241.8 ns |   1.06 ns |   0.94 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 137B         |     312.8 ns |   0.83 ns |   0.74 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 137B         |     320.6 ns |   1.18 ns |   0.99 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 137B         |     334.0 ns |   2.23 ns |   2.09 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 1KB          |   1,488.3 ns |  14.73 ns |  13.06 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1KB          |   1,994.0 ns |   6.82 ns |   6.38 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1KB          |   2,047.9 ns |   5.14 ns |   4.56 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1KB          |   2,164.9 ns |   6.48 ns |   5.42 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 1025B        |   1,485.1 ns |   7.98 ns |   7.47 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 1025B        |   2,016.1 ns |   6.09 ns |   5.69 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 1025B        |   2,041.5 ns |   5.81 ns |   5.44 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1025B        |   2,170.2 ns |  11.75 ns |  10.42 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 8KB          |   9,742.4 ns |  46.32 ns |  38.68 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 8KB          |  13,312.8 ns |  41.62 ns |  34.75 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 8KB          |  13,600.8 ns |  23.09 ns |  21.60 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 8KB          |  15,056.2 ns |  49.15 ns |  43.57 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · Managed      | 128KB        | 154,680.8 ns | 661.00 ns | 618.30 ns |         - |
| TryComputeHash · cSHAKE128 · AVX2         | 128KB        | 211,334.1 ns | 295.35 ns | 276.28 ns |         - |
| TryComputeHash · cSHAKE128 · AVX512F      | 128KB        | 215,808.6 ns | 543.06 ns | 481.41 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128KB        | 238,815.8 ns | 443.33 ns | 393.00 ns |         - |