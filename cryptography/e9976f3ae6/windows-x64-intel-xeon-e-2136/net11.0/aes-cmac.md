| Description                                | TestDataSize | Mean         | Error        | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|-------------:|------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     275.2 ns |      0.13 ns |     0.12 ns |     729 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     977.7 ns |     14.29 ns |    13.36 ns |   5,584 B |         - |
|                                            |              |              |              |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     311.1 ns |      0.19 ns |     0.18 ns |     729 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |   1,111.3 ns |      0.83 ns |     0.65 ns |   5,584 B |         - |
|                                            |              |              |              |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   2,052.8 ns |      0.28 ns |     0.23 ns |     729 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   7,130.5 ns |     18.92 ns |    15.80 ns |   8,452 B |         - |
|                                            |              |              |              |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   2,070.0 ns |      3.85 ns |     3.41 ns |     729 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   7,282.0 ns |     32.06 ns |    26.77 ns |   5,584 B |         - |
|                                            |              |              |              |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |  16,112.7 ns |      4.95 ns |     4.63 ns |     729 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  55,939.6 ns |    112.33 ns |   105.07 ns |   8,452 B |         - |
|                                            |              |              |              |             |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 260,419.8 ns |    231.51 ns |   216.55 ns |     729 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 903,247.0 ns | 10,262.29 ns | 9,599.35 ns |   8,452 B |         - |