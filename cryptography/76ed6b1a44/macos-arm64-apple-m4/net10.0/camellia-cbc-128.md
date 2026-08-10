| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     583.4 ns |     2.61 ns |     2.44 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     900.0 ns |     3.16 ns |     2.96 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     635.4 ns |     3.71 ns |     3.47 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     892.1 ns |     2.70 ns |     2.52 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,109.9 ns |    20.70 ns |    19.36 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,837.9 ns |    17.67 ns |    16.53 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,670.0 ns |    14.73 ns |    13.78 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,871.9 ns |    20.41 ns |    19.09 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  32,465.9 ns |   140.94 ns |   131.84 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,009.8 ns |   137.31 ns |   128.44 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  37,064.0 ns |   164.05 ns |   153.45 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,261.6 ns |   154.66 ns |   144.67 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 521,839.9 ns | 2,451.14 ns | 2,292.80 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 728,615.9 ns | 2,845.84 ns | 2,662.00 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 595,950.4 ns | 2,549.53 ns | 2,384.83 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 718,452.6 ns | 2,779.84 ns | 2,321.29 ns |  327936 B |