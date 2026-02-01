| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128B         |     234.5 ns |     0.88 ns |     0.82 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128B         |     309.5 ns |     0.80 ns |     0.67 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 128B         |     320.5 ns |     0.94 ns |     0.88 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128B         |     357.5 ns |     1.83 ns |     1.71 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 137B         |     480.5 ns |     5.55 ns |     5.20 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 137B         |     625.6 ns |     2.88 ns |     2.69 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 137B         |     644.4 ns |     1.69 ns |     1.41 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 137B         |     651.3 ns |     2.64 ns |     2.34 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1KB          |   1,653.5 ns |     9.42 ns |     8.81 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1KB          |   2,211.5 ns |     6.49 ns |     5.42 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 1KB          |   2,309.3 ns |     7.46 ns |     5.82 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1KB          |   2,489.7 ns |    14.73 ns |    13.06 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1025B        |   1,633.6 ns |     9.52 ns |     8.90 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1025B        |   2,216.3 ns |    10.68 ns |     8.92 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 1025B        |   2,307.3 ns |     7.01 ns |     6.56 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1025B        |   2,475.3 ns |    11.47 ns |    10.73 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 8KB          |  12,152.9 ns |    86.06 ns |    80.51 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 8KB          |  16,544.2 ns |    77.23 ns |    72.24 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 8KB          |  17,198.0 ns |    78.30 ns |    73.24 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 8KB          |  18,558.3 ns |    80.88 ns |    75.66 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128KB        | 189,676.8 ns | 1,222.89 ns | 1,084.06 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128KB        | 259,978.7 ns |   977.26 ns |   914.13 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 128KB        | 269,916.2 ns | 1,571.44 ns | 1,312.22 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128KB        | 293,821.1 ns | 1,771.63 ns | 1,657.18 ns |     112 B |