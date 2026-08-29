| Description                                   | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     224.8 ns |     1.74 ns |   1.36 ns |   4,639 B |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     769.0 ns |     2.03 ns |   1.69 ns |   2,854 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,035.5 ns |     3.57 ns |   2.98 ns |   1,333 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     221.8 ns |     0.73 ns |   0.61 ns |   4,639 B |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     769.4 ns |     2.25 ns |   2.00 ns |   2,862 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,028.7 ns |     1.53 ns |   1.19 ns |   1,333 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     581.2 ns |     3.19 ns |   2.66 ns |   4,643 B |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,308.6 ns |     7.20 ns |   6.73 ns |   2,866 B |         - |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   3,325.3 ns |    17.43 ns |  15.45 ns |   1,333 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     579.5 ns |     3.31 ns |   2.93 ns |   4,643 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   3,310.3 ns |    10.17 ns |   8.49 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,322.4 ns |    10.68 ns |   9.99 ns |   2,858 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,746.1 ns |    51.84 ns |  53.24 ns |   4,576 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  21,682.0 ns |    72.26 ns |  67.59 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  23,676.2 ns |   133.96 ns | 118.75 ns |   2,866 B |         - |
|                                               |              |              |             |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  88,164.4 ns | 1,023.80 ns | 854.92 ns |   4,576 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 332,625.2 ns | 1,039.08 ns | 921.12 ns |   1,333 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 371,242.9 ns | 1,102.42 ns | 977.26 ns |   2,858 B |         - |