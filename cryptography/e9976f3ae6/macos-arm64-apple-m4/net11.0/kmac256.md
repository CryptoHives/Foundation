| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     479.9 ns |   1.80 ns |   1.69 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,013.7 ns |   3.35 ns |   3.13 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     629.8 ns |   1.93 ns |   1.81 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   1,164.0 ns |   5.06 ns |   4.73 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   1,525.7 ns |   3.87 ns |   3.62 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   2,085.2 ns |   8.79 ns |   8.22 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   1,542.6 ns |   3.89 ns |   3.64 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   2,087.0 ns |   7.30 ns |   6.83 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |   9,579.3 ns |  32.93 ns |  30.81 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  10,124.3 ns |  80.40 ns |  71.27 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 148,496.1 ns | 424.70 ns | 397.27 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 148,697.9 ns | 775.40 ns | 725.31 ns |     256 B |