| Description                                     | TestDataSize | Mean         | Error        | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|-------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     680.3 ns |      3.10 ns |     2.90 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,162.7 ns |     12.82 ns |    11.99 ns |     576 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     706.6 ns |      8.11 ns |     7.59 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,149.4 ns |     13.26 ns |    12.40 ns |     576 B |
|                                                 |              |              |              |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,804.2 ns |     49.53 ns |    46.33 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   7,736.5 ns |     76.80 ns |    71.84 ns |    2816 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,981.4 ns |     48.70 ns |    45.56 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   7,678.0 ns |     84.96 ns |    79.47 ns |    2816 B |
|                                                 |              |              |              |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  37,286.5 ns |    386.60 ns |   361.62 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  60,490.1 ns |    672.85 ns |   629.39 ns |   20736 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  38,399.0 ns |    453.69 ns |   424.38 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  59,848.8 ns |    653.31 ns |   545.54 ns |   20736 B |
|                                                 |              |              |              |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 615,283.5 ns |  7,367.44 ns | 6,891.51 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 963,029.0 ns |  9,535.07 ns | 8,919.11 ns |  327936 B |
|                                                 |              |              |              |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 616,771.6 ns |  6,860.99 ns | 6,417.77 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 951,081.1 ns | 10,634.85 ns | 9,947.85 ns |  327936 B |