| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     998.5 ns |     4.80 ns |     4.26 ns |   6,246 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1,060.4 ns |     1.39 ns |     1.08 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     998.0 ns |     5.58 ns |     4.94 ns |   6,248 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1,071.3 ns |     1.67 ns |     1.40 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   3,702.5 ns |    15.95 ns |    14.92 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5,026.1 ns |     7.31 ns |     6.10 ns |   6,883 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   3,692.9 ns |     7.20 ns |     6.01 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5,057.3 ns |    14.47 ns |    12.83 ns |   6,882 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  23,790.0 ns |    83.55 ns |    78.15 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  36,220.0 ns |   140.15 ns |   131.10 ns |   6,882 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 372,095.4 ns | 1,841.40 ns | 1,722.45 ns |   1,107 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 564,266.1 ns | 1,333.51 ns | 1,247.37 ns |   6,880 B |         - |