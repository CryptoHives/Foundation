| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     420.0 ns |     1.62 ns |     1.52 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     554.9 ns |     1.26 ns |     1.17 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     570.7 ns |     1.89 ns |     1.68 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     642.6 ns |     1.18 ns |     0.99 ns |   9,240 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     419.8 ns |     1.29 ns |     1.14 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     554.6 ns |     2.46 ns |     2.18 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     573.3 ns |     1.13 ns |     0.95 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     642.4 ns |     2.20 ns |     2.06 ns |   9,206 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,053.5 ns |     6.27 ns |     4.89 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,721.5 ns |    13.93 ns |    12.35 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   2,788.2 ns |     9.46 ns |     8.38 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,160.1 ns |     6.15 ns |     5.13 ns |   9,189 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,051.6 ns |     6.04 ns |     5.04 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,725.4 ns |     8.50 ns |     7.95 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   2,790.7 ns |     7.10 ns |     6.29 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,168.4 ns |     7.08 ns |     5.91 ns |   9,201 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  16,193.9 ns |    48.61 ns |    43.09 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  21,401.9 ns |    63.19 ns |    52.77 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  21,974.1 ns |    96.80 ns |    80.83 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  24,825.6 ns |    42.64 ns |    37.80 ns |   9,200 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 257,218.1 ns |   713.87 ns |   596.11 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 342,165.2 ns |   995.59 ns |   831.36 ns |        NA |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 349,981.8 ns | 1,045.91 ns |   978.34 ns |        NA |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 395,089.4 ns | 1,560.75 ns | 1,459.93 ns |   9,216 B |         - |