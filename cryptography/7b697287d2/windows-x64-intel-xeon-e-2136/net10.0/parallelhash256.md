| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |   1.044 μs | 0.0031 μs | 0.0029 μs |  10,129 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  37.559 μs | 0.6235 μs | 0.5832 μs |  13,113 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |   1.344 μs | 0.0046 μs | 0.0043 μs |  10,141 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  37.581 μs | 0.4439 μs | 0.3935 μs |  13,125 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   3.224 μs | 0.0121 μs | 0.0113 μs |  10,131 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  41.115 μs | 0.3247 μs | 0.2879 μs |  13,149 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   3.224 μs | 0.0088 μs | 0.0082 μs |  10,131 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  41.355 μs | 0.5693 μs | 0.5325 μs |  13,151 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  19.269 μs | 0.0528 μs | 0.0494 μs |  10,124 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  73.465 μs | 0.5150 μs | 0.4817 μs |  15,525 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 292.186 μs | 0.8492 μs | 0.7528 μs |  10,122 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 598.688 μs | 2.4333 μs | 2.2761 μs |  16,205 B |     128 B |