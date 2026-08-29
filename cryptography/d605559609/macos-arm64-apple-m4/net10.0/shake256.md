| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     159.1 ns |   0.27 ns |   0.24 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     170.5 ns |   0.26 ns |   0.24 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     174.4 ns |   1.07 ns |   0.95 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     304.1 ns |   0.55 ns |   0.52 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     320.4 ns |   4.75 ns |   4.44 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     328.7 ns |   0.66 ns |   0.62 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,203.8 ns |   2.13 ns |   1.89 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,229.2 ns |   4.39 ns |   3.90 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,297.1 ns |   1.58 ns |   1.32 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,205.0 ns |   1.62 ns |   1.44 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,235.3 ns |   9.98 ns |   8.33 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,300.0 ns |   1.28 ns |   1.14 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,141.1 ns |  10.62 ns |   9.93 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,250.1 ns |  67.71 ns |  63.34 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,798.7 ns |  10.66 ns |   9.45 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 145,038.7 ns | 280.40 ns | 262.29 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 145,775.5 ns | 564.48 ns | 500.40 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 154,406.1 ns | 292.38 ns | 273.49 ns |         - |