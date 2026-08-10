| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     148.5 ns |     2.93 ns |     3.26 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     498.6 ns |     9.72 ns |    10.40 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     163.1 ns |     2.28 ns |     2.13 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     539.5 ns |     7.91 ns |     7.01 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,100.6 ns |    20.96 ns |    19.61 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,668.2 ns |    48.82 ns |    45.67 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,099.5 ns |    10.57 ns |     8.82 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,715.1 ns |    41.72 ns |    34.84 ns |   2,365 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   8,582.2 ns |    98.88 ns |    87.66 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  29,938.1 ns |   586.71 ns |   720.54 ns |   2,363 B |         - |
|                                            |              |              |             |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 136,731.5 ns | 1,551.08 ns | 1,374.99 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 465,143.7 ns | 5,563.64 ns | 5,204.24 ns |   2,363 B |         - |