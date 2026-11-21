| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     255.3 ns |   0.69 ns |   0.61 ns |   8,758 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     878.9 ns |   1.99 ns |   1.76 ns |   9,895 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,078.8 ns |  10.32 ns |   8.62 ns |   4,881 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     252.5 ns |   0.64 ns |   0.57 ns |   8,762 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     874.3 ns |   1.50 ns |   1.25 ns |   9,895 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,061.7 ns |   1.39 ns |   1.30 ns |   4,881 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     680.4 ns |   2.09 ns |   1.85 ns |  12,436 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,434.0 ns |   2.78 ns |   2.17 ns |   4,872 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,755.3 ns |   6.98 ns |   6.19 ns |   9,895 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     676.7 ns |   1.21 ns |   1.07 ns |  12,605 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,433.1 ns |   7.11 ns |   6.31 ns |   4,881 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,750.8 ns |   1.82 ns |   1.52 ns |   9,705 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   4,113.3 ns |  15.96 ns |  14.93 ns |  12,644 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  22,247.2 ns |  49.57 ns |  38.70 ns |   4,881 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,725.1 ns |  49.84 ns |  41.62 ns |   5,862 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        | 101,364.8 ns | 237.75 ns | 210.76 ns |  12,644 B |  131318 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 346,898.6 ns | 612.10 ns | 542.61 ns |   4,881 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 421,307.1 ns | 665.74 ns | 590.16 ns |   5,869 B |         - |