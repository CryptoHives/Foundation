| Description                                            | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128B         |      93.30 ns |     0.591 ns |     0.524 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128B         |     103.63 ns |     0.862 ns |     0.806 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128B         |     391.19 ns |     6.748 ns |     5.982 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128B         |     546.46 ns |    10.293 ns |    10.109 ns |    1216 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 137B         |     168.64 ns |     2.053 ns |     1.820 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 137B         |     184.92 ns |     1.468 ns |     1.373 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 137B         |     758.14 ns |     7.946 ns |     7.044 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 137B         |     981.01 ns |    10.051 ns |     8.393 ns |    1232 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1KB          |     631.26 ns |     5.331 ns |     4.451 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1KB          |     737.01 ns |    14.751 ns |    15.784 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1KB          |   3,002.58 ns |    30.921 ns |    28.924 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1KB          |   3,227.18 ns |    63.402 ns |    77.863 ns |    2112 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1025B        |     717.65 ns |     9.831 ns |     8.210 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1025B        |     817.71 ns |    12.836 ns |    12.007 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1025B        |   3,360.37 ns |    64.421 ns |    63.270 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1025B        |   3,636.10 ns |    46.117 ns |    43.138 ns |    2120 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 8KB          |   5,092.52 ns |    69.561 ns |    58.086 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 8KB          |   5,624.61 ns |    26.204 ns |    21.882 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 8KB          |  24,000.15 ns |   360.452 ns |   319.531 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 8KB          |  24,450.98 ns |   219.652 ns |   205.463 ns |    9280 B |
|                                                        |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128KB        |  79,929.28 ns |   525.261 ns |   465.630 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128KB        |  90,545.56 ns |   382.308 ns |   319.244 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128KB        | 378,555.34 ns | 3,928.400 ns | 3,482.424 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128KB        | 415,197.55 ns | 2,259.150 ns | 1,886.493 ns |  132174 B |