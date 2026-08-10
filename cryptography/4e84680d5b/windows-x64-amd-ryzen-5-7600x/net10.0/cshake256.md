| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128B         |     289.7 ns |     5.79 ns |     5.41 ns |     289.8 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128B         |     344.1 ns |     5.11 ns |     4.78 ns |     344.8 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128B         |     355.6 ns |     4.57 ns |     4.05 ns |     356.2 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128B         |     370.8 ns |     4.58 ns |     4.28 ns |     369.5 ns |     176 B |
|                                                    |              |              |             |             |              |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 137B         |     543.6 ns |     5.03 ns |     4.71 ns |     542.9 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 137B         |     686.1 ns |     7.48 ns |     6.63 ns |     684.9 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 137B         |     686.9 ns |     9.51 ns |     8.89 ns |     684.0 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 137B         |     693.1 ns |     2.43 ns |     2.03 ns |     693.6 ns |     176 B |
|                                                    |              |              |             |             |              |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1KB          |   1,711.3 ns |     9.67 ns |     9.05 ns |   1,711.5 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1KB          |   2,383.8 ns |    31.96 ns |    29.89 ns |   2,375.4 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1KB          |   2,395.2 ns |    39.97 ns |    79.83 ns |   2,351.6 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1KB          |   2,516.4 ns |    24.36 ns |    22.78 ns |   2,518.8 ns |     176 B |
|                                                    |              |              |             |             |              |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1025B        |   1,723.2 ns |     7.18 ns |     6.36 ns |   1,723.1 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1025B        |   2,280.3 ns |    11.30 ns |    10.57 ns |   2,278.2 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1025B        |   2,354.2 ns |    10.38 ns |     8.10 ns |   2,355.1 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1025B        |   2,497.8 ns |    14.86 ns |    13.90 ns |   2,499.1 ns |     176 B |
|                                                    |              |              |             |             |              |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 8KB          |  12,491.2 ns |    86.85 ns |    76.99 ns |  12,478.1 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 8KB          |  16,818.6 ns |   107.46 ns |   100.52 ns |  16,780.0 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 8KB          |  17,363.2 ns |    75.35 ns |    62.92 ns |  17,358.8 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 8KB          |  18,655.1 ns |   121.55 ns |   113.70 ns |  18,674.9 ns |     176 B |
|                                                    |              |              |             |             |              |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128KB        | 195,786.1 ns | 1,444.73 ns | 1,280.71 ns | 195,665.7 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128KB        | 263,931.9 ns | 3,669.63 ns | 3,432.58 ns | 262,384.5 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128KB        | 273,308.2 ns | 5,349.95 ns | 4,467.45 ns | 271,628.9 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128KB        | 295,015.3 ns | 1,296.73 ns | 1,212.96 ns | 294,882.3 ns |     176 B |