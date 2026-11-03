| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     240.0 ns |   0.57 ns |   0.51 ns |   5,456 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     311.2 ns |   0.22 ns |   0.20 ns |   4,963 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     323.3 ns |   0.31 ns |   0.29 ns |   3,960 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     374.5 ns |   0.62 ns |   0.55 ns |   6,253 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     469.3 ns |   0.59 ns |   0.52 ns |   5,437 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     612.8 ns |   0.37 ns |   0.34 ns |   4,924 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     633.5 ns |   0.58 ns |   0.54 ns |   3,937 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     719.1 ns |   0.90 ns |   0.85 ns |   7,652 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,841.4 ns |   2.98 ns |   2.79 ns |   5,460 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,408.8 ns |   1.14 ns |   1.06 ns |   4,935 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,473.6 ns |   1.93 ns |   1.80 ns |   3,948 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,835.8 ns |   3.81 ns |   3.38 ns |   7,637 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,839.4 ns |   2.40 ns |   2.25 ns |   5,444 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,413.0 ns |   1.34 ns |   1.25 ns |   4,935 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,472.4 ns |   1.48 ns |   1.38 ns |   3,948 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,833.9 ns |   3.40 ns |   3.01 ns |   7,672 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  13,935.5 ns |  18.13 ns |  16.07 ns |   5,438 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  18,325.5 ns |  11.43 ns |  10.69 ns |   4,929 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  18,749.7 ns |  12.93 ns |  12.10 ns |   3,944 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  21,460.5 ns |  24.09 ns |  22.53 ns |   7,648 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 219,861.5 ns | 298.63 ns | 249.37 ns |   5,442 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 288,666.4 ns | 107.13 ns |  94.97 ns |   4,933 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 295,942.3 ns | 255.76 ns | 226.73 ns |   3,946 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 339,243.3 ns | 653.26 ns | 611.06 ns |   7,635 B |         - |