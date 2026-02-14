| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128B         |     159.6 ns |     1.60 ns |     1.33 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128B         |     161.6 ns |     1.24 ns |     1.16 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128B         |     162.3 ns |     2.01 ns |     1.88 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128B         |     162.7 ns |     1.07 ns |     0.95 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128B         |     608.0 ns |     9.37 ns |     8.76 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 137B         |     242.3 ns |     0.96 ns |     0.80 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 137B         |     244.9 ns |     1.65 ns |     1.38 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 137B         |     245.5 ns |     4.93 ns |     5.27 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 137B         |     251.2 ns |     3.75 ns |     3.51 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 137B         |     896.7 ns |     7.74 ns |     6.86 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1KB          |   1,223.1 ns |     8.26 ns |     7.32 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1KB          |   1,237.8 ns |    13.01 ns |    11.53 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1KB          |   1,238.1 ns |    20.82 ns |    19.47 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1KB          |   1,260.9 ns |    18.10 ns |    16.04 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1KB          |   4,741.3 ns |    93.85 ns |    92.18 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 1025B        |   1,317.9 ns |    18.39 ns |    17.20 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 1025B        |   1,324.8 ns |    26.22 ns |    29.14 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 1025B        |   1,329.5 ns |    26.20 ns |    24.51 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 1025B        |   1,344.4 ns |    14.66 ns |    13.00 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 1025B        |   4,993.0 ns |    49.90 ns |    46.68 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 8KB          |   9,726.0 ns |   115.85 ns |    96.74 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 8KB          |   9,744.1 ns |    64.38 ns |    53.76 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 8KB          |   9,765.7 ns |   132.15 ns |   123.62 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 8KB          |  10,006.2 ns |   116.60 ns |   103.36 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 8KB          |  37,976.0 ns |   737.51 ns |   653.78 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle | 128KB        | 154,952.0 ns | 1,259.43 ns | 1,051.68 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2         | 128KB        | 155,754.7 ns | 2,006.08 ns | 1,778.34 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3        | 128KB        | 156,354.6 ns | 1,422.27 ns | 1,187.66 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2         | 128KB        | 159,288.7 ns |   885.89 ns |   785.32 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed      | 128KB        | 602,295.5 ns | 5,429.99 ns | 4,534.29 ns |         - |