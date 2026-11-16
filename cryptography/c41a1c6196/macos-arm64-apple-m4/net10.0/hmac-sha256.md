| Description                                   | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     372.6 ns |     0.86 ns |      0.72 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     593.7 ns |     2.72 ns |      2.54 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     839.2 ns |    13.21 ns |     12.35 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     375.6 ns |     0.97 ns |      0.81 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     582.3 ns |     3.65 ns |      3.42 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     856.4 ns |    17.51 ns |     15.52 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     661.6 ns |     1.81 ns |      1.61 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     882.4 ns |     2.72 ns |      2.54 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,757.5 ns |    72.78 ns |     97.15 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     665.1 ns |     2.48 ns |      2.20 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     883.0 ns |     2.11 ns |      1.97 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,754.4 ns |    73.26 ns |    100.28 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,059.0 ns |     3.42 ns |      2.86 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,214.2 ns |     2.29 ns |      2.14 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  27,040.3 ns |   524.82 ns |    644.53 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,297.9 ns |    38.92 ns |     36.41 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  48,493.2 ns |    49.54 ns |     46.34 ns |  131292 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 426,351.6 ns | 8,287.51 ns | 10,481.04 ns |         - |