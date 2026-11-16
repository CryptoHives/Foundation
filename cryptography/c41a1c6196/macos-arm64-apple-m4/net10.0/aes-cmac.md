| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     106.1 ns |   0.11 ns |   0.10 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     416.1 ns |   0.39 ns |   0.36 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     124.4 ns |   1.66 ns |   1.56 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     466.4 ns |   0.40 ns |   0.38 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     931.2 ns |   3.34 ns |   3.12 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,120.5 ns |   2.21 ns |   1.96 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     942.2 ns |   2.03 ns |   1.90 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,182.0 ns |   2.30 ns |   2.15 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   7,100.8 ns |   6.68 ns |   5.22 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  24,667.2 ns |  23.13 ns |  21.64 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 117,038.4 ns | 235.78 ns | 209.01 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 395,623.8 ns | 168.77 ns | 149.61 ns |         - |