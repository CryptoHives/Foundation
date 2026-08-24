| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     392.9 ns |   1.37 ns |   1.21 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     625.4 ns |   3.59 ns |   3.36 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     681.4 ns |   0.68 ns |   0.63 ns |         - |
|                                             |              |              |           |           |           |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     394.6 ns |   2.09 ns |   1.95 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     614.2 ns |   2.45 ns |   2.29 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     680.0 ns |   1.16 ns |   1.03 ns |         - |
|                                             |              |              |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     903.9 ns |   3.03 ns |   2.83 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   1,379.8 ns |   3.25 ns |   3.04 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,952.4 ns |   4.22 ns |   3.95 ns |         - |
|                                             |              |              |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     904.3 ns |   1.49 ns |   1.25 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   1,382.5 ns |   3.77 ns |   3.52 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,703.2 ns |   2.50 ns |   2.34 ns |         - |
|                                             |              |              |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,192.4 ns |   2.25 ns |   2.11 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |   9,306.7 ns |   3.38 ns |   3.00 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  20,718.2 ns | 253.75 ns | 237.36 ns |         - |
|                                             |              |              |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  48,208.1 ns |  84.50 ns |  74.91 ns |  131268 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 145,111.3 ns |  27.71 ns |  23.14 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 330,162.9 ns | 528.63 ns | 468.62 ns |         - |