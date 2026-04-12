| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128B         |     157.3 ns |     0.50 ns |     0.47 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128B         |     158.6 ns |     0.98 ns |     0.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128B         |     160.2 ns |     0.31 ns |     0.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128B         |     162.0 ns |     1.27 ns |     1.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128B         |     595.9 ns |     4.89 ns |     4.57 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 137B         |     236.6 ns |     1.07 ns |     1.00 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 137B         |     239.4 ns |     0.48 ns |     0.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 137B         |     243.2 ns |     0.81 ns |     0.76 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 137B         |     244.1 ns |     0.46 ns |     0.43 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 137B         |     890.6 ns |     4.42 ns |     4.14 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1KB          |   1,212.7 ns |     5.83 ns |     5.45 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1KB          |   1,215.7 ns |     1.42 ns |     1.33 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1KB          |   1,234.2 ns |     1.27 ns |     1.06 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1KB          |   1,241.6 ns |     1.77 ns |     1.66 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1KB          |   4,673.5 ns |    30.65 ns |    27.17 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1025B        |   1,291.4 ns |     4.96 ns |     4.39 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1025B        |   1,296.8 ns |     1.52 ns |     1.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1025B        |   1,308.6 ns |     2.27 ns |     2.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1025B        |   1,324.6 ns |     0.94 ns |     0.83 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1025B        |   4,986.0 ns |    49.93 ns |    44.26 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 8KB          |   9,644.9 ns |    28.39 ns |    25.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 8KB          |   9,652.7 ns |    26.29 ns |    23.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 8KB          |   9,683.0 ns |    13.84 ns |    12.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 8KB          |   9,886.9 ns |     9.56 ns |     8.47 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 8KB          |  37,531.4 ns |   528.04 ns |   440.94 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128KB        | 154,333.8 ns |   682.76 ns |   570.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128KB        | 154,389.9 ns |   876.43 ns |   776.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128KB        | 154,900.2 ns |   171.03 ns |   159.98 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128KB        | 158,113.3 ns |   238.41 ns |   211.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128KB        | 596,021.5 ns | 3,885.56 ns | 3,634.56 ns |         - |