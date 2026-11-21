| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       800.3 ns |     3.45 ns |     3.23 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,416.3 ns |     7.22 ns |     6.75 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       408.6 ns |     0.83 ns |     0.74 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,254.4 ns |     3.47 ns |     3.24 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,680.3 ns |    32.90 ns |    30.77 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,405.4 ns |    76.03 ns |    71.12 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,892.6 ns |     9.88 ns |     8.76 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,164.8 ns |    28.09 ns |    26.28 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,709.5 ns |   150.10 ns |   140.41 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   119,377.5 ns |   318.12 ns |   297.57 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    22,903.6 ns |    61.79 ns |    54.78 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    54,379.4 ns |   215.44 ns |   201.53 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   716,511.2 ns | 2,433.59 ns | 2,276.38 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,904,091.8 ns | 5,021.44 ns | 4,697.06 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   369,668.2 ns | 1,271.48 ns | 1,189.35 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   857,834.8 ns | 2,369.65 ns | 2,100.63 ns |     872 B |