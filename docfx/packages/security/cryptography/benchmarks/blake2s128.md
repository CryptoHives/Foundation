| Description                                 | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128B         |     156.6 ns |     0.24 ns |   0.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128B         |     156.9 ns |     0.70 ns |   0.65 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128B         |     160.0 ns |     0.16 ns |   0.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128B         |     162.3 ns |     2.45 ns |   2.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128B         |     593.0 ns |     3.78 ns |   3.53 ns |         - |
|                                             |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 137B         |     235.4 ns |     0.53 ns |   0.50 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 137B         |     239.2 ns |     0.54 ns |   0.50 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 137B         |     243.1 ns |     1.59 ns |   1.24 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 137B         |     244.0 ns |     0.18 ns |   0.16 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 137B         |     883.9 ns |     3.99 ns |   3.73 ns |         - |
|                                             |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1KB          |   1,203.2 ns |     2.61 ns |   2.31 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1KB          |   1,215.2 ns |     1.00 ns |   0.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1KB          |   1,225.0 ns |     3.62 ns |   3.39 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1KB          |   1,241.5 ns |     1.66 ns |   1.55 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1KB          |   4,644.0 ns |    23.02 ns |  21.53 ns |         - |
|                                             |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1025B        |   1,287.3 ns |     2.71 ns |   2.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1025B        |   1,296.1 ns |     0.91 ns |   0.76 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1025B        |   1,299.3 ns |     2.93 ns |   2.74 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1025B        |   1,324.3 ns |     1.17 ns |   1.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1025B        |   4,925.0 ns |    22.87 ns |  20.27 ns |         - |
|                                             |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 8KB          |   9,592.6 ns |    15.91 ns |  14.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 8KB          |   9,659.6 ns |    26.50 ns |  22.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 8KB          |   9,680.3 ns |    10.52 ns |   9.84 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 8KB          |   9,889.1 ns |    10.53 ns |   9.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 8KB          |  37,084.5 ns |   162.22 ns | 151.74 ns |         - |
|                                             |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128KB        | 153,650.0 ns |   491.31 ns | 435.53 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128KB        | 153,760.9 ns |   565.84 ns | 529.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128KB        | 154,896.7 ns |   220.16 ns | 205.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128KB        | 158,149.3 ns |   191.20 ns | 178.85 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128KB        | 591,773.3 ns | 1,006.67 ns | 941.64 ns |         - |