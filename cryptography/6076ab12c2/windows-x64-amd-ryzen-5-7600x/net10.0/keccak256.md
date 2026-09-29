| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     240.2 ns |   0.66 ns |   0.62 ns |   5,472 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     320.4 ns |   0.14 ns |   0.12 ns |   4,981 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     323.1 ns |   0.42 ns |   0.40 ns |   3,960 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     373.5 ns |   0.60 ns |   0.57 ns |   6,285 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     469.1 ns |   0.52 ns |   0.43 ns |   5,433 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     612.9 ns |   0.52 ns |   0.49 ns |   4,942 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     640.1 ns |   0.30 ns |   0.28 ns |   3,937 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     718.4 ns |   1.35 ns |   1.13 ns |   7,661 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,839.7 ns |   1.40 ns |   1.17 ns |   5,444 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,422.5 ns |   1.51 ns |   1.41 ns |   4,953 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,474.3 ns |   1.64 ns |   1.53 ns |   3,948 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,839.1 ns |   5.45 ns |   5.10 ns |   7,656 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,839.9 ns |   5.71 ns |   5.06 ns |   5,460 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,428.6 ns |   2.40 ns |   2.25 ns |   4,969 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,484.8 ns |   2.01 ns |   1.88 ns |   3,948 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,831.0 ns |   4.72 ns |   4.41 ns |   7,637 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  13,950.6 ns |  21.63 ns |  20.24 ns |   5,438 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  18,353.1 ns |  12.42 ns |  11.01 ns |   4,947 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  18,769.2 ns |  16.76 ns |  15.68 ns |   3,942 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  21,465.3 ns |  25.38 ns |  23.74 ns |   7,654 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 219,854.2 ns | 434.25 ns | 384.95 ns |   5,442 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 287,392.7 ns | 104.78 ns |  92.88 ns |   4,951 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 296,132.3 ns | 269.87 ns | 252.44 ns |   3,946 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 338,446.9 ns | 684.52 ns | 640.30 ns |   7,635 B |         - |