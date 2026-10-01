| Description                                     | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     495.1 ns |     0.94 ns |   0.73 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |     783.1 ns |     0.55 ns |   0.51 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     496.1 ns |     3.40 ns |   3.18 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |     779.4 ns |     0.54 ns |   0.51 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   1,704.8 ns |     8.74 ns |   8.17 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   1,974.9 ns |     1.25 ns |   1.17 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   1,703.7 ns |     7.37 ns |   6.15 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   1,973.8 ns |     1.87 ns |   1.75 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  12,123.2 ns |   103.36 ns |  96.68 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  12,292.5 ns |    18.27 ns |  16.20 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 189,462.5 ns | 1,010.21 ns | 895.52 ns |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 190,169.9 ns |   107.89 ns |  95.64 ns |         - |