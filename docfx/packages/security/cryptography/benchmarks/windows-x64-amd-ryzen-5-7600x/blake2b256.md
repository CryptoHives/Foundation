| Description                                            | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128B         |      87.46 ns |     1.262 ns |     1.119 ns |      87.09 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128B         |     101.47 ns |     1.384 ns |     1.295 ns |     101.59 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128B         |     390.90 ns |     7.593 ns |     8.124 ns |     390.41 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128B         |     518.53 ns |     9.914 ns |    10.608 ns |     514.20 ns |    1120 B |
|                                                        |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 137B         |     168.34 ns |     1.321 ns |     1.171 ns |     168.38 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 137B         |     183.87 ns |     0.983 ns |     0.871 ns |     183.89 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 137B         |     771.89 ns |    15.171 ns |    19.726 ns |     769.23 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 137B         |     969.92 ns |    16.784 ns |    14.879 ns |     969.04 ns |    1136 B |
|                                                        |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1KB          |     658.91 ns |    13.167 ns |    28.623 ns |     647.23 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1KB          |     744.06 ns |    14.710 ns |    28.691 ns |     727.25 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1KB          |   2,989.50 ns |    25.533 ns |    19.935 ns |   2,995.47 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1KB          |   3,218.94 ns |    41.143 ns |    38.485 ns |   3,220.80 ns |    2016 B |
|                                                        |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1025B        |     735.98 ns |    14.704 ns |    20.127 ns |     731.65 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1025B        |     808.81 ns |     3.774 ns |     3.151 ns |     808.43 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1025B        |   3,462.12 ns |    53.123 ns |    47.092 ns |   3,465.86 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1025B        |   3,663.63 ns |    40.901 ns |    38.259 ns |   3,666.72 ns |    2024 B |
|                                                        |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 8KB          |   5,206.45 ns |   103.178 ns |   188.668 ns |   5,155.94 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 8KB          |   5,816.64 ns |   111.292 ns |   191.974 ns |   5,739.12 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 8KB          |  24,316.28 ns |   465.013 ns |   497.559 ns |  24,328.00 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 8KB          |  26,017.09 ns |   200.485 ns |   177.725 ns |  26,045.93 ns |    9184 B |
|                                                        |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128KB        |  79,965.65 ns |   567.167 ns |   530.529 ns |  80,096.53 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128KB        |  90,041.91 ns |   363.578 ns |   322.302 ns |  89,969.27 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128KB        | 381,892.70 ns | 3,512.969 ns | 3,286.033 ns | 382,991.89 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128KB        | 415,017.35 ns | 3,743.185 ns | 3,501.378 ns | 415,813.72 ns |  132078 B |