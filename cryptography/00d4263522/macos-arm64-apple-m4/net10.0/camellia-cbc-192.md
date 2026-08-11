| Description                                     | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     852.1 ns |      7.98 ns |      7.47 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,171.3 ns |      1.51 ns |      1.18 ns |     584 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     928.0 ns |      6.46 ns |      6.05 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |   1,184.0 ns |     19.46 ns |     18.20 ns |     584 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,046.7 ns |     58.57 ns |     54.79 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,632.1 ns |      6.52 ns |      5.09 ns |    2824 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |   6,763.8 ns |     70.54 ns |     65.98 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |   7,752.9 ns |     32.14 ns |     25.09 ns |    2824 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  47,776.3 ns |    455.90 ns |    426.45 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,349.8 ns |    672.21 ns |    628.79 ns |   20744 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |  53,259.7 ns |    427.10 ns |    399.51 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |  59,517.5 ns |    165.93 ns |    129.55 ns |   20744 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 766,472.2 ns |  7,635.54 ns |  7,142.28 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 946,367.9 ns |  9,410.58 ns |  8,802.66 ns |  327944 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 851,358.7 ns |  6,233.04 ns |  5,830.39 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 956,373.3 ns | 11,646.55 ns | 10,894.19 ns |  327944 B |