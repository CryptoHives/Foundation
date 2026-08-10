| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       803.7 ns |     1.43 ns |     1.34 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,429.4 ns |     7.20 ns |     6.73 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       421.6 ns |     0.08 ns |     0.07 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,268.4 ns |     0.52 ns |     0.49 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,697.5 ns |     5.95 ns |     5.57 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,465.9 ns |    35.25 ns |    32.97 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,930.0 ns |     6.16 ns |     5.76 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,164.7 ns |     7.95 ns |     7.05 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,788.7 ns |   145.69 ns |   136.28 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   119,738.3 ns |   128.37 ns |   120.08 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    23,055.0 ns |    30.97 ns |    28.97 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    54,269.3 ns |    29.85 ns |    26.46 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   716,851.2 ns | 1,602.47 ns | 1,498.95 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,908,913.6 ns | 2,161.46 ns | 2,021.83 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   372,960.8 ns | 5,181.72 ns | 4,846.99 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   866,411.2 ns | 3,158.04 ns | 2,954.03 ns |     872 B |