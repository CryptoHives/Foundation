| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128B         |     282.5 ns |     3.17 ns |     2.97 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128B         |     358.0 ns |     2.58 ns |     2.41 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128B         |     359.8 ns |     4.38 ns |     4.10 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128B         |     370.6 ns |     4.86 ns |     4.55 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 137B         |     528.0 ns |     4.93 ns |     4.11 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 137B         |     660.1 ns |     4.58 ns |     4.06 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 137B         |     691.8 ns |     3.69 ns |     3.08 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 137B         |     695.3 ns |    10.37 ns |     9.19 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1KB          |   1,693.5 ns |    14.29 ns |    13.37 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1KB          |   2,273.5 ns |    12.01 ns |    10.64 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1KB          |   2,359.7 ns |    15.30 ns |    13.57 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1KB          |   2,506.5 ns |    26.75 ns |    25.03 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1025B        |   1,682.3 ns |    14.91 ns |    13.95 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1025B        |   2,266.6 ns |     5.11 ns |     3.99 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 1025B        |   2,356.2 ns |    17.99 ns |    16.83 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1025B        |   2,519.9 ns |    20.45 ns |    19.13 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 8KB          |  12,193.6 ns |    70.30 ns |    65.76 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 8KB          |  16,570.1 ns |    79.28 ns |    66.20 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 8KB          |  17,245.0 ns |    42.53 ns |    35.52 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 8KB          |  18,655.0 ns |   125.53 ns |   117.43 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128KB        | 190,751.7 ns | 1,428.00 ns | 1,335.75 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128KB        | 260,702.8 ns |   908.13 ns |   849.47 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX512F)      | 128KB        | 274,118.8 ns | 1,298.10 ns | 1,214.24 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128KB        | 293,170.5 ns | 2,900.00 ns | 2,712.66 ns |     176 B |