| Description                                     | TestDataSize | Mean           | Error         | StdDev          | Median       | Allocated |
|------------------------------------------------ |------------- |---------------:|--------------:|----------------:|-------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       844.0 ns |       0.22 ns |         0.17 ns |     844.0 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,210.2 ns |       0.42 ns |         0.37 ns |   1,210.2 ns |     592 B |
|                                                 |              |                |               |                 |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       921.4 ns |       0.22 ns |         0.20 ns |     921.5 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,212.7 ns |       0.60 ns |         0.50 ns |   1,212.6 ns |     592 B |
|                                                 |              |                |               |                 |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,994.8 ns |       1.09 ns |         0.97 ns |   5,994.6 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     7,791.0 ns |      19.25 ns |        15.03 ns |   7,787.9 ns |    2832 B |
|                                                 |              |                |               |                 |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,688.7 ns |       1.58 ns |         1.40 ns |   6,688.4 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,004.4 ns |       7.20 ns |         6.02 ns |   8,005.6 ns |    2832 B |
|                                                 |              |                |               |                 |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    47,378.5 ns |      25.84 ns |        22.91 ns |  47,375.0 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    59,944.2 ns |      31.71 ns |        28.11 ns |  59,938.5 ns |   20752 B |
|                                                 |              |                |               |                 |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    52,822.3 ns |       8.70 ns |         6.79 ns |  52,823.3 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    61,256.2 ns |     113.31 ns |       105.99 ns |  61,294.7 ns |   20752 B |
|                                                 |              |                |               |                 |              |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   759,884.7 ns |     612.72 ns |       511.65 ns | 759,694.3 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 2,299,477.8 ns | 579,261.67 ns | 1,707,966.22 ns | 969,139.2 ns |  327952 B |
|                                                 |              |                |               |                 |              |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   844,184.4 ns |     105.29 ns |        93.34 ns | 844,157.2 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        |   984,076.2 ns |   3,246.55 ns |     2,877.98 ns | 983,486.4 ns |  327952 B |