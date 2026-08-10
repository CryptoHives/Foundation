| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     159.8 ns |   0.51 ns |   0.47 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     170.5 ns |   0.42 ns |   0.39 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     179.2 ns |   0.66 ns |   0.62 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     307.9 ns |   0.92 ns |   0.81 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     326.3 ns |   2.30 ns |   2.15 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     328.6 ns |   0.44 ns |   0.42 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,209.9 ns |   2.59 ns |   2.42 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,268.4 ns |   3.87 ns |   3.23 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,291.1 ns |   2.40 ns |   2.25 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,210.9 ns |   4.08 ns |   3.82 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,272.7 ns |   6.89 ns |   6.45 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,288.9 ns |   3.74 ns |   3.50 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,199.9 ns |  12.82 ns |  12.00 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,507.5 ns |  37.01 ns |  30.90 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,761.4 ns |  15.75 ns |  14.73 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 145,825.4 ns | 228.96 ns | 214.17 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 152,791.8 ns | 793.26 ns | 703.21 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 154,176.4 ns | 255.60 ns | 239.08 ns |         - |