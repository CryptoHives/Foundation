| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     119.2 ns |     0.05 ns |     0.04 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     412.3 ns |     0.26 ns |     0.23 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     134.0 ns |     0.13 ns |     0.11 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     466.1 ns |     4.21 ns |     3.52 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     968.3 ns |     3.89 ns |     3.45 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   3,104.3 ns |     1.23 ns |     0.96 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     991.9 ns |     4.33 ns |     4.05 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   3,145.7 ns |     2.03 ns |     1.90 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |   7,950.8 ns |    78.01 ns |    60.90 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  24,527.7 ns |    22.63 ns |    18.89 ns |         - |
|                                            |              |              |             |             |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 123,681.5 ns |   456.00 ns |   426.54 ns |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 393,732.8 ns | 1,727.62 ns | 1,442.64 ns |         - |