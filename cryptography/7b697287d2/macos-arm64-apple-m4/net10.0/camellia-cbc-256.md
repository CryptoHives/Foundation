| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     818.2 ns |     2.37 ns |     2.22 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,191.7 ns |     5.06 ns |     4.74 ns |     592 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     979.5 ns |     3.87 ns |     3.62 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,175.4 ns |     7.72 ns |     7.22 ns |     592 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   5,790.9 ns |    22.73 ns |    21.26 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,681.0 ns |    23.54 ns |    22.02 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,709.3 ns |    20.66 ns |    19.32 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,796.0 ns |    47.69 ns |    44.61 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  45,404.0 ns |   142.53 ns |   126.35 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,158.6 ns |   107.26 ns |   100.33 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  52,878.9 ns |   166.90 ns |   147.95 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  60,409.4 ns |   160.14 ns |   141.96 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 724,941.7 ns | 2,546.34 ns | 2,381.84 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 943,220.5 ns | 3,660.27 ns | 3,423.82 ns |  327952 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 846,950.3 ns | 2,837.35 ns | 2,654.06 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 966,643.1 ns | 2,959.11 ns | 2,767.96 ns |  327952 B |