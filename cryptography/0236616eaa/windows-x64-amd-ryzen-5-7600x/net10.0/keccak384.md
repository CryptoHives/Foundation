| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     414.2 ns |   0.96 ns |   0.80 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     556.0 ns |   3.09 ns |   2.58 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     568.1 ns |   4.20 ns |   3.72 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     634.6 ns |   1.09 ns |   0.97 ns |   9,182 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     415.6 ns |   1.55 ns |   1.30 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     552.0 ns |   3.07 ns |   2.57 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     571.6 ns |   3.22 ns |   2.52 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     633.9 ns |   0.77 ns |   0.68 ns |   9,203 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,044.3 ns |   6.18 ns |   4.82 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,728.9 ns |  44.41 ns |  39.37 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   2,783.4 ns |  11.26 ns |   9.98 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,114.3 ns |   7.00 ns |   6.20 ns |   9,203 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,028.8 ns |   4.62 ns |   4.32 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,709.0 ns |   9.30 ns |   7.76 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   2,777.6 ns |   9.43 ns |   7.36 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,099.8 ns |   3.62 ns |   3.02 ns |   9,191 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  15,935.9 ns |  47.25 ns |  41.88 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  21,327.5 ns |  53.98 ns |  45.07 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  21,974.0 ns |  89.27 ns |  79.14 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  24,511.0 ns |  46.79 ns |  43.76 ns |   9,208 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 254,051.4 ns | 497.21 ns | 440.76 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 339,760.7 ns | 404.98 ns | 316.18 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 349,747.7 ns | 967.09 ns | 857.30 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 389,375.7 ns | 633.87 ns | 561.91 ns |   9,208 B |         - |