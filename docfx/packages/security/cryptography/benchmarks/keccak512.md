| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128B         |     428.3 ns |     2.25 ns |     2.11 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128B         |     577.6 ns |     2.66 ns |     2.07 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 128B         |     598.6 ns |     1.91 ns |     1.70 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128B         |     645.6 ns |     2.44 ns |     2.03 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 137B         |     424.6 ns |     1.48 ns |     1.23 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 137B         |     573.5 ns |     1.77 ns |     1.66 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 137B         |     595.2 ns |     2.66 ns |     2.08 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 137B         |     648.4 ns |     3.73 ns |     3.49 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1KB          |   2,964.0 ns |    16.65 ns |    15.57 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1KB          |   4,056.3 ns |    14.63 ns |    13.68 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 1KB          |   4,196.1 ns |    12.58 ns |    11.15 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1KB          |   4,530.6 ns |    17.14 ns |    14.32 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1025B        |   2,970.4 ns |    18.08 ns |    16.91 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1025B        |   4,065.9 ns |    11.04 ns |     9.79 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 1025B        |   4,191.4 ns |    12.57 ns |    10.50 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1025B        |   4,560.8 ns |    45.99 ns |    43.02 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 8KB          |  22,126.3 ns |    66.52 ns |    58.97 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 8KB          |  30,519.6 ns |    93.27 ns |    82.68 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 8KB          |  31,516.5 ns |   104.79 ns |    87.51 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 8KB          |  35,283.4 ns |   185.78 ns |   155.14 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128KB        | 353,178.9 ns | 2,312.70 ns | 2,163.30 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128KB        | 486,693.7 ns | 1,689.53 ns | 1,319.07 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 128KB        | 502,173.1 ns | 1,851.59 ns | 1,546.16 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128KB        | 550,239.1 ns | 2,764.10 ns | 2,585.54 ns |     176 B |