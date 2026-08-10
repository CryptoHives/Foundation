| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128B         |     707.6 ns |   5.38 ns |   5.04 ns |   6,297 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128B         |     872.1 ns |   4.62 ns |   4.33 ns |   1,107 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 137B         |   1,014.2 ns |   7.72 ns |   7.22 ns |   6,190 B |         - |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 137B         |   1,078.2 ns |   5.35 ns |   4.47 ns |   1,105 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1KB          |   2,316.8 ns |  16.13 ns |  14.30 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1KB          |   2,924.6 ns |  19.03 ns |  17.80 ns |   6,184 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 1025B        |   2,311.2 ns |   9.00 ns |   7.03 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 1025B        |   2,917.3 ns |  10.07 ns |   8.41 ns |   6,184 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 8KB          |  13,361.4 ns | 135.00 ns | 126.28 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 8KB          |  19,758.9 ns |  97.38 ns |  86.33 ns |   6,188 B |         - |
|                                                 |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA3-256 · CryptoHives-Scalar | 128KB        | 198,584.0 ns | 938.77 ns | 832.20 ns |   1,105 B |         - |
| ComputeMac · HMAC-SHA3-256 · BouncyCastle       | 128KB        | 305,058.3 ns | 382.57 ns | 298.68 ns |   6,183 B |         - |