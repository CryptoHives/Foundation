| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     246.4 ns |     0.68 ns |     0.57 ns |   5,530 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     869.8 ns |     0.96 ns |     0.90 ns |   2,940 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,057.9 ns |     2.21 ns |     1.96 ns |   1,546 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     246.6 ns |     0.52 ns |     0.49 ns |   5,530 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     869.7 ns |     1.18 ns |     1.11 ns |   2,940 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,060.6 ns |     2.33 ns |     2.18 ns |   1,546 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     668.2 ns |     0.74 ns |     0.69 ns |   5,536 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,435.0 ns |     2.61 ns |     2.32 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,745.6 ns |     3.59 ns |     3.36 ns |   2,902 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     663.6 ns |     1.86 ns |     1.65 ns |   5,534 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,410.5 ns |     5.19 ns |     4.60 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,744.3 ns |     3.62 ns |     3.02 ns |   2,940 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   4,000.6 ns |     9.94 ns |     9.30 ns |   5,555 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  22,342.3 ns |    51.48 ns |    48.16 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,690.8 ns |    36.89 ns |    30.80 ns |   2,902 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  93,136.1 ns |   259.93 ns |   243.14 ns |   5,555 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 346,109.2 ns | 1,222.10 ns | 1,143.15 ns |   1,546 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 420,177.2 ns |   605.18 ns |   536.48 ns |   2,922 B |         - |