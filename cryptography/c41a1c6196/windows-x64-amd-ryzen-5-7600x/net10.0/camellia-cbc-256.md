| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       909.3 ns |     1.19 ns |     0.99 ns |   1,289 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,417.6 ns |     4.30 ns |     3.59 ns |   2,911 B |     592 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       938.1 ns |     1.20 ns |     1.00 ns |   1,285 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,410.8 ns |     4.72 ns |     4.42 ns |   2,909 B |     592 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,559.8 ns |     9.88 ns |     8.76 ns |   1,289 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     9,540.6 ns |    26.04 ns |    23.08 ns |   2,911 B |    2832 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,674.6 ns |     7.43 ns |     6.58 ns |   1,291 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     9,467.7 ns |    31.67 ns |    29.62 ns |   2,909 B |    2832 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    51,396.6 ns |    83.81 ns |    78.39 ns |   1,289 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    81,378.9 ns |   213.42 ns |   189.19 ns |   2,911 B |   20752 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    53,820.8 ns |    65.89 ns |    58.41 ns |   1,291 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    73,856.8 ns |   256.73 ns |   227.58 ns |   2,911 B |   20752 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   811,272.0 ns | 1,114.38 ns | 1,042.39 ns |   1,289 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,191,191.4 ns | 2,987.27 ns | 2,494.51 ns |   2,911 B |  327952 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   849,852.6 ns | 1,573.11 ns | 1,394.52 ns |   1,291 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,204,455.6 ns | 3,844.21 ns | 3,407.79 ns |   2,911 B |  327952 B |