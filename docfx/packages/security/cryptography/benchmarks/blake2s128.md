| Description                                 | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128B         |     162.5 ns |      3.27 ns |      3.64 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128B         |     165.9 ns |      2.09 ns |      1.95 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128B         |     171.3 ns |      3.25 ns |      2.88 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128B         |     173.4 ns |      3.48 ns |      3.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128B         |     614.9 ns |      9.69 ns |      9.07 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 137B         |     240.7 ns |      4.31 ns |      4.03 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 137B         |     248.0 ns |      4.23 ns |      3.95 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 137B         |     253.9 ns |      2.76 ns |      2.58 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 137B         |     255.0 ns |      4.94 ns |      6.06 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 137B         |     915.3 ns |     17.84 ns |     16.69 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1KB          |   1,245.7 ns |     18.88 ns |     16.74 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1KB          |   1,246.6 ns |     12.62 ns |     11.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1KB          |   1,270.0 ns |     25.26 ns |     44.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1KB          |   1,275.0 ns |     12.38 ns |     11.58 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1KB          |   4,843.5 ns |     92.50 ns |    113.60 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 1025B        |   1,313.6 ns |     18.00 ns |     15.96 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 1025B        |   1,343.5 ns |     26.15 ns |     24.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 1025B        |   1,344.0 ns |     26.64 ns |     24.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 1025B        |   1,366.8 ns |     20.34 ns |     19.03 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 1025B        |   5,138.8 ns |    101.50 ns |    148.77 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 8KB          |   9,676.1 ns |    139.23 ns |    123.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 8KB          |   9,903.5 ns |    145.83 ns |    136.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 8KB          |  10,095.0 ns |    196.48 ns |    218.39 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 8KB          |  10,200.4 ns |    196.31 ns |    201.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 8KB          |  38,191.9 ns |    607.29 ns |    568.06 ns |         - |
|                                             |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BouncyCastle | 128KB        | 155,297.7 ns |  2,545.60 ns |  2,381.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3        | 128KB        | 159,594.5 ns |  3,060.98 ns |  2,863.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2         | 128KB        | 159,788.8 ns |  3,022.08 ns |  3,103.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2         | 128KB        | 162,493.3 ns |  2,312.89 ns |  2,163.48 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed      | 128KB        | 614,902.4 ns | 11,357.41 ns | 11,154.49 ns |         - |