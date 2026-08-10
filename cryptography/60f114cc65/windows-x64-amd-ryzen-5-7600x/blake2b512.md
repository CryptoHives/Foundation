| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128B         |     101.9 ns |     0.27 ns |     0.22 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128B         |     110.3 ns |     0.29 ns |     0.26 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128B         |     371.5 ns |     2.23 ns |     1.97 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128B         |     506.8 ns |     4.75 ns |     4.44 ns |    1216 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 137B         |     190.3 ns |     0.78 ns |     0.73 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 137B         |     208.2 ns |     0.64 ns |     0.54 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 137B         |     723.6 ns |     4.20 ns |     3.73 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 137B         |     921.1 ns |     4.90 ns |     4.58 ns |    1232 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1KB          |     721.7 ns |     2.18 ns |     1.93 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1KB          |     806.2 ns |    13.37 ns |    12.51 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1KB          |   2,849.7 ns |    10.94 ns |     9.14 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1KB          |   3,066.8 ns |    22.87 ns |    21.40 ns |    2112 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1025B        |     799.6 ns |     1.33 ns |     1.25 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1025B        |     905.9 ns |    13.40 ns |    12.53 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1025B        |   3,228.4 ns |    62.55 ns |    52.23 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1025B        |   3,451.1 ns |    12.10 ns |    10.72 ns |    2120 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 8KB          |   5,614.0 ns |     9.76 ns |     9.13 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 8KB          |   6,559.6 ns |    14.95 ns |    13.98 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 8KB          |  22,714.0 ns |   181.67 ns |   169.93 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 8KB          |  23,311.8 ns |   164.21 ns |   153.61 ns |    9280 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128KB        |  88,791.3 ns |   375.62 ns |   332.97 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128KB        | 104,956.3 ns |   303.52 ns |   283.91 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128KB        | 364,996.7 ns | 3,320.46 ns | 2,943.50 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128KB        | 396,224.7 ns | 2,294.31 ns | 2,033.84 ns |  132174 B |