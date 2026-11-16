| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       925.1 ns |     0.74 ns |     0.65 ns |   1,289 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,428.1 ns |     4.40 ns |     3.90 ns |   2,911 B |     584 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       947.8 ns |     1.14 ns |     1.01 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,423.5 ns |     3.42 ns |     3.20 ns |   2,907 B |     584 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,474.0 ns |    12.62 ns |    11.80 ns |   1,289 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     9,810.0 ns |    19.99 ns |    17.72 ns |   2,911 B |    2824 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,571.5 ns |    11.92 ns |     9.95 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     9,444.1 ns |    27.77 ns |    24.62 ns |   2,909 B |    2824 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    50,688.0 ns |    86.31 ns |    72.08 ns |   1,289 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    76,854.2 ns |   329.80 ns |   308.50 ns |   2,911 B |   20744 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    51,651.0 ns |    85.46 ns |    75.76 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    73,986.4 ns |   171.08 ns |   151.65 ns |   2,911 B |   20744 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   813,437.2 ns | 1,577.04 ns | 1,475.16 ns |   1,283 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,193,543.9 ns | 4,243.16 ns | 3,969.05 ns |   2,911 B |  327944 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   843,568.7 ns | 1,082.93 ns |   959.98 ns |   1,291 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,182,158.0 ns | 6,964.67 ns | 6,514.76 ns |   2,911 B |  327944 B |