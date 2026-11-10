| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     1.199 μs | 0.0024 μs | 0.0021 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     1.288 μs | 0.0018 μs | 0.0016 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1.724 μs | 0.0022 μs | 0.0021 μs |  19,384 B |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     3.182 μs | 0.0085 μs | 0.0080 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     1.102 μs | 0.0021 μs | 0.0020 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     1.187 μs | 0.0028 μs | 0.0026 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1.630 μs | 0.0025 μs | 0.0022 μs |  17,783 B |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     3.088 μs | 0.0084 μs | 0.0079 μs |     390 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2.730 μs | 0.0027 μs | 0.0026 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     3.487 μs | 0.0043 μs | 0.0040 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     7.591 μs | 0.0040 μs | 0.0033 μs |  20,477 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    14.066 μs | 0.0459 μs | 0.0430 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2.641 μs | 0.0020 μs | 0.0019 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     3.393 μs | 0.0029 μs | 0.0025 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     7.439 μs | 0.0070 μs | 0.0065 μs |  18,393 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    14.001 μs | 0.0338 μs | 0.0317 μs |     387 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    15.092 μs | 0.0108 μs | 0.0095 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    20.680 μs | 0.0140 μs | 0.0131 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    54.130 μs | 0.0298 μs | 0.0279 μs |  20,592 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   101.223 μs | 0.3006 μs | 0.2812 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    15.004 μs | 0.0063 μs | 0.0059 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    20.631 μs | 0.0264 μs | 0.0247 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    53.681 μs | 0.0392 μs | 0.0366 μs |  18,363 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   101.121 μs | 0.1843 μs | 0.1724 μs |     387 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   226.547 μs | 0.1198 μs | 0.1120 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   315.671 μs | 0.1585 μs | 0.1405 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   857.972 μs | 0.7851 μs | 0.6960 μs |  19,595 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,599.363 μs | 3.8944 μs | 3.6428 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   226.110 μs | 0.1658 μs | 0.1470 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   315.487 μs | 0.2124 μs | 0.1987 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   853.271 μs | 1.0737 μs | 0.9518 μs |  17,258 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,597.235 μs | 4.6124 μs | 4.3145 μs |     387 B |         - |