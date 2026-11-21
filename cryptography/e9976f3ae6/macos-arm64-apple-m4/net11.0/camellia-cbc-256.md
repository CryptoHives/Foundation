| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     841.2 ns |     3.93 ns |     3.28 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,134.6 ns |     6.10 ns |     5.40 ns |     592 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     944.0 ns |     2.46 ns |     2.30 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,137.3 ns |     3.76 ns |     3.51 ns |     592 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   5,958.1 ns |    16.28 ns |    13.60 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,343.2 ns |    14.76 ns |    13.81 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,831.3 ns |    13.12 ns |    12.27 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,464.0 ns |    19.41 ns |    18.16 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  46,896.5 ns |   110.33 ns |   103.21 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  57,852.7 ns |    92.90 ns |    86.90 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  53,980.6 ns |   157.72 ns |   147.53 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  58,102.9 ns |    97.61 ns |    91.30 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 750,932.4 ns | 1,388.02 ns | 1,230.45 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 908,680.5 ns | 2,205.23 ns | 1,954.88 ns |  327952 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 862,993.2 ns | 1,903.85 ns | 1,589.80 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 929,043.7 ns | 1,247.09 ns | 1,105.51 ns |  327952 B |