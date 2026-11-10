| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |   1.139 μs | 0.0017 μs | 0.0015 μs |   5,557 B |     320 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1.733 μs | 0.0035 μs | 0.0033 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |   1.855 μs | 0.0017 μs | 0.0013 μs |   2,930 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |   1.152 μs | 0.0016 μs | 0.0014 μs |   5,557 B |     336 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1.733 μs | 0.0048 μs | 0.0042 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |   1.842 μs | 0.0030 μs | 0.0026 μs |   2,930 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |   3.776 μs | 0.0054 μs | 0.0048 μs |   5,570 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   5.566 μs | 0.0054 μs | 0.0045 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   7.919 μs | 0.0395 μs | 0.0350 μs |   2,952 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |   3.772 μs | 0.0046 μs | 0.0043 μs |   5,570 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   5.569 μs | 0.0110 μs | 0.0097 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   7.988 μs | 0.0221 μs | 0.0207 μs |   2,930 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |  24.027 μs | 0.0303 μs | 0.0283 μs |   5,579 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  35.878 μs | 0.1312 μs | 0.1227 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  57.881 μs | 0.0492 μs | 0.0460 μs |   2,944 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        | 434.770 μs | 0.5571 μs | 0.5211 μs |   5,579 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 554.927 μs | 2.5542 μs | 2.2642 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 911.101 μs | 1.8338 μs | 1.6256 μs |   2,930 B |         - |