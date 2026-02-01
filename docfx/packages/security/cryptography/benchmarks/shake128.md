| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128B         |     271.0 ns |     2.28 ns |     2.02 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128B         |     344.1 ns |     6.04 ns |     5.35 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 128B         |     350.4 ns |     0.92 ns |     0.86 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128B         |     357.7 ns |     1.73 ns |     1.62 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 128B         |     380.4 ns |     1.55 ns |     1.38 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 137B         |     262.7 ns |     1.31 ns |     1.10 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 137B         |     338.3 ns |     1.00 ns |     0.83 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 137B         |     345.5 ns |     1.14 ns |     1.01 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 137B         |     358.5 ns |     1.52 ns |     1.42 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 137B         |     380.0 ns |     3.14 ns |     2.93 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1KB          |   1,493.2 ns |     7.43 ns |     6.95 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 1KB          |   1,801.5 ns |     7.20 ns |     6.01 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1KB          |   2,008.2 ns |     5.40 ns |     4.21 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 1KB          |   2,070.2 ns |     7.62 ns |     6.76 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1KB          |   2,189.9 ns |    11.70 ns |    10.37 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1025B        |   1,508.4 ns |    11.02 ns |    10.31 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 1025B        |   1,809.9 ns |     9.63 ns |     9.01 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1025B        |   2,006.6 ns |     5.29 ns |     4.13 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 1025B        |   2,072.3 ns |     5.12 ns |     4.79 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1025B        |   2,200.3 ns |    22.01 ns |    20.58 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 8KB          |   9,834.4 ns |    59.29 ns |    55.46 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 8KB          |  11,781.9 ns |   102.61 ns |    95.98 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 8KB          |  13,357.8 ns |    45.97 ns |    38.39 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 8KB          |  13,786.3 ns |    37.65 ns |    35.22 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 8KB          |  15,016.2 ns |    80.83 ns |    75.61 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128KB        | 155,478.8 ns | 1,598.49 ns | 1,495.23 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 128KB        | 185,115.7 ns |   699.16 ns |   583.83 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128KB        | 212,114.4 ns |   483.13 ns |   451.92 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 128KB        | 217,869.7 ns |   480.75 ns |   426.17 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128KB        | 239,320.1 ns | 1,263.94 ns | 1,182.29 ns |     112 B |