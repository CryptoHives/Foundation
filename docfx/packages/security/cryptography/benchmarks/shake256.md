| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128B         |     276.0 ns |     2.27 ns |     2.12 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128B         |     351.8 ns |     1.69 ns |     1.50 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128B         |     358.6 ns |     1.81 ns |     1.51 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 128B         |     359.1 ns |     1.29 ns |     1.20 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 128B         |     385.5 ns |     2.45 ns |     2.29 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 137B         |     515.8 ns |     2.39 ns |     2.12 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 137B         |     623.8 ns |     3.77 ns |     3.53 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 137B         |     656.4 ns |     3.07 ns |     2.57 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 137B         |     669.4 ns |     2.56 ns |     2.14 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 137B         |     684.9 ns |     2.22 ns |     1.86 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1KB          |   1,675.5 ns |    11.08 ns |     9.82 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 1KB          |   2,038.7 ns |    14.15 ns |    12.54 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1KB          |   2,261.0 ns |     4.30 ns |     3.81 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 1KB          |   2,348.2 ns |     5.59 ns |     4.37 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1KB          |   2,481.9 ns |    12.69 ns |    11.25 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1025B        |   1,674.3 ns |     8.75 ns |     7.31 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 1025B        |   2,031.3 ns |    22.25 ns |    19.73 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1025B        |   2,254.1 ns |     5.84 ns |     5.17 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 1025B        |   2,348.5 ns |     4.05 ns |     3.59 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1025B        |   2,484.1 ns |    15.86 ns |    14.83 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 8KB          |  12,123.8 ns |    69.47 ns |    61.58 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 8KB          |  14,453.2 ns |    72.29 ns |    67.62 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 8KB          |  16,573.2 ns |    33.29 ns |    29.51 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 8KB          |  17,230.3 ns |    67.07 ns |    62.74 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 8KB          |  18,645.5 ns |   124.54 ns |   116.50 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128KB        | 190,221.8 ns | 1,339.56 ns | 1,253.02 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (OS)           | 128KB        | 227,659.9 ns | 2,759.90 ns | 2,581.61 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128KB        | 261,363.4 ns | 1,184.42 ns |   924.71 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX512F)      | 128KB        | 269,055.4 ns |   499.45 ns |   442.75 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128KB        | 292,071.1 ns | 1,178.83 ns | 1,045.00 ns |     176 B |