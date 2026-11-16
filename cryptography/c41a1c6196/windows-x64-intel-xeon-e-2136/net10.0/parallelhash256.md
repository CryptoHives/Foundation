| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |   1.384 μs | 0.0028 μs | 0.0023 μs |  10,132 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  49.860 μs | 0.5492 μs | 0.4869 μs |  13,124 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |   1.788 μs | 0.0029 μs | 0.0028 μs |  10,130 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  50.746 μs | 0.9093 μs | 0.8506 μs |  13,111 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   4.309 μs | 0.0173 μs | 0.0162 μs |  10,131 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  55.137 μs | 0.5162 μs | 0.4576 μs |  13,161 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   4.306 μs | 0.0166 μs | 0.0155 μs |  10,131 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  54.761 μs | 0.1893 μs | 0.1478 μs |  13,161 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  25.739 μs | 0.1064 μs | 0.0995 μs |  10,124 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  97.833 μs | 0.5640 μs | 0.4999 μs |  15,498 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 389.882 μs | 1.4095 μs | 1.3184 μs |  10,122 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 780.279 μs | 0.4696 μs | 0.4163 μs |  16,205 B |     128 B |