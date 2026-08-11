| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     161.6 ns |     2.61 ns |     2.44 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     168.8 ns |     2.65 ns |     2.35 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     171.9 ns |     3.00 ns |     2.81 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     309.5 ns |     5.63 ns |     5.27 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     317.5 ns |     5.64 ns |     5.28 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     328.7 ns |     5.25 ns |     4.91 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,230.1 ns |    23.02 ns |    21.53 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,243.9 ns |    24.54 ns |    22.96 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,295.1 ns |    20.60 ns |    19.27 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,225.4 ns |    21.53 ns |    20.14 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,240.3 ns |    17.56 ns |    15.56 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,298.3 ns |    21.02 ns |    18.63 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,195.1 ns |    14.26 ns |    11.13 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,312.0 ns |   171.40 ns |   160.33 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,821.5 ns |   181.75 ns |   170.01 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 147,684.0 ns | 2,827.18 ns | 2,644.54 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 148,094.0 ns | 2,757.48 ns | 2,579.35 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 153,828.3 ns |   276.28 ns |   215.70 ns |         - |