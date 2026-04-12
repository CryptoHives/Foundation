| Description                                            | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128B         |      87.74 ns |     0.489 ns |     0.457 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128B         |     104.92 ns |     0.978 ns |     0.817 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128B         |     384.08 ns |     7.299 ns |     7.495 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128B         |     531.44 ns |    10.630 ns |    15.245 ns |    1216 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 137B         |     168.07 ns |     0.845 ns |     0.749 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 137B         |     186.91 ns |     3.166 ns |     2.961 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 137B         |     755.03 ns |    14.912 ns |    14.646 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 137B         |     969.46 ns |    16.571 ns |    15.500 ns |    1232 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1KB          |     632.14 ns |     3.317 ns |     3.102 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1KB          |     723.32 ns |     5.715 ns |     5.346 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1KB          |   2,984.66 ns |    57.453 ns |    53.741 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1KB          |   3,187.52 ns |    35.358 ns |    31.344 ns |    2112 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1025B        |     715.55 ns |     4.179 ns |     3.909 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1025B        |     807.60 ns |     6.285 ns |     5.879 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1025B        |   3,367.87 ns |    66.353 ns |    65.167 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1025B        |   3,630.80 ns |    65.039 ns |    57.656 ns |    2120 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 8KB          |   5,014.34 ns |    38.857 ns |    34.446 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 8KB          |   5,644.53 ns |    29.162 ns |    27.279 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 8KB          |  23,834.69 ns |   311.551 ns |   276.182 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 8KB          |  24,378.11 ns |   187.710 ns |   175.585 ns |    9280 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128KB        |  80,025.78 ns |   358.905 ns |   335.720 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128KB        |  90,141.16 ns |   445.854 ns |   417.052 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128KB        | 380,325.03 ns | 4,191.431 ns | 3,920.667 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128KB        | 417,042.78 ns | 4,849.698 ns | 4,536.410 ns |  132174 B |