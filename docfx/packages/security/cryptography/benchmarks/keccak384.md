| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128B         |     452.3 ns |     2.93 ns |     2.74 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128B         |     603.2 ns |     2.71 ns |     2.53 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 128B         |     630.1 ns |    11.96 ns |    12.28 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128B         |     653.3 ns |     2.60 ns |     2.17 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 137B         |     449.6 ns |     3.94 ns |     3.50 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 137B         |     600.5 ns |     1.02 ns |     0.85 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 137B         |     619.8 ns |     1.61 ns |     1.50 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 137B         |     652.5 ns |     2.99 ns |     2.80 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1KB          |   2,000.2 ns |    16.73 ns |    15.65 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1KB          |   2,730.0 ns |     5.23 ns |     4.08 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 1KB          |   2,807.0 ns |     8.02 ns |     7.51 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1KB          |   3,078.8 ns |    15.36 ns |    12.82 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1025B        |   1,996.5 ns |    12.75 ns |    11.31 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1025B        |   2,722.6 ns |     8.49 ns |     7.52 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 1025B        |   2,813.6 ns |     9.95 ns |     9.31 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1025B        |   3,062.5 ns |    11.82 ns |    11.05 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 8KB          |  15,524.8 ns |   131.14 ns |   122.67 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 8KB          |  21,250.2 ns |    86.69 ns |    81.09 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 8KB          |  21,887.0 ns |    55.87 ns |    43.62 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 8KB          |  23,876.7 ns |    96.54 ns |    85.58 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128KB        | 246,704.5 ns | 1,791.00 ns | 1,675.30 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128KB        | 338,614.5 ns | 1,389.50 ns | 1,084.83 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX512F)      | 128KB        | 349,068.6 ns |   731.70 ns |   684.43 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128KB        | 382,165.3 ns | 2,501.66 ns | 2,340.05 ns |     144 B |