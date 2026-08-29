| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     983.6 ns |     1.70 ns |     1.50 ns |   6,246 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1,058.0 ns |     3.13 ns |     2.44 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     990.0 ns |     2.14 ns |     1.90 ns |   6,248 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1,064.0 ns |     4.80 ns |     4.01 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   3,667.1 ns |    10.95 ns |     9.71 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5,014.0 ns |     7.82 ns |     6.93 ns |   6,883 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   3,685.8 ns |    43.51 ns |    33.97 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5,052.3 ns |    26.73 ns |    22.32 ns |   6,882 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  23,625.5 ns |   151.08 ns |   126.16 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  35,937.9 ns |    68.02 ns |    56.80 ns |   6,882 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 366,167.6 ns | 1,823.34 ns | 1,522.57 ns |   1,107 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 558,145.4 ns | 1,143.00 ns |   954.46 ns |   6,880 B |         - |