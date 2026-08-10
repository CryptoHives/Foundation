| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128B         |     238.9 ns |     2.05 ns |     1.91 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128B         |     310.5 ns |     1.52 ns |     1.34 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 128B         |     321.4 ns |     1.42 ns |     1.26 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128B         |     364.3 ns |     2.82 ns |     2.50 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 137B         |     488.8 ns |     5.34 ns |     4.99 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 137B         |     628.6 ns |     3.40 ns |     2.84 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 137B         |     651.8 ns |     3.91 ns |     3.47 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 137B         |     660.7 ns |     2.95 ns |     2.62 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1KB          |   1,672.4 ns |    12.44 ns |    11.64 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1KB          |   2,257.9 ns |    44.39 ns |    39.35 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 1KB          |   2,329.4 ns |    10.66 ns |     9.97 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1KB          |   2,496.3 ns |    18.38 ns |    17.19 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1025B        |   1,679.7 ns |    12.81 ns |    11.98 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1025B        |   2,229.8 ns |     9.28 ns |     7.75 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 1025B        |   2,328.1 ns |    46.01 ns |    43.04 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1025B        |   2,491.3 ns |    20.45 ns |    19.13 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 8KB          |  12,449.5 ns |    95.95 ns |    89.76 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 8KB          |  16,724.7 ns |    53.40 ns |    49.95 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 8KB          |  17,260.7 ns |    75.99 ns |    71.08 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 8KB          |  18,765.3 ns |   219.43 ns |   205.25 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128KB        | 194,873.2 ns |   716.05 ns |   597.93 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128KB        | 263,557.5 ns | 1,172.35 ns | 1,039.26 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX512F)      | 128KB        | 271,556.4 ns |   838.97 ns |   743.72 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128KB        | 293,683.1 ns | 1,823.04 ns | 1,616.08 ns |     112 B |