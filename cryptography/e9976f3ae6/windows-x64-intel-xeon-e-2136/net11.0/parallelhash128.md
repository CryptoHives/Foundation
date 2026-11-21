| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |   1.399 μs | 0.0033 μs | 0.0029 μs |  20,376 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  49.518 μs | 0.0221 μs | 0.0207 μs |  23,122 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |   1.402 μs | 0.0014 μs | 0.0013 μs |  20,177 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  49.510 μs | 0.0149 μs | 0.0116 μs |  16,787 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   3.905 μs | 0.0184 μs | 0.0172 μs |  13,842 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  54.584 μs | 0.0796 μs | 0.0665 μs |  16,886 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   3.904 μs | 0.0061 μs | 0.0054 μs |  20,168 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  54.197 μs | 0.0234 μs | 0.0208 μs |  16,886 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  20.958 μs | 0.0557 μs | 0.0465 μs |  13,835 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  90.812 μs | 0.0688 μs | 0.0610 μs |  25,239 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 318.392 μs | 0.8997 μs | 0.8416 μs |  20,170 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 681.400 μs | 0.6597 μs | 0.5509 μs |  25,485 B |     128 B |