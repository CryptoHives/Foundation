| Description                                     | TestDataSize | Mean           | Error        | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|------------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |       800.0 ns |      7.37 ns |     6.89 ns |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1,381.3 ns |     12.14 ns |    11.36 ns |   2,937 B |     576 B |
|                                                 |              |                |              |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |       962.9 ns |      4.16 ns |     3.89 ns |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     1,309.4 ns |      6.61 ns |     5.86 ns |   2,935 B |     576 B |
|                                                 |              |                |              |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     5,430.9 ns |     73.51 ns |    68.76 ns |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |     9,616.5 ns |    123.64 ns |   115.65 ns |   2,937 B |    2816 B |
|                                                 |              |                |              |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |     6,749.6 ns |     18.13 ns |    15.14 ns |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |     8,889.4 ns |     16.02 ns |    14.20 ns |   2,935 B |    2816 B |
|                                                 |              |                |              |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    43,144.5 ns |    433.63 ns |   405.62 ns |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    74,251.1 ns |    815.72 ns |   763.03 ns |   2,935 B |   20736 B |
|                                                 |              |                |              |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |    53,552.6 ns |    627.13 ns |   586.61 ns |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |    68,282.1 ns |    697.63 ns |   652.57 ns |   2,935 B |   20736 B |
|                                                 |              |                |              |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        |   666,355.8 ns |  1,586.86 ns | 1,406.71 ns |   1,311 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,164,096.7 ns |  3,947.38 ns | 3,499.25 ns |   2,935 B |  327936 B |
|                                                 |              |                |              |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        |   853,192.6 ns |  9,795.99 ns | 9,163.18 ns |   1,313 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 1,092,846.2 ns | 10,268.15 ns | 9,604.83 ns |   2,935 B |  327936 B |