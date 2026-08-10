| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     366.3 ns |   0.87 ns |   0.73 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     633.4 ns |   1.21 ns |   1.13 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     511.2 ns |   0.34 ns |   0.27 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     784.5 ns |   0.56 ns |   0.50 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,455.4 ns |   2.76 ns |   2.45 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,684.1 ns |   4.68 ns |   4.38 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,459.2 ns |   4.81 ns |   4.26 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,682.7 ns |   4.10 ns |   3.83 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,650.7 ns |   9.94 ns |   9.30 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,693.0 ns |  20.88 ns |  19.53 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 145,991.8 ns | 605.45 ns | 566.34 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 150,365.2 ns | 236.12 ns | 209.31 ns |         - |