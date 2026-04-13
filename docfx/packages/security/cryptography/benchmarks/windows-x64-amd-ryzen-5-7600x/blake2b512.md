| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128B         |      87.04 ns |     0.637 ns |     0.565 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |      98.92 ns |     0.927 ns |     0.821 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     104.30 ns |     0.759 ns |     0.710 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     156.79 ns |     2.495 ns |     2.334 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     521.20 ns |    10.200 ns |    15.576 ns |    1216 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 137B         |     166.87 ns |     2.393 ns |     1.998 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     179.68 ns |     1.804 ns |     1.599 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     186.47 ns |     3.657 ns |     3.421 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     297.73 ns |     4.681 ns |     4.149 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |     946.30 ns |    18.544 ns |    17.346 ns |    1232 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1KB          |     627.75 ns |     7.770 ns |     6.488 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     650.01 ns |     4.287 ns |     4.011 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     721.91 ns |     5.964 ns |     5.287 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |   1,147.31 ns |    15.356 ns |    14.364 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,130.45 ns |    50.272 ns |    44.565 ns |    2112 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1025B        |     709.66 ns |     4.914 ns |     4.597 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     733.75 ns |     4.033 ns |     3.773 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     805.49 ns |     4.113 ns |     3.847 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |   1,289.22 ns |    16.529 ns |    15.461 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   3,559.94 ns |    67.175 ns |    65.975 ns |    2120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 8KB          |   4,975.39 ns |    37.276 ns |    33.045 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,056.92 ns |     9.194 ns |     8.600 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   5,597.36 ns |    20.041 ns |    18.746 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |   9,015.87 ns |    65.088 ns |    54.352 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  23,791.04 ns |   250.971 ns |   234.759 ns |    9280 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128KB        |  79,381.02 ns |   510.445 ns |   452.496 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  81,268.23 ns |   245.821 ns |   229.941 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        |  89,067.50 ns |   202.408 ns |   189.332 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        | 146,038.19 ns | 2,057.717 ns | 1,924.790 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 404,870.66 ns | 7,102.644 ns | 6,643.818 ns |  132174 B |