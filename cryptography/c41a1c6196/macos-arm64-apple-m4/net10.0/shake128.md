| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     162.4 ns |   0.51 ns |   0.48 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     174.6 ns |   0.36 ns |   0.30 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     181.6 ns |   0.82 ns |   0.73 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     163.3 ns |   0.11 ns |   0.10 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     175.1 ns |   0.29 ns |   0.24 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     177.8 ns |   0.68 ns |   0.63 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,063.3 ns |   1.14 ns |   1.01 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,103.8 ns |   7.24 ns |   6.78 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,146.6 ns |   3.50 ns |   3.27 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,064.0 ns |   1.46 ns |   1.37 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,101.0 ns |   4.66 ns |   4.36 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,145.5 ns |   2.11 ns |   1.98 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,384.8 ns |   6.90 ns |   6.46 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,576.8 ns |  38.19 ns |  35.73 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,936.4 ns |   8.82 ns |   7.36 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 118,265.1 ns | 141.98 ns | 132.81 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 120,768.0 ns | 452.77 ns | 423.52 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 126,434.4 ns | 241.89 ns | 214.43 ns |         - |