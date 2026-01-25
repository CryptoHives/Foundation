| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeHash | SHAKE128 | SHAKE128 (Managed)      | 128B         |     274.3 ns |     2.69 ns |     2.39 ns |     274.1 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX2)         | 128B         |     345.6 ns |     1.32 ns |     1.17 ns |     345.8 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX512F)      | 128B         |     355.4 ns |     1.82 ns |     1.52 ns |     355.1 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (BouncyCastle) | 128B         |     361.6 ns |     2.69 ns |     2.52 ns |     361.0 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (OS)           | 128B         |     383.4 ns |     2.33 ns |     1.94 ns |     383.2 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHAKE128 | SHAKE128 (Managed)      | 137B         |     272.1 ns |     3.66 ns |     3.25 ns |     272.1 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX2)         | 137B         |     343.0 ns |     2.33 ns |     2.18 ns |     343.0 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX512F)      | 137B         |     354.7 ns |     2.74 ns |     2.43 ns |     354.6 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (BouncyCastle) | 137B         |     364.3 ns |     3.12 ns |     2.92 ns |     363.4 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (OS)           | 137B         |     386.9 ns |     3.49 ns |     3.26 ns |     387.7 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHAKE128 | SHAKE128 (Managed)      | 1KB          |   1,550.1 ns |     9.45 ns |     8.84 ns |   1,550.5 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (OS)           | 1KB          |   1,847.3 ns |    29.21 ns |    27.33 ns |   1,839.6 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX2)         | 1KB          |   2,060.5 ns |    15.80 ns |    13.19 ns |   2,058.9 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX512F)      | 1KB          |   2,156.9 ns |    43.06 ns |    82.96 ns |   2,116.2 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (BouncyCastle) | 1KB          |   2,238.9 ns |    43.58 ns |    55.11 ns |   2,222.8 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHAKE128 | SHAKE128 (Managed)      | 1025B        |   1,546.4 ns |    17.88 ns |    14.93 ns |   1,540.1 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (OS)           | 1025B        |   1,876.1 ns |    37.33 ns |    61.34 ns |   1,858.5 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX2)         | 1025B        |   2,066.8 ns |    41.11 ns |    48.94 ns |   2,037.2 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX512F)      | 1025B        |   2,110.8 ns |    21.50 ns |    19.06 ns |   2,108.7 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (BouncyCastle) | 1025B        |   2,204.7 ns |    18.13 ns |    16.96 ns |   2,201.2 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHAKE128 | SHAKE128 (Managed)      | 8KB          |  10,068.4 ns |    46.19 ns |    40.94 ns |  10,071.8 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (OS)           | 8KB          |  11,889.9 ns |   102.44 ns |    90.81 ns |  11,893.3 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX2)         | 8KB          |  13,504.0 ns |    33.08 ns |    27.62 ns |  13,502.1 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX512F)      | 8KB          |  13,952.6 ns |   132.89 ns |   110.97 ns |  13,911.1 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (BouncyCastle) | 8KB          |  15,215.4 ns |    81.93 ns |    76.64 ns |  15,218.8 ns |     112 B |
|                                                  |              |              |             |             |              |           |
| ComputeHash | SHAKE128 | SHAKE128 (Managed)      | 128KB        | 159,214.6 ns | 1,282.23 ns | 1,199.40 ns | 159,576.7 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (OS)           | 128KB        | 187,364.9 ns | 1,747.17 ns | 1,634.31 ns | 186,915.9 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX2)         | 128KB        | 218,259.6 ns | 4,317.57 ns | 5,460.34 ns | 215,645.6 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (AVX512F)      | 128KB        | 224,053.4 ns | 2,321.51 ns | 1,938.57 ns | 224,146.5 ns |     112 B |
| ComputeHash | SHAKE128 | SHAKE128 (BouncyCastle) | 128KB        | 240,069.1 ns | 1,063.67 ns |   994.96 ns | 240,110.6 ns |     112 B |