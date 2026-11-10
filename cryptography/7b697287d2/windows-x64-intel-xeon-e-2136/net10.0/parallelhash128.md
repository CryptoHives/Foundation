| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Median     | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|-----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |   1.408 μs | 0.0027 μs | 0.0025 μs |   1.407 μs |  10,135 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  49.879 μs | 0.4525 μs | 0.4011 μs |  49.675 μs |  13,123 B |     128 B |
|                                                       |              |            |           |           |            |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |   1.393 μs | 0.0012 μs | 0.0011 μs |   1.392 μs |  10,135 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  50.215 μs | 0.7102 μs | 0.6643 μs |  49.772 μs |  13,125 B |     128 B |
|                                                       |              |            |           |           |            |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   3.905 μs | 0.0017 μs | 0.0014 μs |   3.905 μs |  10,138 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  55.594 μs | 1.0621 μs | 1.0907 μs |  54.807 μs |  13,164 B |     128 B |
|                                                       |              |            |           |           |            |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   3.909 μs | 0.0040 μs | 0.0036 μs |   3.908 μs |  10,138 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  55.260 μs | 0.6823 μs | 0.6382 μs |  54.885 μs |  13,164 B |     128 B |
|                                                       |              |            |           |           |            |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  20.950 μs | 0.0220 μs | 0.0184 μs |  20.949 μs |  10,139 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  89.012 μs | 0.5622 μs | 0.5259 μs |  88.748 μs |  14,296 B |     128 B |
|                                                       |              |            |           |           |            |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 317.539 μs | 0.3575 μs | 0.3169 μs | 317.432 μs |  10,129 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 683.183 μs | 0.9551 μs | 0.8466 μs | 683.119 μs |  14,986 B |     128 B |