| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     417.7 ns |     6.92 ns |     5.78 ns |   4,644 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     628.4 ns |    12.43 ns |    13.81 ns |   2,848 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     982.9 ns |    17.48 ns |    14.60 ns |   1,166 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     399.5 ns |     1.99 ns |     1.77 ns |   4,642 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     621.4 ns |     8.33 ns |     6.96 ns |   2,848 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     966.2 ns |     2.62 ns |     2.05 ns |   1,166 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,343.4 ns |     7.91 ns |     7.40 ns |   4,663 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,647.2 ns |    12.80 ns |    11.35 ns |   2,860 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   3,043.5 ns |    19.41 ns |    17.21 ns |   1,166 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,343.4 ns |     7.13 ns |     5.95 ns |   4,663 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,650.8 ns |    10.49 ns |     9.30 ns |   2,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,023.6 ns |    11.47 ns |    10.17 ns |   1,166 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   8,960.4 ns |    33.67 ns |    28.12 ns |   4,576 B |    8360 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  18,828.4 ns |    58.43 ns |    51.80 ns |   2,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  19,511.0 ns |    76.02 ns |    59.35 ns |   1,166 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 166,057.0 ns |   676.17 ns |   564.63 ns |   4,576 B |  131254 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 295,825.4 ns | 1,068.49 ns |   947.19 ns |   2,844 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 302,160.5 ns | 1,132.67 ns | 1,004.08 ns |   1,166 B |         - |