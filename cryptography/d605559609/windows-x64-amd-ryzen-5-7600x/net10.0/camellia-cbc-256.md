| Description                                     | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       768.0 ns |      2.26 ns |      2.11 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,250.6 ns |      7.38 ns |      6.90 ns |     592 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       819.2 ns |      3.26 ns |      2.72 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,246.4 ns |      9.51 ns |      7.94 ns |     592 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,533.3 ns |     17.30 ns |     13.50 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,440.7 ns |     41.56 ns |     38.87 ns |    2832 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,796.4 ns |     27.46 ns |     25.68 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    10,797.8 ns |     64.47 ns |     50.34 ns |    2832 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    44,437.5 ns |    111.38 ns |    104.19 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    66,102.5 ns |    435.21 ns |    385.80 ns |   20752 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    44,764.4 ns |    270.34 ns |    225.75 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    64,963.0 ns |    529.18 ns |    469.10 ns |   20752 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   703,429.4 ns |  9,941.12 ns |  7,761.37 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,050,886.9 ns | 15,732.84 ns | 13,946.76 ns |  327952 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   714,469.4 ns |  2,810.36 ns |  2,628.82 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,033,812.6 ns | 10,268.36 ns |  8,574.55 ns |  327952 B |