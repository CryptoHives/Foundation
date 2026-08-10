| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       758.5 ns |     1.79 ns |     1.59 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,268.5 ns |     2.45 ns |     2.04 ns |     584 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       808.4 ns |     0.81 ns |     0.75 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,282.7 ns |     2.89 ns |     2.56 ns |     584 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,352.3 ns |     7.59 ns |     7.10 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,412.4 ns |    21.29 ns |    18.88 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,725.2 ns |     7.40 ns |     6.18 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,351.4 ns |    18.38 ns |    14.35 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    43,519.3 ns |    49.45 ns |    41.29 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    66,162.4 ns |   193.25 ns |   171.31 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    44,857.7 ns |   108.45 ns |    96.14 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    64,805.5 ns |   112.44 ns |    93.90 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   694,642.8 ns |   632.74 ns |   528.37 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,046,581.9 ns | 2,689.40 ns | 2,384.09 ns |  327944 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   737,230.3 ns |   761.65 ns |   675.18 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,033,221.8 ns | 1,307.44 ns | 1,020.76 ns |  327944 B |