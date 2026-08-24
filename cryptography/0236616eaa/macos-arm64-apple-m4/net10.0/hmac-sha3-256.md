| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     352.7 ns |   4.14 ns |   3.87 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     632.5 ns |   1.06 ns |   0.82 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     494.7 ns |   3.87 ns |   3.43 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     784.0 ns |   0.85 ns |   0.79 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,412.4 ns |   8.76 ns |   7.31 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,679.0 ns |   4.25 ns |   3.55 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,416.3 ns |  13.82 ns |  12.25 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,679.5 ns |   3.73 ns |   3.11 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,442.1 ns |  71.37 ns |  63.26 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,596.7 ns |  10.97 ns |   9.73 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 145,099.8 ns | 285.49 ns | 238.40 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 146,870.3 ns | 941.31 ns | 834.44 ns |         - |