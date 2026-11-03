| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     465.0 ns |   0.68 ns |   0.64 ns |   5,435 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     611.6 ns |   0.34 ns |   0.32 ns |   4,926 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     632.8 ns |   0.47 ns |   0.44 ns |   3,939 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     728.4 ns |   1.66 ns |   1.55 ns |   7,943 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     465.0 ns |   0.64 ns |   0.60 ns |   5,435 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     620.4 ns |   0.38 ns |   0.36 ns |   4,926 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     632.3 ns |   0.31 ns |   0.29 ns |   3,939 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     731.1 ns |   0.79 ns |   0.70 ns |   7,899 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,277.0 ns |   7.39 ns |   6.92 ns |   5,444 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   3,002.7 ns |   1.07 ns |   0.95 ns |   4,935 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   3,080.9 ns |   1.63 ns |   1.53 ns |   3,948 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,561.6 ns |   3.86 ns |   3.61 ns |   7,938 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,276.5 ns |   5.23 ns |   4.89 ns |   5,444 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   3,011.6 ns |   1.39 ns |   1.23 ns |   4,935 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   3,082.5 ns |   2.29 ns |   2.15 ns |   3,948 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,555.5 ns |   4.58 ns |   4.06 ns |   7,896 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  17,891.1 ns |  60.61 ns |  56.70 ns |   5,442 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  23,727.6 ns |   6.80 ns |   5.68 ns |   4,935 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  24,234.8 ns |  12.89 ns |  12.06 ns |   3,951 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  27,842.5 ns |  35.65 ns |  33.35 ns |   7,913 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 285,206.2 ns | 704.62 ns | 659.11 ns |   5,449 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 378,284.7 ns | 160.24 ns | 149.89 ns |   4,940 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 386,341.5 ns | 101.54 ns |  90.01 ns |   3,953 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 447,140.0 ns | 681.47 ns | 637.45 ns |   7,919 B |         - |