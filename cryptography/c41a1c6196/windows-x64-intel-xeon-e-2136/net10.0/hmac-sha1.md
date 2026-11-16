| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     843.2 ns |     1.71 ns |     1.52 ns |   5,562 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |   1,508.0 ns |     9.93 ns |     9.29 ns |   2,946 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   2,005.4 ns |    29.05 ns |    27.17 ns |   1,172 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     839.8 ns |     1.43 ns |     1.34 ns |   5,562 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |   1,495.4 ns |     3.05 ns |     2.85 ns |   2,950 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,978.0 ns |    18.15 ns |    16.98 ns |   1,172 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   2,589.4 ns |     5.41 ns |     5.06 ns |   5,572 B |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   5,861.4 ns |    53.21 ns |    49.77 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   6,061.3 ns |    53.94 ns |    50.46 ns |   2,946 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   2,593.2 ns |     4.48 ns |     4.19 ns |   5,572 B |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   5,886.3 ns |    64.98 ns |    60.78 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   6,368.2 ns |    13.64 ns |    11.39 ns |   2,946 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |  16,057.0 ns |    33.47 ns |    27.95 ns |   5,579 B |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  36,613.8 ns |   168.51 ns |   131.56 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  42,908.5 ns |   451.14 ns |   422.00 ns |   2,946 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 308,584.8 ns |   349.29 ns |   326.72 ns |   5,579 B |  131254 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 570,330.8 ns | 2,723.61 ns | 2,274.34 ns |   1,172 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 667,977.6 ns | 1,875.54 ns | 1,464.29 ns |   2,932 B |         - |