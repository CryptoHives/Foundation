| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     492.9 ns |   1.59 ns |   1.49 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     787.4 ns |   0.52 ns |   0.46 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     499.6 ns |   3.96 ns |   3.71 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     789.4 ns |   2.37 ns |   2.22 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,724.9 ns |  11.75 ns |  10.99 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,997.5 ns |   7.94 ns |   7.43 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,724.8 ns |   7.78 ns |   7.28 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,994.2 ns |   5.73 ns |   5.36 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,141.4 ns |  77.73 ns |  72.71 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,437.2 ns |  31.21 ns |  24.37 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 191,627.7 ns | 777.93 ns | 689.62 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 192,180.9 ns | 401.97 ns | 376.00 ns |         - |