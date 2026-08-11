| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     304.0 ns |     0.95 ns |     0.74 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     321.3 ns |     4.98 ns |     4.66 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     326.0 ns |     5.23 ns |     4.89 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     305.2 ns |     0.59 ns |     0.46 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     321.3 ns |     5.15 ns |     4.57 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     322.5 ns |     0.91 ns |     0.71 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,515.1 ns |    25.81 ns |    24.15 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,550.6 ns |    24.12 ns |    22.56 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,603.7 ns |    23.44 ns |    21.92 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,510.3 ns |    23.05 ns |    21.56 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,553.0 ns |    30.11 ns |    28.17 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,605.3 ns |    23.73 ns |    22.20 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,944.8 ns |   201.37 ns |   188.37 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,044.1 ns |   186.96 ns |   174.88 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,599.2 ns |   169.38 ns |   158.44 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 191,587.6 ns | 2,721.78 ns | 2,545.96 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 191,609.1 ns | 2,779.39 ns | 2,599.85 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 201,832.2 ns | 2,802.40 ns | 2,621.37 ns |         - |