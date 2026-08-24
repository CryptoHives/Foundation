| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     836.9 ns |     4.10 ns |     3.64 ns |        NA |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  16,317.5 ns |    65.78 ns |    58.31 ns |  16,081 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     974.4 ns |     5.67 ns |     4.73 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  16,539.0 ns |    29.30 ns |    24.47 ns |  16,098 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,273.3 ns |     6.38 ns |     4.98 ns |        NA |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  19,450.5 ns |    43.37 ns |    38.45 ns |  16,095 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,274.6 ns |    13.30 ns |    11.79 ns |        NA |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  18,843.5 ns |    50.23 ns |    44.53 ns |  16,099 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  13,726.4 ns |    34.49 ns |    28.80 ns |        NA |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  39,256.5 ns |    88.12 ns |    78.12 ns |  19,230 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 264,900.2 ns | 3,006.02 ns | 2,346.91 ns |        NA |  263276 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 387,116.0 ns |   591.89 ns |   494.26 ns |  19,847 B |     128 B |