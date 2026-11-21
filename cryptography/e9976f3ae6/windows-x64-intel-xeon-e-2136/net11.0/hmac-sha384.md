| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1.355 μs | 0.0004 μs | 0.0004 μs |  12,817 B |     368 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |   1.644 μs | 0.0026 μs | 0.0024 μs |  10,196 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1.681 μs | 0.0025 μs | 0.0021 μs |   4,997 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1.359 μs | 0.0009 μs | 0.0008 μs |  12,627 B |     384 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |   1.640 μs | 0.0017 μs | 0.0015 μs |   9,791 B |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1.682 μs | 0.0033 μs | 0.0030 μs |   4,995 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   3.682 μs | 0.0020 μs | 0.0018 μs |  12,817 B |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   3.920 μs | 0.0050 μs | 0.0045 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   5.255 μs | 0.0085 μs | 0.0071 μs |   9,791 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   3.727 μs | 0.0036 μs | 0.0034 μs |   8,784 B |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   3.938 μs | 0.0190 μs | 0.0178 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   5.226 μs | 0.0106 μs | 0.0089 μs |   9,791 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  21.350 μs | 0.0317 μs | 0.0281 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |  21.752 μs | 0.0111 μs | 0.0104 μs |   8,827 B |    8432 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  34.177 μs | 0.1440 μs | 0.1276 μs |   9,977 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 321.389 μs | 0.5236 μs | 0.4641 μs |   4,988 B |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        | 403.065 μs | 0.3812 μs | 0.3566 μs |  12,497 B |  131366 B |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 535.785 μs | 3.0070 μs | 2.6656 μs |   9,787 B |         - |