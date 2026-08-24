| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     213.5 ns |     0.33 ns |     0.28 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     282.6 ns |     0.70 ns |     0.58 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     292.0 ns |     1.23 ns |     1.16 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     332.2 ns |     0.79 ns |     0.70 ns |   7,941 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     417.6 ns |     0.43 ns |     0.38 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     558.7 ns |     2.60 ns |     2.43 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     572.2 ns |     1.92 ns |     1.70 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     632.3 ns |     1.12 ns |     0.99 ns |   9,237 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,631.3 ns |     1.93 ns |     1.71 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,175.3 ns |    10.51 ns |     8.78 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,229.7 ns |     8.86 ns |     8.29 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,520.6 ns |     6.45 ns |     5.04 ns |   9,268 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,634.6 ns |     2.37 ns |     2.11 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,180.5 ns |    14.95 ns |    12.48 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,278.2 ns |    21.61 ns |    20.21 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,511.9 ns |    13.54 ns |    12.00 ns |   9,203 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  12,413.1 ns |    23.53 ns |    20.86 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  16,531.6 ns |   150.03 ns |   140.34 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  16,965.8 ns |   141.20 ns |   125.17 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  19,006.6 ns |    19.27 ns |    16.09 ns |   9,214 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 195,739.7 ns |   506.71 ns |   449.18 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 261,318.4 ns | 1,384.90 ns | 1,295.44 ns |        NA |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 267,366.6 ns | 1,143.39 ns |   954.79 ns |        NA |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 301,525.5 ns |   692.79 ns |   648.04 ns |   9,218 B |         - |