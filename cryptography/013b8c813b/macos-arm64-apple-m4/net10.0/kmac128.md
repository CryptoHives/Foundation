| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     485.2 ns |   0.59 ns |   0.55 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,060.1 ns |   4.81 ns |   4.50 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     483.6 ns |   0.51 ns |   0.43 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,071.9 ns |   3.54 ns |   3.31 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,385.9 ns |   1.64 ns |   1.53 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   1,994.4 ns |   4.49 ns |   4.20 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,372.6 ns |   0.54 ns |   0.50 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   2,057.4 ns |  11.63 ns |  10.88 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,678.9 ns |   3.77 ns |   3.34 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,551.5 ns |  30.06 ns |  26.65 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 116,595.4 ns |  84.89 ns |  75.26 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 126,294.7 ns | 997.15 ns | 932.74 ns |     256 B |