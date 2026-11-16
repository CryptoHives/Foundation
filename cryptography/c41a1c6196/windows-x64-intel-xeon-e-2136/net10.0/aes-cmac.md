| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |       274.2 ns |      0.16 ns |      0.15 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     1,060.4 ns |     16.41 ns |     15.35 ns |   2,533 B |         - |
|                                            |              |                |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |       307.2 ns |      0.29 ns |      0.27 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     1,186.0 ns |     13.96 ns |     13.06 ns |   2,533 B |         - |
|                                            |              |                |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |     2,098.5 ns |      1.83 ns |      1.53 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |     8,055.8 ns |     98.03 ns |     86.91 ns |   2,533 B |         - |
|                                            |              |                |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |     2,127.7 ns |      3.65 ns |      3.41 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |     8,429.5 ns |     60.51 ns |     50.53 ns |   2,535 B |         - |
|                                            |              |                |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |    16,374.3 ns |     10.62 ns |      9.93 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |    62,738.2 ns |    717.40 ns |    671.06 ns |   2,533 B |         - |
|                                            |              |                |              |              |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        |   258,154.0 ns |     89.95 ns |     70.23 ns |     623 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 1,002,787.9 ns | 19,483.93 ns | 19,135.83 ns |   2,533 B |         - |