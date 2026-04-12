| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128B         |      87.59 ns |     0.703 ns |     0.658 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |     104.93 ns |     1.116 ns |     1.044 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     106.18 ns |     0.940 ns |     0.834 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     383.49 ns |     3.689 ns |     3.451 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     540.80 ns |    10.546 ns |    12.952 ns |    1216 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 137B         |     168.10 ns |     1.742 ns |     1.629 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     186.48 ns |     1.380 ns |     1.223 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     186.66 ns |     2.993 ns |     2.800 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     756.01 ns |    15.124 ns |    14.854 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |     965.53 ns |    14.504 ns |    13.567 ns |    1232 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1KB          |     631.13 ns |     3.250 ns |     2.881 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     664.95 ns |     6.370 ns |     5.958 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     718.99 ns |     3.042 ns |     2.540 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |   2,963.21 ns |    58.295 ns |    57.253 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,215.27 ns |    55.874 ns |    52.265 ns |    2112 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1025B        |     712.50 ns |     3.052 ns |     2.855 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     744.04 ns |     2.464 ns |     2.184 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     805.80 ns |     4.341 ns |     3.848 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |   3,341.11 ns |    50.841 ns |    47.557 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   3,606.81 ns |    46.034 ns |    43.060 ns |    2120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 8KB          |   4,997.54 ns |    36.832 ns |    34.453 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,105.87 ns |    35.919 ns |    33.598 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   5,598.33 ns |    30.760 ns |    27.268 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |  23,686.20 ns |   455.429 ns |   447.293 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  24,609.50 ns |   457.961 ns |   405.970 ns |    9280 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128KB        |  79,540.96 ns |   387.160 ns |   362.150 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  80,872.45 ns |   299.737 ns |   280.374 ns |     248 B |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        |  89,423.54 ns |   477.313 ns |   446.479 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        | 379,934.15 ns | 6,357.846 ns | 5,947.133 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 407,176.06 ns | 5,173.561 ns | 4,586.227 ns |  132174 B |