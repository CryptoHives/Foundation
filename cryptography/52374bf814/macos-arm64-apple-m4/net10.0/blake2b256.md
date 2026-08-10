| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128B         |     126.8 ns |     0.13 ns |     0.12 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 128B         |     224.2 ns |     2.35 ns |     2.20 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128B         |     386.8 ns |     1.52 ns |     1.27 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128B         |     588.5 ns |     5.59 ns |     4.96 ns |    1120 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 137B         |     231.8 ns |     0.39 ns |     0.31 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 137B         |     440.5 ns |     3.09 ns |     2.74 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 137B         |     763.0 ns |     2.62 ns |     2.32 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 137B         |   1,119.7 ns |    21.75 ns |    23.28 ns |    1136 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1KB          |     869.8 ns |     0.86 ns |     0.76 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 1KB          |   1,758.5 ns |    33.42 ns |    35.76 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1KB          |   3,018.0 ns |    14.26 ns |    11.91 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1KB          |   3,984.4 ns |    78.04 ns |   146.57 ns |    2016 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1025B        |     974.9 ns |     1.78 ns |     1.66 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 1025B        |   1,973.8 ns |    15.20 ns |    13.47 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1025B        |   3,445.9 ns |    10.55 ns |     9.87 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1025B        |   4,235.6 ns |    23.97 ns |    22.42 ns |    2024 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 8KB          |   6,795.9 ns |     3.04 ns |     2.84 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 8KB          |  13,796.2 ns |     9.73 ns |     9.10 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 8KB          |  24,216.6 ns |   101.22 ns |    89.73 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 8KB          |  28,571.0 ns |    69.23 ns |    64.75 ns |    9184 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128KB        | 108,377.6 ns |    56.67 ns |    47.32 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 128KB        | 220,543.9 ns |    41.81 ns |    37.06 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128KB        | 386,270.7 ns | 1,292.85 ns | 1,209.33 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128KB        | 463,095.6 ns | 1,105.01 ns | 1,033.63 ns |  132092 B |