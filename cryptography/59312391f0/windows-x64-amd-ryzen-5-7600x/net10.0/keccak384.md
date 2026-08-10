| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | Keccak-384 | Keccak-384 (Managed)      | 128B         |     461.9 ns |     1.62 ns |     1.51 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX2)         | 128B         |     604.7 ns |     1.88 ns |     1.76 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX512F)      | 128B         |     630.6 ns |     1.23 ns |     1.15 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (BouncyCastle) | 128B         |     651.6 ns |     1.79 ns |     1.50 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-384 | Keccak-384 (Managed)      | 137B         |     463.5 ns |     2.66 ns |     2.49 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX2)         | 137B         |     601.6 ns |     1.26 ns |     1.18 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX512F)      | 137B         |     628.4 ns |     1.32 ns |     1.17 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (BouncyCastle) | 137B         |     652.6 ns |     2.05 ns |     1.71 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-384 | Keccak-384 (Managed)      | 1KB          |   2,031.0 ns |    17.20 ns |    16.09 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX2)         | 1KB          |   2,754.0 ns |     6.75 ns |     6.32 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX512F)      | 1KB          |   2,818.6 ns |     6.10 ns |     5.71 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (BouncyCastle) | 1KB          |   3,068.5 ns |    12.34 ns |    11.54 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-384 | Keccak-384 (Managed)      | 1025B        |   2,041.6 ns |    10.70 ns |    10.01 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX2)         | 1025B        |   2,747.5 ns |     5.44 ns |     4.54 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX512F)      | 1025B        |   2,816.4 ns |    10.17 ns |     9.01 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (BouncyCastle) | 1025B        |   3,068.9 ns |    16.41 ns |    15.35 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-384 | Keccak-384 (Managed)      | 8KB          |  15,813.7 ns |   112.26 ns |   105.01 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX2)         | 8KB          |  21,606.4 ns |    74.55 ns |    66.09 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX512F)      | 8KB          |  21,839.1 ns |    74.74 ns |    62.41 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (BouncyCastle) | 8KB          |  23,915.6 ns |    89.86 ns |    79.66 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-384 | Keccak-384 (Managed)      | 128KB        | 250,892.7 ns | 1,578.62 ns | 1,476.64 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX2)         | 128KB        | 343,311.4 ns |   669.51 ns |   626.26 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (AVX512F)      | 128KB        | 348,699.1 ns | 1,027.35 ns |   910.72 ns |     144 B |
| ComputeHash | Keccak-384 | Keccak-384 (BouncyCastle) | 128KB        | 380,540.3 ns | 1,984.28 ns | 1,856.10 ns |     144 B |