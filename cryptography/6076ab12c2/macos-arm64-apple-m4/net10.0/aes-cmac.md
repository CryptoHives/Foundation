| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     108.5 ns |   0.26 ns |   0.25 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     420.8 ns |   0.24 ns |   0.21 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     122.7 ns |   0.10 ns |   0.09 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     469.6 ns |   0.24 ns |   0.22 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     928.3 ns |   3.09 ns |   2.89 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,147.6 ns |   0.70 ns |   0.62 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     913.2 ns |  12.75 ns |  11.93 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,203.8 ns |   0.48 ns |   0.45 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   7,459.3 ns |  84.91 ns |  75.27 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  24,947.1 ns |  20.40 ns |  19.08 ns |         - |
|                                            |              |              |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 113,588.3 ns | 176.92 ns | 156.83 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 399,605.2 ns | 123.38 ns | 109.37 ns |         - |