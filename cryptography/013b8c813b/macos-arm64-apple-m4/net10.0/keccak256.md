| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     157.3 ns |   0.18 ns |   0.17 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     166.6 ns |   0.09 ns |   0.07 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     177.2 ns |   0.51 ns |   0.43 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     304.1 ns |   0.32 ns |   0.30 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     323.5 ns |   0.87 ns |   0.77 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     324.6 ns |   0.48 ns |   0.40 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,203.1 ns |   1.15 ns |   1.02 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,272.9 ns |   7.54 ns |   6.68 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,287.6 ns |  11.45 ns |   9.56 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,203.7 ns |   1.36 ns |   1.21 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,262.0 ns |   4.54 ns |   4.02 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,285.2 ns |   2.39 ns |   2.24 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,205.9 ns |   8.25 ns |   7.71 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,530.1 ns |  24.37 ns |  21.61 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,682.7 ns |   6.04 ns |   5.36 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 145,944.9 ns | 167.11 ns | 156.31 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 149,002.5 ns | 327.53 ns | 290.35 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 153,006.7 ns | 272.88 ns | 255.25 ns |         - |