| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     170.3 ns |   0.22 ns |   0.20 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     557.1 ns |   1.42 ns |   1.19 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     259.0 ns |   0.27 ns |   0.25 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     601.5 ns |   2.05 ns |   1.71 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,272.7 ns |   0.95 ns |   0.84 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   4,057.0 ns |  10.83 ns |   9.04 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,314.0 ns |   1.08 ns |   0.96 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   4,125.7 ns |   7.09 ns |   5.92 ns |   2,511 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |  10,043.4 ns |  10.24 ns |   9.58 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  32,219.0 ns |  58.51 ns |  48.86 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 162,174.8 ns | 184.06 ns | 172.17 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 516,021.6 ns | 953.89 ns | 796.54 ns |   2,509 B |         - |