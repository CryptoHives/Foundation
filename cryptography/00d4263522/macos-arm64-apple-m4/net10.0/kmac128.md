| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     487.9 ns |     0.57 ns |     0.44 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,056.0 ns |     4.44 ns |     3.46 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     488.1 ns |     0.79 ns |     0.62 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,034.0 ns |     2.58 ns |     2.02 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,399.1 ns |    21.16 ns |    19.80 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   1,982.7 ns |     8.86 ns |     6.92 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,391.2 ns |    19.85 ns |    18.57 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   1,957.6 ns |     6.55 ns |     5.11 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,685.3 ns |    10.59 ns |     8.27 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,368.4 ns |    47.83 ns |    37.34 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 118,222.1 ns | 1,654.05 ns | 1,547.20 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 123,117.6 ns |   669.09 ns |   522.38 ns |     256 B |