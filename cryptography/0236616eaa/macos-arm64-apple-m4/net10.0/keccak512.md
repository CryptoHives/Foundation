| Description                                      | TestDataSize | Mean       | Error     | StdDev    | Median     | Allocated |
|------------------------------------------------- |------------- |-----------:|----------:|----------:|-----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |   1.407 μs | 0.0057 μs | 0.0054 μs |   1.405 μs |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |   1.489 μs | 0.0059 μs | 0.0046 μs |   1.487 μs |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |   1.518 μs | 0.0115 μs | 0.0128 μs |   1.511 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |   1.407 μs | 0.0008 μs | 0.0007 μs |   1.406 μs |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |   1.494 μs | 0.0127 μs | 0.0112 μs |   1.491 μs |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |   1.516 μs | 0.0047 μs | 0.0041 μs |   1.514 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2.327 μs | 0.0435 μs | 0.1100 μs |   2.285 μs |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |  10.523 μs | 0.0048 μs | 0.0040 μs |  10.522 μs |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |  11.208 μs | 0.0388 μs | 0.0344 μs |  11.186 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2.232 μs | 0.0026 μs | 0.0024 μs |   2.231 μs |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2.274 μs | 0.0311 μs | 0.0291 μs |   2.268 μs |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2.376 μs | 0.0055 μs | 0.0051 μs |   2.374 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  16.948 μs | 0.0187 μs | 0.0175 μs |  16.943 μs |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17.189 μs | 0.2480 μs | 0.2320 μs |  17.182 μs |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  18.012 μs | 0.0398 μs | 0.0372 μs |  17.990 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 270.936 μs | 0.3321 μs | 0.3106 μs | 270.877 μs |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 279.518 μs | 2.3745 μs | 2.2211 μs | 278.928 μs |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 288.123 μs | 0.5869 μs | 0.5202 μs | 288.083 μs |         - |