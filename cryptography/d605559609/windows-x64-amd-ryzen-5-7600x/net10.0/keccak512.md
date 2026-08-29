| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     414.9 ns |     2.82 ns |     2.36 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     550.9 ns |     1.41 ns |     1.32 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     570.1 ns |     2.51 ns |     2.35 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     644.0 ns |     4.11 ns |     3.85 ns |   9,201 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     416.6 ns |     1.10 ns |     0.91 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     558.9 ns |     2.55 ns |     2.13 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     566.2 ns |     4.78 ns |     4.24 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     640.5 ns |     1.96 ns |     1.83 ns |   9,241 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,043.0 ns |    17.05 ns |    15.95 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,053.8 ns |    76.33 ns |    71.40 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,148.6 ns |    18.04 ns |    15.06 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   4,718.7 ns |    12.32 ns |    10.92 ns |   9,208 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,038.1 ns |    12.51 ns |    11.70 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,040.8 ns |    17.57 ns |    13.72 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,171.5 ns |    24.11 ns |    21.37 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   4,684.7 ns |    21.89 ns |    20.47 ns |   9,210 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  22,960.9 ns |    92.45 ns |    86.47 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  30,705.9 ns |   509.91 ns |   398.10 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  31,514.6 ns |    99.99 ns |    98.20 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  35,666.2 ns |   222.38 ns |   173.62 ns |   9,234 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 367,772.5 ns | 2,468.92 ns | 2,188.63 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 488,156.5 ns | 2,733.45 ns | 2,556.87 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 503,611.7 ns | 1,815.61 ns | 1,698.32 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 568,150.5 ns | 3,268.22 ns | 2,551.61 ns |   9,208 B |         - |