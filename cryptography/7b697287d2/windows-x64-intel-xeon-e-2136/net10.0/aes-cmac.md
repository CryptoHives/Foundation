| Description                                | TestDataSize | Mean         | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     208.6 ns |      3.19 ns |      2.98 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     789.2 ns |     13.87 ns |     12.98 ns |   2,533 B |         - |
|                                            |              |              |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     233.5 ns |      3.81 ns |      3.57 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     889.6 ns |     10.51 ns |      9.83 ns |   2,533 B |         - |
|                                            |              |              |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,619.3 ns |     24.43 ns |     22.85 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   6,277.5 ns |     85.44 ns |     79.92 ns |   2,533 B |         - |
|                                            |              |              |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,617.1 ns |     17.59 ns |     16.45 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   6,382.6 ns |     90.52 ns |     84.67 ns |   2,535 B |         - |
|                                            |              |              |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |  12,435.0 ns |    222.76 ns |    208.37 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  46,800.5 ns |    815.64 ns |    762.95 ns |   2,533 B |         - |
|                                            |              |              |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 196,804.1 ns |  2,757.70 ns |  2,579.55 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 747,785.8 ns | 12,496.93 ns | 11,689.63 ns |   2,533 B |         - |