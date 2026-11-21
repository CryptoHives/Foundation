| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |   1.342 μs | 0.0033 μs | 0.0031 μs |  18,769 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   2.320 μs | 0.0091 μs | 0.0076 μs |  10,516 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   3.650 μs | 0.0029 μs | 0.0026 μs |  25,398 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |   1.336 μs | 0.0026 μs | 0.0023 μs |  18,778 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   2.329 μs | 0.0046 μs | 0.0036 μs |  17,081 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   3.647 μs | 0.0042 μs | 0.0039 μs |  25,200 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   3.856 μs | 0.0140 μs | 0.0124 μs |  18,765 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   5.841 μs | 0.0145 μs | 0.0121 μs |  10,514 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   6.949 μs | 0.0048 μs | 0.0043 μs |  19,082 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   3.827 μs | 0.0117 μs | 0.0103 μs |  12,430 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   5.849 μs | 0.0044 μs | 0.0035 μs |  16,694 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   6.971 μs | 0.0083 μs | 0.0074 μs |  25,425 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  20.868 μs | 0.0444 μs | 0.0416 μs |  18,955 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  30.313 μs | 0.0681 μs | 0.0637 μs |  26,372 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  31.179 μs | 0.1232 μs | 0.1152 μs |  17,475 B |    8248 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 317.871 μs | 0.6349 μs | 0.5629 μs |  18,955 B |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 434.093 μs | 0.3513 μs | 0.3286 μs |  26,225 B |     256 B |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 525.339 μs | 0.4305 μs | 0.4027 μs |  17,301 B |  131191 B |