| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128B         |     270.0 ns |     2.87 ns |     2.68 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128B         |     346.8 ns |     3.00 ns |     2.51 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 128B         |     354.1 ns |     1.97 ns |     1.75 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128B         |     362.1 ns |     3.15 ns |     2.94 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 128B         |     381.9 ns |     3.38 ns |     3.16 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 137B         |     265.0 ns |     2.50 ns |     2.34 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 137B         |     342.9 ns |     1.80 ns |     1.50 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 137B         |     350.4 ns |     2.22 ns |     2.08 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 137B         |     360.7 ns |     3.81 ns |     3.57 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 137B         |     383.0 ns |     3.90 ns |     3.65 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1KB          |   1,505.0 ns |    13.78 ns |    12.22 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 1KB          |   1,815.1 ns |    16.50 ns |    15.44 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1KB          |   2,022.4 ns |    17.41 ns |    15.43 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 1KB          |   2,095.9 ns |    14.09 ns |    12.49 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1KB          |   2,204.9 ns |    26.13 ns |    23.16 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1025B        |   1,503.9 ns |    17.96 ns |    16.80 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 1025B        |   1,803.6 ns |    10.95 ns |     9.71 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1025B        |   2,015.2 ns |     9.13 ns |     8.09 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 1025B        |   2,081.5 ns |     9.73 ns |     8.62 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1025B        |   2,195.1 ns |    14.27 ns |    12.65 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 8KB          |   9,821.7 ns |    94.49 ns |    83.77 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 8KB          |  11,803.8 ns |    81.58 ns |    72.32 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 8KB          |  13,413.3 ns |    85.33 ns |    71.25 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 8KB          |  13,924.4 ns |    66.22 ns |    55.30 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 8KB          |  15,181.5 ns |   154.18 ns |   136.68 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128KB        | 155,443.9 ns |   726.51 ns |   644.03 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (OS)           | 128KB        | 185,015.4 ns | 1,483.71 ns | 1,387.87 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128KB        | 212,473.7 ns | 1,096.11 ns |   915.30 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX512F)      | 128KB        | 220,344.4 ns | 1,592.26 ns | 1,489.40 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128KB        | 238,327.2 ns | 1,681.47 ns | 1,572.85 ns |     112 B |