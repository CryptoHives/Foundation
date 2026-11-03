| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     437.6 ns |     1.85 ns |     1.73 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     711.9 ns |     2.80 ns |     2.62 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |     978.9 ns |     3.32 ns |     2.94 ns |     272 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     438.8 ns |     1.56 ns |     1.46 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     710.3 ns |     3.36 ns |     3.14 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     964.3 ns |     3.37 ns |     3.16 ns |     288 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   1,928.5 ns |    11.38 ns |    10.64 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   1,990.3 ns |     8.80 ns |     8.23 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,394.4 ns |     6.74 ns |     5.97 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   1,925.6 ns |    11.24 ns |    10.51 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   1,987.7 ns |     9.31 ns |     8.25 ns |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,393.2 ns |    11.42 ns |    10.69 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |   9,990.7 ns |    25.36 ns |    23.72 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  13,956.8 ns |    48.57 ns |    45.43 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  15,841.2 ns |    73.53 ns |    68.78 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 153,248.6 ns |   474.83 ns |   444.15 ns |  131244 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 220,549.5 ns |   526.91 ns |   492.87 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 246,829.9 ns | 1,470.41 ns | 1,375.42 ns |         - |