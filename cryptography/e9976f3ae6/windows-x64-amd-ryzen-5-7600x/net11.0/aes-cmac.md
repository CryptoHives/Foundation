| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     164.5 ns |     0.24 ns |     0.23 ns |     723 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     503.9 ns |     1.47 ns |     1.37 ns |   8,405 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     186.5 ns |     0.06 ns |     0.05 ns |     723 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     570.6 ns |     1.61 ns |     1.34 ns |   8,405 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,244.2 ns |     0.66 ns |     0.58 ns |     723 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,835.2 ns |    12.13 ns |    11.35 ns |   8,405 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,271.1 ns |     0.88 ns |     0.74 ns |     723 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,893.3 ns |     7.97 ns |     7.45 ns |   5,537 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   9,891.8 ns |    15.50 ns |    14.49 ns |     723 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  30,424.7 ns |   154.81 ns |   144.81 ns |   8,405 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 158,169.6 ns |   385.03 ns |   360.16 ns |     723 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 484,976.3 ns | 1,363.29 ns | 1,208.52 ns |   5,537 B |         - |