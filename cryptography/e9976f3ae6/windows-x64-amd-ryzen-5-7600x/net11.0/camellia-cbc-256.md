| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       928.4 ns |     2.87 ns |     2.54 ns |  10,332 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,341.5 ns |     3.15 ns |     2.79 ns |   7,729 B |     592 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       994.4 ns |     5.85 ns |     5.47 ns |   3,997 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,316.8 ns |     6.84 ns |     6.07 ns |  13,693 B |     592 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,472.2 ns |    20.67 ns |    17.26 ns |  10,522 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    11,709.5 ns |    48.64 ns |    45.50 ns |   7,729 B |    2832 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,587.1 ns |    24.66 ns |    23.06 ns |  10,522 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     9,410.4 ns |    41.93 ns |    39.22 ns |   7,729 B |    2832 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    50,918.4 ns |   165.21 ns |   154.54 ns |   3,997 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    70,447.3 ns |   374.85 ns |   332.30 ns |  13,688 B |   20752 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    52,687.9 ns |   247.77 ns |   219.64 ns |   3,997 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    68,725.1 ns |   288.01 ns |   269.41 ns |  13,883 B |   20752 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   809,402.4 ns | 4,460.09 ns | 4,171.97 ns |   3,997 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,108,926.6 ns | 6,524.34 ns | 5,783.66 ns |  13,704 B |  327952 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   843,486.6 ns | 3,197.43 ns | 2,834.44 ns |  10,332 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,093,944.7 ns | 6,258.00 ns | 5,547.55 ns |   7,734 B |  327952 B |