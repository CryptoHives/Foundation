| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     439.7 ns |   0.75 ns |   0.71 ns |   4,641 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     506.4 ns |   1.20 ns |   1.13 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     563.2 ns |   0.54 ns |   0.48 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     439.4 ns |   1.14 ns |   1.01 ns |   4,641 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     506.2 ns |   1.51 ns |   1.42 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     573.0 ns |   1.05 ns |   0.87 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,579.8 ns |   2.74 ns |   2.43 ns |   4,663 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   1,786.9 ns |   3.41 ns |   3.19 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,125.4 ns |   5.41 ns |   4.79 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,567.7 ns |   3.61 ns |   3.38 ns |   4,663 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   1,794.2 ns |   3.43 ns |   3.21 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,135.1 ns |   4.31 ns |   3.82 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,696.8 ns |  38.27 ns |  35.79 ns |   4,576 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  11,539.5 ns |   9.91 ns |   8.28 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  15,069.0 ns |  21.27 ns |  18.86 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 178,923.5 ns | 333.59 ns | 278.57 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 196,431.4 ns | 839.34 ns | 785.12 ns |   4,576 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 237,202.8 ns | 411.07 ns | 384.51 ns |   2,824 B |         - |