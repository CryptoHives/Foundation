| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     156.8 ns |   0.12 ns |   0.10 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     170.3 ns |   0.22 ns |   0.19 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     179.6 ns |   0.86 ns |   0.67 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     314.6 ns |   6.04 ns |   6.20 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     331.7 ns |   5.69 ns |   6.32 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     333.6 ns |   6.53 ns |   8.26 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,224.8 ns |   9.86 ns |   8.24 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,288.6 ns |   2.16 ns |   1.69 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,301.6 ns |   4.47 ns |   3.49 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,218.6 ns |   1.32 ns |   1.24 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,288.0 ns |   2.84 ns |   2.65 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,300.9 ns |   2.76 ns |   2.45 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,286.8 ns |  11.57 ns |  10.25 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,492.8 ns |  32.86 ns |  30.74 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,728.2 ns |  17.76 ns |  15.74 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 146,779.2 ns | 238.13 ns | 211.10 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 149,803.9 ns | 924.86 ns | 772.30 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 153,747.4 ns | 209.09 ns | 195.59 ns |         - |