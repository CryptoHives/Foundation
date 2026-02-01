| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128B         |     427.9 ns |     2.25 ns |     1.88 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128B         |     575.0 ns |     2.08 ns |     1.62 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 128B         |     595.2 ns |     2.62 ns |     2.45 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128B         |     650.1 ns |     3.53 ns |     3.30 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 137B         |     423.3 ns |     1.87 ns |     1.46 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 137B         |     571.3 ns |     1.65 ns |     1.46 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 137B         |     592.5 ns |     2.76 ns |     2.16 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 137B         |     650.3 ns |     4.64 ns |     4.34 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1KB          |   2,963.6 ns |    17.97 ns |    16.81 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1KB          |   4,074.9 ns |    15.99 ns |    14.18 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 1KB          |   4,196.3 ns |    18.72 ns |    16.59 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1KB          |   4,534.0 ns |    40.70 ns |    36.08 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1025B        |   2,973.1 ns |    19.23 ns |    17.99 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1025B        |   4,063.0 ns |    10.11 ns |     9.46 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 1025B        |   4,180.4 ns |     9.74 ns |     8.63 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1025B        |   4,535.6 ns |    34.51 ns |    30.60 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 8KB          |  22,190.6 ns |   128.24 ns |   119.96 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 8KB          |  30,490.6 ns |   107.85 ns |    84.20 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 8KB          |  31,405.0 ns |   134.16 ns |   125.49 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 8KB          |  34,291.4 ns |   157.36 ns |   147.19 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128KB        | 355,174.0 ns | 2,083.66 ns | 1,847.11 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128KB        | 486,191.9 ns | 1,587.45 ns | 1,484.90 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX512F)      | 128KB        | 499,985.1 ns | 1,548.87 ns | 1,373.04 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128KB        | 550,037.1 ns | 3,462.01 ns | 3,238.37 ns |     176 B |