| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128B         |   1,000.6 ns |   6.36 ns |   5.64 ns |   6,917 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128B         |   1,070.1 ns |   3.13 ns |   2.77 ns |   1,105 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 137B         |     994.2 ns |   2.87 ns |   2.55 ns |   6,242 B |         - |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 137B         |   1,071.3 ns |   2.72 ns |   2.54 ns |   1,105 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1KB          |   2,707.6 ns |   2.34 ns |   1.83 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1KB          |   3,505.3 ns |   5.37 ns |   4.48 ns |   6,866 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 1025B        |   2,707.7 ns |   5.39 ns |   4.21 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 1025B        |   3,516.6 ns |   5.37 ns |   4.19 ns |   6,864 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 8KB          |  16,788.6 ns |  53.62 ns |  47.54 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 8KB          |  25,090.6 ns |  66.34 ns |  62.06 ns |   6,865 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-384 · CryptoHives-Scalar | 128KB        | 258,118.2 ns | 311.34 ns | 243.08 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-384 · BouncyCastle       | 128KB        | 394,086.3 ns | 578.40 ns | 512.74 ns |   6,869 B |         - |