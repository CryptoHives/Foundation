| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     1.200 μs | 0.0038 μs | 0.0035 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     1.290 μs | 0.0040 μs | 0.0037 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1.726 μs | 0.0045 μs | 0.0039 μs |  19,383 B |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     3.183 μs | 0.0091 μs | 0.0085 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     1.103 μs | 0.0041 μs | 0.0038 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     1.186 μs | 0.0038 μs | 0.0035 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1.656 μs | 0.0042 μs | 0.0037 μs |  17,859 B |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     3.086 μs | 0.0075 μs | 0.0070 μs |     390 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2.732 μs | 0.0046 μs | 0.0043 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     3.491 μs | 0.0043 μs | 0.0040 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     7.571 μs | 0.0226 μs | 0.0212 μs |  20,610 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    14.047 μs | 0.0483 μs | 0.0452 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2.640 μs | 0.0044 μs | 0.0041 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     3.394 μs | 0.0034 μs | 0.0028 μs |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     7.421 μs | 0.0149 μs | 0.0124 μs |  18,399 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    14.082 μs | 0.0548 μs | 0.0513 μs |     390 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    15.083 μs | 0.0114 μs | 0.0107 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    20.663 μs | 0.0288 μs | 0.0269 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    55.771 μs | 0.1020 μs | 0.0955 μs |  20,712 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   101.036 μs | 0.4671 μs | 0.4369 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    14.988 μs | 0.0076 μs | 0.0068 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    20.615 μs | 0.0197 μs | 0.0175 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    53.609 μs | 0.0836 μs | 0.0698 μs |  18,526 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   100.759 μs | 0.4104 μs | 0.3839 μs |     387 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   225.966 μs | 0.1156 μs | 0.1025 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   315.111 μs | 0.3350 μs | 0.3134 μs |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   854.644 μs | 2.9902 μs | 2.7970 μs |  19,595 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,597.506 μs | 6.1435 μs | 5.7466 μs |     310 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   226.041 μs | 0.0822 μs | 0.0769 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   315.255 μs | 0.3050 μs | 0.2853 μs |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   851.743 μs | 2.3041 μs | 2.1552 μs |  17,258 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,599.052 μs | 5.0974 μs | 4.7681 μs |     390 B |         - |