| Description                                | TestDataSize | Mean            | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |        90.73 ns |     0.409 ns |     0.363 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |       569.90 ns |     1.108 ns |     0.982 ns |  11,811 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |       752.18 ns |     0.948 ns |     0.792 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     1,590.89 ns |     3.366 ns |     3.149 ns |   2,929 B |     832 B |
|                                            |              |                 |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |       156.07 ns |     0.088 ns |     0.083 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |       621.86 ns |     1.157 ns |     1.026 ns |   9,525 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |       792.25 ns |     2.306 ns |     1.925 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     1,409.86 ns |     4.354 ns |     3.859 ns |   2,918 B |     832 B |
|                                            |              |                 |              |              |           |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |       367.64 ns |     0.205 ns |     0.171 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |       738.58 ns |     1.711 ns |     1.601 ns |  12,066 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |     5,114.86 ns |     6.600 ns |     6.174 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |     9,317.17 ns |    22.995 ns |    21.510 ns |   2,933 B |     832 B |
|                                            |              |                 |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |       894.79 ns |     0.355 ns |     0.332 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     1,329.55 ns |     1.015 ns |     0.793 ns |   9,529 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |     5,554.84 ns |    71.115 ns |    63.042 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |     8,750.73 ns |    17.945 ns |    16.786 ns |   2,924 B |     832 B |
|                                            |              |                 |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     2,135.69 ns |     2.957 ns |     2.766 ns |  11,835 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |     2,681.67 ns |     2.976 ns |     2.638 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |    40,068.64 ns |    26.118 ns |    24.431 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |    73,893.23 ns |   132.763 ns |   117.691 ns |   2,935 B |     832 B |
|                                            |              |                 |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |     6,841.69 ns |     1.197 ns |     1.120 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |     7,039.85 ns |     3.640 ns |     3.039 ns |  10,011 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |    43,638.01 ns |   105.962 ns |    93.932 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |    62,869.64 ns |   206.504 ns |   161.225 ns |   2,935 B |     832 B |
|                                            |              |                 |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |    26,170.71 ns |    18.271 ns |    16.197 ns |  12,882 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |    41,849.34 ns |    49.247 ns |    43.656 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        |   641,781.45 ns |   455.188 ns |   355.381 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 1,114,822.77 ns | 2,965.713 ns | 2,629.027 ns |   2,935 B |     832 B |
|                                            |              |                 |              |              |           |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |   106,183.27 ns |    48.097 ns |    40.163 ns |  11,326 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |   108,571.25 ns |    46.561 ns |    43.553 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        |   698,929.76 ns | 2,099.144 ns | 1,963.540 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 1,001,499.51 ns | 2,685.721 ns | 2,512.225 ns |   2,935 B |     832 B |