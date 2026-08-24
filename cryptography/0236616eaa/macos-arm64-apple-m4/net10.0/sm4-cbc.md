| Description                            | TestDataSize | Mean           | Error       | StdDev      | Median         | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|---------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       950.1 ns |     0.52 ns |     0.41 ns |       949.9 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,427.3 ns |     7.32 ns |     6.11 ns |     1,425.1 ns |      40 B |
|                                        |              |                |             |             |                |           |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,522.3 ns |     4.77 ns |     4.23 ns |     1,521.9 ns |      40 B |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     3,351.7 ns |   707.42 ns | 2,085.84 ns |     5,145.8 ns |         - |
|                                        |              |                |             |             |                |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,776.5 ns |    53.65 ns |    47.56 ns |     6,797.4 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,916.8 ns |    40.68 ns |    38.05 ns |     8,916.4 ns |      40 B |
|                                        |              |                |             |             |                |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,777.6 ns |    14.88 ns |    13.19 ns |     7,778.0 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    10,168.7 ns |    13.52 ns |    12.65 ns |    10,169.8 ns |      40 B |
|                                        |              |                |             |             |                |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    52,711.1 ns |   111.20 ns |   104.02 ns |    52,715.5 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    69,975.9 ns |   272.22 ns |   241.32 ns |    70,021.8 ns |      40 B |
|                                        |              |                |             |             |                |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    61,580.2 ns |    60.23 ns |    53.39 ns |    61,571.4 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    79,555.2 ns | 1,477.44 ns | 1,309.71 ns |    80,499.9 ns |      40 B |
|                                        |              |                |             |             |                |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   848,341.4 ns |   192.57 ns |   170.71 ns |   848,322.0 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,126,685.0 ns | 1,089.28 ns | 1,018.92 ns | 1,126,575.4 ns |      40 B |
|                                        |              |                |             |             |                |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   985,007.1 ns | 1,590.75 ns | 1,410.15 ns |   984,902.0 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,263,761.5 ns |   515.15 ns |   456.67 ns | 1,263,885.5 ns |      40 B |