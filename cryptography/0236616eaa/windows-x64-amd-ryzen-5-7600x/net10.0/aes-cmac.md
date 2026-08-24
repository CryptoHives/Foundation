| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     150.2 ns |   0.12 ns |   0.11 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     475.5 ns |   1.10 ns |   0.92 ns |   2,363 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     163.6 ns |   0.22 ns |   0.17 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     532.2 ns |   1.60 ns |   1.50 ns |   2,363 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,085.7 ns |   1.58 ns |   1.40 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,607.5 ns |   9.72 ns |   9.10 ns |   2,363 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,105.9 ns |   2.79 ns |   2.18 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,714.5 ns |  11.45 ns |  10.71 ns |   2,365 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   8,483.9 ns |  12.49 ns |  10.43 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  28,654.0 ns | 186.10 ns | 155.41 ns |   2,363 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 136,896.2 ns | 147.14 ns | 130.43 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 456,610.7 ns | 552.21 ns | 489.52 ns |   2,363 B |         - |