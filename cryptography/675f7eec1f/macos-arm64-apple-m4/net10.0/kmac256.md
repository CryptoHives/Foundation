| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     489.2 ns |   0.42 ns |   0.39 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,042.1 ns |   1.75 ns |   1.46 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     638.3 ns |   1.60 ns |   1.50 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,195.7 ns |   2.62 ns |   2.32 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,552.6 ns |   1.46 ns |   1.37 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,197.7 ns |   9.00 ns |   8.42 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,534.1 ns |   1.51 ns |   1.41 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,198.8 ns |   7.77 ns |   7.27 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,592.8 ns |   3.60 ns |   3.20 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,357.3 ns |  49.92 ns |  46.70 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 146,052.2 ns | 163.54 ns | 144.97 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 151,429.0 ns | 653.99 ns | 579.75 ns |     256 B |