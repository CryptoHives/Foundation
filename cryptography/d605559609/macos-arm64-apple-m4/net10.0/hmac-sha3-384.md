| Description                                     | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     495.4 ns |     2.16 ns |   2.02 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     782.0 ns |     0.38 ns |   0.32 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     496.4 ns |     3.19 ns |   2.99 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     778.2 ns |     0.68 ns |   0.64 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,709.5 ns |     5.72 ns |   4.78 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,967.6 ns |     3.65 ns |   3.04 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,705.0 ns |     5.75 ns |   4.49 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,964.7 ns |     2.73 ns |   2.13 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,116.3 ns |   126.11 ns | 111.80 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,248.1 ns |    13.43 ns |  11.90 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 190,233.2 ns |   274.14 ns | 243.02 ns |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 190,600.8 ns | 1,044.84 ns | 926.23 ns |         - |