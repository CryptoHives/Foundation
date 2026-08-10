| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     780.4 ns |     5.75 ns |     5.10 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  16,556.5 ns |   108.69 ns |   101.67 ns |  16,240 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     784.4 ns |     9.33 ns |     8.72 ns |        NA |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  16,496.6 ns |   107.32 ns |   100.38 ns |  16,241 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,091.5 ns |    23.75 ns |    22.21 ns |        NA |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  18,758.8 ns |    75.51 ns |    70.64 ns |  16,364 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,094.6 ns |    17.71 ns |    16.57 ns |        NA |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  18,963.0 ns |    99.21 ns |    92.80 ns |  15,784 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  11,392.4 ns |    57.21 ns |    50.71 ns |        NA |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  36,015.8 ns |   392.85 ns |   348.25 ns |  16,510 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 225,793.1 ns | 2,024.11 ns | 1,794.32 ns |        NA |  263308 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 333,839.2 ns | 2,495.77 ns | 2,212.44 ns |  18,006 B |     128 B |