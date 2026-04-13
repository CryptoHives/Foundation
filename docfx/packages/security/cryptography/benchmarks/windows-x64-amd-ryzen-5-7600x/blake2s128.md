| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128B         |     155.6 ns |     1.08 ns |     1.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128B         |     157.0 ns |     0.50 ns |     0.47 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128B         |     158.0 ns |     1.17 ns |     1.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128B         |     160.4 ns |     1.08 ns |     1.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128B         |     160.9 ns |     1.09 ns |     1.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128B         |     599.6 ns |     3.98 ns |     3.73 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 137B         |     228.1 ns |     1.24 ns |     1.16 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 137B         |     238.7 ns |     1.72 ns |     1.52 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 137B         |     240.2 ns |     1.56 ns |     1.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 137B         |     242.5 ns |     1.87 ns |     1.66 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 137B         |     244.7 ns |     1.51 ns |     1.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 137B         |     894.8 ns |     4.04 ns |     3.78 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1KB          |   1,142.2 ns |     6.26 ns |     5.86 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1KB          |   1,217.0 ns |     7.36 ns |     6.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1KB          |   1,218.6 ns |     3.89 ns |     3.24 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1KB          |   1,230.2 ns |     7.86 ns |     7.36 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1KB          |   1,248.7 ns |     7.32 ns |     6.85 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1KB          |   4,705.2 ns |    37.84 ns |    35.39 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1025B        |   1,215.2 ns |     8.54 ns |     7.99 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1025B        |   1,296.0 ns |     1.06 ns |     0.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1025B        |   1,299.8 ns |    10.74 ns |    10.04 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1025B        |   1,308.7 ns |     8.76 ns |     8.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1025B        |   1,328.5 ns |     3.33 ns |     3.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1025B        |   5,004.1 ns |    35.23 ns |    32.95 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 8KB          |   9,005.2 ns |    26.33 ns |    24.63 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 8KB          |   9,638.4 ns |    32.33 ns |    30.24 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 8KB          |   9,670.7 ns |    48.42 ns |    40.43 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 8KB          |   9,699.4 ns |    10.90 ns |    10.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 8KB          |   9,905.0 ns |    13.65 ns |    12.77 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 8KB          |  37,405.3 ns |   148.42 ns |   131.57 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128KB        | 143,956.7 ns |   418.43 ns |   391.40 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128KB        | 153,895.8 ns |   490.64 ns |   458.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128KB        | 154,549.4 ns |   657.81 ns |   615.32 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128KB        | 154,890.4 ns |   223.80 ns |   209.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128KB        | 158,461.0 ns |   241.72 ns |   226.11 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128KB        | 597,035.8 ns | 2,047.81 ns | 1,710.01 ns |         - |