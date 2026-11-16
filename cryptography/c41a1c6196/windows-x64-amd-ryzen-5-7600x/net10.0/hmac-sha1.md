| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     443.8 ns |   1.08 ns |   0.90 ns |   5,533 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     694.8 ns |   2.16 ns |   1.80 ns |   2,894 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,017.3 ns |   1.35 ns |   1.13 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     452.8 ns |   0.68 ns |   0.57 ns |   5,533 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     696.5 ns |   1.66 ns |   1.47 ns |   2,898 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,019.3 ns |   2.34 ns |   2.19 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   1,493.9 ns |   6.31 ns |   5.59 ns |   5,556 B |    1192 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,980.8 ns |   5.36 ns |   4.76 ns |   2,902 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   3,167.3 ns |   7.95 ns |   7.04 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   1,491.0 ns |   4.19 ns |   3.50 ns |   5,556 B |    1200 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,982.9 ns |   7.20 ns |   6.01 ns |   2,876 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   3,175.7 ns |   4.97 ns |   4.65 ns |   1,166 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   9,857.0 ns |  37.85 ns |  33.56 ns |   5,555 B |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  20,418.6 ns |  24.26 ns |  20.26 ns |   1,166 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  21,223.4 ns |  58.72 ns |  49.04 ns |   2,902 B |         - |
|                                             |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 186,284.0 ns | 902.63 ns | 844.32 ns |   5,555 B |  131254 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 315,011.2 ns | 515.04 ns | 430.09 ns |   1,166 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 333,338.1 ns | 222.96 ns | 186.18 ns |   2,894 B |         - |