| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     300.6 ns |     0.60 ns |     0.47 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     318.1 ns |     0.82 ns |     0.64 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     320.3 ns |     6.29 ns |     5.89 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     301.0 ns |     0.53 ns |     0.41 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     322.2 ns |     5.78 ns |     5.41 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     324.0 ns |     5.53 ns |     5.17 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,241.3 ns |     2.51 ns |     1.96 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,258.5 ns |     7.46 ns |     5.83 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,364.0 ns |     7.10 ns |     5.54 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,240.5 ns |     2.74 ns |     2.14 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,276.6 ns |    37.77 ns |    33.48 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,388.2 ns |    40.28 ns |    37.68 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  17,008.6 ns |    17.96 ns |    15.00 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,166.6 ns |   159.09 ns |   124.20 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  17,941.8 ns |    29.86 ns |    23.31 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 273,355.5 ns | 1,799.85 ns | 1,502.96 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 273,378.7 ns | 2,321.51 ns | 1,938.57 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 286,725.3 ns | 1,053.44 ns |   822.45 ns |         - |