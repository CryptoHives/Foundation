| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128B         |     279.5 ns |     1.65 ns |     1.47 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128B         |     353.3 ns |     3.50 ns |     3.27 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128B         |     358.7 ns |     3.23 ns |     3.02 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128B         |     360.2 ns |     1.11 ns |     0.98 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 137B         |     521.4 ns |     2.83 ns |     2.64 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 137B         |     660.3 ns |     4.11 ns |     3.85 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 137B         |     672.8 ns |     4.61 ns |     3.60 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 137B         |     686.1 ns |     3.32 ns |     2.59 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1KB          |   1,681.7 ns |     9.31 ns |     8.70 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1KB          |   2,266.0 ns |     7.59 ns |     7.10 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1KB          |   2,358.0 ns |     5.51 ns |     5.16 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1KB          |   2,499.9 ns |    10.81 ns |     9.03 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1025B        |   1,694.8 ns |     7.84 ns |     7.33 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1025B        |   2,258.8 ns |     9.55 ns |     7.46 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1025B        |   2,343.2 ns |     6.40 ns |     5.68 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1025B        |   2,491.1 ns |    11.64 ns |    10.89 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 8KB          |  12,200.6 ns |   108.68 ns |    96.35 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 8KB          |  16,589.5 ns |    63.36 ns |    59.27 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 8KB          |  17,254.5 ns |    72.01 ns |    60.13 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 8KB          |  18,627.0 ns |   126.18 ns |   118.02 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128KB        | 191,028.4 ns | 1,362.13 ns | 1,207.49 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128KB        | 259,558.2 ns |   755.67 ns |   706.85 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128KB        | 270,962.8 ns |   871.57 ns |   727.80 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128KB        | 293,457.0 ns | 1,633.13 ns | 1,363.74 ns |     176 B |