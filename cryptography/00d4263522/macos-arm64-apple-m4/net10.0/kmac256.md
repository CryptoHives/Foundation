| Description                                    | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     488.2 ns |     1.23 ns |   0.96 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,021.8 ns |     3.75 ns |   2.93 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     643.6 ns |    11.14 ns |  10.42 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,169.2 ns |     3.45 ns |   2.69 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,607.1 ns |    24.96 ns |  23.34 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,104.3 ns |     6.74 ns |   5.26 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,544.8 ns |    21.30 ns |  19.92 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,103.0 ns |    13.46 ns |  11.24 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,670.0 ns |   183.96 ns | 172.08 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,167.0 ns |   168.31 ns | 157.44 ns |     256 B |
|                                                |              |              |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 145,786.5 ns |   203.41 ns | 158.81 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 148,346.2 ns | 1,091.46 ns | 852.14 ns |     256 B |