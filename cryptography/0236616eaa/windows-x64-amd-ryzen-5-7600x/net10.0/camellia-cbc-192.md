| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       764.2 ns |     1.45 ns |     1.29 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,260.6 ns |     2.94 ns |     2.75 ns |     584 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       814.5 ns |     0.65 ns |     0.51 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,242.5 ns |     5.02 ns |     4.20 ns |     584 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,383.7 ns |     7.95 ns |     7.05 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,405.9 ns |    13.91 ns |    10.86 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,741.1 ns |    20.45 ns |    17.08 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,288.6 ns |    11.09 ns |     9.84 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    43,486.5 ns |    59.85 ns |    49.97 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    65,839.4 ns |   221.17 ns |   206.88 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    45,077.4 ns |    45.80 ns |    38.25 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    64,800.5 ns |   173.60 ns |   153.89 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   708,351.6 ns |   738.57 ns |   616.74 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,050,073.1 ns | 2,844.68 ns | 2,521.73 ns |  327944 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   720,645.3 ns | 1,027.63 ns |   858.12 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,044,005.2 ns | 3,086.63 ns | 2,736.22 ns |  327944 B |