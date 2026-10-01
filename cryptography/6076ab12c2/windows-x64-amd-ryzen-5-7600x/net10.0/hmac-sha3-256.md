| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     756.1 ns |   0.53 ns |   0.47 ns |  10,081 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     963.1 ns |   1.14 ns |   1.01 ns |   1,439 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1,097.2 ns |   0.83 ns |   0.73 ns |   6,971 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,223.2 ns |   1.28 ns |   1.13 ns |   1,437 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,587.9 ns |   2.28 ns |   2.02 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   3,203.5 ns |   3.94 ns |   3.68 ns |   6,946 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,560.5 ns |   3.12 ns |   2.91 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   3,191.3 ns |   1.53 ns |   1.28 ns |   6,956 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  14,604.9 ns |  12.79 ns |  11.97 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  21,671.0 ns |  16.59 ns |  14.71 ns |   6,963 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 219,965.7 ns | 119.02 ns | 111.33 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 336,013.5 ns | 271.63 ns | 240.80 ns |   6,957 B |         - |