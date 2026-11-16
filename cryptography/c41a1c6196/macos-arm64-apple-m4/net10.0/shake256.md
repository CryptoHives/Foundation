| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     162.4 ns |   0.67 ns |   0.63 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     172.3 ns |   0.27 ns |   0.26 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     182.7 ns |   0.72 ns |   0.68 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     311.8 ns |   0.26 ns |   0.24 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     324.9 ns |   1.27 ns |   1.12 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     331.0 ns |   1.01 ns |   0.90 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,219.8 ns |   1.71 ns |   1.60 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,249.0 ns |   4.77 ns |   4.23 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,304.7 ns |   1.88 ns |   1.67 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,218.8 ns |   2.66 ns |   2.49 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,252.0 ns |   3.72 ns |   3.30 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,303.9 ns |   1.43 ns |   1.20 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,204.6 ns |  24.86 ns |  22.04 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,349.7 ns |  56.27 ns |  52.64 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,837.3 ns |  10.36 ns |   9.18 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 146,708.0 ns | 370.04 ns | 346.14 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 147,426.9 ns | 237.01 ns | 210.10 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 155,708.5 ns | 198.62 ns | 176.07 ns |         - |