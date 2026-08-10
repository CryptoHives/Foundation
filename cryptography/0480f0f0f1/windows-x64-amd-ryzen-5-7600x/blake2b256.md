| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128B         |      87.62 ns |     1.764 ns |     1.733 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      96.09 ns |     0.978 ns |     0.915 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     100.05 ns |     0.978 ns |     0.914 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     139.03 ns |     2.707 ns |     3.325 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     496.29 ns |     9.784 ns |    14.032 ns |    1120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 137B         |     166.17 ns |     1.516 ns |     1.344 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     177.54 ns |     1.342 ns |     1.190 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     186.97 ns |     1.546 ns |     1.447 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     259.22 ns |     5.042 ns |     4.952 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |     947.04 ns |    17.987 ns |    17.666 ns |    1136 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1KB          |     630.13 ns |     4.220 ns |     3.947 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     653.33 ns |     2.750 ns |     2.572 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     716.37 ns |     3.574 ns |     2.984 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |     987.51 ns |    19.435 ns |    18.180 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,145.06 ns |    62.759 ns |    77.074 ns |    2016 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 1025B        |     711.48 ns |     4.542 ns |     4.249 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     730.82 ns |     5.407 ns |     5.057 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     803.72 ns |     6.398 ns |     5.342 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |   1,100.77 ns |    15.878 ns |    14.075 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   3,565.09 ns |    71.265 ns |    84.836 ns |    2024 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 8KB          |   4,974.12 ns |    31.228 ns |    29.211 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,093.12 ns |    29.185 ns |    27.300 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   5,591.12 ns |    28.034 ns |    23.409 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |   7,738.33 ns |   142.733 ns |   126.529 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  24,103.01 ns |   461.986 ns |   432.142 ns |    9184 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                     | 128KB        |  79,534.90 ns |   413.658 ns |   386.936 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  80,742.72 ns |   316.183 ns |   264.027 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        |  89,437.68 ns |   513.170 ns |   480.020 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        | 124,605.86 ns | 2,484.490 ns | 3,400.799 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 407,812.83 ns | 8,064.829 ns | 7,920.740 ns |  132078 B |