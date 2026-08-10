| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     399.8 ns |     4.32 ns |     4.05 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     545.2 ns |     2.31 ns |     2.16 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     561.1 ns |     1.60 ns |     1.50 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     625.8 ns |     3.32 ns |     3.10 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     398.1 ns |     2.33 ns |     2.06 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     544.5 ns |     2.18 ns |     1.93 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     563.0 ns |     2.05 ns |     1.92 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     626.5 ns |     2.53 ns |     2.24 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   2,938.9 ns |    19.36 ns |    18.11 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,000.9 ns |    14.78 ns |    12.34 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,121.2 ns |    10.57 ns |     9.37 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   4,524.9 ns |    21.00 ns |    18.62 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   2,933.9 ns |    15.10 ns |    14.12 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,011.6 ns |    14.13 ns |    12.53 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,134.2 ns |    11.53 ns |     9.63 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   4,519.2 ns |    18.21 ns |    17.03 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  22,180.5 ns |   150.53 ns |   125.70 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  30,390.5 ns |    93.26 ns |    82.67 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  31,171.7 ns |    96.00 ns |    89.80 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  34,416.4 ns |   196.80 ns |   174.46 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 355,415.3 ns | 2,350.04 ns | 2,198.23 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 484,546.4 ns |   949.76 ns |   841.93 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 500,648.4 ns | 1,676.36 ns | 1,568.07 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 551,718.7 ns | 2,190.32 ns | 1,829.02 ns |         - |