| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128B         |     272.2 ns |     2.50 ns |     2.34 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128B         |     354.2 ns |     4.27 ns |     3.57 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128B         |     360.2 ns |     6.97 ns |     6.85 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128B         |     364.3 ns |     4.76 ns |     4.45 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 137B         |     270.2 ns |     2.54 ns |     2.38 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 137B         |     348.3 ns |     3.38 ns |     2.82 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 137B         |     349.4 ns |     2.61 ns |     2.44 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 137B         |     362.4 ns |     3.00 ns |     2.81 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1KB          |   1,509.7 ns |    12.97 ns |    12.13 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1KB          |   2,028.5 ns |    15.68 ns |    14.66 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1KB          |   2,083.7 ns |    10.49 ns |     8.76 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1KB          |   2,204.0 ns |    22.67 ns |    21.21 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1025B        |   1,515.0 ns |    20.67 ns |    18.32 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1025B        |   2,036.5 ns |    15.64 ns |    14.63 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1025B        |   2,087.4 ns |     7.30 ns |     6.09 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1025B        |   2,202.3 ns |    17.66 ns |    16.52 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 8KB          |   9,876.7 ns |    83.13 ns |    77.76 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 8KB          |  13,403.5 ns |    76.67 ns |    64.02 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 8KB          |  13,811.7 ns |    79.86 ns |    62.35 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 8KB          |  15,072.7 ns |   115.59 ns |   102.47 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128KB        | 156,368.1 ns | 1,917.09 ns | 1,793.24 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128KB        | 212,493.7 ns |   706.81 ns |   590.22 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128KB        | 218,953.0 ns | 1,384.98 ns | 1,156.52 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128KB        | 239,874.9 ns | 1,463.68 ns | 1,297.52 ns |     112 B |