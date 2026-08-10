| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     871.6 ns |    10.46 ns |     9.78 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,016.9 ns |     3.20 ns |     2.99 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,107.9 ns |     4.93 ns |     4.61 ns |     416 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     875.9 ns |     6.53 ns |     6.11 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,017.6 ns |     5.14 ns |     4.80 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,086.8 ns |     8.35 ns |     7.81 ns |     432 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,578.1 ns |     6.58 ns |     6.16 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,407.8 ns |     6.79 ns |     6.02 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,784.1 ns |    31.31 ns |    29.29 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,580.0 ns |     6.79 ns |     6.35 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,410.2 ns |     5.23 ns |     4.64 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,776.6 ns |    27.88 ns |    26.08 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   5,547.0 ns |    26.51 ns |    24.79 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,483.3 ns |    54.61 ns |    48.41 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  17,963.7 ns |   281.24 ns |   263.07 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  79,245.8 ns |   506.72 ns |   473.98 ns |  131388 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 203,458.1 ns |   543.54 ns |   453.88 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 276,815.7 ns | 5,261.95 ns | 5,630.22 ns |         - |