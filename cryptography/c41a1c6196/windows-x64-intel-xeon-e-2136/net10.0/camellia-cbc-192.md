| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.338 μs | 0.0028 μs | 0.0025 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     2.345 μs | 0.0044 μs | 0.0041 μs |   2,935 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.627 μs | 0.0011 μs | 0.0009 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     2.183 μs | 0.0261 μs | 0.0231 μs |   2,933 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     9.318 μs | 0.0069 μs | 0.0064 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    15.587 μs | 0.0300 μs | 0.0266 μs |   2,933 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |    11.492 μs | 0.0047 μs | 0.0044 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    14.423 μs | 0.1135 μs | 0.1062 μs |   2,931 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    73.109 μs | 0.0339 μs | 0.0317 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   117.634 μs | 0.2326 μs | 0.2062 μs |   2,935 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    89.575 μs | 0.0136 μs | 0.0120 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   111.571 μs | 0.3155 μs | 0.2634 μs |   2,935 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,172.152 μs | 1.5172 μs | 1.4192 μs |   1,311 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,970.223 μs | 4.7896 μs | 3.7394 μs |   2,935 B |  327944 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,429.230 μs | 0.5772 μs | 0.4819 μs |   1,313 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,786.581 μs | 5.9718 μs | 5.5860 μs |   2,935 B |  327944 B |