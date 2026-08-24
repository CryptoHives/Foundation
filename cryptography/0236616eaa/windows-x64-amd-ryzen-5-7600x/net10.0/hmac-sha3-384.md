| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     976.5 ns |     1.97 ns |     1.54 ns |   6,917 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1,061.9 ns |     8.42 ns |     7.46 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     976.3 ns |     1.46 ns |     1.14 ns |   6,242 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1,057.5 ns |     4.33 ns |     3.61 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   2,664.2 ns |     6.80 ns |     6.03 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3,449.0 ns |    10.25 ns |     9.08 ns |   6,856 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   2,658.4 ns |     4.76 ns |     4.22 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3,451.5 ns |     5.66 ns |     4.73 ns |   6,868 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  16,528.3 ns |    31.73 ns |    29.68 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  24,695.1 ns |    34.97 ns |    31.00 ns |   6,865 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 253,959.0 ns |   744.51 ns |   581.26 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 388,862.1 ns | 1,236.92 ns | 1,096.50 ns |   6,864 B |         - |