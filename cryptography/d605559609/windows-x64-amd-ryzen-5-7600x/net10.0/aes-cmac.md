| Description                                | TestDataSize | Mean         | Error       | StdDev      | Median       | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     149.6 ns |     0.52 ns |     0.44 ns |     149.5 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     487.0 ns |     6.03 ns |     5.04 ns |     485.3 ns |   2,363 B |         - |
|                                            |              |              |             |             |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     168.6 ns |     0.34 ns |     0.30 ns |     168.5 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     534.9 ns |     1.58 ns |     1.40 ns |     534.4 ns |   2,363 B |         - |
|                                            |              |              |             |             |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,103.4 ns |    21.55 ns |    26.47 ns |   1,087.2 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,628.5 ns |    13.58 ns |    12.04 ns |   3,629.6 ns |   2,363 B |         - |
|                                            |              |              |             |             |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,112.9 ns |     2.13 ns |     1.66 ns |   1,112.4 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,686.8 ns |    16.23 ns |    12.67 ns |   3,682.8 ns |   2,365 B |         - |
|                                            |              |              |             |             |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   8,519.7 ns |    20.21 ns |    16.88 ns |   8,513.6 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  28,808.1 ns |   105.59 ns |    98.77 ns |  28,781.4 ns |   2,363 B |         - |
|                                            |              |              |             |             |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 138,375.0 ns | 1,343.34 ns | 1,256.56 ns | 137,717.2 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 460,078.3 ns | 1,377.48 ns | 1,288.49 ns | 459,637.9 ns |   2,363 B |         - |