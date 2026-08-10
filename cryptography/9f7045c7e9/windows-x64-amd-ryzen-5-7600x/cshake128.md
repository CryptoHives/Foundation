| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128B         |     271.6 ns |   1.57 ns |   1.47 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128B         |     349.9 ns |   1.81 ns |   1.61 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128B         |     353.2 ns |   0.73 ns |   0.68 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128B         |     359.2 ns |   1.76 ns |   1.56 ns |     112 B |
|                                                    |              |              |           |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 137B         |     271.3 ns |   1.90 ns |   1.69 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 137B         |     345.9 ns |   1.39 ns |   1.16 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 137B         |     351.0 ns |   1.31 ns |   1.09 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 137B         |     359.3 ns |   2.29 ns |   2.14 ns |     112 B |
|                                                    |              |              |           |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1KB          |   1,510.8 ns |   7.46 ns |   6.97 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1KB          |   2,015.0 ns |   5.76 ns |   5.11 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1KB          |   2,081.5 ns |   5.13 ns |   4.80 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1KB          |   2,192.9 ns |   8.84 ns |   7.39 ns |     112 B |
|                                                    |              |              |           |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 1025B        |   1,507.4 ns |  10.64 ns |   9.96 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 1025B        |   2,019.4 ns |   9.12 ns |   8.09 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 1025B        |   2,084.0 ns |   9.37 ns |   8.77 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 1025B        |   2,193.3 ns |  15.37 ns |  13.62 ns |     112 B |
|                                                    |              |              |           |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 8KB          |   9,875.7 ns |  96.95 ns |  85.94 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 8KB          |  13,396.5 ns |  35.01 ns |  32.74 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 8KB          |  13,867.7 ns |  33.96 ns |  30.10 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 8KB          |  15,068.7 ns |  96.97 ns |  85.96 ns |     112 B |
|                                                    |              |              |           |           |           |
| ComputeHash · cSHAKE128 · cSHAKE128 (Managed)      | 128KB        | 155,905.9 ns | 855.35 ns | 800.09 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX2)         | 128KB        | 212,135.8 ns | 569.21 ns | 504.59 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (AVX512F)      | 128KB        | 220,319.3 ns | 548.32 ns | 486.07 ns |     112 B |
| ComputeHash · cSHAKE128 · cSHAKE128 (BouncyCastle) | 128KB        | 239,045.3 ns | 576.47 ns | 539.23 ns |     112 B |