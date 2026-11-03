| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     351.1 ns |     2.71 ns |     2.40 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     636.4 ns |     1.13 ns |     1.01 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     497.8 ns |     4.40 ns |     4.12 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     793.3 ns |     1.85 ns |     1.64 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,415.7 ns |     8.11 ns |     6.77 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,689.8 ns |     6.18 ns |     5.78 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,448.9 ns |     8.84 ns |     8.27 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,689.7 ns |     3.75 ns |     3.33 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,441.2 ns |    70.30 ns |    65.76 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,646.3 ns |    33.07 ns |    30.93 ns |         - |
|                                                 |              |              |             |             |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 145,823.7 ns |   529.39 ns |   495.19 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 147,519.8 ns | 2,028.44 ns | 1,897.40 ns |         - |