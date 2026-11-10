| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     274.1 ns |     0.16 ns |     0.15 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |   1,044.7 ns |     1.81 ns |     1.51 ns |   2,533 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     307.2 ns |     0.19 ns |     0.18 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |   1,172.6 ns |     4.57 ns |     4.06 ns |   2,533 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   2,100.5 ns |     2.30 ns |     2.15 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   8,004.5 ns |    26.32 ns |    23.33 ns |   2,533 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   2,124.7 ns |     1.79 ns |     1.67 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   8,389.3 ns |    22.85 ns |    20.25 ns |   2,535 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |  16,423.3 ns |    28.98 ns |    27.11 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  61,810.8 ns |   271.69 ns |   254.14 ns |   2,533 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 258,311.5 ns |    48.73 ns |    43.20 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 994,395.2 ns | 7,309.28 ns | 6,837.10 ns |   2,533 B |         - |