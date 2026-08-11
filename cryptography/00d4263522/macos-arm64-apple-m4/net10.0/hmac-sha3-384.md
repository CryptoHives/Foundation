| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     496.7 ns |   1.55 ns |   1.37 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     782.2 ns |   0.70 ns |   0.65 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     497.0 ns |   1.66 ns |   1.56 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     778.7 ns |   2.04 ns |   1.81 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,713.8 ns |   5.51 ns |   5.16 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,978.0 ns |   2.44 ns |   2.16 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,710.3 ns |   4.46 ns |   3.72 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,973.9 ns |   5.30 ns |   4.96 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,155.9 ns |  62.89 ns |  58.82 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,315.6 ns |  14.95 ns |  12.48 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 191,314.2 ns | 256.28 ns | 214.01 ns |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 191,531.5 ns | 480.78 ns | 401.47 ns |         - |