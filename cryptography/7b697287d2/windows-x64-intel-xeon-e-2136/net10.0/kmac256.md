| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |   1.015 μs | 0.0049 μs | 0.0046 μs |   8,415 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1.740 μs | 0.0065 μs | 0.0061 μs |   7,284 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2.726 μs | 0.0094 μs | 0.0088 μs |  16,643 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |   1.303 μs | 0.0032 μs | 0.0028 μs |   8,377 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   2.148 μs | 0.0067 μs | 0.0063 μs |   7,281 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   3.129 μs | 0.0118 μs | 0.0110 μs |  16,716 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   3.171 μs | 0.0121 μs | 0.0113 μs |   8,403 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   4.778 μs | 0.0157 μs | 0.0147 μs |   7,558 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   5.636 μs | 0.0224 μs | 0.0209 μs |  16,708 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   3.171 μs | 0.0068 μs | 0.0057 μs |   8,403 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   4.795 μs | 0.0184 μs | 0.0172 μs |   7,571 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   5.612 μs | 0.0095 μs | 0.0084 μs |  16,701 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  19.267 μs | 0.0956 μs | 0.0894 μs |   8,382 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  27.434 μs | 0.0691 μs | 0.0612 μs |   7,467 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  27.519 μs | 0.0747 μs | 0.0662 μs |  20,035 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 291.662 μs | 0.7753 μs | 0.7252 μs |   8,389 B |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 399.917 μs | 1.4517 μs | 1.3580 μs |  20,134 B |     256 B |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 462.036 μs | 1.1723 μs | 1.0965 μs |   7,864 B |  131151 B |