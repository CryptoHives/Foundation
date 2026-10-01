| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     481.3 ns |   0.76 ns |   0.71 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,031.3 ns |   2.93 ns |   2.59 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     629.9 ns |   0.66 ns |   0.62 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,176.9 ns |   6.99 ns |   6.20 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,548.0 ns |   1.64 ns |   1.54 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,140.3 ns |  14.25 ns |  13.33 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,550.6 ns |   2.20 ns |   1.95 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,147.7 ns |  13.24 ns |  12.38 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,594.2 ns |  12.62 ns |  11.81 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,189.4 ns |  18.02 ns |  15.97 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 147,156.9 ns | 191.91 ns | 179.51 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 149,360.6 ns | 977.39 ns | 866.43 ns |     256 B |