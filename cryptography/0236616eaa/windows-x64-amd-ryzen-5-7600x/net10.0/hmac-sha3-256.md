| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     675.8 ns |   1.25 ns |   1.11 ns |   6,896 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     866.1 ns |   1.79 ns |   1.59 ns |   1,107 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     977.3 ns |   2.33 ns |   2.07 ns |   6,280 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,068.7 ns |   3.01 ns |   2.67 ns |   1,105 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,284.7 ns |   1.84 ns |   1.54 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   2,846.8 ns |   6.45 ns |   6.03 ns |   6,888 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,279.3 ns |   5.76 ns |   5.11 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   2,853.5 ns |  10.01 ns |   8.36 ns |   6,890 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  13,034.6 ns |  19.40 ns |  16.20 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  19,284.4 ns |  21.74 ns |  18.15 ns |   6,895 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 196,173.0 ns | 475.66 ns | 421.66 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 299,358.5 ns | 599.29 ns | 500.44 ns |   6,899 B |         - |