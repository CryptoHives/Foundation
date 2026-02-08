| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 128B         |     101.9 ns |     0.19 ns |     0.18 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 128B         |     109.5 ns |     0.49 ns |     0.41 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 128B         |     372.1 ns |     0.82 ns |     0.73 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 137B         |     190.1 ns |     0.63 ns |     0.59 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 137B         |     207.8 ns |     0.36 ns |     0.30 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 137B         |     727.0 ns |     2.44 ns |     2.28 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 1KB          |     715.9 ns |     2.00 ns |     1.87 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 1KB          |     790.8 ns |     2.21 ns |     2.07 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 1KB          |   2,882.9 ns |     7.77 ns |     6.89 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 1025B        |     806.5 ns |    12.33 ns |    10.93 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 1025B        |     895.2 ns |     6.80 ns |     6.36 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 1025B        |   3,199.4 ns |    12.64 ns |    11.83 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 8KB          |   5,587.6 ns |    15.33 ns |    13.59 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 8KB          |   6,362.9 ns |   126.04 ns |   123.79 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 8KB          |  22,614.9 ns |    94.59 ns |    88.48 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · BLAKE2b-512 · BouncyCastle | 128KB        |  88,816.8 ns |   302.69 ns |   283.14 ns |         - |
| TryComputeHash · BLAKE2b-512 · AVX2         | 128KB        | 102,087.0 ns | 1,837.86 ns | 1,719.13 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed      | 128KB        | 362,079.3 ns | 1,326.08 ns | 1,240.42 ns |         - |