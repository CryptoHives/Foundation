| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128B         |     102.9 ns |     0.26 ns |     0.25 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128B         |     108.4 ns |     0.32 ns |     0.29 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128B         |     365.6 ns |     1.23 ns |     1.15 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128B         |     502.7 ns |     3.95 ns |     3.69 ns |    1216 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 137B         |     190.1 ns |     0.86 ns |     0.81 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 137B         |     205.8 ns |     0.46 ns |     0.41 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 137B         |     713.0 ns |     1.53 ns |     1.28 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 137B         |     913.2 ns |     2.70 ns |     2.52 ns |    1232 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1KB          |     718.2 ns |     1.57 ns |     1.31 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1KB          |     823.2 ns |     3.79 ns |     3.55 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1KB          |   2,823.3 ns |     7.98 ns |     7.46 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1KB          |   3,030.5 ns |     7.91 ns |     7.40 ns |    2112 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 1025B        |     805.0 ns |     1.76 ns |     1.65 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 1025B        |     921.8 ns |     7.44 ns |     6.96 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 1025B        |   3,179.3 ns |    11.48 ns |    10.74 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 1025B        |   3,433.9 ns |    12.32 ns |    11.52 ns |    2120 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 8KB          |   5,594.6 ns |     9.53 ns |     8.92 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 8KB          |   6,538.1 ns |    17.74 ns |    16.59 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 8KB          |  22,439.4 ns |    40.78 ns |    31.84 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 8KB          |  23,134.7 ns |    47.25 ns |    39.46 ns |    9280 B |
|                                                        |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle            | 128KB        |  89,132.1 ns |   269.63 ns |   239.02 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2                    | 128KB        | 104,527.7 ns |   174.19 ns |   154.42 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                 | 128KB        | 359,655.5 ns |   700.37 ns |   584.84 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious) | 128KB        | 397,470.6 ns | 1,673.69 ns | 1,565.57 ns |  132174 B |