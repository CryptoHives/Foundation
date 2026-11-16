| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     828.1 ns |     1.53 ns |     1.28 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,233.7 ns |     3.59 ns |     3.36 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     936.6 ns |     2.23 ns |     2.08 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,187.7 ns |     3.76 ns |     3.14 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,910.9 ns |     8.66 ns |     7.23 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,690.5 ns |    44.59 ns |    41.71 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,772.4 ns |    26.42 ns |    24.71 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   8,097.1 ns |    43.02 ns |    40.24 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  45,817.7 ns |   160.90 ns |   142.64 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,543.3 ns |   123.72 ns |   115.72 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  54,253.7 ns |   178.09 ns |   166.58 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  61,182.4 ns |   314.63 ns |   294.30 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 734,017.8 ns | 2,540.57 ns | 2,252.15 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 950,111.5 ns | 3,153.11 ns | 2,949.42 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 855,554.4 ns | 1,072.56 ns |   950.80 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 978,685.4 ns | 4,321.64 ns | 4,042.46 ns |  327944 B |