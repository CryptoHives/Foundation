| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | SHAKE256 | SHAKE256 (Managed)      | 128B         |     281.1 ns |     3.12 ns |     2.91 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX2)         | 128B         |     350.3 ns |     3.76 ns |     3.52 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX512F)      | 128B         |     361.4 ns |     2.18 ns |     1.93 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (BouncyCastle) | 128B         |     363.3 ns |     3.04 ns |     2.69 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (OS)           | 128B         |     392.8 ns |     4.34 ns |     4.06 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHAKE256 | SHAKE256 (Managed)      | 137B         |     546.6 ns |     9.55 ns |     8.93 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (OS)           | 137B         |     629.5 ns |     5.73 ns |     5.36 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (BouncyCastle) | 137B         |     674.7 ns |    13.43 ns |    11.91 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX2)         | 137B         |     690.3 ns |    10.41 ns |     9.23 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX512F)      | 137B         |     714.5 ns |    14.12 ns |    15.69 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHAKE256 | SHAKE256 (Managed)      | 1KB          |   1,763.7 ns |    33.95 ns |    31.76 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (OS)           | 1KB          |   2,084.0 ns |    37.35 ns |    34.94 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX2)         | 1KB          |   2,352.4 ns |    46.80 ns |    62.48 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX512F)      | 1KB          |   2,486.8 ns |    49.54 ns |    97.79 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (BouncyCastle) | 1KB          |   2,556.0 ns |    42.73 ns |    35.69 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHAKE256 | SHAKE256 (Managed)      | 1025B        |   1,726.4 ns |    18.47 ns |    17.28 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (OS)           | 1025B        |   2,060.4 ns |    20.55 ns |    19.22 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX2)         | 1025B        |   2,285.5 ns |    12.06 ns |    11.29 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX512F)      | 1025B        |   2,377.2 ns |    23.91 ns |    21.19 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (BouncyCastle) | 1025B        |   2,502.9 ns |    22.30 ns |    20.86 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHAKE256 | SHAKE256 (Managed)      | 8KB          |  12,518.9 ns |    83.29 ns |    73.84 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (OS)           | 8KB          |  14,612.3 ns |    66.50 ns |    58.95 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX2)         | 8KB          |  16,751.1 ns |   142.72 ns |   126.52 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX512F)      | 8KB          |  17,255.1 ns |    67.68 ns |    60.00 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (BouncyCastle) | 8KB          |  18,806.4 ns |   204.78 ns |   191.55 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash | SHAKE256 | SHAKE256 (Managed)      | 128KB        | 195,071.0 ns | 1,289.73 ns | 1,143.31 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (OS)           | 128KB        | 233,228.6 ns | 4,529.66 ns | 5,034.70 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX2)         | 128KB        | 262,998.1 ns | 2,985.11 ns | 2,792.27 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (AVX512F)      | 128KB        | 276,664.5 ns | 5,407.75 ns | 7,755.64 ns |     176 B |
| ComputeHash | SHAKE256 | SHAKE256 (BouncyCastle) | 128KB        | 301,641.4 ns | 6,032.75 ns | 5,643.04 ns |     176 B |