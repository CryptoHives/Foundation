| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128B         |     126.5 ns |     0.27 ns |     0.25 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 128B         |     224.4 ns |     1.18 ns |     1.10 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128B         |     391.1 ns |     1.12 ns |     1.05 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128B         |     589.7 ns |     2.86 ns |     2.68 ns |    1120 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 137B         |     231.0 ns |     0.20 ns |     0.18 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 137B         |     445.3 ns |     6.47 ns |     6.05 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 137B         |     775.3 ns |     2.18 ns |     2.04 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 137B         |   1,094.9 ns |     3.29 ns |     2.91 ns |    1136 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1KB          |     868.6 ns |     0.48 ns |     0.45 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 1KB          |   1,763.2 ns |    26.09 ns |    24.41 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1KB          |   3,083.1 ns |    11.65 ns |    10.89 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1KB          |   3,765.2 ns |    11.00 ns |    10.29 ns |    2016 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1025B        |     974.5 ns |     0.86 ns |     0.76 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 1025B        |   1,958.3 ns |    11.02 ns |     9.21 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1025B        |   3,467.7 ns |     8.47 ns |     7.51 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1025B        |   4,278.9 ns |    20.90 ns |    19.55 ns |    2024 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 8KB          |   6,794.7 ns |     3.31 ns |     3.10 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 8KB          |  13,920.8 ns |    99.03 ns |    82.69 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 8KB          |  24,628.2 ns |    75.90 ns |    71.00 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 8KB          |  29,061.8 ns |    87.33 ns |    81.68 ns |    9184 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128KB        | 108,406.0 ns |    47.08 ns |    44.04 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Neon)      | 128KB        | 222,025.7 ns | 1,153.38 ns | 1,078.87 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128KB        | 394,033.8 ns | 1,013.46 ns |   947.99 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128KB        | 470,733.4 ns | 1,239.01 ns | 1,158.97 ns |  132092 B |