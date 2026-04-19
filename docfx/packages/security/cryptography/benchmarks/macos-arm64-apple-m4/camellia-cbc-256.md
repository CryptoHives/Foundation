| Description                                     | TestDataSize | Mean         | Error        | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|-------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     833.7 ns |      3.17 ns |     2.64 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,197.1 ns |      3.20 ns |     2.50 ns |     592 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     919.9 ns |     10.67 ns |     9.45 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,186.3 ns |     23.06 ns |    20.44 ns |     592 B |
|                                                 |              |              |              |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   5,980.4 ns |     72.86 ns |    68.15 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,673.4 ns |     45.26 ns |    37.80 ns |    2832 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,615.0 ns |     34.80 ns |    27.17 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,722.3 ns |     10.67 ns |     8.33 ns |    2832 B |
|                                                 |              |              |              |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  46,472.1 ns |    134.30 ns |   112.15 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  58,895.8 ns |    107.64 ns |    95.42 ns |   20752 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  51,871.9 ns |    225.46 ns |   188.27 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,646.4 ns |    193.08 ns |   171.16 ns |   20752 B |
|                                                 |              |              |              |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 743,947.6 ns |  2,307.12 ns | 2,158.08 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 947,592.7 ns | 11,232.16 ns | 9,957.02 ns |  327952 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 827,772.7 ns |  2,624.53 ns | 2,326.58 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 945,784.0 ns |  1,517.25 ns | 1,345.00 ns |  327952 B |