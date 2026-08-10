| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     213.6 ns |     1.69 ns |     1.58 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     283.8 ns |     4.24 ns |     3.54 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     292.7 ns |     2.06 ns |     1.82 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     337.2 ns |     2.23 ns |     2.09 ns |   8,331 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     418.3 ns |     3.14 ns |     2.94 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     555.7 ns |     4.92 ns |     4.36 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     576.0 ns |     6.79 ns |     6.02 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     643.6 ns |     4.49 ns |     4.20 ns |   8,832 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,634.4 ns |    10.02 ns |     9.37 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,191.2 ns |    21.89 ns |    20.48 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,241.7 ns |    22.86 ns |    21.39 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,529.1 ns |    18.71 ns |    16.59 ns |   8,806 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,634.0 ns |    21.48 ns |    19.05 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,196.7 ns |    27.90 ns |    24.74 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,241.1 ns |    21.45 ns |    19.02 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,520.7 ns |    16.81 ns |    15.73 ns |   8,803 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  12,428.6 ns |   137.18 ns |   128.32 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  16,602.0 ns |   155.04 ns |   145.02 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  17,008.6 ns |   189.86 ns |   168.30 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  19,102.8 ns |   221.18 ns |   206.89 ns |   8,815 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 196,896.2 ns | 1,449.41 ns | 1,355.78 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 262,749.1 ns | 2,694.46 ns | 2,520.40 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 267,733.4 ns | 2,596.19 ns | 2,301.46 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 300,843.0 ns | 1,542.58 ns | 1,367.45 ns |   8,820 B |         - |