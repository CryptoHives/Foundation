| Description                                           | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     790.7 ns |     5.07 ns |   4.49 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  16,523.6 ns |    58.67 ns |  52.01 ns |  16,102 B |     128 B |
|                                                       |              |              |             |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     796.7 ns |     2.03 ns |   1.90 ns |        NA |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  16,734.5 ns |    41.91 ns |  37.15 ns |  16,095 B |     128 B |
|                                                       |              |              |             |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,128.1 ns |     5.02 ns |   4.45 ns |        NA |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  18,951.9 ns |    46.90 ns |  43.87 ns |  16,107 B |     128 B |
|                                                       |              |              |             |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,110.8 ns |     9.08 ns |   8.05 ns |        NA |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  19,142.3 ns |    35.45 ns |  27.67 ns |  16,113 B |     128 B |
|                                                       |              |              |             |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  11,561.3 ns |    53.04 ns |  49.62 ns |        NA |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  36,124.0 ns |   102.24 ns |  90.64 ns |  18,055 B |     128 B |
|                                                       |              |              |             |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 231,407.1 ns | 1,101.41 ns | 976.37 ns |        NA |  263308 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 333,172.7 ns |   787.55 ns | 657.64 ns |  18,678 B |     128 B |