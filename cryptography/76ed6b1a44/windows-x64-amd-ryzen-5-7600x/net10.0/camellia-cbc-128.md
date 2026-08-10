| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     558.5 ns |     1.58 ns |     1.32 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,000.8 ns |     4.70 ns |     4.17 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     595.3 ns |     1.70 ns |     1.33 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     988.9 ns |     4.18 ns |     3.91 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,136.4 ns |    11.15 ns |     9.89 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,567.2 ns |    22.50 ns |    21.04 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,245.5 ns |    13.97 ns |    11.66 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   6,491.1 ns |    33.41 ns |    29.62 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  31,046.8 ns |    84.39 ns |    70.47 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  51,167.1 ns |   213.12 ns |   199.36 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  32,941.2 ns |   122.10 ns |   101.96 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  50,629.8 ns |   215.24 ns |   201.34 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 524,037.7 ns | 1,927.75 ns | 1,803.22 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 816,509.8 ns | 1,865.98 ns | 1,558.17 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 525,168.9 ns | 1,186.69 ns |   926.49 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 805,274.2 ns | 3,474.21 ns | 2,712.44 ns |  327936 B |