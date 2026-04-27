| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     831.3 ns |     3.36 ns |     2.98 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,196.5 ns |     3.71 ns |     3.29 ns |     592 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     888.3 ns |     4.69 ns |     4.39 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,167.4 ns |     5.89 ns |     5.51 ns |     592 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   5,884.4 ns |    71.64 ns |    63.50 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,653.6 ns |    18.85 ns |    17.63 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,439.5 ns |    20.14 ns |    18.84 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,675.2 ns |    25.75 ns |    20.11 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  46,431.4 ns |   179.93 ns |   168.31 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,034.3 ns |    99.45 ns |    93.03 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  51,102.3 ns |   236.79 ns |   209.91 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,348.3 ns |   200.40 ns |   187.46 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 742,813.1 ns | 3,121.44 ns | 2,606.54 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 939,621.1 ns | 2,158.14 ns | 1,802.14 ns |  327952 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 818,136.6 ns | 4,710.09 ns | 3,933.14 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 946,057.0 ns | 4,722.34 ns | 3,943.36 ns |  327952 B |