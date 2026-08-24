| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     534.8 ns |    10.51 ns |    14.73 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,108.2 ns |    15.42 ns |    13.67 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     539.4 ns |     7.91 ns |     7.40 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,153.5 ns |    18.96 ns |    32.19 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,709.9 ns |    19.97 ns |    21.37 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   2,290.8 ns |    44.69 ns |    54.88 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,793.7 ns |    21.21 ns |    16.56 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   2,326.6 ns |    45.48 ns |    73.43 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   9,866.5 ns |   196.47 ns |   359.25 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  39,474.3 ns |   270.73 ns |   253.24 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 557,677.6 ns | 2,025.87 ns | 1,895.00 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 565,018.5 ns | 4,458.01 ns | 4,170.02 ns |     256 B |