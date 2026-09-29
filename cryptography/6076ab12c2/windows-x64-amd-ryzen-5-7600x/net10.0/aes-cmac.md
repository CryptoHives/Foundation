| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128B         |     164.1 ns |   0.14 ns |   0.13 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128B         |     535.1 ns |   0.59 ns |   0.52 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 137B         |     186.7 ns |   0.14 ns |   0.13 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 137B         |     598.5 ns |   0.55 ns |   0.51 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1KB          |   1,259.2 ns |   0.95 ns |   0.89 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1KB          |   4,046.2 ns |   3.90 ns |   3.25 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 1025B        |   1,279.4 ns |   0.96 ns |   0.85 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 1025B        |   4,118.1 ns |  14.05 ns |  13.15 ns |   2,511 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 8KB          |  10,048.7 ns |   8.62 ns |   7.20 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 8KB          |  32,139.1 ns |  31.30 ns |  29.28 ns |   2,509 B |         - |
|                                            |              |              |           |           |           |           |
| ComputeMac · AES-CMAC · CryptoHives-Scalar | 128KB        | 162,618.9 ns | 208.62 ns | 195.15 ns |     617 B |         - |
| ComputeMac · AES-CMAC · BouncyCastle       | 128KB        | 513,966.5 ns | 640.85 ns | 599.45 ns |   2,509 B |         - |