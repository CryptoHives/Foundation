| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128B         |     157.7 ns |     0.28 ns |     0.26 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128B         |     158.0 ns |     0.38 ns |     0.33 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128B         |     160.8 ns |     0.21 ns |     0.19 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128B         |     161.7 ns |     0.70 ns |     0.62 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128B         |     594.6 ns |     3.66 ns |     3.43 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 137B         |     236.1 ns |     1.17 ns |     1.10 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 137B         |     239.7 ns |     0.30 ns |     0.28 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 137B         |     244.5 ns |     0.29 ns |     0.26 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 137B         |     245.6 ns |     0.48 ns |     0.43 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 137B         |     883.9 ns |     4.74 ns |     4.43 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1KB          |   1,206.2 ns |     2.89 ns |     2.56 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1KB          |   1,215.5 ns |     1.54 ns |     1.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1KB          |   1,230.9 ns |     3.97 ns |     3.52 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1KB          |   1,240.8 ns |     1.12 ns |     0.99 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1KB          |   4,631.9 ns |    15.03 ns |    13.32 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1025B        |   1,286.8 ns |     5.32 ns |     4.97 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1025B        |   1,297.5 ns |     1.10 ns |     1.03 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1025B        |   1,305.5 ns |     4.15 ns |     3.47 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1025B        |   1,325.0 ns |     0.99 ns |     0.92 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1025B        |   4,926.4 ns |    11.71 ns |    10.38 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 8KB          |   9,621.8 ns |    42.54 ns |    39.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 8KB          |   9,672.1 ns |    23.61 ns |    20.93 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 8KB          |   9,679.6 ns |    11.17 ns |    10.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 8KB          |   9,885.4 ns |     8.98 ns |     8.40 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 8KB          |  36,998.4 ns |   113.31 ns |   100.45 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128KB        | 153,491.8 ns |   438.60 ns |   366.25 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128KB        | 153,809.1 ns |   341.77 ns |   302.97 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128KB        | 154,941.4 ns |   165.67 ns |   154.97 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128KB        | 158,103.2 ns |   176.54 ns |   165.14 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128KB        | 592,589.6 ns | 1,672.05 ns | 1,482.23 ns |         - |