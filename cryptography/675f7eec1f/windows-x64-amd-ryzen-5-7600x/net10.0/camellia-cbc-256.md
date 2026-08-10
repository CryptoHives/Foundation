| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       783.6 ns |     2.53 ns |     2.36 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,262.4 ns |     6.13 ns |     5.12 ns |     592 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       806.5 ns |     5.10 ns |     4.78 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,266.0 ns |     6.75 ns |     5.99 ns |     592 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,390.9 ns |    26.34 ns |    24.64 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,359.8 ns |    27.41 ns |    21.40 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,718.3 ns |    48.53 ns |    40.52 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,289.1 ns |    55.11 ns |    51.55 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    43,461.3 ns |   183.16 ns |   162.36 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    65,470.7 ns |   440.37 ns |   411.92 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    44,986.4 ns |   234.10 ns |   218.97 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    64,500.5 ns |   365.08 ns |   341.50 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   696,082.4 ns | 2,132.11 ns | 1,890.06 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,044,034.8 ns | 8,025.66 ns | 7,114.54 ns |  327952 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   717,694.9 ns | 3,087.83 ns | 2,888.35 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,055,022.0 ns | 4,332.22 ns | 4,052.36 ns |  327952 B |