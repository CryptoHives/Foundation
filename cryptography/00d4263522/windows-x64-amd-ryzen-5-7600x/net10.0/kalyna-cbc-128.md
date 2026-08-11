| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       932.6 ns |      3.32 ns |      2.95 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,374.4 ns |     19.63 ns |     18.37 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       403.5 ns |      2.28 ns |      2.02 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,367.6 ns |     11.68 ns |     10.93 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     6,598.8 ns |     23.58 ns |     22.06 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    14,565.4 ns |     86.94 ns |     72.60 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,788.6 ns |     11.77 ns |     11.01 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,130.0 ns |     32.08 ns |     28.44 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    51,925.6 ns |    191.66 ns |    169.90 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   111,767.8 ns |    627.24 ns |    586.72 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    21,865.1 ns |    139.05 ns |    130.07 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,505.5 ns |    265.90 ns |    235.71 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   846,255.4 ns | 13,106.61 ns | 10,232.78 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,855,045.9 ns | 28,021.83 ns | 26,211.64 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   348,924.7 ns |  2,110.02 ns |  1,973.72 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   848,155.2 ns |  4,309.39 ns |  4,031.01 ns |     872 B |