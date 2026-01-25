| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | cSHAKE256 | cSHAKE256 (Managed)      | 128B         |     284.6 ns |     1.95 ns |     1.82 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX2)         | 128B         |     351.6 ns |     4.96 ns |     4.64 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (BouncyCastle) | 128B         |     360.5 ns |     1.16 ns |     1.09 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX512F)      | 128B         |     374.7 ns |     1.52 ns |     1.42 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE256 | cSHAKE256 (Managed)      | 137B         |     529.2 ns |     3.52 ns |     3.12 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (BouncyCastle) | 137B         |     658.6 ns |     3.12 ns |     2.92 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX2)         | 137B         |     668.9 ns |     1.50 ns |     1.41 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX512F)      | 137B         |     687.4 ns |     1.95 ns |     1.73 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE256 | cSHAKE256 (Managed)      | 1KB          |   1,716.5 ns |    11.38 ns |    10.09 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX2)         | 1KB          |   2,288.9 ns |    10.76 ns |     9.54 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX512F)      | 1KB          |   2,356.6 ns |    11.58 ns |    10.83 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (BouncyCastle) | 1KB          |   2,504.4 ns |    12.84 ns |    12.01 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE256 | cSHAKE256 (Managed)      | 1025B        |   1,716.5 ns |    11.07 ns |     9.81 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX2)         | 1025B        |   2,273.0 ns |     8.50 ns |     7.95 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX512F)      | 1025B        |   2,353.9 ns |     7.74 ns |     6.86 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (BouncyCastle) | 1025B        |   2,496.7 ns |    17.28 ns |    16.17 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE256 | cSHAKE256 (Managed)      | 8KB          |  12,348.6 ns |    90.76 ns |    80.45 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX2)         | 8KB          |  16,653.3 ns |    39.59 ns |    33.06 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX512F)      | 8KB          |  17,358.4 ns |    54.26 ns |    50.76 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (BouncyCastle) | 8KB          |  18,611.5 ns |   105.56 ns |    98.74 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE256 | cSHAKE256 (Managed)      | 128KB        | 195,151.4 ns | 1,561.55 ns | 1,460.67 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX2)         | 128KB        | 261,252.6 ns | 1,406.47 ns | 1,315.61 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (AVX512F)      | 128KB        | 271,908.0 ns |   830.21 ns |   735.96 ns |     176 B |
| ComputeHash | cSHAKE256 | cSHAKE256 (BouncyCastle) | 128KB        | 293,971.9 ns | 2,699.30 ns | 2,524.93 ns |     176 B |