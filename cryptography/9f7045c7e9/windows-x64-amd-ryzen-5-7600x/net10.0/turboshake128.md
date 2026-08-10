| Description                                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128B         |     176.3 ns |   1.26 ns |   1.06 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128B         |     202.8 ns |   0.38 ns |   0.32 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 128B         |     208.1 ns |   0.57 ns |   0.53 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 137B         |     173.0 ns |   0.66 ns |   0.62 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 137B         |     199.6 ns |   0.57 ns |   0.51 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 137B         |     205.6 ns |   0.71 ns |   0.67 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1KB          |     860.6 ns |   4.00 ns |   3.54 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1KB          |   1,107.0 ns |   6.63 ns |   5.18 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 1KB          |   1,161.4 ns |   3.04 ns |   2.85 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1025B        |     860.3 ns |   2.72 ns |   2.55 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1025B        |   1,106.8 ns |   5.34 ns |   4.74 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 1025B        |   1,160.1 ns |   5.48 ns |   4.86 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 8KB          |   5,339.8 ns |  33.23 ns |  29.46 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 8KB          |   7,043.8 ns |  27.19 ns |  22.70 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 8KB          |   7,429.2 ns |   9.61 ns |   8.03 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128KB        |  84,140.0 ns | 428.99 ns | 358.22 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128KB        | 111,109.6 ns | 228.52 ns | 213.76 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 128KB        | 117,903.5 ns | 350.69 ns | 310.87 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128B         |     203.9 ns |   1.27 ns |   1.13 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128B         |     223.1 ns |   0.68 ns |   0.64 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 128B         |     230.0 ns |   0.61 ns |   0.54 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 137B         |     194.9 ns |   0.92 ns |   0.86 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 137B         |     220.1 ns |   0.81 ns |   0.76 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 137B         |     228.1 ns |   0.87 ns |   0.77 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1KB          |     883.0 ns |   5.75 ns |   5.38 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1KB          |   1,132.9 ns |   5.25 ns |   4.91 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 1KB          |   1,185.1 ns |   5.51 ns |   4.60 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1025B        |     885.1 ns |   5.25 ns |   4.65 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1025B        |   1,131.7 ns |   3.30 ns |   2.92 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 1025B        |   1,187.4 ns |   8.81 ns |   7.36 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 8KB          |   5,370.5 ns |  19.85 ns |  16.58 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 8KB          |   7,069.2 ns |  25.70 ns |  21.46 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 8KB          |   7,426.8 ns |  14.84 ns |  11.58 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128KB        |  84,365.7 ns | 646.15 ns | 604.41 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128KB        | 111,231.5 ns | 856.54 ns | 668.73 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 128KB        | 118,109.5 ns | 317.08 ns | 264.78 ns |     176 B |