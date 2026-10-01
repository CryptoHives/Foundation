| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     890.2 ns |     3.72 ns |     3.48 ns |  20,924 B |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  19,743.9 ns |    79.44 ns |    70.42 ns |  13,073 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     895.5 ns |     3.02 ns |     2.83 ns |  17,424 B |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  19,108.5 ns |    86.94 ns |    81.33 ns |  13,075 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,363.0 ns |    17.67 ns |    16.53 ns |  16,757 B |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  21,774.3 ns |    97.28 ns |    90.99 ns |  13,120 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,372.8 ns |    17.83 ns |    16.68 ns |  17,551 B |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  22,248.5 ns |    89.57 ns |    79.40 ns |  13,101 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  12,894.6 ns |    94.77 ns |    88.65 ns |  20,668 B |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,155.5 ns |   187.37 ns |   175.27 ns |  14,279 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 256,345.7 ns | 1,569.14 ns | 1,467.77 ns |  20,396 B |  263308 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 371,940.9 ns | 1,603.38 ns | 1,499.80 ns |  14,937 B |     128 B |