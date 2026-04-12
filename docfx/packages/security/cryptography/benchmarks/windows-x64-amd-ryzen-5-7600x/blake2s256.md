| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128B         |     158.1 ns |     0.35 ns |     0.32 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128B         |     161.1 ns |     0.25 ns |     0.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128B         |     162.0 ns |     0.21 ns |     0.19 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128B         |     163.2 ns |     0.87 ns |     0.81 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128B         |     597.9 ns |     6.05 ns |     5.66 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 137B         |     236.9 ns |     0.95 ns |     0.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 137B         |     239.8 ns |     0.37 ns |     0.33 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 137B         |     244.5 ns |     0.21 ns |     0.20 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 137B         |     246.5 ns |     1.21 ns |     1.13 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 137B         |     891.8 ns |     6.59 ns |     6.16 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1KB          |   1,211.0 ns |     4.50 ns |     4.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1KB          |   1,216.5 ns |     1.84 ns |     1.73 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1KB          |   1,233.9 ns |     2.85 ns |     2.67 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1KB          |   1,241.9 ns |     1.38 ns |     1.29 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1KB          |   4,674.4 ns |    24.77 ns |    20.69 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1025B        |   1,291.3 ns |     5.57 ns |     5.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1025B        |   1,298.1 ns |     1.82 ns |     1.62 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1025B        |   1,310.4 ns |     3.24 ns |     2.88 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1025B        |   1,325.6 ns |     1.62 ns |     1.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1025B        |   4,967.9 ns |    32.27 ns |    28.60 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 8KB          |   9,640.7 ns |    47.98 ns |    44.88 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 8KB          |   9,684.5 ns |    18.39 ns |    16.30 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 8KB          |   9,689.1 ns |    10.96 ns |    10.25 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 8KB          |   9,888.7 ns |    11.86 ns |    10.52 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 8KB          |  37,314.9 ns |   345.06 ns |   288.14 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128KB        | 154,081.4 ns |   536.41 ns |   447.92 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128KB        | 154,083.3 ns |   608.03 ns |   568.76 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128KB        | 154,924.6 ns |   229.67 ns |   214.83 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128KB        | 158,210.1 ns |   295.99 ns |   276.87 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128KB        | 598,431.5 ns | 5,193.57 ns | 4,603.96 ns |         - |