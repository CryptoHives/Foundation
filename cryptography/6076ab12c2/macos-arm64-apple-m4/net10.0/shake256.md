| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     164.0 ns |   0.27 ns |   0.26 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     173.2 ns |   0.26 ns |   0.23 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     178.3 ns |   0.64 ns |   0.57 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     309.7 ns |   0.19 ns |   0.18 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     326.4 ns |   1.15 ns |   1.02 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     333.3 ns |   0.36 ns |   0.32 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,225.1 ns |   0.75 ns |   0.70 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,258.6 ns |   4.48 ns |   3.97 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,313.0 ns |   2.84 ns |   2.51 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,225.4 ns |   1.05 ns |   0.98 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,261.0 ns |   6.64 ns |   6.21 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,314.8 ns |   3.12 ns |   2.76 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,289.3 ns |   5.36 ns |   5.01 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,383.1 ns |  52.03 ns |  48.67 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,916.2 ns |  27.46 ns |  24.34 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 148,288.7 ns | 145.51 ns | 121.51 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 149,058.6 ns | 717.84 ns | 636.35 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 156,815.7 ns | 292.04 ns | 273.18 ns |         - |