| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128B         |     250.9 ns |     0.87 ns |   0.73 ns |  16,138 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128B         |     326.8 ns |     0.22 ns |   0.21 ns |  15,620 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128B         |     328.3 ns |     0.33 ns |   0.30 ns |   8,308 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128B         |     400.2 ns |     1.81 ns |   1.69 ns |   8,778 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 137B         |     473.6 ns |     1.66 ns |   1.39 ns |  16,317 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 137B         |     619.1 ns |     0.42 ns |   0.39 ns |  15,799 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 137B         |     653.5 ns |     0.46 ns |   0.39 ns |  14,822 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 137B         |     725.5 ns |     1.52 ns |   1.27 ns |  16,509 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1KB          |   2,103.0 ns |    11.77 ns |   9.83 ns |  16,134 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1KB          |   2,410.9 ns |     1.69 ns |   1.58 ns |  15,815 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1KB          |   2,502.6 ns |     1.22 ns |   1.02 ns |  14,639 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1KB          |   2,834.0 ns |     9.43 ns |   8.36 ns |  16,473 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 1025B        |   1,852.0 ns |     4.22 ns |   3.52 ns |  16,134 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 1025B        |   2,398.9 ns |     2.42 ns |   2.15 ns |   9,290 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 1025B        |   2,494.3 ns |     1.81 ns |   1.69 ns |  14,648 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 1025B        |   2,849.9 ns |    25.39 ns |  23.75 ns |  16,473 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 8KB          |  14,033.7 ns |    25.39 ns |  22.50 ns |  16,134 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 8KB          |  18,533.6 ns |    21.11 ns |  19.74 ns |  15,815 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 8KB          |  18,872.3 ns |    16.25 ns |  13.57 ns |  14,648 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 8KB          |  21,324.5 ns |    63.58 ns |  56.36 ns |  16,465 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar  | 128KB        | 221,622.6 ns | 1,003.76 ns | 938.92 ns |   9,790 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2    | 128KB        | 294,433.7 ns |   147.61 ns | 130.85 ns |   9,290 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX512F | 128KB        | 298,080.3 ns |   215.96 ns | 180.33 ns |   8,313 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle        | 128KB        | 337,642.5 ns |   589.44 ns | 492.21 ns |  16,665 B |         - |