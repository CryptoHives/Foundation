| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     394.7 ns |     0.28 ns |     0.26 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     614.2 ns |     2.16 ns |     2.02 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     816.0 ns |    15.79 ns |    19.39 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     396.2 ns |     0.60 ns |     0.56 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     601.8 ns |     2.36 ns |     2.20 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     829.8 ns |    14.33 ns |    13.41 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     702.4 ns |     2.87 ns |     2.40 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     904.0 ns |     3.64 ns |     3.41 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,611.0 ns |    71.22 ns |    84.78 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     704.4 ns |     1.89 ns |     1.58 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     906.9 ns |     4.47 ns |     4.18 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,644.6 ns |    70.55 ns |    89.23 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,129.8 ns |    14.56 ns |    13.62 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,204.5 ns |     9.41 ns |     8.80 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,006.7 ns |   510.50 ns |   567.42 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,643.1 ns |   247.29 ns |   231.32 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  48,960.4 ns |   155.92 ns |   145.84 ns |  131292 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 417,123.7 ns | 7,061.04 ns | 6,604.90 ns |         - |