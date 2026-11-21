| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       915.1 ns |     3.21 ns |     2.84 ns |   3,997 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,346.7 ns |     9.45 ns |     7.89 ns |  13,887 B |     584 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       948.8 ns |     1.11 ns |     0.98 ns |   3,997 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,313.2 ns |     3.17 ns |     2.65 ns |   7,738 B |     584 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,458.9 ns |    10.32 ns |     8.06 ns |  10,332 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,903.2 ns |    43.37 ns |    40.57 ns |  13,697 B |    2824 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,658.9 ns |    10.92 ns |    10.22 ns |  10,332 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,798.3 ns |    58.69 ns |    54.90 ns |  13,887 B |    2824 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    51,272.6 ns |   252.78 ns |   236.45 ns |  10,522 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    69,824.9 ns |   522.31 ns |   436.16 ns |   7,734 B |   20744 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    52,138.8 ns |   279.84 ns |   248.07 ns |  10,332 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    68,568.2 ns |   249.68 ns |   221.33 ns |  13,693 B |   20744 B |
|                                                 |              |                |             |             |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   841,923.4 ns | 3,847.41 ns | 3,598.87 ns |  10,533 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,128,135.7 ns | 6,617.01 ns | 5,865.81 ns |  13,883 B |  327944 B |
|                                                 |              |                |             |             |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   859,783.3 ns | 3,798.68 ns | 3,367.43 ns |  10,332 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,092,425.8 ns | 6,723.24 ns | 5,959.98 ns |  13,693 B |  327944 B |