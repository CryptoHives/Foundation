| Description                            | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       962.6 ns |     1.40 ns |     1.10 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,466.8 ns |     1.41 ns |     1.18 ns |   2,913 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,026.7 ns |     1.27 ns |     1.06 ns |   1,285 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,485.5 ns |     2.12 ns |     1.98 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,801.3 ns |     9.22 ns |     8.63 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,521.7 ns |    19.40 ns |    18.14 ns |   2,913 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,296.8 ns |    11.38 ns |    10.64 ns |   1,285 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,683.4 ns |    10.63 ns |     9.95 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    59,235.1 ns |   209.75 ns |   185.94 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    73,847.3 ns |   137.35 ns |   128.48 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    57,579.7 ns |   116.39 ns |    97.19 ns |   1,283 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    75,235.5 ns |    65.72 ns |    58.26 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   854,330.4 ns | 1,056.95 ns |   936.96 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,176,612.4 ns | 1,583.07 ns | 1,403.35 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   917,484.5 ns |   862.52 ns |   764.60 ns |   1,283 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,198,303.5 ns | 1,260.42 ns | 1,117.33 ns |   2,911 B |      40 B |