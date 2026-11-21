| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |   1.393 μs | 0.0043 μs | 0.0040 μs |  20,367 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  49.551 μs | 0.0378 μs | 0.0354 μs |  23,297 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |   1.804 μs | 0.0019 μs | 0.0018 μs |  20,177 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  50.018 μs | 0.0126 μs | 0.0112 μs |  16,857 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   4.266 μs | 0.0028 μs | 0.0022 μs |  13,833 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  54.745 μs | 0.0534 μs | 0.0474 μs |  23,206 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   4.284 μs | 0.0182 μs | 0.0171 μs |  13,833 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  55.056 μs | 0.0718 μs | 0.0636 μs |  23,206 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  25.633 μs | 0.0184 μs | 0.0164 μs |  13,844 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  97.323 μs | 0.1003 μs | 0.0837 μs |  19,970 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 389.645 μs | 1.1649 μs | 1.0896 μs |  20,170 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 780.587 μs | 0.4883 μs | 0.4329 μs |  26,496 B |     128 B |