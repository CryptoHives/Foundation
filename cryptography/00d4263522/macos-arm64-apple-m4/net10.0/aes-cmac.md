| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     120.0 ns |   0.14 ns |   0.12 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     415.9 ns |   1.29 ns |   1.21 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     134.9 ns |   0.39 ns |   0.37 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     464.5 ns |   0.95 ns |   0.89 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     974.6 ns |   2.97 ns |   2.32 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,106.9 ns |   2.78 ns |   2.60 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     989.2 ns |   4.76 ns |   4.45 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,158.2 ns |   7.21 ns |   6.75 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   7,720.9 ns |  28.22 ns |  26.40 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  24,668.4 ns |  23.33 ns |  21.82 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 123,611.5 ns | 361.44 ns | 338.09 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 395,552.6 ns | 501.15 ns | 468.78 ns |         - |