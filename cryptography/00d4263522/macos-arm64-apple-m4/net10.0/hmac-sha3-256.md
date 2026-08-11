| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     350.3 ns |   1.78 ns |   1.48 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     634.0 ns |   0.40 ns |   0.37 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |     495.3 ns |   1.68 ns |   1.49 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |     785.8 ns |   2.39 ns |   2.23 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   1,418.6 ns |  11.00 ns |  10.29 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   1,685.4 ns |   4.18 ns |   3.91 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   1,415.4 ns |   4.43 ns |   4.14 ns |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   1,688.4 ns |   1.69 ns |   1.50 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |   9,647.3 ns |  13.31 ns |  12.45 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |   9,661.6 ns |  29.99 ns |  28.05 ns |         - |
|                                                 |              |              |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 146,037.1 ns | 535.61 ns | 501.01 ns |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 146,772.4 ns | 445.16 ns | 394.62 ns |         - |