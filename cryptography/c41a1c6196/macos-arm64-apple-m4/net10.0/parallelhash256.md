| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     515.1 ns |     1.58 ns |     1.48 ns |     515.1 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  30,686.6 ns |   608.00 ns | 1,704.89 ns |  31,597.4 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     667.2 ns |     1.78 ns |     1.58 ns |     667.4 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  30,720.4 ns |   605.08 ns | 1,043.74 ns |  30,792.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   1,578.4 ns |     4.41 ns |     4.13 ns |   1,578.5 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  32,160.6 ns |   639.11 ns | 1,615.12 ns |  33,035.4 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   1,576.7 ns |     5.99 ns |     5.60 ns |   1,576.6 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  32,121.6 ns |   648.48 ns | 1,912.07 ns |  33,035.0 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |   9,600.0 ns |    24.08 ns |    22.52 ns |   9,598.0 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  43,639.6 ns |   872.40 ns | 1,433.38 ns |  44,455.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 146,922.0 ns |   423.76 ns |   396.39 ns | 146,944.7 ns |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 256,731.6 ns | 2,914.44 ns | 2,433.69 ns | 257,511.8 ns |     128 B |