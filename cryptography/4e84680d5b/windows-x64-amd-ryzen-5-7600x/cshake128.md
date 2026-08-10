| Description                                        | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128B         |     281.5 ns |     5.66 ns |   5.30 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128B         |     344.8 ns |     3.74 ns |   3.50 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128B         |     354.4 ns |     4.18 ns |   3.91 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128B         |     370.4 ns |     4.06 ns |   3.60 ns |     112 B |
|                                                    |              |              |             |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 137B         |     317.8 ns |     4.45 ns |   4.16 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 137B         |     348.3 ns |     5.20 ns |   4.87 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 137B         |     351.7 ns |     2.13 ns |   1.78 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 137B         |     372.6 ns |     5.12 ns |   4.79 ns |     112 B |
|                                                    |              |              |             |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1KB          |   1,576.2 ns |    23.07 ns |  21.58 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1KB          |   2,053.7 ns |    30.27 ns |  25.28 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1KB          |   2,106.0 ns |    22.88 ns |  20.28 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1KB          |   2,242.9 ns |    33.35 ns |  29.57 ns |     112 B |
|                                                    |              |              |             |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1025B        |   1,561.6 ns |     5.79 ns |   4.83 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1025B        |   2,045.4 ns |    21.51 ns |  16.79 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1025B        |   2,112.6 ns |    32.59 ns |  30.49 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1025B        |   2,253.1 ns |    32.92 ns |  30.79 ns |     112 B |
|                                                    |              |              |             |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 8KB          |  10,247.4 ns |   168.59 ns | 140.78 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 8KB          |  13,803.1 ns |   235.46 ns | 220.25 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 8KB          |  14,090.1 ns |   230.00 ns | 192.06 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 8KB          |  15,316.2 ns |   129.21 ns | 114.54 ns |     112 B |
|                                                    |              |              |             |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128KB        | 161,614.9 ns |   987.06 ns | 923.30 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128KB        | 213,320.7 ns |   498.57 ns | 466.37 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128KB        | 220,653.3 ns |   613.76 ns | 479.18 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128KB        | 243,202.1 ns | 1,123.21 ns | 995.70 ns |     112 B |