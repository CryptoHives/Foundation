| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     417.1 ns |     1.00 ns |     0.89 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     550.4 ns |     3.08 ns |     2.89 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     572.8 ns |     3.07 ns |     2.40 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     645.5 ns |     1.56 ns |     1.30 ns |   9,155 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     416.4 ns |     0.45 ns |     0.37 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     549.2 ns |     1.80 ns |     1.59 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     576.0 ns |     4.76 ns |     3.97 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     646.8 ns |     2.12 ns |     1.88 ns |   9,228 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,045.3 ns |     5.41 ns |     4.80 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,042.3 ns |    14.70 ns |    13.03 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,158.3 ns |    15.10 ns |    13.38 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   4,719.7 ns |     9.33 ns |     7.28 ns |   9,237 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,046.7 ns |     8.83 ns |     7.37 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,035.9 ns |    20.36 ns |    19.04 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,157.1 ns |    11.03 ns |    10.32 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   4,699.8 ns |     7.65 ns |     6.39 ns |   9,241 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  23,085.8 ns |    67.34 ns |    62.99 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  30,588.4 ns |    43.45 ns |    40.64 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  31,523.3 ns |   139.84 ns |   123.96 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  35,903.2 ns |    48.04 ns |    44.93 ns |   9,208 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 368,315.1 ns |   483.00 ns |   403.33 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 488,371.5 ns | 1,061.07 ns |   940.61 ns |        NA |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 504,463.5 ns | 1,932.25 ns | 1,807.43 ns |        NA |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 570,304.6 ns | 2,365.99 ns | 1,975.71 ns |   9,208 B |         - |