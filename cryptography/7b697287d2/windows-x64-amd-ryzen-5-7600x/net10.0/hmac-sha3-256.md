| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     760.7 ns |   1.06 ns |   0.99 ns |  10,081 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     968.5 ns |   2.41 ns |   2.25 ns |   1,439 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1,097.5 ns |   1.85 ns |   1.73 ns |   6,424 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,194.7 ns |   3.35 ns |   3.13 ns |   1,437 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,566.1 ns |   5.71 ns |   5.07 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   3,186.5 ns |   3.47 ns |   3.25 ns |   6,961 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,562.8 ns |   6.11 ns |   5.72 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   3,212.2 ns |   4.60 ns |   4.30 ns |   6,961 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  14,653.8 ns |  15.16 ns |  12.66 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  21,552.6 ns |  32.62 ns |  28.92 ns |   6,963 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 220,017.9 ns | 243.60 ns | 215.95 ns |   1,437 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 334,469.8 ns | 461.35 ns | 431.55 ns |   6,953 B |         - |