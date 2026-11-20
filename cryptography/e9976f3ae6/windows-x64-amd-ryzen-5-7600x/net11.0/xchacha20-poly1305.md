| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     569.5 ns |     3.81 ns |     3.38 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     634.5 ns |     2.18 ns |     1.82 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,085.0 ns |     2.97 ns |     2.78 ns |  33,959 B |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,221.3 ns |     8.89 ns |     8.31 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     514.3 ns |     3.28 ns |     3.07 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     582.1 ns |     4.20 ns |     3.72 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,027.9 ns |     6.25 ns |     5.84 ns |  32,306 B |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,171.3 ns |     7.94 ns |     7.42 ns |     386 B |         - |
|                                                   |              |              |             |             |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,616.4 ns |     6.77 ns |     6.33 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,151.8 ns |     7.77 ns |     7.27 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,741.1 ns |    32.72 ns |    30.61 ns |  33,192 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,416.2 ns |    28.05 ns |    26.24 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,561.5 ns |     9.15 ns |     8.56 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,100.9 ns |    15.17 ns |    14.19 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,707.4 ns |    32.95 ns |    30.82 ns |  31,844 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,391.7 ns |    42.86 ns |    40.09 ns |     386 B |         - |
|                                                   |              |              |             |             |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,986.3 ns |    59.99 ns |    56.12 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  14,179.8 ns |    28.97 ns |    25.68 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  33,630.5 ns |   142.79 ns |   133.57 ns |  32,871 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,939.2 ns |   517.56 ns |   484.13 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,889.2 ns |    26.71 ns |    23.67 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  14,186.4 ns |    30.73 ns |    27.24 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  34,042.5 ns |   273.61 ns |   242.55 ns |  31,442 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,792.8 ns |   225.65 ns |   211.07 ns |     386 B |         - |
|                                                   |              |              |             |             |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 152,615.9 ns |   331.83 ns |   294.16 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 221,795.5 ns |   607.78 ns |   538.78 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 539,566.5 ns | 2,975.97 ns | 2,783.73 ns |  38,843 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 610,762.5 ns | 3,662.94 ns | 3,426.32 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 152,538.1 ns |   467.88 ns |   437.65 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 222,895.5 ns | 1,494.90 ns | 1,398.33 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 538,579.0 ns | 2,048.93 ns | 1,916.57 ns |  55,721 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 612,340.3 ns | 3,567.01 ns | 3,336.58 ns |     386 B |         - |