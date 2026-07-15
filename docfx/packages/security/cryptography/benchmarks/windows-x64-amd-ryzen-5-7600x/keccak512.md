| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     477.6 ns |     1.14 ns |     1.01 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     547.1 ns |     1.59 ns |     1.41 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     569.5 ns |     1.63 ns |     1.44 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     646.1 ns |     0.81 ns |     0.76 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     413.2 ns |     0.41 ns |     0.34 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     548.0 ns |     1.19 ns |     0.99 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     576.5 ns |     2.36 ns |     1.97 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     646.3 ns |     2.07 ns |     1.73 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,032.8 ns |     7.29 ns |     6.46 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,031.5 ns |    11.67 ns |     9.75 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,147.0 ns |    18.31 ns |    16.23 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   4,663.5 ns |     8.50 ns |     7.10 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,017.7 ns |     2.93 ns |     2.29 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,036.1 ns |    11.57 ns |    10.82 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,148.1 ns |     8.87 ns |     7.86 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   4,673.1 ns |    12.71 ns |    11.89 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  22,971.0 ns |    75.00 ns |    58.56 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  30,558.3 ns |    98.02 ns |    91.69 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  31,387.8 ns |    85.36 ns |    75.67 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  35,740.4 ns |   203.45 ns |   169.89 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 365,178.5 ns |   726.56 ns |   679.62 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 503,445.0 ns | 1,551.94 ns | 1,375.75 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 510,925.8 ns | 2,083.87 ns | 1,949.26 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 568,685.7 ns |   795.10 ns |   704.83 ns |         - |