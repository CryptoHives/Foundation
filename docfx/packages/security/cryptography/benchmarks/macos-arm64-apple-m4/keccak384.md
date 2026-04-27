| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     302.7 ns |   0.24 ns |   0.20 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     320.5 ns |   0.65 ns |   0.54 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     327.2 ns |   2.57 ns |   2.28 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     307.3 ns |   0.39 ns |   0.33 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     321.3 ns |   0.81 ns |   0.76 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     324.3 ns |   0.62 ns |   0.55 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,528.8 ns |   2.72 ns |   2.12 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,566.6 ns |   6.17 ns |   5.47 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,593.9 ns |   2.19 ns |   2.05 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,530.2 ns |   1.04 ns |   0.92 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,574.6 ns |   6.88 ns |   6.10 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,595.7 ns |   3.03 ns |   2.83 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  12,051.4 ns |   7.42 ns |   6.58 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,163.8 ns |  30.93 ns |  27.42 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,493.0 ns |  12.34 ns |  10.30 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 192,623.2 ns | 165.46 ns | 129.18 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 195,703.5 ns | 953.01 ns | 795.80 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 200,130.6 ns | 221.99 ns | 196.79 ns |         - |