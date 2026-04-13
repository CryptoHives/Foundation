| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128B         |     156.3 ns |     0.36 ns |     0.34 ns |     156.2 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128B         |     157.6 ns |     0.15 ns |     0.13 ns |     157.6 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128B         |     158.0 ns |     0.90 ns |     0.80 ns |     157.7 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128B         |     161.2 ns |     0.26 ns |     0.24 ns |     161.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128B         |     161.3 ns |     0.23 ns |     0.20 ns |     161.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128B         |     597.3 ns |     2.65 ns |     2.21 ns |     597.5 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 137B         |     233.0 ns |     0.87 ns |     0.77 ns |     233.0 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 137B         |     237.0 ns |     0.60 ns |     0.53 ns |     237.1 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 137B         |     239.6 ns |     0.41 ns |     0.38 ns |     239.4 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 137B         |     244.6 ns |     0.45 ns |     0.42 ns |     244.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 137B         |     245.5 ns |     1.40 ns |     1.31 ns |     245.8 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 137B         |     887.0 ns |     2.87 ns |     2.54 ns |     886.7 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1KB          |   1,175.9 ns |    21.79 ns |    58.53 ns |   1,147.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1KB          |   1,210.1 ns |     6.55 ns |     6.12 ns |   1,209.8 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1KB          |   1,216.0 ns |     1.25 ns |     1.17 ns |   1,216.0 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1KB          |   1,241.4 ns |     1.68 ns |     1.57 ns |   1,241.4 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1KB          |   1,435.0 ns |    11.38 ns |    10.64 ns |   1,435.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1KB          |   4,762.4 ns |    41.47 ns |    38.79 ns |   4,748.0 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 1025B        |   1,216.1 ns |     9.51 ns |     7.94 ns |   1,214.9 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 1025B        |   1,289.3 ns |     8.65 ns |     8.09 ns |   1,286.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 1025B        |   1,301.8 ns |     7.64 ns |     7.14 ns |   1,297.8 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 1025B        |   1,312.2 ns |     7.56 ns |     6.32 ns |   1,310.9 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 1025B        |   1,332.1 ns |     8.01 ns |     7.49 ns |   1,331.0 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 1025B        |   4,983.6 ns |    45.03 ns |    42.12 ns |   4,980.9 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 8KB          |   9,019.3 ns |    35.78 ns |    29.88 ns |   9,019.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 8KB          |   9,664.1 ns |    27.99 ns |    24.81 ns |   9,664.2 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 8KB          |   9,696.9 ns |    73.17 ns |    68.45 ns |   9,685.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 8KB          |   9,760.7 ns |    15.90 ns |    13.28 ns |   9,754.0 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 8KB          |   9,980.3 ns |    21.00 ns |    17.53 ns |   9,982.5 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 8KB          |  38,621.4 ns |   751.84 ns |   738.41 ns |  38,277.2 ns |         - |
|                                                         |              |              |             |             |              |           |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Blake2Fast) | 128KB        | 146,018.0 ns | 2,749.36 ns | 2,571.75 ns | 145,178.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle             | 128KB        | 154,859.0 ns | 1,517.70 ns | 1,267.34 ns | 154,601.3 ns |         - |
| TryComputeHash · BLAKE2s-256 · Ssse3                    | 128KB        | 156,376.3 ns |   181.89 ns |   161.24 ns | 156,391.6 ns |         - |
| TryComputeHash · BLAKE2s-256 · AVX2                     | 128KB        | 156,721.3 ns |   581.59 ns |   485.65 ns | 156,729.6 ns |         - |
| TryComputeHash · BLAKE2s-256 · Sse2                     | 128KB        | 159,418.3 ns |   294.20 ns |   275.19 ns | 159,416.8 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed                  | 128KB        | 607,289.3 ns | 6,288.24 ns | 5,574.36 ns | 606,842.5 ns |         - |