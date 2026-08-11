| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |     391.1 ns |     1.32 ns |     1.17 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     619.1 ns |     2.93 ns |     2.75 ns |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |     643.8 ns |     0.75 ns |     0.71 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |     392.9 ns |     2.04 ns |     1.91 ns |         - |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     605.8 ns |     3.32 ns |     3.11 ns |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |     667.9 ns |     1.30 ns |     1.21 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |     892.3 ns |     2.78 ns |     2.47 ns |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   1,388.6 ns |     1.28 ns |     1.07 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   2,879.6 ns |     5.71 ns |     5.34 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |     893.2 ns |     3.24 ns |     3.03 ns |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   1,383.6 ns |     4.54 ns |     4.24 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   2,873.7 ns |     9.45 ns |     8.84 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |   3,203.8 ns |     1.52 ns |     1.35 ns |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |   9,354.7 ns |    25.43 ns |    21.24 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  20,565.2 ns |    49.84 ns |    46.62 ns |         - |
|                                             |              |              |             |             |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        |  49,002.2 ns |    64.48 ns |    60.31 ns |  131268 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 145,874.4 ns |   566.07 ns |   441.95 ns |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 321,985.7 ns | 2,815.76 ns | 2,633.86 ns |         - |