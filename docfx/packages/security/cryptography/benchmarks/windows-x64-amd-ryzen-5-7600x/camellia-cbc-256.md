| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       750.5 ns |     2.23 ns |     2.08 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,233.7 ns |     7.38 ns |     6.90 ns |     592 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       804.1 ns |     2.59 ns |     2.29 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,222.7 ns |     4.23 ns |     3.53 ns |     592 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,308.2 ns |    21.39 ns |    17.86 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,187.9 ns |    49.43 ns |    43.82 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,605.6 ns |    22.87 ns |    20.27 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,087.9 ns |    34.91 ns |    27.25 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    42,935.1 ns |   128.89 ns |   114.26 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    64,006.4 ns |   404.48 ns |   358.56 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    44,244.8 ns |   176.47 ns |   156.43 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    63,254.9 ns |   255.71 ns |   226.68 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   708,096.8 ns | 1,033.36 ns |   862.91 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,023,024.3 ns | 5,659.55 ns | 5,293.95 ns |  327952 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   718,076.9 ns | 1,384.94 ns | 1,227.71 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,016,476.3 ns | 6,341.07 ns | 5,931.44 ns |  327952 B |