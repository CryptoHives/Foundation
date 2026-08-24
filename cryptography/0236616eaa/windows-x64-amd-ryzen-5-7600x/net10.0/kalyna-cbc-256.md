| Description                                   | TestDataSize | Mean           | Error        | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,263.4 ns |      2.41 ns |     2.14 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,287.4 ns |      8.01 ns |     6.25 ns |    1112 B |
|                                               |              |                |              |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       552.8 ns |      1.36 ns |     1.20 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,747.7 ns |      3.26 ns |     2.89 ns |    1112 B |
|                                               |              |                |              |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,999.3 ns |     10.05 ns |     8.39 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    20,070.0 ns |     32.14 ns |    26.84 ns |    1112 B |
|                                               |              |                |              |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     3,896.3 ns |      7.81 ns |     6.52 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,579.0 ns |     12.59 ns |    11.16 ns |    1112 B |
|                                               |              |                |              |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    70,884.8 ns |     98.44 ns |    76.86 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   154,478.2 ns |    396.93 ns |   371.29 ns |    1112 B |
|                                               |              |                |              |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    30,607.6 ns |     20.32 ns |    16.97 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    71,855.2 ns |    198.23 ns |   165.53 ns |    1112 B |
|                                               |              |                |              |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,131,591.9 ns |  1,675.59 ns | 1,399.19 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,457,374.5 ns | 11,366.23 ns | 9,491.32 ns |    1112 B |
|                                               |              |                |              |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   489,014.1 ns |    396.12 ns |   351.15 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,140,495.5 ns |  1,877.64 ns | 1,567.91 ns |    1112 B |