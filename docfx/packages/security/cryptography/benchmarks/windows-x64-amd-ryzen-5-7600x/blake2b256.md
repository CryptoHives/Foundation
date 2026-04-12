| Description                                            | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128B         |      87.94 ns |     1.610 ns |     1.506 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128B         |     100.98 ns |     0.911 ns |     0.852 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128B         |     387.22 ns |     5.643 ns |     5.002 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128B         |     521.38 ns |    10.411 ns |    21.268 ns |    1120 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 137B         |     169.98 ns |     3.340 ns |     3.430 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 137B         |     195.94 ns |     2.320 ns |     2.170 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 137B         |     773.51 ns |    15.122 ns |    18.002 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 137B         |     974.25 ns |    19.510 ns |    33.654 ns |    1136 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1KB          |     627.71 ns |     3.940 ns |     3.685 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1KB          |     727.01 ns |     6.611 ns |     5.860 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1KB          |   3,007.04 ns |    57.602 ns |    70.740 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1KB          |   3,171.70 ns |    26.056 ns |    21.758 ns |    2016 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1025B        |     732.88 ns |    13.855 ns |    15.400 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1025B        |     808.27 ns |     6.412 ns |     5.998 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1025B        |   3,356.09 ns |    66.615 ns |    74.043 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1025B        |   3,602.54 ns |    65.236 ns |    61.022 ns |    2024 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 8KB          |   4,995.74 ns |    19.582 ns |    15.289 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 8KB          |   5,617.03 ns |    22.779 ns |    19.021 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 8KB          |  23,914.64 ns |   471.445 ns |   561.221 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 8KB          |  24,480.59 ns |   381.554 ns |   356.906 ns |    9184 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128KB        |  84,448.81 ns | 1,647.164 ns | 2,752.042 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128KB        |  88,982.88 ns |   671.300 ns |   627.934 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128KB        | 378,912.54 ns | 5,052.417 ns | 4,218.997 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128KB        | 414,485.68 ns | 7,916.450 ns | 8,129.611 ns |  132078 B |