| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     825.0 ns |     3.36 ns |     3.14 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,227.1 ns |     4.81 ns |     4.50 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     928.2 ns |     3.79 ns |     3.54 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,175.2 ns |     7.04 ns |     6.59 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,821.7 ns |    24.86 ns |    22.03 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,620.6 ns |    31.00 ns |    29.00 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,704.7 ns |    34.94 ns |    32.69 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,799.9 ns |    33.65 ns |    28.10 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  45,604.9 ns |   235.29 ns |   220.09 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,120.7 ns |   185.22 ns |   173.26 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  52,964.7 ns |   193.10 ns |   180.63 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  60,568.1 ns |   277.04 ns |   259.15 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 729,247.4 ns | 3,756.78 ns | 3,514.10 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 945,423.4 ns | 3,865.78 ns | 3,616.06 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 848,439.7 ns | 3,479.19 ns | 3,254.43 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 966,168.1 ns | 6,352.66 ns | 5,942.28 ns |  327944 B |