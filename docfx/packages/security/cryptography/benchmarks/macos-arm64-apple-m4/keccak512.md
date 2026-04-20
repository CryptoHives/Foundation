| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     307.1 ns |   0.32 ns |   0.25 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     320.3 ns |   0.52 ns |   0.49 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     335.7 ns |   1.27 ns |   1.13 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     303.2 ns |   0.58 ns |   0.48 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     319.1 ns |   1.03 ns |   0.96 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     326.7 ns |   1.12 ns |   1.05 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,270.7 ns |   2.30 ns |   2.04 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,340.3 ns |  18.47 ns |  17.28 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,368.3 ns |   3.71 ns |   3.29 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,299.3 ns |   4.56 ns |   4.05 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,318.3 ns |   9.56 ns |   8.94 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,369.7 ns |   6.94 ns |   6.50 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  17,202.5 ns |  19.01 ns |  16.85 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,422.1 ns |  70.30 ns |  62.32 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  17,950.7 ns |  33.82 ns |  29.98 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 274,909.7 ns | 309.68 ns | 258.60 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 277,699.9 ns | 898.75 ns | 750.50 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 286,797.2 ns | 362.25 ns | 321.13 ns |         - |