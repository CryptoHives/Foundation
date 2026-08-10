| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     158.3 ns |   0.38 ns |   0.36 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     168.3 ns |   0.53 ns |   0.41 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     178.5 ns |   0.87 ns |   0.78 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     307.1 ns |   0.30 ns |   0.28 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     326.8 ns |   0.16 ns |   0.13 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     331.7 ns |   0.76 ns |   0.64 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,218.7 ns |   1.55 ns |   1.37 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,270.4 ns |   6.71 ns |   5.95 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,287.8 ns |   2.77 ns |   2.46 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,218.0 ns |   0.48 ns |   0.45 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,288.3 ns |   1.46 ns |   1.36 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,307.5 ns |   2.98 ns |   2.49 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,211.6 ns |  13.51 ns |  12.64 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,589.2 ns |  48.18 ns |  42.71 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,750.4 ns |  16.20 ns |  15.15 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 146,361.8 ns | 530.32 ns | 496.06 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 151,849.6 ns | 673.35 ns | 562.28 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 154,400.3 ns | 357.97 ns | 334.85 ns |         - |