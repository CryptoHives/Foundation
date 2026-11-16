| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |   1.346 μs | 0.0031 μs | 0.0027 μs |   8,412 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   2.341 μs | 0.0159 μs | 0.0141 μs |   7,284 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   3.651 μs | 0.0039 μs | 0.0037 μs |  16,762 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |   1.365 μs | 0.0030 μs | 0.0026 μs |   8,412 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   2.328 μs | 0.0052 μs | 0.0049 μs |   7,569 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   3.658 μs | 0.0029 μs | 0.0026 μs |  16,771 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.844 μs | 0.0191 μs | 0.0179 μs |   8,390 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   5.877 μs | 0.0318 μs | 0.0297 μs |   7,554 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   6.985 μs | 0.0052 μs | 0.0046 μs |  16,775 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   3.868 μs | 0.0160 μs | 0.0150 μs |   8,390 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   5.863 μs | 0.0218 μs | 0.0182 μs |   7,555 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   6.981 μs | 0.0069 μs | 0.0058 μs |  16,818 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  20.912 μs | 0.0622 μs | 0.0519 μs |   8,398 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  30.733 μs | 0.0301 μs | 0.0251 μs |  21,342 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  31.103 μs | 0.0946 μs | 0.0839 μs |   7,467 B |    8248 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 318.321 μs | 1.5624 μs | 1.4614 μs |   8,388 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 442.464 μs | 0.2859 μs | 0.2674 μs |  21,460 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 517.655 μs | 0.6528 μs | 0.6106 μs |   7,824 B |  131151 B |