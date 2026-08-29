| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     788.0 ns |     4.73 ns |     3.95 ns |        NA |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  16,255.7 ns |    74.12 ns |    69.33 ns |  16,081 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     989.1 ns |    19.20 ns |    20.54 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  16,610.7 ns |    70.64 ns |    55.15 ns |  16,092 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,301.4 ns |     8.77 ns |     7.77 ns |        NA |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  19,178.1 ns |   172.33 ns |   152.77 ns |  16,099 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,304.7 ns |     8.34 ns |     6.96 ns |        NA |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  18,878.2 ns |    79.65 ns |    70.61 ns |  16,099 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  13,893.5 ns |    56.78 ns |    50.34 ns |        NA |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  40,026.8 ns |   155.43 ns |   129.79 ns |  19,220 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 266,532.7 ns | 1,296.59 ns | 1,149.40 ns |        NA |  263276 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 388,294.2 ns | 1,884.55 ns | 1,762.80 ns |  19,847 B |     128 B |