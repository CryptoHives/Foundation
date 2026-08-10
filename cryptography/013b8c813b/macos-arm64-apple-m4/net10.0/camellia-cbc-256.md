| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     833.3 ns |     2.83 ns |     2.65 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,188.1 ns |     2.76 ns |     2.58 ns |     592 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     903.6 ns |     2.55 ns |     2.38 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,158.2 ns |     2.28 ns |     2.13 ns |     592 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   5,905.3 ns |    22.22 ns |    20.79 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,601.3 ns |     9.86 ns |     9.22 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,545.6 ns |    14.52 ns |    13.58 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,915.2 ns |    23.18 ns |    20.55 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  46,525.0 ns |   200.57 ns |   187.61 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  58,538.1 ns |    85.47 ns |    79.94 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  51,691.6 ns |   136.98 ns |   128.13 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,110.0 ns |    75.57 ns |    70.69 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 746,317.2 ns | 2,124.71 ns | 1,883.50 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 960,280.5 ns | 1,479.53 ns | 1,383.95 ns |  327952 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 827,393.4 ns | 2,260.21 ns | 2,114.20 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 938,050.4 ns | 3,219.61 ns | 3,011.63 ns |  327952 B |