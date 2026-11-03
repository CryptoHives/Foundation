| Description                                    | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     488.8 ns |     1.72 ns |   1.61 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,034.7 ns |     4.31 ns |   3.82 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     635.4 ns |     0.54 ns |   0.50 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,176.6 ns |     4.25 ns |   3.98 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,534.8 ns |     1.86 ns |   1.74 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,106.2 ns |     8.74 ns |   7.75 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,530.1 ns |     0.99 ns |   0.88 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,103.0 ns |     9.72 ns |   9.09 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,478.4 ns |     6.13 ns |   5.74 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,079.4 ns |    27.07 ns |  22.60 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 144,861.2 ns |   245.22 ns | 229.38 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 147,418.0 ns | 1,041.23 ns | 973.96 ns |     256 B |