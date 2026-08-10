| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     302.4 ns |     0.65 ns |     0.58 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     322.1 ns |     0.44 ns |     0.39 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     322.6 ns |     1.21 ns |     1.07 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     300.1 ns |     0.32 ns |     0.28 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     322.0 ns |     0.37 ns |     0.35 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     323.6 ns |     0.79 ns |     0.70 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,493.5 ns |     1.30 ns |     1.22 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,585.8 ns |     1.21 ns |     1.01 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,594.7 ns |     1.72 ns |     1.44 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,493.0 ns |     0.90 ns |     0.80 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,561.5 ns |     6.35 ns |     5.30 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,585.6 ns |     1.46 ns |     1.30 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,771.0 ns |    10.86 ns |    10.16 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,156.3 ns |   115.31 ns |   107.86 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,492.5 ns |    22.46 ns |    21.01 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 189,417.5 ns |   154.67 ns |   144.68 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 198,459.5 ns | 1,957.03 ns | 1,634.21 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 198,889.5 ns |   454.06 ns |   424.73 ns |         - |