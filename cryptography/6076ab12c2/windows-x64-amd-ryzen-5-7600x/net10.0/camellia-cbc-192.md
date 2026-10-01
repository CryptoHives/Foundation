| Description                                     | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       903.2 ns |      9.46 ns |      8.85 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,440.2 ns |     17.33 ns |     16.21 ns |     584 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       947.0 ns |     10.06 ns |      9.41 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,430.5 ns |     18.92 ns |     17.70 ns |     584 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,393.0 ns |     44.96 ns |     42.05 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     9,642.7 ns |     98.50 ns |     92.14 ns |    2824 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,647.3 ns |     74.18 ns |     69.39 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     9,580.0 ns |     99.79 ns |     93.35 ns |    2824 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    51,252.9 ns |    352.18 ns |    312.20 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    76,449.9 ns |    623.98 ns |    583.68 ns |   20744 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    52,493.1 ns |    636.41 ns |    595.30 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    74,365.5 ns |    932.21 ns |    871.99 ns |   20744 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   822,321.0 ns |  6,796.48 ns |  6,357.43 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,205,873.1 ns | 11,657.58 ns | 10,904.51 ns |  327944 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   833,979.0 ns |  3,556.08 ns |  3,326.36 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,189,394.8 ns | 10,325.06 ns |  9,658.07 ns |  327944 B |