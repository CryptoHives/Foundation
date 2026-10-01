| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     302.8 ns |   0.38 ns |   0.34 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     318.8 ns |   1.20 ns |   1.00 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     323.8 ns |   0.88 ns |   0.82 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     302.7 ns |   0.42 ns |   0.37 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     321.0 ns |   3.07 ns |   2.87 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     323.9 ns |   0.21 ns |   0.17 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,233.3 ns |   2.14 ns |   1.90 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,270.7 ns |  24.06 ns |  22.51 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,380.6 ns |   4.39 ns |   4.11 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,231.8 ns |   2.89 ns |   2.70 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,265.8 ns |  24.53 ns |  21.74 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,380.5 ns |   4.61 ns |   3.85 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  16,935.0 ns |  15.27 ns |  14.28 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  16,936.4 ns |  49.45 ns |  41.29 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  18,037.7 ns |  41.53 ns |  36.82 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 270,471.4 ns | 714.43 ns | 596.58 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 271,568.4 ns | 285.94 ns | 267.47 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 287,720.9 ns | 281.40 ns | 234.98 ns |         - |