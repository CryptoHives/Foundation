| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     484.9 ns |   0.85 ns |   0.76 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,025.1 ns |   3.64 ns |   3.41 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     632.7 ns |   1.02 ns |   0.90 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,175.4 ns |   3.31 ns |   3.10 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,530.0 ns |   2.54 ns |   2.12 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,107.5 ns |   7.49 ns |   6.25 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,552.6 ns |   2.48 ns |   2.32 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,112.3 ns |   7.94 ns |   7.04 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,483.1 ns |  28.39 ns |  23.71 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,041.8 ns |  21.81 ns |  18.21 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 145,258.1 ns | 182.37 ns | 170.59 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 147,505.5 ns | 951.18 ns | 794.28 ns |     256 B |