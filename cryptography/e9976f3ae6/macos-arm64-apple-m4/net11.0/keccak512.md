| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     308.2 ns |     0.62 ns |     0.58 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     321.1 ns |     1.82 ns |     1.70 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     328.6 ns |     1.00 ns |     0.94 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     307.7 ns |     0.90 ns |     0.84 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     321.1 ns |     2.56 ns |     2.39 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     329.8 ns |     1.03 ns |     0.96 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,262.0 ns |     7.39 ns |     6.92 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,282.1 ns |    12.70 ns |    10.60 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,406.1 ns |    13.54 ns |    12.67 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,263.9 ns |     5.20 ns |     4.87 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,285.3 ns |    14.35 ns |    13.42 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,414.3 ns |     6.69 ns |     6.26 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  17,164.5 ns |    44.31 ns |    41.44 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,175.6 ns |   113.56 ns |   106.22 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  18,225.3 ns |    50.51 ns |    47.25 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 274,911.0 ns | 1,497.01 ns | 1,327.06 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 275,835.3 ns |   682.72 ns |   638.62 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 291,614.6 ns | 1,068.09 ns |   999.09 ns |         - |