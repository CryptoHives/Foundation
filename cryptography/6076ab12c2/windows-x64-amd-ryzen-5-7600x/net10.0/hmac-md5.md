| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     499.7 ns |   0.80 ns |   0.71 ns |   5,535 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     587.0 ns |   0.44 ns |   0.42 ns |   2,882 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     633.6 ns |   0.35 ns |   0.33 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     497.6 ns |   0.69 ns |   0.61 ns |   5,535 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     585.8 ns |   0.40 ns |   0.36 ns |   2,882 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     639.0 ns |   0.34 ns |   0.32 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,815.9 ns |   1.56 ns |   1.38 ns |   5,557 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,008.0 ns |   2.34 ns |   2.19 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,462.6 ns |   1.37 ns |   1.29 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,813.0 ns |   1.40 ns |   1.31 ns |   5,557 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,014.0 ns |   1.90 ns |   1.78 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,461.7 ns |   1.24 ns |   1.16 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  12,338.0 ns |  17.47 ns |  15.49 ns |   5,558 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  12,994.8 ns |   6.00 ns |   5.32 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  17,469.5 ns |  11.08 ns |   9.82 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 201,377.1 ns | 122.89 ns | 114.95 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 224,706.9 ns | 290.67 ns | 271.89 ns |   5,558 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 274,411.3 ns | 111.24 ns |  98.61 ns |   2,882 B |         - |