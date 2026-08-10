| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128B         |     129.0 ns |     0.12 ns |     0.11 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 128B         |     232.6 ns |     0.60 ns |     0.56 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128B         |     394.1 ns |     1.24 ns |     1.16 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128B         |     610.2 ns |     2.28 ns |     2.14 ns |    1216 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 137B         |     233.8 ns |     0.14 ns |     0.13 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 137B         |     445.4 ns |     5.57 ns |     5.21 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 137B         |     779.0 ns |     2.10 ns |     1.97 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 137B         |   1,118.5 ns |     4.42 ns |     4.14 ns |    1232 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1KB          |     872.4 ns |     0.54 ns |     0.50 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 1KB          |   1,744.5 ns |     4.81 ns |     4.50 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1KB          |   3,087.7 ns |    10.91 ns |    10.20 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1KB          |   3,790.6 ns |    19.74 ns |    18.47 ns |    2112 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1025B        |     977.5 ns |     1.47 ns |     1.38 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 1025B        |   2,009.4 ns |    39.35 ns |    43.73 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1025B        |   3,477.3 ns |     8.41 ns |     7.87 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1025B        |   4,313.9 ns |    24.88 ns |    23.27 ns |    2120 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 8KB          |   6,801.7 ns |     3.51 ns |     3.28 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 8KB          |  13,895.6 ns |    67.48 ns |    63.12 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 8KB          |  24,667.8 ns |    72.71 ns |    68.02 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 8KB          |  29,061.3 ns |    78.42 ns |    73.35 ns |    9280 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128KB        | 108,415.7 ns |    69.42 ns |    64.94 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 128KB        | 222,170.2 ns | 1,126.74 ns | 1,053.96 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128KB        | 394,592.4 ns | 1,469.54 ns | 1,374.60 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128KB        | 470,910.8 ns | 1,174.52 ns | 1,098.65 ns |  132188 B |