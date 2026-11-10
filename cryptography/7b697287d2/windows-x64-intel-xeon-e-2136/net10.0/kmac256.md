| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |   1.346 μs | 0.0013 μs | 0.0011 μs |   8,415 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   2.320 μs | 0.0061 μs | 0.0057 μs |   7,281 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   3.625 μs | 0.0032 μs | 0.0028 μs |  16,606 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |   1.734 μs | 0.0011 μs | 0.0009 μs |   8,377 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   2.869 μs | 0.0060 μs | 0.0056 μs |   7,569 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   4.174 μs | 0.0044 μs | 0.0037 μs |  16,716 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.221 μs | 0.0062 μs | 0.0058 μs |   8,403 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   6.362 μs | 0.0116 μs | 0.0108 μs |   7,197 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   7.502 μs | 0.0096 μs | 0.0090 μs |  16,729 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   4.220 μs | 0.0040 μs | 0.0033 μs |   8,403 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   6.393 μs | 0.0109 μs | 0.0102 μs |   7,557 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   7.517 μs | 0.0067 μs | 0.0059 μs |  16,721 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  25.607 μs | 0.0459 μs | 0.0429 μs |   8,382 B |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  36.735 μs | 0.0268 μs | 0.0223 μs |  20,019 B |     256 B |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  37.489 μs | 0.0524 μs | 0.0490 μs |   7,464 B |    8248 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 389.004 μs | 0.3806 μs | 0.3374 μs |   8,389 B |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 532.683 μs | 0.9355 μs | 0.8293 μs |  20,088 B |     256 B |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 614.973 μs | 0.4254 μs | 0.3771 μs |   7,852 B |  131151 B |