| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     490.2 ns |   0.52 ns |   0.48 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,064.9 ns |   4.58 ns |   4.29 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     489.2 ns |   0.72 ns |   0.68 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,061.2 ns |   4.29 ns |   4.01 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,389.8 ns |   1.90 ns |   1.69 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   2,016.1 ns |   6.00 ns |   5.61 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,382.5 ns |   3.88 ns |   3.63 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   2,023.3 ns |   7.50 ns |   6.65 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,695.7 ns |   8.62 ns |   8.06 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,611.2 ns |  42.90 ns |  40.13 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 117,400.9 ns | 336.31 ns | 298.13 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 124,464.7 ns | 770.54 ns | 720.76 ns |     256 B |