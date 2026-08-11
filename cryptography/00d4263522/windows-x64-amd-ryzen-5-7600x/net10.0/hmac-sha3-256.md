| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     686.2 ns |   2.01 ns |   1.78 ns |   6,896 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     871.6 ns |   1.78 ns |   1.57 ns |   1,107 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     998.3 ns |   2.64 ns |   2.21 ns |   6,914 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,081.8 ns |   4.43 ns |   3.93 ns |   1,105 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,319.6 ns |  10.93 ns |   9.69 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   2,876.7 ns |   4.56 ns |   3.56 ns |   6,898 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,317.8 ns |   4.24 ns |   3.54 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   2,889.6 ns |   7.84 ns |   6.95 ns |   6,898 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  13,205.5 ns |  26.96 ns |  22.51 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  19,595.9 ns |  62.81 ns |  52.45 ns |   6,895 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 199,265.3 ns | 473.92 ns | 420.12 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 303,792.5 ns | 831.84 ns | 737.40 ns |   6,899 B |         - |