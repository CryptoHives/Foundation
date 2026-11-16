| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     450.7 ns |     1.05 ns |     0.98 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     727.7 ns |     3.02 ns |     2.82 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |   1,001.6 ns |     3.64 ns |     3.40 ns |     272 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     453.0 ns |     1.42 ns |     1.33 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     726.0 ns |     1.77 ns |     1.47 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     987.2 ns |     5.84 ns |     5.46 ns |     288 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   1,993.4 ns |     6.20 ns |     5.50 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,062.0 ns |    11.80 ns |    11.04 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,460.6 ns |    13.54 ns |    12.67 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   1,988.0 ns |    11.91 ns |    11.14 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,059.7 ns |    11.31 ns |    10.58 ns |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,452.1 ns |    12.96 ns |    12.13 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,260.0 ns |    50.20 ns |    46.96 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,293.2 ns |    30.31 ns |    28.35 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  16,230.8 ns |   105.02 ns |    98.23 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 156,805.1 ns |   687.31 ns |   642.91 ns |  131244 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 225,686.8 ns |   612.37 ns |   572.81 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 252,310.0 ns | 1,237.83 ns | 1,097.31 ns |         - |