| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128B         |      86.03 ns |     0.600 ns |     0.532 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |     100.90 ns |     1.932 ns |     1.897 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     104.13 ns |     0.253 ns |     0.225 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     178.16 ns |     1.034 ns |     0.916 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     543.03 ns |     9.037 ns |     8.453 ns |    1216 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 137B         |     167.61 ns |     0.971 ns |     0.908 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     177.70 ns |     0.538 ns |     0.450 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     186.26 ns |     3.723 ns |     3.824 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     339.67 ns |     2.471 ns |     2.311 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |     930.45 ns |     7.830 ns |     7.324 ns |    1232 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1KB          |     625.91 ns |     2.600 ns |     2.304 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     650.03 ns |     4.762 ns |     4.454 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     717.67 ns |     2.016 ns |     1.886 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |   1,287.70 ns |     4.170 ns |     3.901 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,089.76 ns |    19.595 ns |    18.329 ns |    2112 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1025B        |     711.66 ns |     6.036 ns |     5.646 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     732.17 ns |     4.650 ns |     4.350 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     806.89 ns |     5.274 ns |     4.404 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |   1,465.99 ns |     8.604 ns |     8.049 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   3,509.01 ns |    23.648 ns |    22.120 ns |    2120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 8KB          |   4,971.42 ns |    20.580 ns |    18.243 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,071.71 ns |    28.543 ns |    26.699 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   5,590.79 ns |    19.342 ns |    17.146 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |  10,246.39 ns |    65.031 ns |    60.830 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  23,703.41 ns |   156.571 ns |   146.457 ns |    9280 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128KB        |  79,512.24 ns |   424.724 ns |   376.507 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  80,862.06 ns |   371.825 ns |   329.613 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        |  89,202.02 ns |   382.540 ns |   357.829 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        | 164,326.98 ns |   461.566 ns |   409.167 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 399,631.54 ns | 2,314.776 ns | 2,051.989 ns |  132174 B |