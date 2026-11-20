| Description                                     | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |   1.777 μs | 0.0013 μs | 0.0013 μs |  12,991 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   2.126 μs | 0.0036 μs | 0.0032 μs |   5,512 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |   1.769 μs | 0.0008 μs | 0.0008 μs |  13,181 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   2.105 μs | 0.0015 μs | 0.0014 μs |   5,503 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   7.410 μs | 0.0080 μs | 0.0075 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   8.879 μs | 0.0202 μs | 0.0189 μs |   9,738 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   7.352 μs | 0.0075 μs | 0.0070 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   8.880 μs | 0.0203 μs | 0.0190 μs |   9,734 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  46.671 μs | 0.0209 μs | 0.0195 μs |   5,503 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  62.785 μs | 0.0696 μs | 0.0617 μs |  13,575 B |         - |
|                                                 |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 723.661 μs | 0.2896 μs | 0.2567 μs |   5,505 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 991.592 μs | 1.3012 μs | 1.2171 μs |  13,558 B |         - |