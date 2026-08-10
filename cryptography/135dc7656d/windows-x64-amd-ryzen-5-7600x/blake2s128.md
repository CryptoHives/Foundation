| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128B         |     158.2 ns |     0.48 ns |     0.45 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128B         |     158.3 ns |     0.67 ns |     0.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128B         |     158.9 ns |     2.18 ns |     1.93 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128B         |     163.0 ns |     2.11 ns |     1.97 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128B         |     596.8 ns |     1.73 ns |     1.53 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 137B         |     237.4 ns |     1.19 ns |     1.11 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 137B         |     240.6 ns |     0.84 ns |     0.66 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 137B         |     243.3 ns |     1.09 ns |     0.91 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 137B         |     245.6 ns |     0.60 ns |     0.56 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 137B         |     895.0 ns |     8.05 ns |     7.53 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1KB          |   1,218.7 ns |     2.81 ns |     2.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1KB          |   1,225.7 ns |    14.26 ns |    13.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1KB          |   1,227.2 ns |     3.20 ns |     2.50 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1KB          |   1,247.4 ns |     2.70 ns |     2.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1KB          |   4,682.4 ns |    29.11 ns |    24.30 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1025B        |   1,296.4 ns |     5.49 ns |     5.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1025B        |   1,303.3 ns |     2.77 ns |     2.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1025B        |   1,309.9 ns |    10.72 ns |    10.03 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1025B        |   1,333.5 ns |     3.80 ns |     3.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1025B        |   4,972.0 ns |    18.90 ns |    16.75 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 8KB          |   9,697.8 ns |    69.58 ns |    61.68 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 8KB          |   9,712.2 ns |    87.48 ns |    73.05 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 8KB          |   9,718.3 ns |    26.03 ns |    21.73 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 8KB          |   9,951.7 ns |    23.10 ns |    20.48 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 8KB          |  37,607.4 ns |   478.35 ns |   424.04 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128KB        | 154,890.9 ns | 1,429.09 ns | 1,266.85 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128KB        | 155,336.3 ns |   457.55 ns |   427.99 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128KB        | 157,423.7 ns | 2,592.44 ns | 2,424.97 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128KB        | 160,574.9 ns | 1,991.14 ns | 1,862.51 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128KB        | 598,904.3 ns | 3,504.74 ns | 2,926.61 ns |         - |