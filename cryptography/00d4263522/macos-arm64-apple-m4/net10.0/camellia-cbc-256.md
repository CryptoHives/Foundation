| Description                                     | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     853.2 ns |      9.69 ns |      9.07 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,182.8 ns |     20.79 ns |     19.44 ns |     592 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     927.9 ns |      6.83 ns |      6.39 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,175.0 ns |      1.56 ns |      1.22 ns |     592 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,046.5 ns |     61.32 ns |     57.36 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,649.3 ns |      5.55 ns |      4.33 ns |    2832 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,775.4 ns |     50.90 ns |     47.61 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,710.6 ns |     14.60 ns |     11.40 ns |    2832 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  47,752.7 ns |    466.84 ns |    436.68 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,660.5 ns |    694.21 ns |    649.36 ns |   20752 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  53,277.2 ns |    410.45 ns |    383.94 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  60,079.6 ns |    591.80 ns |    553.57 ns |   20752 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 763,147.5 ns |  7,828.57 ns |  7,322.85 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 946,625.2 ns | 10,675.04 ns |  9,985.44 ns |  327952 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 853,048.0 ns |  9,438.57 ns |  8,828.85 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 963,792.4 ns | 18,682.16 ns | 20,765.17 ns |  327952 B |