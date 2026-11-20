| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     468.2 ns |     0.78 ns |     0.65 ns |  16,317 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     626.8 ns |     0.35 ns |     0.27 ns |  15,618 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     636.0 ns |     0.89 ns |     0.83 ns |  14,632 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     714.6 ns |     1.47 ns |     1.23 ns |  10,117 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     468.2 ns |     0.86 ns |     0.72 ns |  16,317 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     612.0 ns |     0.49 ns |     0.43 ns |  15,618 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     639.0 ns |     0.29 ns |     0.22 ns |  14,831 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     725.4 ns |     1.17 ns |     0.92 ns |  16,642 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,288.7 ns |     6.10 ns |     5.09 ns |  16,315 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,994.2 ns |     1.75 ns |     1.55 ns |  15,625 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   3,104.3 ns |     2.13 ns |     1.99 ns |  14,648 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,515.1 ns |    12.32 ns |    11.52 ns |  16,337 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,287.7 ns |     5.35 ns |     4.47 ns |  16,134 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,989.6 ns |     2.02 ns |     1.79 ns |  15,815 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   3,101.2 ns |     2.51 ns |     2.23 ns |  14,838 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,514.1 ns |     6.39 ns |     5.33 ns |  16,742 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  17,992.2 ns |    59.60 ns |    55.75 ns |  16,324 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  23,562.6 ns |    11.69 ns |    10.93 ns |  15,815 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  24,351.4 ns |    14.46 ns |    12.07 ns |  14,648 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  27,393.5 ns |    50.12 ns |    39.13 ns |  10,055 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 289,183.6 ns | 4,652.58 ns | 3,632.43 ns |  16,138 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 374,691.4 ns |   163.24 ns |   144.70 ns |  15,828 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 389,062.8 ns |   198.14 ns |   185.34 ns |   8,326 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 437,461.4 ns |   698.21 ns |   583.04 ns |  16,619 B |         - |