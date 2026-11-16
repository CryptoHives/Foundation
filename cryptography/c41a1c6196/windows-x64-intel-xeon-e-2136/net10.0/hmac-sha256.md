| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |   1.146 μs | 0.0010 μs | 0.0009 μs |   5,557 B |     320 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1.739 μs | 0.0098 μs | 0.0087 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |   1.847 μs | 0.0095 μs | 0.0089 μs |   2,944 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |   1.153 μs | 0.0006 μs | 0.0005 μs |   5,557 B |     336 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1.746 μs | 0.0147 μs | 0.0138 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |   1.868 μs | 0.0056 μs | 0.0050 μs |   2,944 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |   3.765 μs | 0.0060 μs | 0.0056 μs |   5,568 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   5.689 μs | 0.0175 μs | 0.0163 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   8.057 μs | 0.0638 μs | 0.0597 μs |   2,952 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |   3.776 μs | 0.0101 μs | 0.0094 μs |   5,570 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   5.714 μs | 0.0366 μs | 0.0342 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   8.024 μs | 0.0232 μs | 0.0217 μs |   2,944 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |  24.027 μs | 0.0381 μs | 0.0337 μs |   5,579 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  36.072 μs | 0.0941 μs | 0.0834 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  58.734 μs | 0.1976 μs | 0.1848 μs |   2,952 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        | 429.803 μs | 0.2901 μs | 0.2265 μs |   5,579 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 556.486 μs | 1.5556 μs | 1.2990 μs |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 916.890 μs | 4.3087 μs | 4.0304 μs |   2,944 B |         - |