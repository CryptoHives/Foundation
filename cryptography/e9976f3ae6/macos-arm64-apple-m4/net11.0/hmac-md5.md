| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     449.9 ns |     1.04 ns |     0.92 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     727.3 ns |     1.23 ns |     1.09 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |   1,001.8 ns |     4.87 ns |     4.55 ns |     272 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     451.5 ns |     1.11 ns |     1.04 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     726.7 ns |     2.80 ns |     2.48 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     986.4 ns |     5.09 ns |     4.76 ns |     288 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   1,980.4 ns |    10.79 ns |    10.09 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,061.6 ns |     6.21 ns |     5.81 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,451.4 ns |     9.46 ns |     8.85 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   1,978.3 ns |    14.25 ns |    13.33 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,057.8 ns |    12.05 ns |    11.27 ns |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,441.4 ns |    14.43 ns |    13.49 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,261.5 ns |    37.22 ns |    32.99 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,345.6 ns |    50.81 ns |    47.53 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  16,196.8 ns |   140.43 ns |   131.36 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 159,596.5 ns |   595.86 ns |   557.36 ns |  131242 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 225,143.0 ns |   801.95 ns |   750.15 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 251,903.4 ns | 1,072.33 ns | 1,003.06 ns |         - |