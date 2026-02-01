| Description                                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128B         |     177.7 ns |   1.07 ns |   0.95 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128B         |     201.3 ns |   0.62 ns |   0.58 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 128B         |     206.8 ns |   0.64 ns |   0.60 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 137B         |     173.6 ns |   1.54 ns |   1.44 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 137B         |     198.6 ns |   0.45 ns |   0.40 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 137B         |     204.0 ns |   0.81 ns |   0.76 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1KB          |     862.4 ns |   5.60 ns |   5.24 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1KB          |   1,112.0 ns |   2.09 ns |   1.85 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 1KB          |   1,158.4 ns |   2.08 ns |   1.84 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1025B        |     864.3 ns |   3.62 ns |   3.39 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1025B        |   1,106.1 ns |   3.36 ns |   2.63 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 1025B        |   1,156.7 ns |   2.79 ns |   2.47 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 8KB          |   5,360.1 ns |  36.84 ns |  34.46 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 8KB          |   7,039.8 ns |  21.81 ns |  18.21 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 8KB          |   7,402.7 ns |  27.02 ns |  25.28 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128KB        |  83,658.5 ns | 235.66 ns | 196.79 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128KB        | 111,133.2 ns | 399.82 ns | 333.87 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX512F) | 128KB        | 116,863.2 ns | 239.32 ns | 223.86 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128B         |     201.0 ns |   1.88 ns |   1.75 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128B         |     224.3 ns |   1.66 ns |   1.55 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 128B         |     227.7 ns |   0.56 ns |   0.52 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 137B         |     196.4 ns |   1.44 ns |   1.35 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 137B         |     220.3 ns |   0.71 ns |   0.67 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 137B         |     225.7 ns |   0.90 ns |   0.84 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1KB          |     882.8 ns |   5.44 ns |   5.09 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1KB          |   1,127.7 ns |   3.40 ns |   3.18 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 1KB          |   1,180.1 ns |   5.18 ns |   4.33 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1025B        |     884.8 ns |   5.95 ns |   5.56 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1025B        |   1,126.6 ns |   3.60 ns |   3.37 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 1025B        |   1,181.5 ns |   4.25 ns |   3.55 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 8KB          |   5,367.3 ns |  32.22 ns |  30.14 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 8KB          |   7,054.2 ns |  16.07 ns |  12.54 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 8KB          |   7,415.9 ns |  16.04 ns |  13.39 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128KB        |  84,332.6 ns | 933.20 ns | 872.91 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128KB        | 111,070.5 ns | 183.68 ns | 171.82 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX512F) | 128KB        | 117,483.9 ns | 655.18 ns | 580.80 ns |     176 B |