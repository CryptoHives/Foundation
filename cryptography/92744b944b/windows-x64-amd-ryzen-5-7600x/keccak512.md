| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     411.4 ns |     0.78 ns |     0.70 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     554.8 ns |     1.93 ns |     1.80 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     574.8 ns |     2.00 ns |     1.87 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     625.5 ns |     2.42 ns |     2.14 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     400.2 ns |     0.50 ns |     0.44 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     547.1 ns |     8.55 ns |     8.40 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     556.9 ns |     1.97 ns |     1.75 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     626.1 ns |     2.13 ns |     1.99 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   2,946.9 ns |    13.57 ns |    12.70 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,004.1 ns |    17.66 ns |    16.52 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,131.6 ns |    17.24 ns |    15.28 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   4,523.0 ns |    18.75 ns |    17.54 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   2,951.7 ns |     9.73 ns |     9.10 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,006.9 ns |    12.42 ns |    10.37 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,137.8 ns |    27.93 ns |    21.81 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   4,524.5 ns |    15.63 ns |    14.62 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  22,174.1 ns |    65.65 ns |    58.20 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  30,140.3 ns |    40.21 ns |    35.65 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  31,081.1 ns |   110.63 ns |    86.38 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  34,277.4 ns |   120.24 ns |   106.59 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 353,737.5 ns |   872.10 ns |   815.77 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 484,958.1 ns | 5,067.74 ns | 7,268.00 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 496,425.7 ns | 1,628.53 ns | 1,523.33 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 561,994.7 ns | 2,048.58 ns | 1,916.25 ns |         - |