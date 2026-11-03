| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       916.1 ns |     0.98 ns |     0.87 ns |   1,289 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,426.3 ns |     3.99 ns |     3.33 ns |   2,911 B |     592 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       962.8 ns |     4.12 ns |     3.85 ns |   1,291 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,413.3 ns |     4.14 ns |     3.87 ns |   2,909 B |     592 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,448.5 ns |    15.91 ns |    14.88 ns |   1,289 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     9,601.1 ns |    34.27 ns |    32.06 ns |   2,911 B |    2832 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,692.7 ns |    20.65 ns |    17.24 ns |   1,291 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     9,506.7 ns |    13.31 ns |    11.80 ns |   2,909 B |    2832 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    51,509.7 ns |    50.93 ns |    42.53 ns |   1,289 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    75,453.7 ns |   162.26 ns |   151.78 ns |   2,911 B |   20752 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    52,122.0 ns |    76.32 ns |    71.39 ns |   1,291 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    74,199.6 ns |   266.15 ns |   248.96 ns |   2,911 B |   20752 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   812,364.6 ns |   994.40 ns |   881.51 ns |   1,283 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,197,787.3 ns | 2,745.14 ns | 2,433.50 ns |   2,911 B |  327952 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   841,346.3 ns |   910.41 ns |   760.23 ns |   1,291 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,183,540.5 ns | 4,543.81 ns | 4,250.28 ns |   2,911 B |  327952 B |