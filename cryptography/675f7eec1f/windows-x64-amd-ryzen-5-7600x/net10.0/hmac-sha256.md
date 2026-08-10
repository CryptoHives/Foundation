| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     225.5 ns |     1.44 ns |     1.28 ns |   4,639 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     776.0 ns |     2.39 ns |     1.87 ns |   2,858 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,025.3 ns |     5.67 ns |     5.31 ns |   1,333 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     230.9 ns |     0.84 ns |     0.70 ns |   4,639 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     779.7 ns |     1.96 ns |     1.64 ns |   2,858 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,026.9 ns |     3.06 ns |     2.56 ns |   1,333 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     594.4 ns |     2.73 ns |     2.42 ns |   4,643 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,287.7 ns |     6.18 ns |     4.82 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,343.4 ns |    11.99 ns |     9.36 ns |   2,858 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     598.7 ns |     4.23 ns |     3.95 ns |   4,643 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,284.5 ns |    10.15 ns |     9.00 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,339.9 ns |    18.34 ns |    16.26 ns |   2,858 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,903.2 ns |    55.09 ns |    51.53 ns |   4,576 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  21,262.2 ns |    34.74 ns |    27.12 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  23,795.9 ns |   126.37 ns |   105.52 ns |   2,858 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  87,991.1 ns | 1,194.02 ns | 1,058.47 ns |   4,576 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 331,851.5 ns | 2,206.93 ns | 1,956.39 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 374,616.2 ns | 1,505.54 ns | 1,257.20 ns |   2,858 B |         - |