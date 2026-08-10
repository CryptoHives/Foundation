| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     160.9 ns |   0.16 ns |   0.15 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     169.7 ns |   0.13 ns |   0.10 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     179.4 ns |   0.53 ns |   0.44 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     303.0 ns |   0.45 ns |   0.42 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     327.0 ns |   0.30 ns |   0.25 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     330.9 ns |   6.59 ns |   7.59 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,201.9 ns |   1.13 ns |   1.06 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,261.3 ns |   1.15 ns |   1.02 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,282.6 ns |   1.70 ns |   1.50 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,201.3 ns |   1.24 ns |   1.16 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,263.6 ns |   4.36 ns |   3.87 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,281.7 ns |   0.61 ns |   0.48 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,114.5 ns |  15.16 ns |  14.19 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,425.8 ns |  42.59 ns |  35.57 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,683.6 ns |   6.88 ns |   6.10 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 144,570.2 ns | 228.87 ns | 214.08 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 149,071.9 ns | 362.25 ns | 321.13 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 153,241.2 ns | 289.84 ns | 271.12 ns |         - |