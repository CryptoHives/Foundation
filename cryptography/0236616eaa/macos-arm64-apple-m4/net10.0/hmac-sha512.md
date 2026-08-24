| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     899.5 ns |    17.81 ns |    20.51 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,021.2 ns |    16.67 ns |    14.77 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,125.6 ns |    22.24 ns |    39.54 ns |     416 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     904.4 ns |    17.92 ns |    21.33 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,027.3 ns |     6.33 ns |     5.29 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,083.3 ns |     5.97 ns |     5.59 ns |     432 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,579.7 ns |    27.38 ns |    21.38 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,406.2 ns |    34.42 ns |    26.88 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,824.6 ns |    56.45 ns |   101.79 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,596.8 ns |     8.62 ns |     8.06 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,395.7 ns |     4.24 ns |     3.31 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,883.7 ns |    56.06 ns |    80.39 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   5,601.4 ns |    62.68 ns |    52.34 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,508.1 ns |   185.08 ns |   164.07 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  18,813.9 ns |   361.91 ns |   387.24 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  81,011.5 ns |   399.33 ns |   373.53 ns |  131388 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 202,277.6 ns |   409.53 ns |   363.04 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 292,278.6 ns | 5,634.93 ns | 6,707.98 ns |         - |