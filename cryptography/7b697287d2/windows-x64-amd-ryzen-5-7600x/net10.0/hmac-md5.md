| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     502.1 ns |   0.83 ns |   0.74 ns |   5,532 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     587.2 ns |   0.62 ns |   0.55 ns |   2,882 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     642.2 ns |   0.84 ns |   0.79 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     498.5 ns |   1.13 ns |   1.06 ns |   5,532 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     587.0 ns |   0.46 ns |   0.40 ns |   2,882 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     641.0 ns |   0.73 ns |   0.69 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,815.0 ns |   1.50 ns |   1.33 ns |   5,554 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,015.7 ns |   3.32 ns |   3.11 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,467.6 ns |   2.53 ns |   2.36 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,813.6 ns |   1.60 ns |   1.50 ns |   5,554 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,023.8 ns |   1.91 ns |   1.79 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,465.6 ns |   2.10 ns |   1.86 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  12,326.3 ns |   9.09 ns |   8.50 ns |   5,555 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  13,010.8 ns |  10.52 ns |   9.32 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  17,455.7 ns |  15.62 ns |  14.61 ns |   2,882 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 201,702.1 ns | 172.12 ns | 152.58 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 224,340.7 ns | 107.68 ns | 100.73 ns |   5,555 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 275,046.4 ns | 211.20 ns | 197.56 ns |   2,882 B |         - |