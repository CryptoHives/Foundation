| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     455.9 ns |     1.24 ns |     1.16 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     733.9 ns |     1.02 ns |     0.96 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |   1,009.8 ns |     4.70 ns |     4.40 ns |     272 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     456.9 ns |     1.64 ns |     1.53 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     733.4 ns |     1.03 ns |     0.96 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     992.8 ns |     4.87 ns |     4.55 ns |     288 B |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   2,024.8 ns |     9.89 ns |     9.26 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,088.3 ns |    14.00 ns |    13.10 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,486.1 ns |     7.62 ns |     7.13 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,021.2 ns |     8.76 ns |     8.20 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,081.7 ns |    10.44 ns |     9.76 ns |    1176 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,484.3 ns |    10.85 ns |    10.15 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,378.3 ns |    58.93 ns |    55.12 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,527.0 ns |    58.83 ns |    49.12 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  16,489.7 ns |    68.56 ns |    64.13 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 158,955.2 ns |   667.98 ns |   624.83 ns |  131244 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 229,665.6 ns |   652.98 ns |   578.85 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 256,074.6 ns | 1,601.28 ns | 1,497.84 ns |         - |