| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128B         |     982.5 ns |   8.14 ns |   7.62 ns |   6,248 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128B         |   1,051.9 ns |   2.16 ns |   2.02 ns |   1,105 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 137B         |     980.6 ns |   1.06 ns |   0.83 ns |   6,248 B |         - |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 137B         |   1,046.7 ns |   2.59 ns |   2.30 ns |   1,105 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1KB          |   3,640.0 ns |   8.07 ns |   7.15 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1KB          |   5,002.3 ns |  16.39 ns |  13.68 ns |   6,877 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 1025B        |   3,642.6 ns |   8.71 ns |   7.72 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 1025B        |   5,009.9 ns |   6.01 ns |   5.02 ns |   6,876 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 8KB          |  23,412.7 ns |  35.44 ns |  29.60 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 8KB          |  35,310.6 ns |  59.13 ns |  52.41 ns |   6,882 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-512 · CryptoHives-Scalar | 128KB        | 364,040.0 ns | 505.66 ns | 422.25 ns |   1,107 B |         - |
| ComputeMac · HMAC-SHA3-512 · BouncyCastle       | 128KB        | 557,265.9 ns | 879.18 ns | 779.37 ns |   6,880 B |         - |