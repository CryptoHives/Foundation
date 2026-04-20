| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     157.3 ns |   0.24 ns |   0.20 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     166.9 ns |   0.15 ns |   0.12 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     178.3 ns |   0.29 ns |   0.22 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     305.8 ns |   0.89 ns |   0.74 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     324.9 ns |   1.03 ns |   0.86 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     331.1 ns |   6.38 ns |   6.83 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,232.5 ns |   2.49 ns |   2.33 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,267.5 ns |   2.82 ns |   2.50 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,286.0 ns |   3.37 ns |   3.15 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,221.1 ns |   1.44 ns |   1.28 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,268.5 ns |   4.55 ns |   4.04 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,286.1 ns |   3.21 ns |   2.84 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,269.5 ns |  10.51 ns |   9.31 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,519.3 ns |  39.63 ns |  35.13 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,740.7 ns |  28.12 ns |  24.93 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 147,398.1 ns | 113.86 ns | 100.93 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 150,396.5 ns | 549.22 ns | 458.62 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 153,848.1 ns | 245.89 ns | 217.97 ns |         - |