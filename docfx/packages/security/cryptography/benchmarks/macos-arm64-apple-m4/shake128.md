| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     179.7 ns |   1.19 ns |   1.12 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     260.2 ns |   3.44 ns |   2.87 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     179.7 ns |   1.03 ns |   0.91 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     244.0 ns |   1.07 ns |   1.00 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,117.6 ns |   4.77 ns |   4.23 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,407.8 ns |   7.42 ns |   6.57 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,115.5 ns |   3.09 ns |   2.58 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,404.2 ns |   6.25 ns |   5.85 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,683.0 ns |  34.79 ns |  30.84 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,976.4 ns |  26.07 ns |  24.38 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 122,490.6 ns | 216.49 ns | 169.02 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 125,088.4 ns | 311.63 ns | 291.50 ns |         - |