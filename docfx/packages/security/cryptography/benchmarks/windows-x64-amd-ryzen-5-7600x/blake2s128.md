| Description                                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128B         |     158.0 ns |     0.76 ns |     0.71 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128B         |     158.7 ns |     0.55 ns |     0.49 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128B         |     158.9 ns |     1.20 ns |     0.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128B         |     160.1 ns |     0.78 ns |     0.73 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128B         |     161.0 ns |     0.63 ns |     0.59 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128B         |     607.9 ns |    10.28 ns |     9.62 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 137B         |     231.9 ns |     0.55 ns |     0.51 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 137B         |     238.4 ns |     2.00 ns |     1.78 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 137B         |     240.2 ns |     0.56 ns |     0.52 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 137B         |     244.6 ns |     1.43 ns |     1.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 137B         |     244.6 ns |     0.60 ns |     0.56 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 137B         |     908.7 ns |    11.46 ns |    10.72 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1KB          |   1,144.7 ns |     3.63 ns |     3.39 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1KB          |   1,219.3 ns |     5.90 ns |     5.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1KB          |   1,219.4 ns |     1.98 ns |     1.76 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1KB          |   1,227.2 ns |     3.01 ns |     2.81 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1KB          |   1,245.0 ns |     1.55 ns |     1.37 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1KB          |   4,815.4 ns |    94.95 ns |   123.47 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 1025B        |   1,216.6 ns |     4.91 ns |     4.60 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 1025B        |   1,297.2 ns |     6.32 ns |     5.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 1025B        |   1,299.2 ns |     1.35 ns |     1.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 1025B        |   1,303.3 ns |     4.98 ns |     4.66 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 1025B        |   1,328.7 ns |     1.90 ns |     1.69 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 1025B        |   5,065.4 ns |    97.72 ns |   104.56 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 8KB          |   9,034.4 ns |    42.30 ns |    39.57 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 8KB          |   9,657.2 ns |    26.66 ns |    23.63 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 8KB          |   9,717.9 ns |    70.87 ns |    66.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 8KB          |   9,720.7 ns |    20.73 ns |    18.37 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 8KB          |   9,908.9 ns |    22.64 ns |    20.07 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 8KB          |  37,886.7 ns |   750.02 ns |   664.87 ns |         - |
|                                                         |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · BLAKE2s-128 (Blake2Fast) | 128KB        | 144,031.9 ns |   536.53 ns |   501.87 ns |     136 B |
| TryComputeHash · BLAKE2s-128 · BouncyCastle             | 128KB        | 153,741.5 ns |   318.87 ns |   282.67 ns |         - |
| TryComputeHash · BLAKE2s-128 · Ssse3                    | 128KB        | 154,956.5 ns |   218.84 ns |   204.70 ns |         - |
| TryComputeHash · BLAKE2s-128 · AVX2                     | 128KB        | 155,415.0 ns | 1,088.94 ns | 1,018.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · Sse2                     | 128KB        | 158,493.9 ns |   314.22 ns |   293.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · Managed                  | 128KB        | 605,164.8 ns | 7,953.89 ns | 7,050.92 ns |         - |