| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     318.2 ns |     2.58 ns |     2.28 ns |     318.0 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     321.9 ns |     0.90 ns |     0.80 ns |     321.8 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     873.5 ns |   194.60 ns |   573.77 ns |     415.1 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     300.4 ns |     1.18 ns |     1.04 ns |     300.2 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     320.6 ns |     3.56 ns |     3.33 ns |     319.6 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     322.6 ns |     1.65 ns |     1.46 ns |     322.3 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,231.1 ns |     7.55 ns |     6.30 ns |   2,228.8 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,321.2 ns |    16.20 ns |    13.53 ns |   2,319.3 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,382.1 ns |     8.29 ns |     6.92 ns |   2,379.7 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,230.3 ns |     5.46 ns |     4.56 ns |   2,228.9 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,258.6 ns |    14.50 ns |    12.11 ns |   2,255.8 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,380.6 ns |     9.11 ns |     7.61 ns |   2,378.0 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  17,024.5 ns |   143.94 ns |   120.20 ns |  16,980.5 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,099.9 ns |   131.47 ns |   122.97 ns |  17,038.0 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  18,026.7 ns |    36.61 ns |    32.45 ns |  18,027.8 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 271,802.8 ns |   430.15 ns |   402.36 ns | 271,764.0 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 272,784.1 ns | 1,226.66 ns | 1,024.31 ns | 272,511.2 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 288,042.0 ns |   498.24 ns |   416.05 ns | 288,011.9 ns |         - |