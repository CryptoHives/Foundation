| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128B         |     272.0 ns |     2.60 ns |     2.30 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128B         |     352.0 ns |     1.94 ns |     1.62 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128B         |     353.8 ns |     1.31 ns |     1.23 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128B         |     360.4 ns |     2.21 ns |     2.07 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 137B         |     267.4 ns |     1.21 ns |     1.13 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 137B         |     347.2 ns |     0.84 ns |     0.78 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 137B         |     348.4 ns |     0.45 ns |     0.40 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 137B         |     361.8 ns |     1.68 ns |     1.49 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1KB          |   1,513.7 ns |     7.58 ns |     6.72 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1KB          |   2,014.8 ns |     4.35 ns |     3.63 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1KB          |   2,074.0 ns |     3.69 ns |     3.08 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1KB          |   2,193.0 ns |     9.33 ns |     8.73 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1025B        |   1,504.2 ns |    12.11 ns |    10.11 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1025B        |   2,013.8 ns |     6.15 ns |     5.45 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1025B        |   2,081.8 ns |     9.13 ns |     7.13 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1025B        |   2,202.7 ns |    13.51 ns |    12.63 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 8KB          |   9,865.9 ns |    65.15 ns |    60.94 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 8KB          |  13,364.5 ns |    27.88 ns |    23.28 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 8KB          |  13,842.1 ns |    36.30 ns |    28.34 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 8KB          |  15,130.1 ns |   150.13 ns |   133.09 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128KB        | 156,466.0 ns | 1,713.01 ns | 1,518.54 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128KB        | 211,894.7 ns |   361.57 ns |   338.21 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128KB        | 218,598.3 ns |   591.81 ns |   524.62 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128KB        | 239,649.4 ns | 1,080.10 ns | 1,010.33 ns |     112 B |