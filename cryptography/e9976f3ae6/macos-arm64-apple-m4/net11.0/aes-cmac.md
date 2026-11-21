| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     116.4 ns |   0.30 ns |   0.27 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     405.8 ns |   0.52 ns |   0.46 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     130.8 ns |   0.56 ns |   0.52 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     454.5 ns |   0.84 ns |   0.78 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     948.6 ns |   2.22 ns |   2.08 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,064.7 ns |   4.32 ns |   4.04 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     979.7 ns |   5.52 ns |   5.17 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,119.6 ns |   2.42 ns |   2.26 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   7,624.8 ns |  21.30 ns |  19.92 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  24,328.3 ns |  19.97 ns |  18.68 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 123,281.8 ns | 587.79 ns | 549.82 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 390,320.6 ns | 321.62 ns | 300.85 ns |         - |