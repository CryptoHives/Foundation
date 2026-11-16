| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       834.5 ns |     2.37 ns |     2.22 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,229.9 ns |     5.57 ns |     5.21 ns |     592 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       935.6 ns |     3.30 ns |     3.09 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,191.6 ns |     4.61 ns |     4.32 ns |     592 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,861.1 ns |    12.00 ns |    10.02 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     7,691.4 ns |    47.19 ns |    44.15 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,773.1 ns |    11.90 ns |     9.93 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,126.5 ns |    34.84 ns |    32.59 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    45,865.7 ns |   166.32 ns |   155.57 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    59,857.0 ns |   235.62 ns |   208.87 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    53,453.0 ns |   136.11 ns |   127.32 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    60,792.7 ns |   375.63 ns |   351.37 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   738,902.8 ns | 2,594.43 ns | 2,426.83 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        |   950,481.0 ns | 3,358.78 ns | 3,141.81 ns |  327952 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   855,093.4 ns | 1,642.79 ns | 1,456.29 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,011,837.7 ns | 6,788.79 ns | 6,350.24 ns |  327952 B |