| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     431.2 ns |   0.89 ns |   0.79 ns |   4,641 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     506.0 ns |   1.75 ns |   1.64 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     557.5 ns |   1.14 ns |   0.89 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     431.6 ns |   1.68 ns |   1.40 ns |   4,641 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     502.8 ns |   1.14 ns |   1.01 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     562.0 ns |   1.10 ns |   0.98 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,568.6 ns |   4.08 ns |   3.81 ns |   4,663 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   1,774.8 ns |  25.79 ns |  20.14 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,114.5 ns |   3.53 ns |   2.94 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,566.7 ns |   3.36 ns |   2.80 ns |   4,663 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   1,773.1 ns |   3.12 ns |   2.61 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,132.1 ns |  32.41 ns |  30.32 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,664.7 ns |  22.13 ns |  19.62 ns |   4,576 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  11,407.1 ns |  18.47 ns |  14.42 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,955.1 ns |  28.16 ns |  21.99 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 177,090.3 ns | 392.67 ns | 327.90 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 195,209.3 ns | 420.93 ns | 373.14 ns |   4,576 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 235,642.1 ns | 398.90 ns | 311.43 ns |   2,810 B |         - |