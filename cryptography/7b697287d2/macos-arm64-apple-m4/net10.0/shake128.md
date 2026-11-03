| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     161.4 ns |   0.22 ns |   0.20 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     173.2 ns |   0.27 ns |   0.23 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     175.5 ns |   1.48 ns |   1.39 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     161.9 ns |   0.19 ns |   0.16 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     173.2 ns |   0.25 ns |   0.22 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     176.3 ns |   0.79 ns |   0.74 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,051.2 ns |   1.70 ns |   1.59 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,089.9 ns |   5.27 ns |   4.40 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,134.5 ns |   1.82 ns |   1.71 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,055.2 ns |   5.01 ns |   4.68 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,097.8 ns |   8.80 ns |   8.23 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,141.2 ns |   3.93 ns |   3.28 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,330.2 ns |  20.14 ns |  18.84 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,551.3 ns |  63.93 ns |  59.80 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,929.3 ns |  27.53 ns |  25.75 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 117,676.9 ns | 423.87 ns | 396.49 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 120,154.1 ns | 648.19 ns | 574.60 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 125,984.6 ns | 494.39 ns | 462.46 ns |         - |