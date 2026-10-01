| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     351.3 ns |     2.88 ns |     2.69 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     636.1 ns |     0.37 ns |     0.32 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     494.3 ns |     4.86 ns |     4.55 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     790.4 ns |     0.71 ns |     0.66 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,410.8 ns |     7.02 ns |     6.57 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,691.9 ns |     1.09 ns |     1.02 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,407.2 ns |     4.56 ns |     4.04 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,679.1 ns |     1.20 ns |     1.12 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,426.7 ns |    68.09 ns |    63.69 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,679.5 ns |     7.99 ns |     7.47 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 145,079.3 ns |   255.04 ns |   238.56 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 149,673.2 ns | 1,207.40 ns | 1,129.40 ns |         - |