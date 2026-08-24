| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     428.3 ns |   1.04 ns |   0.92 ns |   4,643 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     504.0 ns |   1.01 ns |   0.89 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     553.0 ns |   2.13 ns |   1.99 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     436.2 ns |   0.51 ns |   0.45 ns |   4,641 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     501.6 ns |   1.53 ns |   1.28 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     558.9 ns |   0.76 ns |   0.59 ns |   1,031 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,559.2 ns |   3.04 ns |   2.69 ns |   4,663 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   1,752.4 ns |   2.03 ns |   1.80 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,108.7 ns |   3.38 ns |   2.82 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,558.0 ns |   1.95 ns |   1.82 ns |   4,663 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   1,760.3 ns |   3.10 ns |   2.59 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,107.6 ns |   3.41 ns |   3.02 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,648.4 ns |  49.09 ns |  40.99 ns |   4,576 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  11,339.4 ns |  17.61 ns |  14.71 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,940.0 ns |  18.17 ns |  16.11 ns |   2,824 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 175,995.2 ns | 417.08 ns | 390.14 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 193,601.6 ns | 487.70 ns | 456.19 ns |   4,576 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 234,942.3 ns | 329.11 ns | 274.82 ns |   2,824 B |         - |