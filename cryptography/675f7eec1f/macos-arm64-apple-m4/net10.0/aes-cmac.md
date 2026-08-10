| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     120.2 ns |   0.13 ns |   0.12 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     415.4 ns |   0.89 ns |   0.83 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     135.0 ns |   0.15 ns |   0.14 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     464.4 ns |   1.44 ns |   1.28 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     987.2 ns |   4.84 ns |   4.53 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,110.4 ns |   2.20 ns |   1.95 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     998.0 ns |   2.80 ns |   2.62 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,162.4 ns |   1.28 ns |   1.13 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   7,765.2 ns |  72.70 ns |  68.00 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  24,712.5 ns |  18.61 ns |  17.41 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 125,650.9 ns | 298.40 ns | 279.12 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 395,022.3 ns | 957.52 ns | 895.66 ns |         - |