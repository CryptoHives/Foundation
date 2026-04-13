| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128B         |      86.00 ns |     1.038 ns |     0.971 ns |      85.95 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |      99.35 ns |     1.108 ns |     1.037 ns |      99.00 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     103.29 ns |     1.245 ns |     1.164 ns |     102.97 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     136.60 ns |     1.905 ns |     1.591 ns |     136.58 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     525.00 ns |    10.487 ns |    19.953 ns |     515.60 ns |    1216 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 137B         |     167.92 ns |     1.070 ns |     1.001 ns |     167.83 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     179.02 ns |     1.151 ns |     1.077 ns |     178.90 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     185.39 ns |     3.057 ns |     2.859 ns |     186.06 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     259.12 ns |     5.017 ns |     6.523 ns |     256.78 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |     952.02 ns |    19.005 ns |    21.887 ns |     951.86 ns |    1232 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1KB          |     630.22 ns |     3.850 ns |     3.601 ns |     628.79 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     649.39 ns |     2.919 ns |     2.279 ns |     649.16 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     728.13 ns |     3.260 ns |     3.049 ns |     727.81 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |     976.88 ns |    19.193 ns |    20.537 ns |     968.45 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,152.70 ns |    57.946 ns |    51.367 ns |   3,145.98 ns |    2112 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 1025B        |     711.36 ns |     3.915 ns |     3.662 ns |     709.83 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     735.19 ns |     4.353 ns |     4.072 ns |     733.75 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     809.10 ns |     4.297 ns |     4.019 ns |     808.54 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |   1,108.03 ns |    22.140 ns |    21.744 ns |   1,099.31 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   3,619.11 ns |    71.746 ns |    67.111 ns |   3,597.04 ns |    2120 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 8KB          |   4,977.64 ns |    29.231 ns |    27.343 ns |   4,979.30 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,094.11 ns |    37.533 ns |    35.108 ns |   5,083.28 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   5,594.71 ns |    23.816 ns |    22.278 ns |   5,590.93 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |   7,714.45 ns |   138.236 ns |   122.542 ns |   7,743.02 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  24,028.93 ns |   479.074 ns |   491.974 ns |  23,932.05 ns |    9280 B |
|                                                         |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-512 · AVX2                     | 128KB        |  79,356.52 ns |   351.857 ns |   293.816 ns |  79,325.20 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  81,126.81 ns |   477.077 ns |   446.258 ns |  80,947.47 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        |  89,266.18 ns |   523.788 ns |   437.387 ns |  89,211.81 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        | 122,427.12 ns | 1,784.676 ns | 1,669.387 ns | 121,847.58 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 407,919.43 ns | 7,878.411 ns | 8,756.833 ns | 406,472.80 ns |  132174 B |