| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     303.7 ns |     0.29 ns |     0.27 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     323.1 ns |     2.36 ns |     2.09 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     326.0 ns |     0.32 ns |     0.27 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     303.3 ns |     0.29 ns |     0.27 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     323.7 ns |     2.57 ns |     2.40 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     327.2 ns |     0.71 ns |     0.66 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,496.6 ns |     1.21 ns |     1.13 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,579.4 ns |    10.28 ns |     9.62 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,604.1 ns |     2.24 ns |     2.10 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,497.1 ns |     1.70 ns |     1.59 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,553.3 ns |    18.11 ns |    16.94 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,605.9 ns |     5.14 ns |     4.81 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,774.7 ns |     9.63 ns |     8.54 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  11,939.0 ns |    73.26 ns |    68.52 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,605.7 ns |    24.55 ns |    22.96 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 189,575.9 ns |   101.53 ns |    79.27 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 191,081.0 ns | 1,617.00 ns | 1,512.55 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 201,268.1 ns |   499.35 ns |   467.09 ns |         - |