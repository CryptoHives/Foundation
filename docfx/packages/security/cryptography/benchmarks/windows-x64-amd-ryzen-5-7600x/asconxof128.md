| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · Managed      | 128B         |     570.3 ns |     2.92 ns |     2.73 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128B         |     764.6 ns |     4.33 ns |     4.05 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 137B         |     602.0 ns |     2.85 ns |     2.67 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 137B         |     803.2 ns |     3.68 ns |     3.44 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1KB          |   3,682.8 ns |    17.62 ns |    16.48 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1KB          |   4,934.5 ns |    33.02 ns |    29.27 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1025B        |   3,689.6 ns |    22.15 ns |    19.64 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1025B        |   4,933.2 ns |    21.07 ns |    19.71 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 8KB          |  28,565.1 ns |   149.34 ns |   132.39 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 8KB          |  38,400.4 ns |   221.01 ns |   206.73 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 128KB        | 454,699.5 ns | 1,741.61 ns | 1,543.89 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128KB        | 612,026.3 ns | 5,271.48 ns | 4,930.95 ns |         - |