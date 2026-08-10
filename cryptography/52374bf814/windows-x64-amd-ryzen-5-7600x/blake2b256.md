| Description                                            | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128B         |      98.77 ns |     0.182 ns |     0.161 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128B         |     107.30 ns |     0.247 ns |     0.231 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128B         |     364.75 ns |     1.445 ns |     1.352 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128B         |     486.42 ns |     2.493 ns |     2.332 ns |    1120 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 137B         |     186.87 ns |     0.528 ns |     0.494 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 137B         |     204.71 ns |     0.640 ns |     0.599 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 137B         |     715.95 ns |     4.027 ns |     3.767 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 137B         |     909.54 ns |     1.678 ns |     1.401 ns |    1136 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1KB          |     717.79 ns |     2.119 ns |     1.982 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1KB          |     819.39 ns |     2.971 ns |     2.779 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1KB          |   2,819.30 ns |     6.932 ns |     6.145 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1KB          |   2,993.45 ns |     4.124 ns |     3.655 ns |    2016 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1025B        |     801.14 ns |     2.909 ns |     2.721 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1025B        |     924.95 ns |     4.650 ns |     4.349 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1025B        |   3,172.66 ns |    10.301 ns |     9.635 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1025B        |   3,413.68 ns |    11.563 ns |    10.816 ns |    2024 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 8KB          |   5,639.65 ns |    16.957 ns |    14.160 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 8KB          |   6,524.74 ns |    18.712 ns |    16.588 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 8KB          |  22,588.89 ns |    47.420 ns |    42.036 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 8KB          |  23,084.37 ns |    74.722 ns |    69.895 ns |    9184 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128KB        |  88,882.87 ns |   191.387 ns |   159.816 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128KB        | 104,729.18 ns |   158.411 ns |   148.178 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128KB        | 360,613.04 ns |   767.925 ns |   641.252 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128KB        | 394,263.23 ns | 1,333.598 ns | 1,247.448 ns |  132078 B |