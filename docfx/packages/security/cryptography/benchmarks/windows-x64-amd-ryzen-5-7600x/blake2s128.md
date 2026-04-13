| Description                                             | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128B         |     155.7 ns |      0.58 ns |      0.51 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128B         |     157.9 ns |      1.20 ns |      1.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128B         |     158.6 ns |      0.62 ns |      0.58 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128B         |     158.7 ns |      1.00 ns |      0.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128B         |     161.1 ns |      1.20 ns |      1.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128B         |     607.1 ns |     10.52 ns |      9.84 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 137B         |     227.3 ns |      0.32 ns |      0.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 137B         |     237.7 ns |      1.16 ns |      1.03 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 137B         |     239.8 ns |      0.45 ns |      0.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 137B         |     242.7 ns |      0.78 ns |      0.73 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 137B         |     244.1 ns |      0.34 ns |      0.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 137B         |     908.7 ns |     14.29 ns |     13.37 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1KB          |   1,140.1 ns |      4.10 ns |      3.83 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1KB          |   1,212.5 ns |      4.71 ns |      4.18 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1KB          |   1,218.3 ns |      1.30 ns |      1.21 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1KB          |   1,231.5 ns |      6.43 ns |      6.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1KB          |   1,246.1 ns |      1.65 ns |      1.55 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1KB          |   4,752.6 ns |     91.89 ns |     85.96 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1025B        |   1,209.1 ns |      3.59 ns |      3.00 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1025B        |   1,293.7 ns |      2.69 ns |      2.39 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1025B        |   1,298.8 ns |      1.96 ns |      1.74 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1025B        |   1,305.6 ns |      4.09 ns |      3.62 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1025B        |   1,327.8 ns |      2.20 ns |      1.95 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1025B        |   5,027.1 ns |     73.74 ns |     68.97 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 8KB          |   9,009.1 ns |     37.17 ns |     34.77 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 8KB          |   9,633.7 ns |     27.19 ns |     25.43 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 8KB          |   9,675.5 ns |     33.05 ns |     30.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 8KB          |   9,700.8 ns |      9.82 ns |      8.71 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 8KB          |   9,890.5 ns |     17.38 ns |     16.26 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 8KB          |  37,797.2 ns |    588.44 ns |    550.43 ns |         - |
|                                                         |              |              |              |              |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128KB        | 144,012.4 ns |    467.75 ns |    414.65 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128KB        | 153,897.9 ns |    398.12 ns |    352.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128KB        | 154,663.5 ns |  1,151.18 ns |    961.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128KB        | 154,861.5 ns |    143.94 ns |    127.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128KB        | 158,433.0 ns |    218.83 ns |    204.70 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128KB        | 606,575.6 ns | 11,435.06 ns | 11,230.76 ns |         - |