| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     158.5 ns |   0.60 ns |   0.50 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     171.4 ns |   2.35 ns |   2.20 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     181.0 ns |   1.00 ns |   0.84 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     158.6 ns |   0.71 ns |   0.60 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     171.7 ns |   1.94 ns |   1.82 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     180.5 ns |   0.58 ns |   0.45 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,072.8 ns |  12.08 ns |  11.30 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,138.1 ns |  20.45 ns |  19.13 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,149.4 ns |  11.92 ns |  11.15 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,067.6 ns |   0.55 ns |   0.48 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,136.5 ns |   7.37 ns |   6.54 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,148.3 ns |  13.98 ns |  13.08 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,456.4 ns |  74.10 ns |  69.31 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,795.7 ns |  98.13 ns |  91.79 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,942.2 ns | 102.64 ns |  96.01 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 118,130.5 ns | 114.91 ns | 107.49 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 123,132.5 ns | 356.45 ns | 333.42 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 125,449.4 ns | 626.37 ns | 523.05 ns |         - |