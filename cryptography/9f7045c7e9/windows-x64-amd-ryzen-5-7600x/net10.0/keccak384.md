| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128B         |     452.6 ns |     4.26 ns |     3.78 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128B         |     605.8 ns |     1.91 ns |     1.60 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 128B         |     625.6 ns |     2.76 ns |     2.30 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128B         |     649.0 ns |     3.30 ns |     3.08 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 137B         |     456.8 ns |     2.93 ns |     2.74 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 137B         |     601.4 ns |     3.37 ns |     2.82 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 137B         |     621.3 ns |     3.17 ns |     2.96 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 137B         |     650.6 ns |     4.42 ns |     4.14 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1KB          |   2,004.5 ns |    19.86 ns |    17.61 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1KB          |   2,739.4 ns |    12.62 ns |    10.54 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 1KB          |   2,817.6 ns |    10.62 ns |     8.86 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1KB          |   3,059.7 ns |    11.75 ns |    10.41 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1025B        |   1,997.6 ns |    14.07 ns |    12.48 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1025B        |   2,738.6 ns |     7.90 ns |     6.17 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 1025B        |   2,820.2 ns |    12.87 ns |    11.41 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1025B        |   3,070.5 ns |    12.05 ns |    10.06 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 8KB          |  15,531.8 ns |    77.77 ns |    72.75 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 8KB          |  21,253.0 ns |    68.50 ns |    57.20 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 8KB          |  21,949.1 ns |    73.91 ns |    69.14 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 8KB          |  23,823.8 ns |    74.75 ns |    66.26 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128KB        | 246,199.5 ns | 1,467.50 ns | 1,145.73 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128KB        | 340,461.3 ns |   993.63 ns |   929.44 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 128KB        | 350,126.0 ns | 2,216.89 ns | 1,851.20 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128KB        | 381,852.3 ns | 2,091.53 ns | 1,956.42 ns |     144 B |