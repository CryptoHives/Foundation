| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · Managed      | 128B         |     250.0 ns |   1.18 ns |   1.05 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128B         |     324.9 ns |   0.69 ns |   0.64 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128B         |     331.2 ns |   1.71 ns |   1.60 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128B         |     333.0 ns |   0.80 ns |   0.71 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128B         |     352.5 ns |   1.87 ns |   1.75 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · Managed      | 137B         |     490.8 ns |   2.18 ns |   2.04 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 137B         |     583.9 ns |   2.07 ns |   1.73 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 137B         |     629.2 ns |   2.77 ns |   2.59 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 137B         |     641.6 ns |   2.42 ns |   2.26 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 137B         |     659.1 ns |   1.79 ns |   1.67 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · Managed      | 1KB          |   1,644.5 ns |   6.84 ns |   6.40 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1KB          |   1,995.6 ns |   7.25 ns |   6.43 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1KB          |   2,225.3 ns |   3.80 ns |   3.37 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1KB          |   2,324.8 ns |   5.71 ns |   5.06 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1KB          |   2,460.1 ns |   9.68 ns |   9.05 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · Managed      | 1025B        |   1,639.1 ns |   3.78 ns |   3.53 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 1025B        |   2,000.1 ns |  12.67 ns |  11.24 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 1025B        |   2,225.6 ns |   9.82 ns |   9.18 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 1025B        |   2,324.4 ns |   9.18 ns |   8.59 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 1025B        |   2,459.1 ns |  10.70 ns |  10.01 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · Managed      | 8KB          |  12,136.0 ns |  80.99 ns |  75.76 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 8KB          |  14,395.7 ns |  53.46 ns |  50.01 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 8KB          |  16,526.7 ns |  61.52 ns |  57.55 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 8KB          |  17,242.2 ns |  31.10 ns |  29.09 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 8KB          |  18,505.7 ns |  66.80 ns |  62.48 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · Managed      | 128KB        | 189,786.5 ns | 576.15 ns | 510.74 ns |         - |
| TryComputeHash · SHAKE256 · OS Native    | 128KB        | 226,152.7 ns | 968.64 ns | 906.07 ns |         - |
| TryComputeHash · SHAKE256 · AVX2         | 128KB        | 259,879.5 ns | 854.69 ns | 799.48 ns |         - |
| TryComputeHash · SHAKE256 · AVX512F      | 128KB        | 270,569.7 ns | 852.96 ns | 797.86 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle | 128KB        | 291,624.5 ns | 755.72 ns | 631.06 ns |         - |