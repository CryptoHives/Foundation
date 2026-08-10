| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128B         |     105.5 ns |     0.32 ns |     0.28 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128B         |     107.6 ns |     0.36 ns |     0.34 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128B         |     369.3 ns |     2.07 ns |     1.84 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128B         |     501.0 ns |     3.82 ns |     3.19 ns |    1120 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 137B         |     187.1 ns |     0.62 ns |     0.58 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 137B         |     205.0 ns |     0.58 ns |     0.55 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 137B         |     724.2 ns |     4.25 ns |     3.32 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 137B         |     902.7 ns |     7.81 ns |     7.31 ns |    1136 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1KB          |     714.1 ns |     1.33 ns |     1.24 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1KB          |     804.2 ns |    13.10 ns |    12.25 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1KB          |   2,846.8 ns |    14.99 ns |    13.29 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1KB          |   3,028.1 ns |    22.88 ns |    19.10 ns |    2016 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 1025B        |     798.6 ns |     2.46 ns |     2.30 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 1025B        |     915.1 ns |    12.96 ns |    12.13 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 1025B        |   3,201.9 ns |    10.81 ns |    10.11 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 1025B        |   3,445.0 ns |    19.81 ns |    17.56 ns |    2024 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 8KB          |   5,605.2 ns |    21.74 ns |    16.97 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 8KB          |   6,555.0 ns |    20.55 ns |    18.22 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 8KB          |  22,771.2 ns |   115.50 ns |   102.38 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 8KB          |  23,310.3 ns |   191.81 ns |   170.03 ns |    9184 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle            | 128KB        |  88,571.6 ns |   257.57 ns |   228.33 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2                    | 128KB        | 104,882.1 ns |   364.67 ns |   341.11 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                 | 128KB        | 363,922.3 ns | 2,669.46 ns | 2,497.02 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious) | 128KB        | 395,481.9 ns | 1,828.77 ns | 1,621.16 ns |  132078 B |