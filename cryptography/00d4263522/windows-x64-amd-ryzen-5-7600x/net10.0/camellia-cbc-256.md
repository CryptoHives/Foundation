| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       753.0 ns |     3.20 ns |     2.99 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,237.0 ns |     7.71 ns |     7.21 ns |     592 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       800.2 ns |     4.90 ns |     4.59 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,219.9 ns |     8.03 ns |     7.51 ns |     592 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,323.1 ns |    17.07 ns |    15.97 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,288.0 ns |    45.23 ns |    42.31 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,648.3 ns |    27.55 ns |    25.77 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,199.6 ns |    71.26 ns |    66.65 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    43,059.7 ns |   295.48 ns |   276.39 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    64,923.5 ns |   545.55 ns |   510.31 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    44,640.8 ns |   221.46 ns |   207.15 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    64,147.3 ns |   310.74 ns |   275.46 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   695,064.4 ns | 3,596.69 ns | 3,364.34 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,039,033.5 ns | 7,783.71 ns | 7,280.89 ns |  327952 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   714,687.5 ns | 3,511.31 ns | 3,284.48 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,034,656.2 ns | 7,787.63 ns | 7,284.55 ns |  327952 B |