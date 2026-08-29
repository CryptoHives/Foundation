| Description                                     | TestDataSize | Mean           | Error         | StdDev          | Median         | Allocated |
|------------------------------------------------ |------------- |---------------:|--------------:|----------------:|---------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       840.0 ns |       7.83 ns |         6.94 ns |       841.8 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,221.4 ns |      13.91 ns |        13.02 ns |     1,225.7 ns |     592 B |
|                                                 |              |                |               |                 |                |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       923.1 ns |       0.15 ns |         0.13 ns |       923.1 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,217.0 ns |       0.74 ns |         0.61 ns |     1,217.1 ns |     592 B |
|                                                 |              |                |               |                 |                |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,933.2 ns |      15.31 ns |        14.32 ns |     5,931.1 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     7,835.4 ns |      52.58 ns |        41.05 ns |     7,819.4 ns |    2832 B |
|                                                 |              |                |               |                 |                |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     6,698.3 ns |       1.11 ns |         0.98 ns |     6,698.0 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,003.8 ns |       7.10 ns |         6.64 ns |     8,002.4 ns |    2832 B |
|                                                 |              |                |               |                 |                |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    47,249.7 ns |      47.74 ns |        42.32 ns |    47,251.2 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    59,843.9 ns |      47.49 ns |        42.10 ns |    59,841.4 ns |   20752 B |
|                                                 |              |                |               |                 |                |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    52,889.2 ns |       8.12 ns |         7.59 ns |    52,888.2 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    61,922.6 ns |     141.14 ns |       132.02 ns |    61,931.1 ns |   20752 B |
|                                                 |              |                |               |                 |                |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   753,757.5 ns |     231.39 ns |       180.66 ns |   753,747.3 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        |   961,315.0 ns |   2,992.73 ns |     2,799.40 ns |   961,478.7 ns |  327952 B |
|                                                 |              |                |               |                 |                |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   845,231.3 ns |     129.02 ns |       107.74 ns |   845,216.0 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 2,698,828.1 ns | 659,451.92 ns | 1,944,409.00 ns | 1,010,247.5 ns |  327952 B |