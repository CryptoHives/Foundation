| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |     980.2 ns |     3.38 ns |     2.82 ns |   6,242 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1,068.9 ns |     1.97 ns |     1.54 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     983.7 ns |     2.38 ns |     2.22 ns |   6,242 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1,073.2 ns |    16.60 ns |    13.86 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   2,693.6 ns |     4.66 ns |     3.89 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3,488.7 ns |    49.09 ns |    40.99 ns |   6,866 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   2,682.9 ns |     8.01 ns |     7.10 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3,462.8 ns |     9.53 ns |     7.95 ns |   6,866 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  16,613.6 ns |    48.28 ns |    42.80 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  24,935.9 ns |    24.71 ns |    21.90 ns |   6,870 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 255,354.3 ns |   727.65 ns |   607.62 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 391,410.8 ns | 1,412.56 ns | 1,321.31 ns |   6,857 B |         - |