| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       939.0 ns |     1.51 ns |     1.34 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,395.8 ns |     4.48 ns |     3.74 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       408.9 ns |     0.61 ns |     0.54 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,349.4 ns |     4.88 ns |     4.33 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     6,662.2 ns |    36.52 ns |    32.38 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    14,743.5 ns |    17.95 ns |    16.79 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,889.3 ns |     3.30 ns |     2.76 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,221.0 ns |    15.19 ns |    14.21 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    52,205.6 ns |    96.48 ns |    85.53 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   113,368.8 ns |   211.22 ns |   176.38 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    22,104.5 ns |    77.35 ns |    68.57 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,885.1 ns |    90.11 ns |    75.24 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   832,992.3 ns |   688.57 ns |   574.99 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,804,435.8 ns | 3,596.84 ns | 3,188.50 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   352,261.0 ns |   833.95 ns |   780.07 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   853,046.2 ns | 2,588.77 ns | 2,021.15 ns |     872 B |