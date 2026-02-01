| Description                                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128B         |     185.7 ns |   1.62 ns |   1.52 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128B         |     215.3 ns |   0.47 ns |   0.44 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 128B         |     216.5 ns |   0.68 ns |   0.64 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 137B         |     335.6 ns |   1.60 ns |   1.34 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 137B         |     389.1 ns |   0.78 ns |   0.73 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 137B         |     403.3 ns |   0.83 ns |   0.74 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1KB          |     947.7 ns |   5.80 ns |   5.43 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1KB          |   1,219.4 ns |   3.53 ns |   3.13 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 1KB          |   1,284.3 ns |   2.50 ns |   2.34 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1025B        |     959.1 ns |   6.38 ns |   5.96 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1025B        |   1,224.8 ns |   5.21 ns |   4.62 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 1025B        |   1,281.6 ns |   1.78 ns |   1.67 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 8KB          |   6,613.6 ns |  51.29 ns |  47.98 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 8KB          |   8,664.5 ns |  33.45 ns |  26.12 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 8KB          |   9,118.3 ns |  31.38 ns |  26.20 ns |     176 B |
|                                                       |              |              |           |           |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128KB        | 102,543.6 ns | 431.50 ns | 360.32 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128KB        | 134,903.7 ns | 343.47 ns | 304.47 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 128KB        | 141,614.8 ns | 444.84 ns | 371.46 ns |     176 B |