| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |   1.351 μs | 0.0024 μs | 0.0020 μs |   8,394 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   2.329 μs | 0.0099 μs | 0.0088 μs |   7,283 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   3.611 μs | 0.0066 μs | 0.0055 μs |  16,663 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |   1.737 μs | 0.0054 μs | 0.0051 μs |   8,377 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   2.881 μs | 0.0171 μs | 0.0160 μs |   7,284 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   4.176 μs | 0.0082 μs | 0.0064 μs |  16,719 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   4.231 μs | 0.0137 μs | 0.0128 μs |   8,403 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   6.367 μs | 0.0204 μs | 0.0191 μs |   7,596 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   7.537 μs | 0.0167 μs | 0.0148 μs |  16,710 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   4.240 μs | 0.0207 μs | 0.0194 μs |   8,382 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   6.472 μs | 0.0169 μs | 0.0158 μs |   7,557 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   7.488 μs | 0.0088 μs | 0.0078 μs |  16,651 B |     256 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  25.576 μs | 0.0387 μs | 0.0362 μs |   8,382 B |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  36.622 μs | 0.0572 μs | 0.0507 μs |  20,034 B |     256 B |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  37.390 μs | 0.0279 μs | 0.0233 μs |   7,464 B |    8248 B |
|                                                |              |            |           |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 390.104 μs | 1.4619 μs | 1.3675 μs |   8,389 B |         - |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 532.312 μs | 0.4802 μs | 0.4010 μs |  20,088 B |     256 B |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 609.287 μs | 0.9911 μs | 0.9271 μs |   7,855 B |  131151 B |