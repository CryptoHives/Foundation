| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     848.6 ns |     1.33 ns |     1.25 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,187.2 ns |     1.49 ns |     1.24 ns |     592 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     922.2 ns |     1.45 ns |     1.36 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |   1,170.9 ns |     2.82 ns |     2.64 ns |     592 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,013.4 ns |    15.20 ns |    14.22 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,665.7 ns |    15.83 ns |    14.81 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |   6,681.2 ns |    11.98 ns |    11.20 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |   7,758.0 ns |     8.99 ns |     7.97 ns |    2832 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  47,495.8 ns |    67.48 ns |    63.12 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,261.2 ns |   167.90 ns |   157.05 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |  52,733.1 ns |   101.65 ns |    95.08 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |  59,659.8 ns |   165.19 ns |   154.51 ns |   20752 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 759,407.6 ns | 1,752.83 ns | 1,639.60 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 942,412.9 ns | 1,820.81 ns | 1,703.19 ns |  327952 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 843,474.2 ns | 2,331.77 ns | 2,181.14 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 946,768.7 ns | 2,408.86 ns | 2,253.25 ns |  327952 B |