| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | cSHAKE128 | cSHAKE128 (Managed)      | 128B         |     275.1 ns |     1.72 ns |     1.43 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX2)         | 128B         |     351.5 ns |     2.30 ns |     2.15 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX512F)      | 128B         |     353.9 ns |     0.63 ns |     0.52 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (BouncyCastle) | 128B         |     360.4 ns |     2.30 ns |     2.15 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE128 | cSHAKE128 (Managed)      | 137B         |     271.5 ns |     2.91 ns |     2.28 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX2)         | 137B         |     340.5 ns |     1.02 ns |     0.90 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX512F)      | 137B         |     349.7 ns |     0.88 ns |     0.73 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (BouncyCastle) | 137B         |     363.7 ns |     2.60 ns |     2.43 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE128 | cSHAKE128 (Managed)      | 1KB          |   1,545.5 ns |     7.80 ns |     7.30 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX2)         | 1KB          |   2,024.0 ns |     6.80 ns |     6.03 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX512F)      | 1KB          |   2,092.8 ns |     6.91 ns |     5.77 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (BouncyCastle) | 1KB          |   2,203.2 ns |    17.48 ns |    16.35 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE128 | cSHAKE128 (Managed)      | 1025B        |   1,535.6 ns |     8.16 ns |     7.63 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX2)         | 1025B        |   2,029.4 ns |     7.73 ns |     7.23 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX512F)      | 1025B        |   2,089.8 ns |     9.53 ns |     8.92 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (BouncyCastle) | 1025B        |   2,200.4 ns |    11.61 ns |    10.86 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE128 | cSHAKE128 (Managed)      | 8KB          |  10,083.2 ns |    69.74 ns |    65.23 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX2)         | 8KB          |  13,519.8 ns |    23.27 ns |    21.77 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX512F)      | 8KB          |  13,889.1 ns |    23.27 ns |    19.43 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (BouncyCastle) | 8KB          |  15,125.7 ns |    67.91 ns |    63.52 ns |     112 B |
|                                                    |              |              |             |             |           |
| ComputeHash | cSHAKE128 | cSHAKE128 (Managed)      | 128KB        | 159,329.5 ns | 1,023.56 ns |   907.36 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX2)         | 128KB        | 213,679.8 ns |   538.80 ns |   504.00 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (AVX512F)      | 128KB        | 220,480.3 ns |   407.45 ns |   340.24 ns |     112 B |
| ComputeHash | cSHAKE128 | cSHAKE128 (BouncyCastle) | 128KB        | 239,727.6 ns | 1,420.33 ns | 1,328.58 ns |     112 B |