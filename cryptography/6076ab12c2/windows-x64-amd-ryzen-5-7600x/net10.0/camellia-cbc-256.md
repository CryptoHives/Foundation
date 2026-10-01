| Description                                     | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       908.2 ns |      9.11 ns |      8.52 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,430.5 ns |     16.45 ns |     15.39 ns |     592 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       952.5 ns |      8.38 ns |      7.84 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,421.9 ns |     10.55 ns |      9.36 ns |     592 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,343.6 ns |     48.84 ns |     45.68 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     9,691.6 ns |     88.41 ns |     82.70 ns |    2832 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,612.2 ns |     33.44 ns |     29.64 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     9,703.3 ns |     73.47 ns |     68.73 ns |    2832 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    50,973.6 ns |    310.77 ns |    242.63 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    75,583.4 ns |    308.77 ns |    257.84 ns |   20752 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    51,871.1 ns |    417.31 ns |    390.35 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    76,977.2 ns |    688.59 ns |    644.11 ns |   20752 B |
|                                                 |              |                |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   828,108.3 ns |  7,756.93 ns |  7,255.84 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,203,472.1 ns | 11,081.76 ns | 10,365.89 ns |  327952 B |
|                                                 |              |                |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   833,669.2 ns |  8,160.15 ns |  7,633.01 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,191,186.7 ns |  7,790.26 ns |  7,287.02 ns |  327952 B |