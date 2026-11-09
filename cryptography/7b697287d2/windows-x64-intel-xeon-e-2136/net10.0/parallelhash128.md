| Description                                           | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |   1.044 μs | 0.0035 μs | 0.0033 μs |  10,135 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  37.314 μs | 0.6513 μs | 0.6092 μs |  13,117 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |   1.043 μs | 0.0026 μs | 0.0024 μs |  10,135 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  37.535 μs | 0.5370 μs | 0.5023 μs |  13,129 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2.935 μs | 0.0110 μs | 0.0103 μs |  10,138 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  40.683 μs | 0.3982 μs | 0.3530 μs |  13,158 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2.953 μs | 0.0245 μs | 0.0217 μs |  10,138 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  41.114 μs | 0.4711 μs | 0.4176 μs |  13,150 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  15.728 μs | 0.0379 μs | 0.0317 μs |  10,139 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  68.607 μs | 0.4534 μs | 0.3786 μs |  14,305 B |     128 B |
|                                                       |              |            |           |           |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 238.376 μs | 0.7800 μs | 0.7296 μs |  10,129 B |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 514.054 μs | 1.5122 μs | 1.4146 μs |  14,986 B |     128 B |