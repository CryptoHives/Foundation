| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128B         |     279.7 ns |     2.38 ns |     2.23 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128B         |     356.5 ns |     3.02 ns |     2.82 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128B         |     360.4 ns |     2.41 ns |     2.26 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128B         |     361.3 ns |     5.57 ns |     5.21 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 137B         |     524.8 ns |     4.45 ns |     3.94 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 137B         |     657.5 ns |     3.29 ns |     3.08 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 137B         |     670.9 ns |     1.28 ns |     1.07 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 137B         |     690.4 ns |     3.66 ns |     3.25 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1KB          |   1,685.4 ns |    10.79 ns |     9.57 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1KB          |   2,272.9 ns |     8.79 ns |     8.22 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1KB          |   2,356.8 ns |     9.39 ns |     7.33 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1KB          |   2,495.7 ns |    14.90 ns |    13.21 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1025B        |   1,682.2 ns |     6.80 ns |     6.36 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1025B        |   2,265.8 ns |     6.84 ns |     5.34 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1025B        |   2,354.1 ns |     5.40 ns |     4.79 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1025B        |   2,494.2 ns |    13.58 ns |    12.70 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 8KB          |  12,178.7 ns |    44.62 ns |    34.84 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 8KB          |  16,602.1 ns |    50.65 ns |    44.90 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 8KB          |  17,294.8 ns |    32.61 ns |    27.23 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 8KB          |  18,659.2 ns |   121.54 ns |   107.74 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128KB        | 190,443.6 ns | 1,593.98 ns | 1,413.02 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128KB        | 260,159.4 ns |   834.66 ns |   696.98 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128KB        | 270,869.2 ns | 1,321.04 ns | 1,031.38 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128KB        | 293,720.8 ns | 1,845.03 ns | 1,725.84 ns |     176 B |