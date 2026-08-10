| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     452.4 ns |     6.10 ns |     5.41 ns |   4,641 B |     272 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     510.5 ns |     6.69 ns |     5.93 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     559.7 ns |     7.53 ns |     7.04 ns |   1,031 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     444.1 ns |     4.52 ns |     3.78 ns |   4,641 B |     288 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     508.0 ns |     4.32 ns |     3.37 ns |   2,824 B |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     560.9 ns |     5.21 ns |     4.62 ns |   1,031 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,614.7 ns |    19.16 ns |    16.98 ns |   4,663 B |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   1,784.5 ns |    32.36 ns |    30.27 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,215.6 ns |    43.20 ns |    53.06 ns |   2,824 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,620.5 ns |    31.86 ns |    35.41 ns |   4,663 B |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   1,845.0 ns |    35.16 ns |    34.53 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,201.0 ns |    42.57 ns |    49.02 ns |   2,824 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,954.6 ns |    71.27 ns |    66.67 ns |   4,576 B |    8336 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  11,806.6 ns |   223.08 ns |   247.95 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  15,129.2 ns |    29.31 ns |    24.48 ns |   2,824 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 187,704.8 ns | 3,254.53 ns | 5,784.92 ns |   1,031 B |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 197,668.7 ns | 2,013.22 ns | 1,571.79 ns |   4,576 B |  131230 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 237,655.4 ns | 1,296.81 ns | 1,149.59 ns |   2,824 B |         - |