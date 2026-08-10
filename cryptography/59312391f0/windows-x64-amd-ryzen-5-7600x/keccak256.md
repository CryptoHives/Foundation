| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | Keccak-256 | Keccak-256 (Managed)      | 128B         |     239.2 ns |     1.96 ns |     1.83 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX2)         | 128B         |     311.3 ns |     0.71 ns |     0.63 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX512F)      | 128B         |     323.3 ns |     1.20 ns |     1.12 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (BouncyCastle) | 128B         |     360.7 ns |     1.51 ns |     1.34 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-256 | Keccak-256 (Managed)      | 137B         |     486.8 ns |     2.35 ns |     2.08 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX2)         | 137B         |     628.5 ns |     3.11 ns |     2.91 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (BouncyCastle) | 137B         |     652.3 ns |     3.75 ns |     3.50 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX512F)      | 137B         |     652.4 ns |     2.31 ns |     2.05 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-256 | Keccak-256 (Managed)      | 1KB          |   1,671.1 ns |     8.22 ns |     7.29 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX2)         | 1KB          |   2,238.6 ns |     5.28 ns |     4.68 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX512F)      | 1KB          |   2,317.8 ns |     9.88 ns |     8.25 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (BouncyCastle) | 1KB          |   2,485.1 ns |    21.01 ns |    19.65 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-256 | Keccak-256 (Managed)      | 1025B        |   1,675.1 ns |     9.98 ns |     9.33 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX2)         | 1025B        |   2,229.9 ns |     7.48 ns |     6.63 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX512F)      | 1025B        |   2,316.5 ns |     8.48 ns |     7.93 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (BouncyCastle) | 1025B        |   2,484.2 ns |    17.02 ns |    15.92 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-256 | Keccak-256 (Managed)      | 8KB          |  12,366.3 ns |    79.03 ns |    73.92 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX2)         | 8KB          |  16,776.8 ns |    44.47 ns |    37.14 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX512F)      | 8KB          |  17,094.4 ns |    44.58 ns |    41.70 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (BouncyCastle) | 8KB          |  18,709.8 ns |    79.30 ns |    74.18 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-256 | Keccak-256 (Managed)      | 128KB        | 194,062.1 ns |   800.79 ns |   749.06 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX2)         | 128KB        | 263,848.7 ns |   896.09 ns |   838.20 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (AVX512F)      | 128KB        | 271,863.1 ns |   615.76 ns |   545.86 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak-256 (BouncyCastle) | 128KB        | 292,550.3 ns | 1,142.47 ns | 1,012.77 ns |     112 B |