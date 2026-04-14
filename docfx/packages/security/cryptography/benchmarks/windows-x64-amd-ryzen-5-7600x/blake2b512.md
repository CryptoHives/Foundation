| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128B         |      85.97 ns |     1.157 ns |     1.082 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |      99.44 ns |     1.300 ns |     1.216 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     102.35 ns |     1.085 ns |     1.015 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     138.25 ns |     2.679 ns |     2.631 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     529.55 ns |    10.617 ns |    20.201 ns |    1216 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 137B         |     167.77 ns |     0.918 ns |     0.767 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     179.70 ns |     1.812 ns |     1.607 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     184.38 ns |     2.647 ns |     2.476 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     259.29 ns |     4.676 ns |     4.146 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |     963.20 ns |    14.382 ns |    13.453 ns |    1232 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1KB          |     628.78 ns |     2.889 ns |     2.702 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     650.68 ns |     3.782 ns |     3.538 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     720.43 ns |     5.740 ns |     5.369 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |     990.22 ns |    19.766 ns |    28.973 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,164.30 ns |    60.460 ns |    64.691 ns |    2112 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1025B        |     712.47 ns |     4.229 ns |     3.956 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     732.46 ns |     2.398 ns |     2.002 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     803.96 ns |     4.172 ns |     3.484 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |   1,106.75 ns |    21.722 ns |    25.858 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   3,557.07 ns |    49.337 ns |    43.736 ns |    2120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 8KB          |   4,958.14 ns |    15.924 ns |    14.116 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,075.71 ns |    24.351 ns |    21.587 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   5,600.21 ns |    12.466 ns |    11.051 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |   7,743.88 ns |   145.249 ns |   142.654 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  24,015.72 ns |   480.204 ns |   449.183 ns |    9280 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128KB        |  79,262.04 ns |   240.617 ns |   213.301 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  80,661.74 ns |   166.099 ns |   129.679 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        |  89,005.69 ns |   210.637 ns |   186.725 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        | 122,989.17 ns |   694.614 ns |   649.742 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 407,704.50 ns | 7,375.880 ns | 6,899.402 ns |  132174 B |