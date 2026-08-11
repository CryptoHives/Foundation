| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     161.6 ns |   0.34 ns |   0.32 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     171.7 ns |   0.44 ns |   0.39 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     173.6 ns |   1.61 ns |   1.50 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     161.3 ns |   0.49 ns |   0.45 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     171.7 ns |   0.21 ns |   0.20 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     174.6 ns |   1.43 ns |   1.34 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,060.6 ns |   3.62 ns |   3.39 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,085.4 ns |   2.82 ns |   2.36 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,131.6 ns |   3.15 ns |   2.95 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,063.6 ns |   4.02 ns |   3.56 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,084.0 ns |   2.06 ns |   1.61 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,134.6 ns |   3.73 ns |   3.12 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,352.0 ns |   6.52 ns |   5.78 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,504.2 ns |  19.62 ns |  17.39 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,872.8 ns |  17.81 ns |  16.66 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 118,101.0 ns |  59.22 ns |  55.40 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 119,205.6 ns | 336.42 ns | 298.22 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 125,349.4 ns | 900.67 ns | 842.49 ns |         - |