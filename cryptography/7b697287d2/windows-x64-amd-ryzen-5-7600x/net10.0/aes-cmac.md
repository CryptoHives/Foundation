| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     170.2 ns |   0.13 ns |   0.11 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     536.1 ns |   1.52 ns |   1.43 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     189.0 ns |   0.14 ns |   0.13 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     599.8 ns |   1.39 ns |   1.23 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,274.0 ns |   0.77 ns |   0.68 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   4,057.4 ns |   7.63 ns |   7.14 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,294.5 ns |   0.85 ns |   0.79 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   4,128.5 ns |  13.00 ns |  11.53 ns |   2,511 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |  10,047.8 ns |   8.33 ns |   7.38 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  32,291.6 ns |  88.50 ns |  82.78 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 160,341.0 ns | 153.62 ns | 143.70 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 515,163.1 ns | 832.18 ns | 737.71 ns |   2,509 B |         - |