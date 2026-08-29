| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     349.3 ns |   1.16 ns |   0.97 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     632.9 ns |   0.89 ns |   0.84 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     496.1 ns |   4.44 ns |   3.70 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     792.5 ns |   1.60 ns |   1.34 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,418.2 ns |  12.34 ns |  10.94 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,681.0 ns |   5.45 ns |   4.83 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,412.9 ns |   9.26 ns |   8.21 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,679.6 ns |   4.55 ns |   3.80 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,593.5 ns |  16.27 ns |  14.43 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,643.5 ns |  43.36 ns |  40.56 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 145,331.2 ns | 916.89 ns | 765.64 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 146,496.7 ns | 938.71 ns | 832.14 ns |         - |