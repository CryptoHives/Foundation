| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,070.5 ns |      3.68 ns |      3.07 ns |   4,189 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,715.5 ns |     21.52 ns |     19.08 ns |  13,693 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       474.8 ns |      1.49 ns |      1.25 ns |  10,714 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,506.8 ns |      4.63 ns |      4.11 ns |   7,729 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     7,601.2 ns |     29.50 ns |     27.59 ns |  10,714 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    16,866.4 ns |    181.99 ns |    161.33 ns |  13,883 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     3,246.4 ns |      4.04 ns |      3.58 ns |   4,189 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     8,044.7 ns |     26.35 ns |     22.00 ns |  13,693 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    59,886.1 ns |    270.82 ns |    226.15 ns |   4,189 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   129,073.8 ns |    840.04 ns |    744.67 ns |  13,688 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    25,374.0 ns |     60.52 ns |     50.53 ns |  10,524 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    60,797.3 ns |    283.80 ns |    265.47 ns |   7,738 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   956,965.0 ns |  3,241.01 ns |  3,031.64 ns |  10,714 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 2,059,264.5 ns | 14,194.54 ns | 12,583.09 ns |   7,734 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   407,881.0 ns |  1,956.54 ns |  1,830.15 ns |  10,524 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   950,282.4 ns |  5,804.10 ns |  5,429.15 ns |  13,693 B |     872 B |