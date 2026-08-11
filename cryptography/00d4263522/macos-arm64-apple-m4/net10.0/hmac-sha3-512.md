| Description                                     | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     501.0 ns |     1.92 ns |   1.80 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     772.4 ns |     1.62 ns |   1.51 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     497.3 ns |     1.98 ns |   1.76 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     772.2 ns |     0.84 ns |   0.78 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,449.5 ns |     3.77 ns |   3.15 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,718.0 ns |     2.94 ns |   2.75 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,516.3 ns |    13.87 ns |  11.58 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,707.4 ns |    10.27 ns |   9.61 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,275.4 ns |    67.58 ns |  59.91 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,523.3 ns |    13.84 ns |  12.95 ns |         - |
|                                                 |              |              |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 273,418.1 ns | 1,040.93 ns | 922.76 ns |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 277,290.2 ns |   710.09 ns | 592.95 ns |         - |