| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     479.9 ns |   0.83 ns |   0.78 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,034.3 ns |   3.09 ns |   2.89 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     628.7 ns |   0.72 ns |   0.63 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,184.3 ns |   3.03 ns |   2.83 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,523.0 ns |   1.40 ns |   1.24 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,122.0 ns |   9.40 ns |   7.85 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,524.3 ns |   3.56 ns |   2.98 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,122.2 ns |   7.18 ns |   6.71 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,427.9 ns |  15.72 ns |  13.13 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,293.9 ns |  40.63 ns |  33.92 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 144,662.7 ns | 212.98 ns | 199.22 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 153,577.0 ns | 574.49 ns | 537.38 ns |     256 B |