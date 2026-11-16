| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     492.1 ns |   1.57 ns |   1.47 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,038.0 ns |   3.53 ns |   2.94 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     642.3 ns |   1.58 ns |   1.48 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,186.9 ns |   5.30 ns |   4.96 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,553.7 ns |   5.40 ns |   5.05 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,126.5 ns |   8.27 ns |   7.73 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,549.5 ns |   4.48 ns |   4.19 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,168.8 ns |   6.07 ns |   5.68 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,596.1 ns |  22.35 ns |  20.91 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,164.2 ns |  61.16 ns |  57.21 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 146,919.9 ns | 305.35 ns | 270.69 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 148,887.0 ns | 848.72 ns | 793.89 ns |     256 B |