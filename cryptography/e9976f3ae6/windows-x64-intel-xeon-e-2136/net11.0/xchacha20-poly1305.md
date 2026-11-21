| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     1.173 μs | 0.0012 μs | 0.0011 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     1.248 μs | 0.0039 μs | 0.0036 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1.675 μs | 0.0015 μs | 0.0013 μs |  32,559 B |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     3.138 μs | 0.0094 μs | 0.0088 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     1.081 μs | 0.0033 μs | 0.0031 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     1.155 μs | 0.0034 μs | 0.0032 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1.583 μs | 0.0054 μs | 0.0048 μs |  34,291 B |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     3.047 μs | 0.0133 μs | 0.0125 μs |     390 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2.575 μs | 0.0031 μs | 0.0029 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     3.329 μs | 0.0023 μs | 0.0020 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     7.247 μs | 0.0037 μs | 0.0035 μs |  34,510 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    13.775 μs | 0.0432 μs | 0.0404 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2.481 μs | 0.0034 μs | 0.0032 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     3.263 μs | 0.0081 μs | 0.0076 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     7.158 μs | 0.0045 μs | 0.0042 μs |  26,126 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    13.685 μs | 0.0471 μs | 0.0441 μs |     390 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    13.871 μs | 0.0091 μs | 0.0085 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    19.456 μs | 0.0111 μs | 0.0104 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    51.827 μs | 0.0280 μs | 0.0248 μs |  33,294 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    99.281 μs | 0.2211 μs | 0.2068 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    13.788 μs | 0.0030 μs | 0.0026 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    19.399 μs | 0.0216 μs | 0.0202 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    53.210 μs | 0.0304 μs | 0.0284 μs |  31,368 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    99.010 μs | 0.4692 μs | 0.4389 μs |     390 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   206.666 μs | 0.0791 μs | 0.0701 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   296.056 μs | 0.1935 μs | 0.1810 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   823.123 μs | 1.6333 μs | 1.5278 μs |  33,739 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,570.683 μs | 3.8749 μs | 3.6246 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   206.714 μs | 0.0366 μs | 0.0342 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   295.950 μs | 0.1993 μs | 0.1864 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   822.200 μs | 0.8075 μs | 0.7553 μs |  25,582 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,567.889 μs | 5.2827 μs | 4.9415 μs |     390 B |         - |