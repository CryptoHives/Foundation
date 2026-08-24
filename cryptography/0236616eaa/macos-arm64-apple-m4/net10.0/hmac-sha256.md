| Description                                   | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     390.6 ns |     0.52 ns |      0.44 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     615.7 ns |     2.50 ns |      2.34 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     850.7 ns |    16.86 ns |     25.75 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     394.3 ns |     0.69 ns |      0.58 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     606.1 ns |     3.98 ns |      3.72 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     856.1 ns |    17.06 ns |     16.75 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     702.2 ns |     2.90 ns |      2.42 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     908.4 ns |     2.69 ns |      2.52 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,378.2 ns |     6.04 ns |      5.36 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     709.1 ns |     7.73 ns |      6.86 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     905.2 ns |     2.22 ns |      1.96 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,769.3 ns |    75.33 ns |    141.49 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,140.6 ns |    20.57 ns |     18.23 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,237.3 ns |    41.58 ns |     38.90 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  27,045.0 ns |   531.23 ns |    872.82 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,915.7 ns |   387.24 ns |    343.28 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  49,069.2 ns |   817.66 ns |    764.84 ns |  131292 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 420,841.4 ns | 8,372.15 ns | 14,663.15 ns |         - |