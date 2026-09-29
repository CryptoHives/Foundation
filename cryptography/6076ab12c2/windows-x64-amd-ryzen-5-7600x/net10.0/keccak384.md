| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     464.8 ns |     1.18 ns |   0.99 ns |   5,435 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     610.8 ns |     0.22 ns |   0.20 ns |   4,944 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     632.9 ns |     0.55 ns |   0.52 ns |   3,939 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     726.5 ns |     1.38 ns |   1.29 ns |   7,938 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     467.1 ns |     0.75 ns |   0.63 ns |   5,435 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     612.3 ns |     0.55 ns |   0.52 ns |   4,944 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     638.1 ns |     0.54 ns |   0.50 ns |   3,939 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     729.0 ns |     1.02 ns |   0.90 ns |   7,910 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,274.9 ns |     5.31 ns |   4.71 ns |   5,444 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   3,009.8 ns |     1.37 ns |   1.21 ns |   4,953 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   3,079.2 ns |     1.69 ns |   1.58 ns |   3,948 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,575.9 ns |     3.63 ns |   3.40 ns |   7,913 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,276.1 ns |     4.46 ns |   4.18 ns |   5,444 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,997.9 ns |     1.23 ns |   1.15 ns |   4,953 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   3,080.4 ns |     1.84 ns |   1.72 ns |   3,948 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,574.6 ns |     5.35 ns |   5.01 ns |   7,925 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  17,910.1 ns |    42.25 ns |  39.52 ns |   5,442 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  23,590.7 ns |    11.45 ns |  10.71 ns |   4,951 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  24,225.3 ns |    15.48 ns |  14.48 ns |   3,946 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  27,865.4 ns |    35.69 ns |  31.63 ns |   7,912 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 285,581.4 ns | 1,008.96 ns | 943.78 ns |   5,449 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 377,734.5 ns |   128.75 ns | 114.13 ns |   4,958 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 386,846.3 ns |   213.58 ns | 189.33 ns |   3,953 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 442,749.5 ns |   356.47 ns | 333.44 ns |   7,919 B |         - |