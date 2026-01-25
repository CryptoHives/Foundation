| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | Keccak-512 | Keccak-512 (Managed)      | 128B         |     438.0 ns |     2.14 ns |     2.00 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX2)         | 128B         |     578.8 ns |     1.26 ns |     1.06 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX512F)      | 128B         |     605.3 ns |     1.99 ns |     1.86 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (BouncyCastle) | 128B         |     648.5 ns |     4.05 ns |     3.59 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-512 | Keccak-512 (Managed)      | 137B         |     433.7 ns |     3.28 ns |     3.07 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX2)         | 137B         |     574.9 ns |     2.13 ns |     1.66 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX512F)      | 137B         |     598.4 ns |     2.10 ns |     1.86 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (BouncyCastle) | 137B         |     649.9 ns |     3.33 ns |     3.11 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-512 | Keccak-512 (Managed)      | 1KB          |   3,024.1 ns |    15.20 ns |    12.70 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX2)         | 1KB          |   4,118.7 ns |    16.73 ns |    14.83 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX512F)      | 1KB          |   4,214.7 ns |    11.97 ns |    10.00 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (BouncyCastle) | 1KB          |   4,517.9 ns |    17.29 ns |    16.17 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-512 | Keccak-512 (Managed)      | 1025B        |   3,021.7 ns |    16.62 ns |    13.88 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX2)         | 1025B        |   4,119.9 ns |    13.58 ns |    12.70 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX512F)      | 1025B        |   4,204.5 ns |    16.82 ns |    14.04 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (BouncyCastle) | 1025B        |   4,569.4 ns |    40.95 ns |    38.30 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-512 | Keccak-512 (Managed)      | 8KB          |  22,558.9 ns |   126.53 ns |   118.36 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX2)         | 8KB          |  30,815.5 ns |    89.55 ns |    79.38 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX512F)      | 8KB          |  31,549.4 ns |   181.68 ns |   151.71 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (BouncyCastle) | 8KB          |  35,149.9 ns |   173.64 ns |   153.93 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash | Keccak-512 | Keccak-512 (Managed)      | 128KB        | 358,333.8 ns | 1,780.28 ns | 1,578.18 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX2)         | 128KB        | 494,543.0 ns | 2,082.12 ns | 1,947.62 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (AVX512F)      | 128KB        | 499,659.2 ns | 1,771.35 ns | 1,479.16 ns |     176 B |
| ComputeHash | Keccak-512 | Keccak-512 (BouncyCastle) | 128KB        | 548,415.5 ns | 4,691.62 ns | 4,388.54 ns |     176 B |