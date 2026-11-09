| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     908.0 ns |   3.42 ns |   2.85 ns |  10,172 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |   1,277.7 ns |   1.73 ns |   1.53 ns |   1,460 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1,297.8 ns |   1.55 ns |   1.30 ns |   6,464 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,577.7 ns |   1.65 ns |   1.46 ns |   1,458 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   3,426.0 ns |   4.31 ns |   4.03 ns |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   3,757.9 ns |   6.67 ns |   6.24 ns |   6,999 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   3,424.3 ns |   8.31 ns |   7.37 ns |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   3,747.4 ns |   6.54 ns |   6.11 ns |   6,997 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  19,244.4 ns |  25.05 ns |  22.21 ns |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  25,274.4 ns |  44.19 ns |  36.90 ns |   7,002 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 287,510.4 ns | 377.39 ns | 334.55 ns |   1,458 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 392,139.0 ns | 527.77 ns | 493.68 ns |   6,998 B |         - |