| Description                                   | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     392.2 ns |     1.01 ns |      0.95 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     623.0 ns |     2.69 ns |      2.51 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     849.6 ns |    16.99 ns |     28.38 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     392.7 ns |     0.77 ns |      0.64 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     612.0 ns |     3.10 ns |      2.90 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     839.6 ns |    16.49 ns |     28.45 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     708.8 ns |     4.28 ns |      3.79 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     915.0 ns |     4.77 ns |      4.47 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,383.5 ns |     6.29 ns |      5.58 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     715.1 ns |     7.27 ns |      6.80 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     918.5 ns |     7.03 ns |      6.23 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,679.5 ns |    72.25 ns |    142.62 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,073.0 ns |    14.87 ns |     13.18 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,190.0 ns |    14.17 ns |     11.83 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  27,183.0 ns |   533.64 ns |    876.78 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,985.1 ns |   272.82 ns |    255.20 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  49,687.5 ns |   902.96 ns |    800.45 ns |  131292 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 422,194.1 ns | 8,328.37 ns | 18,105.19 ns |         - |