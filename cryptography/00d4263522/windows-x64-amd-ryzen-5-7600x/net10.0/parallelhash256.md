| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     782.5 ns |     1.82 ns |     1.52 ns |        NA |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  16,292.7 ns |    28.28 ns |    25.07 ns |  16,083 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     990.8 ns |     3.43 ns |     2.86 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  16,854.6 ns |    26.52 ns |    22.15 ns |  16,088 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,311.5 ns |     7.62 ns |     6.76 ns |        NA |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  19,227.5 ns |    25.83 ns |    21.57 ns |  16,092 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,319.6 ns |     8.62 ns |     6.73 ns |        NA |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  19,146.4 ns |    39.59 ns |    35.09 ns |  16,098 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  13,899.2 ns |    25.11 ns |    22.26 ns |        NA |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  39,888.3 ns |    75.57 ns |    63.10 ns |  19,230 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 266,596.2 ns | 1,830.60 ns | 1,528.63 ns |        NA |  263276 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 390,920.0 ns | 1,368.18 ns | 1,212.85 ns |  19,847 B |     128 B |