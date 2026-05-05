| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     2.156 μs | 0.0046 μs | 0.0043 μs |     2.157 μs |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     3.288 μs | 0.0058 μs | 0.0049 μs |     3.287 μs |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     4.272 μs | 0.0011 μs | 0.0010 μs |     4.272 μs |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     6.557 μs | 0.1285 μs | 0.1428 μs |     6.672 μs |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |    11.071 μs | 0.1061 μs | 0.0941 μs |    11.038 μs |         - |
|                                                  |              |              |           |           |              |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     1.836 μs | 0.0108 μs | 0.0101 μs |     1.840 μs |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     2.344 μs | 0.0040 μs | 0.0033 μs |     2.344 μs |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     4.112 μs | 0.0013 μs | 0.0012 μs |     4.112 μs |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     6.232 μs | 0.0103 μs | 0.0092 μs |     6.229 μs |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     9.582 μs | 0.1183 μs | 0.1106 μs |     9.581 μs |         - |
|                                                  |              |              |           |           |              |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |    10.548 μs | 0.0649 μs | 0.0607 μs |    10.533 μs |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |    11.339 μs | 0.0041 μs | 0.0032 μs |    11.338 μs |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |    15.822 μs | 0.0718 μs | 0.0672 μs |    15.797 μs |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |    19.073 μs | 0.0068 μs | 0.0056 μs |    19.074 μs |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    33.905 μs | 0.0143 μs | 0.0112 μs |    33.902 μs |         - |
|                                                  |              |              |           |           |              |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |    10.092 μs | 0.0111 μs | 0.0104 μs |    10.090 μs |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |    10.421 μs | 0.0099 μs | 0.0083 μs |    10.418 μs |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |    14.138 μs | 0.1184 μs | 0.1108 μs |    14.106 μs |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |    18.914 μs | 0.0143 μs | 0.0111 μs |    18.917 μs |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    33.723 μs | 0.0110 μs | 0.0098 μs |    33.721 μs |         - |
|                                                  |              |              |           |           |              |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    54.149 μs | 0.1266 μs | 0.1123 μs |    54.176 μs |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    75.021 μs | 0.1526 μs | 0.1191 μs |    75.002 μs |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |    75.338 μs | 0.2684 μs | 0.2095 μs |    75.238 μs |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |   137.033 μs | 0.0552 μs | 0.0517 μs |   137.046 μs |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   243.532 μs | 0.2211 μs | 0.1726 μs |   243.494 μs |         - |
|                                                  |              |              |           |           |              |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    51.838 μs | 0.1845 μs | 0.1636 μs |    51.836 μs |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    74.306 μs | 0.0370 μs | 0.0328 μs |    74.303 μs |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |    75.394 μs | 0.1183 μs | 0.0988 μs |    75.344 μs |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |   136.922 μs | 0.1618 μs | 0.1434 μs |   136.941 μs |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   243.441 μs | 0.0565 μs | 0.0472 μs |   243.437 μs |         - |
|                                                  |              |              |           |           |              |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   773.679 μs | 2.9226 μs | 2.4405 μs |   774.563 μs |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 1,174.941 μs | 2.0728 μs | 1.7309 μs | 1,174.399 μs |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 1,189.233 μs | 3.4307 μs | 3.2091 μs | 1,188.708 μs |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 2,173.125 μs | 5.2605 μs | 4.6633 μs | 2,172.153 μs |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 3,835.770 μs | 3.5903 μs | 3.1827 μs | 3,835.275 μs |         - |
|                                                  |              |              |           |           |              |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   720.085 μs | 2.2119 μs | 2.0690 μs |   720.637 μs |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 1,180.734 μs | 2.7441 μs | 2.4326 μs | 1,181.029 μs |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 1,193.358 μs | 1.4276 μs | 1.3354 μs | 1,192.924 μs |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 2,158.831 μs | 0.5012 μs | 0.4443 μs | 2,158.781 μs |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 3,840.596 μs | 3.5656 μs | 3.1608 μs | 3,840.163 μs |         - |