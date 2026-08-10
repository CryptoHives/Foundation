| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128B         |     129.2 ns |     0.11 ns |     0.10 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 128B         |     227.1 ns |     1.02 ns |     0.96 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128B         |     386.6 ns |     1.06 ns |     0.99 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128B         |     596.6 ns |     2.26 ns |     2.12 ns |    1216 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 137B         |     234.0 ns |     0.16 ns |     0.15 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 137B         |     438.1 ns |     0.19 ns |     0.17 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 137B         |     762.1 ns |     2.69 ns |     2.51 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 137B         |   1,095.4 ns |     7.26 ns |     6.44 ns |    1232 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1KB          |     872.5 ns |     0.65 ns |     0.61 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 1KB          |   1,731.2 ns |     0.44 ns |     0.41 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1KB          |   3,022.8 ns |    10.77 ns |    10.08 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1KB          |   3,743.0 ns |    19.49 ns |    16.27 ns |    2112 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1025B        |     977.1 ns |     1.41 ns |     1.17 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 1025B        |   1,951.8 ns |     4.56 ns |     3.81 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1025B        |   3,426.2 ns |    12.55 ns |    11.13 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1025B        |   4,273.5 ns |    42.90 ns |    35.82 ns |    2120 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 8KB          |   6,796.7 ns |    14.28 ns |    12.66 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 8KB          |  13,886.2 ns |    83.08 ns |    69.37 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 8KB          |  24,317.0 ns |    95.63 ns |    89.45 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 8KB          |  28,806.0 ns |   115.69 ns |    96.61 ns |    9280 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128KB        | 108,368.7 ns |   341.95 ns |   285.54 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)      | 128KB        | 222,781.4 ns | 1,374.85 ns | 1,073.40 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128KB        | 389,464.6 ns | 3,276.30 ns | 2,735.86 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128KB        | 467,503.4 ns | 1,620.49 ns | 1,436.52 ns |  132188 B |