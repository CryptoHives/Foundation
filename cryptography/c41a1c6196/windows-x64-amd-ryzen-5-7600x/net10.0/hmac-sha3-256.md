| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     758.7 ns |   1.15 ns |   0.96 ns |  10,081 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     967.9 ns |   1.97 ns |   1.84 ns |   1,439 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1,099.7 ns |   1.25 ns |   1.05 ns |   6,972 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,196.1 ns |   3.00 ns |   2.50 ns |   1,437 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,569.2 ns |   6.66 ns |   5.90 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   3,211.3 ns |   9.23 ns |   7.71 ns |   6,964 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,577.9 ns |   7.11 ns |   5.55 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   3,189.4 ns |   3.30 ns |   2.92 ns |   6,964 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  14,689.3 ns |  56.91 ns |  47.52 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  21,701.1 ns |  29.74 ns |  24.83 ns |   6,963 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 220,865.9 ns | 570.42 ns | 476.33 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 336,472.0 ns | 440.61 ns | 390.59 ns |   6,953 B |         - |