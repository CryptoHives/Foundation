| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     215.1 ns |   0.97 ns |   0.86 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     281.4 ns |   0.65 ns |   0.58 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     292.2 ns |   0.67 ns |   0.63 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     341.7 ns |   0.44 ns |   0.39 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     419.4 ns |   1.29 ns |   1.07 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     554.1 ns |   1.71 ns |   1.43 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     572.4 ns |   1.46 ns |   1.30 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     649.2 ns |   0.62 ns |   0.52 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,639.0 ns |   1.94 ns |   1.51 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,179.4 ns |   4.42 ns |   3.69 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,240.9 ns |  11.50 ns |  10.20 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,534.4 ns |   3.15 ns |   2.80 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,637.5 ns |   1.42 ns |   1.26 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,178.6 ns |   7.01 ns |   6.56 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,232.3 ns |   9.22 ns |   8.62 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,541.2 ns |   5.13 ns |   4.29 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  12,454.1 ns |  43.02 ns |  35.92 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  16,548.9 ns |  43.34 ns |  38.42 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  16,923.1 ns |  47.35 ns |  39.54 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  19,256.4 ns |  22.48 ns |  19.93 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 196,844.7 ns | 339.31 ns | 300.79 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 261,760.8 ns | 530.20 ns | 470.00 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 267,796.4 ns | 761.59 ns | 712.39 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 303,418.8 ns | 465.35 ns | 435.29 ns |         - |