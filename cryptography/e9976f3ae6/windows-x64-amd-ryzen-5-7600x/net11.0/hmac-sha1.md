| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     447.4 ns |     0.66 ns |     0.55 ns |   8,762 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     690.5 ns |     0.80 ns |     0.67 ns |   9,687 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,021.1 ns |     2.07 ns |     1.83 ns |   1,121 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     442.4 ns |     0.80 ns |     0.71 ns |   8,762 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     694.1 ns |     1.31 ns |     1.16 ns |   9,687 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,020.9 ns |     2.22 ns |     1.86 ns |   1,121 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,502.1 ns |     3.90 ns |     3.64 ns |  12,605 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,991.8 ns |     7.94 ns |     7.43 ns |   5,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   3,175.9 ns |     9.78 ns |     8.67 ns |   1,121 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,518.8 ns |     7.39 ns |     6.91 ns |   8,762 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   3,003.7 ns |    14.47 ns |    13.54 ns |   9,687 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,195.0 ns |    17.03 ns |    15.93 ns |   1,121 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |  10,065.2 ns |    73.32 ns |    68.58 ns |   8,801 B |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  20,795.3 ns |    67.35 ns |    59.70 ns |   1,121 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  21,382.2 ns |   115.42 ns |   107.96 ns |   5,844 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 193,713.3 ns | 1,227.95 ns | 1,148.63 ns |   8,801 B |  131294 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 320,005.9 ns | 1,291.25 ns | 1,207.84 ns |   1,121 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 334,068.2 ns |   334.39 ns |   261.07 ns |   5,851 B |         - |