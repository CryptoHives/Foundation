| Description                                     | TestDataSize | Mean         | Error       | StdDev       | Median       | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     843.9 ns |     0.11 ns |      0.09 ns |     843.9 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,215.0 ns |     0.47 ns |      0.39 ns |   1,215.0 ns |     584 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     921.6 ns |     0.08 ns |      0.07 ns |     921.6 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,232.4 ns |     0.50 ns |      0.44 ns |   1,232.4 ns |     584 B |
|                                                 |              |              |             |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,997.3 ns |     0.50 ns |      0.44 ns |   5,997.3 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |  28,137.9 ns | 4,765.71 ns | 14,051.81 ns |  37,717.8 ns |    2824 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,694.6 ns |     0.67 ns |      0.59 ns |   6,694.6 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,991.4 ns |     3.92 ns |      3.66 ns |   7,991.4 ns |    2824 B |
|                                                 |              |              |             |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  45,880.9 ns |   125.51 ns |    117.40 ns |  45,861.5 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,766.6 ns |    51.85 ns |     48.50 ns |  59,763.9 ns |   20744 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  52,852.7 ns |     6.04 ns |      5.65 ns |  52,852.1 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  61,393.7 ns |    87.93 ns |     77.95 ns |  61,395.0 ns |   20744 B |
|                                                 |              |              |             |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 756,138.7 ns | 1,542.66 ns |  1,443.00 ns | 756,571.4 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 955,325.0 ns | 1,817.79 ns |  1,611.42 ns | 955,475.1 ns |  327944 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 844,494.4 ns |    82.96 ns |     73.54 ns | 844,496.9 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 986,235.0 ns | 4,220.74 ns |  3,741.57 ns | 985,618.8 ns |  327944 B |