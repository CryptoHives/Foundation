| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     901.3 ns |    10.33 ns |     9.66 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |     953.6 ns |     8.28 ns |     6.91 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,076.2 ns |     2.81 ns |     2.63 ns |     416 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     911.5 ns |     4.29 ns |     4.02 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |     963.6 ns |    15.03 ns |    14.76 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,057.5 ns |     2.48 ns |     2.32 ns |     432 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,560.2 ns |     5.32 ns |     4.98 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,261.4 ns |    21.38 ns |    17.85 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,891.9 ns |    36.29 ns |    33.95 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,562.8 ns |     4.02 ns |     3.56 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,261.5 ns |    22.89 ns |    19.11 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,890.7 ns |    54.48 ns |    55.94 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   5,507.2 ns |     9.34 ns |     8.74 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  12,609.0 ns |    95.41 ns |    74.49 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  18,612.2 ns |   358.24 ns |   398.18 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  80,956.8 ns |   171.40 ns |   160.33 ns |  131386 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 193,821.7 ns | 3,836.39 ns | 4,264.13 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 291,953.5 ns | 4,557.10 ns | 4,262.72 ns |         - |