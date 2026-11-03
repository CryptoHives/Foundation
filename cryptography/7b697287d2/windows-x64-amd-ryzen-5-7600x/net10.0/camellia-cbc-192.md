| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       905.5 ns |     1.34 ns |     1.25 ns |   1,289 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,477.9 ns |     4.83 ns |     4.52 ns |   2,909 B |     584 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       954.8 ns |     1.32 ns |     1.24 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,424.1 ns |     2.80 ns |     2.48 ns |   2,909 B |     584 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,555.7 ns |    14.43 ns |    13.49 ns |   1,289 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     9,626.6 ns |    22.90 ns |    21.42 ns |   2,911 B |    2824 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,685.8 ns |    10.80 ns |    10.11 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     9,472.9 ns |    20.64 ns |    18.29 ns |   2,909 B |    2824 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    51,553.5 ns |    67.53 ns |    63.17 ns |   1,289 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    75,104.5 ns |   296.63 ns |   277.47 ns |   2,911 B |   20744 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    52,025.8 ns |    60.58 ns |    53.70 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    74,275.1 ns |   242.05 ns |   202.12 ns |   2,911 B |   20744 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   809,260.2 ns | 1,742.67 ns | 1,630.10 ns |   1,283 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,197,811.0 ns | 2,941.87 ns | 2,751.83 ns |   2,911 B |  327944 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   838,164.2 ns | 1,883.74 ns | 1,762.05 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,182,673.6 ns | 3,095.28 ns | 2,743.88 ns |   2,911 B |  327944 B |