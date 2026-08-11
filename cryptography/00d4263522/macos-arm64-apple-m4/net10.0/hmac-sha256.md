| Description                                   | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     394.7 ns |     0.31 ns |      0.29 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     607.8 ns |     2.50 ns |      2.34 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     822.2 ns |    15.97 ns |     18.40 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     395.6 ns |     0.50 ns |      0.45 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     596.1 ns |     2.37 ns |      2.22 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     827.5 ns |    16.44 ns |     16.88 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     692.7 ns |     2.94 ns |      2.75 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     894.3 ns |     2.94 ns |      2.75 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,575.2 ns |    70.03 ns |     98.17 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     697.8 ns |     3.65 ns |      3.23 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     892.3 ns |     3.64 ns |      3.41 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,644.1 ns |    68.42 ns |     70.26 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,083.8 ns |    12.96 ns |     12.13 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,191.8 ns |     4.84 ns |      4.53 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,485.1 ns |   463.77 ns |    433.81 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,410.7 ns |    55.08 ns |     51.53 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  48,763.9 ns |    46.64 ns |     41.34 ns |  131292 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 414,915.9 ns | 8,144.31 ns | 10,001.95 ns |         - |