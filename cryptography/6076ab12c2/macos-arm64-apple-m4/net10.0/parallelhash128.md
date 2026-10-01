| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     638.3 ns |     0.31 ns |     0.26 ns |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  26,453.7 ns |   654.99 ns | 1,931.26 ns |     128 B |
|                                                       |              |              |             |             |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     636.0 ns |     0.34 ns |     0.30 ns |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  26,156.9 ns |   768.79 ns | 2,266.81 ns |     128 B |
|                                                       |              |              |             |             |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   1,621.4 ns |     0.75 ns |     0.66 ns |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  27,978.0 ns | 1,010.47 ns | 2,979.39 ns |     128 B |
|                                                       |              |              |             |             |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   1,623.7 ns |     2.40 ns |     2.24 ns |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  28,242.0 ns |   699.71 ns | 2,063.12 ns |     128 B |
|                                                       |              |              |             |             |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |   8,436.4 ns |     3.89 ns |     3.25 ns |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  39,185.9 ns |   872.59 ns | 2,572.85 ns |     128 B |
|                                                       |              |              |             |             |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 140,308.5 ns |   202.12 ns |   189.06 ns |  263336 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 230,928.0 ns | 1,132.24 ns | 1,059.10 ns |     128 B |