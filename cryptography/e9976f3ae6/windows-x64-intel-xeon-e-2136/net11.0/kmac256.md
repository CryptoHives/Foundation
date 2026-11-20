| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |   1.333 μs | 0.0008 μs | 0.0007 μs |  18,970 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   2.331 μs | 0.0075 μs | 0.0062 μs |  17,273 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   3.600 μs | 0.0047 μs | 0.0041 μs |  25,196 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |   1.721 μs | 0.0008 μs | 0.0007 μs |  12,423 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   2.870 μs | 0.0098 μs | 0.0092 μs |  17,273 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   4.163 μs | 0.0142 μs | 0.0133 μs |  19,047 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.214 μs | 0.0144 μs | 0.0128 μs |  18,966 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   6.363 μs | 0.0070 μs | 0.0058 μs |  10,518 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   7.471 μs | 0.0039 μs | 0.0032 μs |  19,063 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   4.224 μs | 0.0076 μs | 0.0071 μs |  12,432 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   6.406 μs | 0.0128 μs | 0.0120 μs |  16,694 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   7.463 μs | 0.0076 μs | 0.0064 μs |  25,398 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  25.566 μs | 0.0512 μs | 0.0478 μs |  12,430 B |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  36.671 μs | 0.0541 μs | 0.0480 μs |  29,849 B |     256 B |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  37.499 μs | 0.0333 μs | 0.0312 μs |  17,287 B |    8248 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 389.088 μs | 1.1954 μs | 1.0597 μs |  18,957 B |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 531.819 μs | 0.3969 μs | 0.3519 μs |  23,110 B |     256 B |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 628.253 μs | 0.4926 μs | 0.4608 μs |  17,482 B |  131191 B |