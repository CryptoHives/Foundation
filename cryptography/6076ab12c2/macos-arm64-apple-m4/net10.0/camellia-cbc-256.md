| Description                                     | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     842.0 ns |      0.75 ns |      0.66 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,228.1 ns |      0.85 ns |      0.71 ns |     592 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     938.0 ns |      0.29 ns |      0.24 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,196.6 ns |      0.51 ns |      0.48 ns |     592 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   5,969.2 ns |      3.10 ns |      2.75 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,813.5 ns |      6.38 ns |      5.33 ns |    2832 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,698.7 ns |      1.53 ns |      1.28 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,962.5 ns |      3.56 ns |      3.16 ns |    2832 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  47,023.7 ns |     49.24 ns |     43.65 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  60,153.1 ns |     40.74 ns |     36.11 ns |   20752 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  52,848.0 ns |     40.88 ns |     34.14 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  61,542.2 ns |    138.38 ns |    115.55 ns |   20752 B |
|                                                 |              |              |              |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 749,601.6 ns |  1,093.88 ns |    913.44 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 976,387.7 ns |  1,870.19 ns |  1,561.69 ns |  327952 B |
|                                                 |              |              |              |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 850,034.8 ns | 10,916.49 ns | 15,656.10 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 986,656.8 ns |  3,927.18 ns |  3,673.49 ns |  327952 B |