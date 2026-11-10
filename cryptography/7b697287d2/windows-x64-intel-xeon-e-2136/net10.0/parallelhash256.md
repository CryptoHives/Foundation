| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |   1.390 μs | 0.0017 μs | 0.0016 μs |  10,132 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  49.981 μs | 0.6951 μs | 0.6502 μs |  13,113 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |   1.793 μs | 0.0021 μs | 0.0020 μs |  10,141 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  50.195 μs | 0.1891 μs | 0.1579 μs |  13,111 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   4.296 μs | 0.0080 μs | 0.0071 μs |  10,134 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  55.454 μs | 0.4921 μs | 0.4362 μs |  13,149 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   4.289 μs | 0.0047 μs | 0.0041 μs |  10,131 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  55.698 μs | 0.7307 μs | 0.6835 μs |  13,149 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  25.664 μs | 0.0355 μs | 0.0332 μs |  10,124 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  95.491 μs | 0.5534 μs | 0.5176 μs |  15,499 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 389.611 μs | 0.4321 μs | 0.3831 μs |  10,122 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 785.640 μs | 0.7512 μs | 0.6659 μs |  16,205 B |     128 B |