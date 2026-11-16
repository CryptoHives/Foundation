| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     466.4 ns |     1.29 ns |     1.08 ns |   5,435 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     613.1 ns |     0.39 ns |     0.32 ns |   4,926 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     631.5 ns |     0.92 ns |     0.86 ns |   3,939 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     731.2 ns |     3.30 ns |     3.09 ns |   7,945 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     472.4 ns |     2.50 ns |     2.34 ns |   5,435 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     615.6 ns |     0.88 ns |     0.78 ns |   4,926 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     633.2 ns |     0.33 ns |     0.31 ns |   3,939 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     739.6 ns |     2.62 ns |     2.18 ns |   7,902 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,288.2 ns |    10.79 ns |     8.43 ns |   5,444 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   3,020.1 ns |     4.31 ns |     3.82 ns |   4,935 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   3,099.9 ns |     8.41 ns |     7.86 ns |   3,948 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,568.3 ns |     8.08 ns |     6.74 ns |   7,913 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,297.2 ns |    19.51 ns |    18.25 ns |   5,444 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   3,049.5 ns |    32.37 ns |    30.28 ns |   4,935 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   3,139.9 ns |    15.10 ns |    14.13 ns |   3,948 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,587.9 ns |    10.60 ns |     9.39 ns |   7,913 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  17,921.4 ns |    63.65 ns |    56.43 ns |   5,444 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  23,767.0 ns |    13.39 ns |    12.53 ns |   4,935 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  24,313.3 ns |    33.61 ns |    29.80 ns |   3,948 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  27,869.4 ns |    62.88 ns |    52.51 ns |   7,913 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 285,203.0 ns |   920.62 ns |   768.76 ns |   5,449 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 378,697.9 ns |   485.91 ns |   454.52 ns |   4,940 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 387,250.1 ns |   230.78 ns |   215.88 ns |   3,953 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 446,339.9 ns | 1,439.38 ns | 1,275.98 ns |   7,897 B |         - |