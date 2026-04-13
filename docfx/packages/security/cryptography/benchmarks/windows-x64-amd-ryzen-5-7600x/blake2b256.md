| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128B         |      86.57 ns |     1.198 ns |     1.062 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      95.71 ns |     0.237 ns |     0.198 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     100.22 ns |     0.982 ns |     0.918 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     175.40 ns |     1.784 ns |     1.669 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     504.20 ns |     7.624 ns |     7.131 ns |    1120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 137B         |     165.97 ns |     0.371 ns |     0.290 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     181.51 ns |     3.557 ns |     3.806 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     182.75 ns |     2.685 ns |     2.511 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     337.60 ns |     0.889 ns |     0.743 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |     930.42 ns |     3.748 ns |     3.129 ns |    1136 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1KB          |     631.49 ns |     2.072 ns |     1.730 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     652.82 ns |     1.631 ns |     1.362 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     731.13 ns |    11.829 ns |    10.486 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |   1,332.75 ns |    12.260 ns |    11.468 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,162.75 ns |    18.167 ns |    16.105 ns |    2016 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1025B        |     715.41 ns |     2.291 ns |     2.031 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     735.36 ns |     2.251 ns |     1.996 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     810.15 ns |     2.231 ns |     1.863 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |   1,478.00 ns |     3.626 ns |     3.028 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   3,574.53 ns |     4.863 ns |     4.061 ns |    2024 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 8KB          |   5,111.23 ns |   100.642 ns |    98.844 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,230.70 ns |    48.862 ns |    45.706 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   5,696.75 ns |    29.243 ns |    24.419 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |  10,475.66 ns |    41.591 ns |    38.905 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  24,381.79 ns |   291.123 ns |   243.100 ns |    9184 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  81,593.08 ns |   360.243 ns |   319.346 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128KB        |  83,230.07 ns | 1,457.537 ns | 1,559.548 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        |  92,111.67 ns |   379.216 ns |   316.663 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        | 167,350.18 ns |   743.924 ns |   621.211 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 417,658.58 ns | 2,338.404 ns | 2,072.934 ns |  132078 B |