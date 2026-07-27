| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     162.0 ns |   0.30 ns |   0.28 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     171.6 ns |   0.40 ns |   0.38 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     181.9 ns |   1.47 ns |   1.37 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     161.8 ns |   0.21 ns |   0.19 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     171.7 ns |   0.54 ns |   0.50 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     182.0 ns |   0.68 ns |   0.64 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,057.3 ns |   2.02 ns |   1.89 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,123.6 ns |   7.99 ns |   7.08 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,136.4 ns |   1.90 ns |   1.77 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,059.6 ns |   1.96 ns |   1.84 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,137.4 ns |   1.08 ns |   1.01 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,149.0 ns |   3.01 ns |   2.81 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,335.5 ns |  18.47 ns |  17.27 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,724.1 ns |  35.59 ns |  29.72 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,863.1 ns |  17.64 ns |  16.50 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 117,130.3 ns | 245.03 ns | 229.20 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 122,788.7 ns | 669.28 ns | 558.88 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 125,342.2 ns | 226.10 ns | 211.49 ns |         - |