| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     678.9 ns |     2.13 ns |     1.78 ns |   6,896 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     870.4 ns |     2.86 ns |     2.53 ns |   1,107 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     982.5 ns |     3.78 ns |     3.54 ns |   6,280 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,076.4 ns |     2.66 ns |     2.22 ns |   1,105 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,301.1 ns |    13.81 ns |    10.78 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   2,861.5 ns |     8.97 ns |     8.40 ns |   6,903 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,297.9 ns |     8.38 ns |     7.84 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   2,876.2 ns |    11.95 ns |     9.98 ns |   6,903 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  13,123.5 ns |    36.60 ns |    30.56 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  19,434.8 ns |    43.53 ns |    36.35 ns |   6,890 B |         - |
|                                                 |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 197,555.2 ns |   468.20 ns |   390.97 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 301,387.7 ns | 1,380.18 ns | 1,291.02 ns |   6,899 B |         - |