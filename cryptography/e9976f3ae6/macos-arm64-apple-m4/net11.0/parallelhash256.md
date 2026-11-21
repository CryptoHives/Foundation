| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     505.3 ns |     0.48 ns |     0.43 ns |     505.4 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  28,923.6 ns |   770.32 ns | 2,271.29 ns |  29,414.5 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     663.7 ns |     1.64 ns |     1.53 ns |     663.3 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  28,638.5 ns |   787.05 ns | 2,320.64 ns |  29,306.0 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   1,561.5 ns |     0.78 ns |     0.72 ns |   1,561.3 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  30,304.5 ns |   604.79 ns | 1,235.43 ns |  30,704.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   1,562.6 ns |     1.56 ns |     1.46 ns |   1,562.6 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  30,217.1 ns |   600.86 ns | 1,743.20 ns |  30,841.7 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |   9,557.2 ns |    13.76 ns |    12.87 ns |   9,562.3 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  41,343.4 ns |   796.44 ns | 1,436.15 ns |  41,609.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 146,799.7 ns |   481.67 ns |   450.56 ns | 147,019.7 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 245,863.5 ns | 2,216.93 ns | 2,073.72 ns | 246,864.4 ns |     128 B |