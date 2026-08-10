| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       933.8 ns |     1.32 ns |     1.17 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,461.0 ns |     6.82 ns |     6.04 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       407.2 ns |     0.61 ns |     0.54 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,374.2 ns |     3.91 ns |     3.26 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     6,635.1 ns |     5.87 ns |     5.49 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    14,855.9 ns |    22.05 ns |    19.54 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,821.9 ns |     6.11 ns |     5.10 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,208.9 ns |     9.57 ns |     7.99 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    52,478.9 ns |    71.54 ns |    55.85 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   113,068.6 ns |   221.71 ns |   196.54 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    22,032.9 ns |    17.96 ns |    15.00 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,799.7 ns |   103.36 ns |    91.62 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   835,971.6 ns | 1,014.67 ns |   847.29 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,801,318.7 ns | 3,535.37 ns | 2,952.19 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   353,480.4 ns |   452.41 ns |   401.05 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   851,175.7 ns | 1,023.60 ns |   907.40 ns |     872 B |