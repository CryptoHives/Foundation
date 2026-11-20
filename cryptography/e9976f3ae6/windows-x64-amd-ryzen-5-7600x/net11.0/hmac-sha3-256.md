| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     760.5 ns |   1.69 ns |   1.58 ns |  12,309 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     973.8 ns |   3.43 ns |   3.04 ns |   5,493 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1,096.2 ns |   2.46 ns |   2.05 ns |  12,929 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,200.7 ns |   2.12 ns |   1.77 ns |   5,482 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,574.7 ns |   5.07 ns |   4.24 ns |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   3,206.1 ns |   6.16 ns |   5.46 ns |  14,722 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,578.7 ns |   5.59 ns |   4.67 ns |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   3,198.9 ns |   8.94 ns |   7.93 ns |  14,722 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  14,763.7 ns |  25.10 ns |  20.96 ns |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  21,774.7 ns |  48.13 ns |  42.66 ns |   9,661 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 220,952.2 ns | 223.76 ns | 174.69 ns |   5,491 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 333,739.1 ns | 592.10 ns | 494.43 ns |   9,639 B |         - |