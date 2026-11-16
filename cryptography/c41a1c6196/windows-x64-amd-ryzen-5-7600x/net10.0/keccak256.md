| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     248.9 ns |   4.77 ns |   3.98 ns |   5,456 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     315.3 ns |   1.24 ns |   1.16 ns |   4,947 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     324.4 ns |   0.40 ns |   0.37 ns |   3,960 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     380.2 ns |   1.56 ns |   1.39 ns |   6,276 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     475.4 ns |   4.00 ns |   3.74 ns |   5,433 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     619.5 ns |   6.48 ns |   6.37 ns |   4,928 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     638.0 ns |   1.42 ns |   1.33 ns |   3,937 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     726.8 ns |   2.63 ns |   2.19 ns |   7,661 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   1,845.5 ns |  10.35 ns |   8.65 ns |   5,444 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,414.4 ns |   3.05 ns |   2.54 ns |   4,935 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,479.4 ns |   3.48 ns |   3.08 ns |   3,964 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,837.5 ns |   9.24 ns |   7.72 ns |   7,637 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,860.1 ns |  16.07 ns |  14.24 ns |   5,444 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,415.3 ns |   3.18 ns |   2.97 ns |   4,935 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,474.3 ns |   1.85 ns |   1.64 ns |   3,948 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,830.8 ns |   7.82 ns |   6.94 ns |   7,652 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  13,942.0 ns |  37.35 ns |  29.16 ns |   5,440 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  18,321.9 ns |  24.57 ns |  22.98 ns |   4,931 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  18,776.9 ns |  13.11 ns |  12.27 ns |   3,944 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  21,484.5 ns |  38.72 ns |  32.34 ns |   7,648 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 220,416.4 ns | 391.08 ns | 305.33 ns |   5,442 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 288,622.0 ns | 119.12 ns |  99.47 ns |   4,933 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 296,819.0 ns | 432.19 ns | 404.27 ns |   3,946 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 336,871.6 ns | 731.39 ns | 610.74 ns |   7,635 B |         - |