| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     495.7 ns |     9.22 ns |    21.38 ns |     483.7 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,027.7 ns |     4.93 ns |     4.61 ns |   1,027.6 ns |     256 B |
|                                                |              |              |             |             |              |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     630.7 ns |     1.02 ns |     0.80 ns |     630.6 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,173.7 ns |     5.45 ns |     5.10 ns |   1,173.5 ns |     256 B |
|                                                |              |              |             |             |              |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,563.7 ns |    29.62 ns |    66.25 ns |   1,527.0 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,103.4 ns |    10.78 ns |    10.09 ns |   2,105.4 ns |     256 B |
|                                                |              |              |             |             |              |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,540.1 ns |    19.06 ns |    15.91 ns |   1,546.7 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,103.2 ns |    15.61 ns |    13.84 ns |   2,097.8 ns |     256 B |
|                                                |              |              |             |             |              |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,451.2 ns |    11.32 ns |    10.03 ns |   9,450.7 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,090.6 ns |    60.28 ns |    53.44 ns |  10,076.5 ns |     256 B |
|                                                |              |              |             |             |              |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 144,787.5 ns |   129.24 ns |   114.57 ns | 144,758.1 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 146,864.1 ns | 1,230.90 ns | 1,151.38 ns | 146,246.9 ns |     256 B |