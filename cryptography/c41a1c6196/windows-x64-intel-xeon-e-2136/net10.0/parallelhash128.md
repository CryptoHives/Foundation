| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |   1.390 μs | 0.0012 μs | 0.0010 μs |  10,135 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  49.969 μs | 0.5402 μs | 0.5053 μs |  13,113 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |   1.395 μs | 0.0052 μs | 0.0049 μs |  10,135 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  49.676 μs | 0.4621 μs | 0.3858 μs |  13,124 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   3.924 μs | 0.0125 μs | 0.0117 μs |  10,127 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  54.612 μs | 0.5006 μs | 0.4180 μs |  13,164 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   3.906 μs | 0.0074 μs | 0.0069 μs |  10,127 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  54.714 μs | 0.4678 μs | 0.3906 μs |  13,150 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  21.052 μs | 0.0983 μs | 0.0919 μs |  10,128 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  91.165 μs | 0.4457 μs | 0.3722 μs |  14,296 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 318.996 μs | 1.6049 μs | 1.5012 μs |  10,129 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 685.259 μs | 0.6469 μs | 0.6051 μs |  14,986 B |     128 B |