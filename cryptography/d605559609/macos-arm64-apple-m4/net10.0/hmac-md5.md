| Description                                | TestDataSize | Mean         | Error     | StdDev    | Median       | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128B         |     469.5 ns |   0.31 ns |   0.24 ns |     469.5 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128B         |     733.0 ns |   0.56 ns |   0.50 ns |     732.8 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 128B         |   1,054.4 ns |  10.56 ns |   9.36 ns |   1,054.3 ns |     272 B |
|                                            |              |              |           |           |              |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 137B         |     456.1 ns |   1.83 ns |   1.71 ns |     455.8 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 137B         |     733.6 ns |   0.13 ns |   0.11 ns |     733.6 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 137B         |     989.5 ns |  19.63 ns |  32.25 ns |     972.6 ns |     288 B |
|                                            |              |              |           |           |              |           |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1KB          |   1,983.4 ns |   9.99 ns |   8.85 ns |   1,983.8 ns |         - |
| ComputeMac · HMAC-MD5 · OS                 | 1KB          |   2,023.3 ns |  11.37 ns |  10.08 ns |   2,022.4 ns |    1168 B |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1KB          |   2,489.8 ns |  13.67 ns |  11.42 ns |   2,492.3 ns |         - |
|                                            |              |              |           |           |              |           |
| ComputeMac · HMAC-MD5 · OS                 | 1025B        |   2,112.1 ns |  13.36 ns |  11.84 ns |   2,110.8 ns |    1176 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 1025B        |   2,129.8 ns |  24.70 ns |  21.90 ns |   2,135.7 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 1025B        |   2,479.6 ns |  24.85 ns |  19.40 ns |   2,477.2 ns |         - |
|                                            |              |              |           |           |              |           |
| ComputeMac · HMAC-MD5 · OS                 | 8KB          |  10,819.3 ns | 208.19 ns | 204.47 ns |  10,762.2 ns |    8336 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 8KB          |  14,787.4 ns |  61.21 ns |  57.25 ns |  14,776.9 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 8KB          |  16,908.1 ns |   7.97 ns |   6.65 ns |  16,907.4 ns |         - |
|                                            |              |              |           |           |              |           |
| ComputeMac · HMAC-MD5 · OS                 | 128KB        | 161,185.6 ns | 523.74 ns | 437.35 ns | 161,029.8 ns |  131244 B |
| ComputeMac · HMAC-MD5 · BouncyCastle       | 128KB        | 232,427.5 ns | 694.60 ns | 649.73 ns | 232,472.2 ns |         - |
| ComputeMac · HMAC-MD5 · CryptoHives-Scalar | 128KB        | 258,370.8 ns | 351.51 ns | 328.80 ns | 258,319.8 ns |         - |