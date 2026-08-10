| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     299.5 ns |     0.84 ns |     0.74 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     320.0 ns |     1.27 ns |     1.19 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     324.8 ns |     1.42 ns |     1.18 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     302.5 ns |     0.37 ns |     0.33 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     320.0 ns |     0.48 ns |     0.45 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     324.4 ns |     0.86 ns |     0.76 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,243.6 ns |     3.43 ns |     3.21 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,311.1 ns |     8.30 ns |     6.93 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,375.7 ns |     2.37 ns |     1.98 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,244.8 ns |     3.42 ns |     3.20 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,321.4 ns |    10.65 ns |     9.96 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,373.1 ns |     1.61 ns |     1.43 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  17,061.7 ns |    12.47 ns |    11.05 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,428.4 ns |    88.79 ns |    74.14 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  17,997.0 ns |    28.32 ns |    26.49 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 272,824.5 ns |   364.28 ns |   322.92 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 278,497.1 ns | 1,234.30 ns | 1,094.18 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 287,967.4 ns |   397.86 ns |   372.16 ns |         - |