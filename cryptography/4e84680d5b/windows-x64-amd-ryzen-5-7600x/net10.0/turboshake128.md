| Description                                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128B         |     187.1 ns |   1.45 ns |   1.28 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128B         |     207.3 ns |   0.71 ns |   0.66 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 128B         |     212.8 ns |   0.56 ns |   0.50 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 137B         |     182.5 ns |   0.94 ns |   0.84 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 137B         |     204.0 ns |   0.83 ns |   0.78 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 137B         |     211.9 ns |   0.83 ns |   0.78 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1KB          |     892.0 ns |   5.54 ns |   5.18 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1KB          |   1,116.2 ns |   4.07 ns |   3.40 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 1KB          |   1,174.4 ns |   2.90 ns |   2.42 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1025B        |     932.6 ns |   6.75 ns |   6.31 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1025B        |   1,114.3 ns |   3.54 ns |   3.13 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 1025B        |   1,176.0 ns |   8.11 ns |   6.78 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 8KB          |   5,533.2 ns |  43.83 ns |  38.85 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 8KB          |   7,077.3 ns |  12.24 ns |  10.22 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 8KB          |   7,432.0 ns |   8.06 ns |   6.29 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128KB        |  86,596.5 ns | 688.47 ns | 610.31 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128KB        | 111,700.0 ns | 105.56 ns |  88.15 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 128KB        | 118,098.4 ns | 192.50 ns | 170.64 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128B         |     203.6 ns |   1.79 ns |   1.59 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128B         |     235.7 ns |   0.87 ns |   0.77 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 128B         |     242.7 ns |   1.01 ns |   0.95 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 137B         |     201.1 ns |   1.29 ns |   1.20 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 137B         |     225.8 ns |   0.76 ns |   0.71 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 137B         |     230.7 ns |   1.02 ns |   0.91 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1KB          |     909.6 ns |   5.98 ns |   5.59 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1KB          |   1,135.9 ns |   3.80 ns |   3.55 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 1KB          |   1,205.8 ns |  18.68 ns |  15.60 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1025B        |     911.0 ns |   4.03 ns |   3.77 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1025B        |   1,140.5 ns |   3.82 ns |   3.58 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 1025B        |   1,198.1 ns |   4.71 ns |   3.93 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 8KB          |   5,552.1 ns |  27.74 ns |  24.59 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 8KB          |   7,099.7 ns |  14.22 ns |  11.87 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 8KB          |   7,477.5 ns |  14.82 ns |  12.38 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128KB        |  87,155.1 ns | 564.37 ns | 527.91 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128KB        | 112,014.8 ns | 288.21 ns | 240.67 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 128KB        | 118,411.4 ns | 295.64 ns | 276.54 ns |     176 B |