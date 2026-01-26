| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128B         |     279.6 ns |     2.94 ns |     2.75 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128B         |     347.8 ns |     4.65 ns |     4.12 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 128B         |     351.4 ns |     4.65 ns |     4.35 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128B         |     369.7 ns |     3.57 ns |     3.34 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 128B         |     383.7 ns |     1.65 ns |     1.46 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 137B         |     276.9 ns |     1.68 ns |     1.57 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 137B         |     342.2 ns |     4.43 ns |     3.93 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 137B         |     353.3 ns |     1.07 ns |     0.95 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 137B         |     364.5 ns |     3.24 ns |     2.71 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 137B         |     383.9 ns |     3.60 ns |     3.36 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1KB          |   1,559.0 ns |    11.65 ns |    10.90 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 1KB          |   1,846.7 ns |    15.80 ns |    14.00 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1KB          |   2,033.8 ns |     9.44 ns |     7.88 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 1KB          |   2,104.3 ns |     7.07 ns |     6.62 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1KB          |   2,232.8 ns |    26.62 ns |    24.90 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1025B        |   1,555.5 ns |     6.37 ns |     5.96 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 1025B        |   1,836.2 ns |     9.19 ns |     8.59 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1025B        |   2,042.3 ns |     9.30 ns |     7.77 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 1025B        |   2,149.1 ns |     8.57 ns |     8.02 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1025B        |   2,227.7 ns |    18.13 ns |    15.14 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 8KB          |  10,149.0 ns |    58.39 ns |    51.77 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 8KB          |  11,955.8 ns |    76.53 ns |    63.90 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 8KB          |  13,559.2 ns |    72.68 ns |    64.43 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 8KB          |  13,951.4 ns |    41.08 ns |    34.30 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 8KB          |  15,250.0 ns |    60.48 ns |    50.51 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128KB        | 160,461.6 ns | 1,273.29 ns | 1,191.03 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 128KB        | 188,681.9 ns | 1,111.37 ns | 1,039.58 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128KB        | 213,457.2 ns |   969.31 ns |   809.42 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 128KB        | 226,149.9 ns |   552.81 ns |   490.05 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128KB        | 241,816.2 ns | 1,211.74 ns | 1,133.47 ns |     112 B |