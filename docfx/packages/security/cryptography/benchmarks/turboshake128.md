| Description                                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (Managed) | 128B         |     183.0 ns |     2.18 ns |     1.94 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX2)    | 128B         |     209.2 ns |     2.43 ns |     2.27 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX512F) | 128B         |     216.2 ns |     2.63 ns |     2.46 ns |     112 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (Managed) | 137B         |     182.3 ns |     3.30 ns |     2.93 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX2)    | 137B         |     206.8 ns |     4.03 ns |     6.62 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX512F) | 137B         |     213.5 ns |     3.35 ns |     3.13 ns |     112 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (Managed) | 1KB          |     908.0 ns |    16.73 ns |    17.18 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX2)    | 1KB          |   1,141.3 ns |    19.43 ns |    18.17 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX512F) | 1KB          |   1,216.0 ns |    24.15 ns |    33.05 ns |     112 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (Managed) | 1025B        |     891.7 ns |    16.70 ns |    16.40 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX2)    | 1025B        |   1,152.3 ns |    18.58 ns |    31.04 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX512F) | 1025B        |   1,200.5 ns |    17.42 ns |    15.44 ns |     112 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (Managed) | 8KB          |   5,681.7 ns |   112.10 ns |   124.59 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX2)    | 8KB          |   7,370.3 ns |   144.94 ns |   282.69 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX512F) | 8KB          |   7,702.7 ns |   143.27 ns |   134.01 ns |     112 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (Managed) | 128KB        |  86,454.3 ns |   568.24 ns |   531.53 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX2)    | 128KB        | 112,332.4 ns |   785.51 ns |   655.93 ns |     112 B |
| ComputeHash | TurboSHAKE128-32 | TurboSHAKE128-32 (AVX512F) | 128KB        | 121,350.8 ns | 2,361.71 ns | 3,534.89 ns |     112 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (Managed) | 128B         |     207.9 ns |     4.16 ns |     5.11 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX2)    | 128B         |     228.9 ns |     2.83 ns |     2.51 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX512F) | 128B         |     238.6 ns |     1.86 ns |     1.74 ns |     176 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (Managed) | 137B         |     202.4 ns |     3.86 ns |     3.42 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX2)    | 137B         |     226.7 ns |     4.56 ns |     4.04 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX512F) | 137B         |     238.2 ns |     4.78 ns |     4.47 ns |     176 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (Managed) | 1KB          |     943.2 ns |    18.77 ns |    40.80 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX2)    | 1KB          |   1,147.0 ns |     9.95 ns |     8.31 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX512F) | 1KB          |   1,202.1 ns |     5.92 ns |     4.94 ns |     176 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (Managed) | 1025B        |     930.0 ns |    18.34 ns |    29.08 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX2)    | 1025B        |   1,149.0 ns |    10.56 ns |     9.36 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX512F) | 1025B        |   1,230.1 ns |    21.50 ns |    23.90 ns |     176 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (Managed) | 8KB          |   5,526.0 ns |    53.06 ns |    44.31 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX2)    | 8KB          |   7,152.3 ns |    40.83 ns |    31.88 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX512F) | 8KB          |   8,033.1 ns |   158.96 ns |   424.30 ns |     176 B |
|                                                             |              |              |             |             |           |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (Managed) | 128KB        |  87,357.1 ns | 1,279.29 ns | 1,196.65 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX2)    | 128KB        | 112,464.0 ns |   546.58 ns |   426.74 ns |     176 B |
| ComputeHash | TurboSHAKE128-64 | TurboSHAKE128-64 (AVX512F) | 128KB        | 118,593.1 ns |   432.08 ns |   360.80 ns |     176 B |