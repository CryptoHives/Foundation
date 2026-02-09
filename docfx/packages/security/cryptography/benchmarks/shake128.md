| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · Managed      | 128B         |     242.2 ns |     0.85 ns |     0.71 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128B         |     316.2 ns |     0.92 ns |     0.86 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128B         |     323.9 ns |     0.63 ns |     0.59 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128B         |     331.1 ns |     0.96 ns |     0.90 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128B         |     353.8 ns |     0.86 ns |     0.72 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 137B         |     241.0 ns |     1.74 ns |     1.63 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 137B         |     313.3 ns |     1.01 ns |     0.95 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 137B         |     320.5 ns |     0.58 ns |     0.51 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 137B         |     331.6 ns |     0.84 ns |     0.75 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 137B         |     355.2 ns |     1.28 ns |     1.20 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1KB          |   1,470.3 ns |     8.81 ns |     8.24 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1KB          |   1,768.1 ns |     9.11 ns |     7.61 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1KB          |   1,985.3 ns |     8.25 ns |     7.31 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1KB          |   2,048.5 ns |     5.70 ns |     5.33 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1KB          |   2,160.5 ns |     6.27 ns |     5.55 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 1025B        |   1,469.0 ns |     4.37 ns |     3.87 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 1025B        |   1,765.2 ns |     4.26 ns |     3.99 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 1025B        |   1,984.3 ns |     4.49 ns |     3.98 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 1025B        |   2,051.2 ns |     4.02 ns |     3.57 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 1025B        |   2,163.8 ns |     9.86 ns |     8.74 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 8KB          |   9,751.8 ns |    42.73 ns |    37.88 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 8KB          |  11,727.2 ns |    70.74 ns |    62.71 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 8KB          |  13,318.4 ns |    26.75 ns |    25.02 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 8KB          |  13,786.4 ns |    17.17 ns |    15.22 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 8KB          |  15,047.9 ns |    49.30 ns |    46.11 ns |         - |
|                                          |              |              |             |             |           |
| TryComputeHash · SHAKE128 · Managed      | 128KB        | 154,600.7 ns |   538.23 ns |   477.13 ns |         - |
| TryComputeHash · SHAKE128 · OS Native    | 128KB        | 184,772.8 ns | 1,558.66 ns | 1,457.98 ns |         - |
| TryComputeHash · SHAKE128 · AVX2         | 128KB        | 211,494.2 ns |   268.90 ns |   238.37 ns |         - |
| TryComputeHash · SHAKE128 · AVX512F      | 128KB        | 218,372.0 ns |   388.23 ns |   363.15 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle | 128KB        | 238,364.1 ns |   688.62 ns |   644.14 ns |         - |