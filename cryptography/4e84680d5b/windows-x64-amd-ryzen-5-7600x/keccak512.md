| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128B         |     437.8 ns |     2.60 ns |     2.31 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128B         |     580.2 ns |     2.95 ns |     2.76 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 128B         |     603.4 ns |     2.05 ns |     1.92 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128B         |     656.1 ns |     7.17 ns |     6.71 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 137B         |     435.9 ns |     2.50 ns |     2.34 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 137B         |     575.6 ns |     3.22 ns |     3.01 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 137B         |     598.1 ns |     1.73 ns |     1.62 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 137B         |     657.1 ns |     7.14 ns |     6.68 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1KB          |   3,030.8 ns |    14.37 ns |    12.74 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1KB          |   4,133.6 ns |    23.64 ns |    18.46 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 1KB          |   4,228.6 ns |    24.73 ns |    20.65 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1KB          |   4,573.7 ns |    32.29 ns |    26.96 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1025B        |   3,030.0 ns |    25.03 ns |    23.41 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1025B        |   4,192.3 ns |    20.87 ns |    17.42 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 1025B        |   4,213.8 ns |    23.88 ns |    21.17 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1025B        |   4,551.4 ns |    40.12 ns |    35.57 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 8KB          |  22,670.0 ns |   105.47 ns |    93.50 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 8KB          |  31,053.7 ns |   162.95 ns |   127.22 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 8KB          |  31,591.2 ns |   106.26 ns |    88.74 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 8KB          |  34,418.8 ns |   271.64 ns |   240.81 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128KB        | 361,491.7 ns | 2,157.75 ns | 2,018.36 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128KB        | 494,492.6 ns | 2,491.68 ns | 2,330.72 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 128KB        | 501,666.5 ns | 1,304.91 ns | 1,156.77 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128KB        | 553,113.6 ns | 1,862.48 ns | 1,651.04 ns |     176 B |