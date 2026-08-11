| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     151.9 ns |     0.43 ns |     0.38 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     483.5 ns |     3.09 ns |     2.58 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     166.8 ns |     0.26 ns |     0.23 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     540.9 ns |     1.55 ns |     1.38 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,102.8 ns |     1.60 ns |     1.33 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,672.3 ns |    20.44 ns |    19.12 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,116.0 ns |     2.22 ns |     2.08 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,714.9 ns |     7.96 ns |     7.05 ns |   2,365 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   8,664.0 ns |     8.93 ns |     7.91 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  29,223.8 ns |   113.03 ns |   105.73 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 137,692.7 ns |   350.48 ns |   327.84 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 463,943.6 ns | 1,469.71 ns | 1,302.86 ns |   2,363 B |         - |