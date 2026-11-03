| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     106.2 ns |     0.44 ns |     0.41 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     413.8 ns |     1.21 ns |     1.13 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     118.8 ns |     0.55 ns |     0.51 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     465.5 ns |     1.75 ns |     1.64 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     877.8 ns |     8.02 ns |     7.50 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,117.9 ns |     6.02 ns |     5.63 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     891.3 ns |     6.98 ns |     6.53 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,158.9 ns |    11.68 ns |    10.93 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   6,846.2 ns |    30.35 ns |    26.90 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  24,580.4 ns |    87.99 ns |    82.30 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 112,365.9 ns |   518.88 ns |   485.36 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 393,500.4 ns | 1,255.49 ns | 1,174.38 ns |         - |