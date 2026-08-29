| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     845.4 ns |     7.33 ns |     6.49 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,203.3 ns |     2.78 ns |     2.60 ns |     584 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |   4,353.1 ns |     1.97 ns |     1.64 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   5,724.2 ns |     3.11 ns |     2.75 ns |     584 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   5,963.8 ns |     8.25 ns |     7.72 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,752.6 ns |     5.83 ns |     5.46 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |  31,611.3 ns |     9.03 ns |     7.54 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |  37,526.1 ns |    39.10 ns |    36.58 ns |    2824 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  47,494.2 ns |    19.38 ns |    17.18 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,784.8 ns |    62.60 ns |    55.49 ns |   20744 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  62,307.2 ns |   461.10 ns |   431.31 ns |   20744 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          | 249,927.7 ns |   514.72 ns |   456.29 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 753,887.3 ns |   566.57 ns |   529.97 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 955,969.5 ns | 2,101.83 ns | 1,863.22 ns |  327944 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 844,880.7 ns |   237.67 ns |   222.32 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 990,510.9 ns | 5,766.32 ns | 5,393.82 ns |  327944 B |