| Description                                           | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     764.0 ns |   2.20 ns |   1.84 ns |  10,099 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  18,991.2 ns |  12.19 ns |  10.18 ns |  13,073 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     782.8 ns |   0.95 ns |   0.79 ns |  10,110 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  18,613.4 ns |  37.44 ns |  31.27 ns |  13,081 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,145.4 ns |   2.33 ns |   1.94 ns |  10,091 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  21,475.1 ns |  36.91 ns |  32.72 ns |  13,109 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,143.1 ns |   6.92 ns |   5.78 ns |  10,102 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  21,377.2 ns |  28.49 ns |  25.25 ns |  13,120 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  11,796.4 ns |  29.74 ns |  24.83 ns |  10,092 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,356.4 ns | 100.05 ns |  88.69 ns |  14,287 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 180,103.9 ns | 487.30 ns | 406.91 ns |  10,093 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 369,836.9 ns | 800.81 ns | 668.71 ns |  14,937 B |     128 B |