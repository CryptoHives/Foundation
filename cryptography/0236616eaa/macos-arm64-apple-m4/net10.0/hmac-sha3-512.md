| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     498.3 ns |     1.22 ns |     0.95 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |     767.2 ns |     0.29 ns |     0.24 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     495.6 ns |     1.76 ns |     1.37 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |     766.7 ns |     0.39 ns |     0.34 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   2,441.9 ns |    14.71 ns |    13.04 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   2,696.9 ns |     7.70 ns |     6.02 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   2,440.9 ns |    15.02 ns |    13.31 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   2,698.5 ns |     2.33 ns |     2.07 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  17,220.5 ns |    97.45 ns |    81.37 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  17,421.3 ns |    11.90 ns |    11.13 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 273,628.3 ns | 2,533.81 ns | 2,246.16 ns |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 274,332.1 ns |   254.03 ns |   237.62 ns |         - |