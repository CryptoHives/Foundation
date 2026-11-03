| Description                                           | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     763.1 ns |   2.08 ns |   1.94 ns |  10,110 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  18,653.4 ns |  54.79 ns |  51.25 ns |  13,062 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     762.1 ns |   1.23 ns |   1.15 ns |  10,099 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  18,786.6 ns |  28.53 ns |  26.68 ns |  13,086 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,144.1 ns |   7.02 ns |   6.56 ns |  10,102 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  21,478.8 ns |  40.04 ns |  35.50 ns |  13,122 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,145.3 ns |   5.02 ns |   4.70 ns |  10,102 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  22,008.4 ns |  25.86 ns |  24.19 ns |  13,099 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  11,796.9 ns |  20.32 ns |  18.01 ns |  10,092 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,070.3 ns |  62.48 ns |  58.44 ns |  14,287 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 180,232.6 ns | 381.34 ns | 356.71 ns |  10,093 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 369,692.4 ns | 384.86 ns | 300.48 ns |  14,937 B |     128 B |