| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     511.9 ns |     1.27 ns |     1.19 ns |     511.9 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  28,755.0 ns |   947.71 ns | 2,794.36 ns |  29,321.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     506.8 ns |     1.82 ns |     1.70 ns |     506.0 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  28,268.1 ns |   954.41 ns | 2,814.10 ns |  29,301.5 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   1,419.3 ns |     5.26 ns |     4.92 ns |   1,419.6 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  30,610.3 ns |   675.67 ns | 1,992.22 ns |  30,946.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   1,413.9 ns |     4.98 ns |     4.66 ns |   1,415.0 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  30,512.2 ns |   666.27 ns | 1,964.51 ns |  30,891.0 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |   7,680.8 ns |    11.47 ns |     9.58 ns |   7,680.9 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  39,083.1 ns |   775.81 ns | 1,061.93 ns |  39,467.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 118,786.3 ns |   233.42 ns |   218.35 ns | 118,837.9 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 216,702.1 ns | 1,394.37 ns | 1,304.30 ns | 217,060.5 ns |     128 B |