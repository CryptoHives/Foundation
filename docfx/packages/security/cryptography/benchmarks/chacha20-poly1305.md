| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     343.7 ns |     1.79 ns |     1.67 ns |         - |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     549.9 ns |     2.81 ns |     2.63 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     757.7 ns |     6.40 ns |     5.67 ns |     896 B |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     345.9 ns |     1.47 ns |     1.37 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     455.7 ns |     3.79 ns |     3.55 ns |     816 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     499.0 ns |     3.39 ns |     3.17 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,761.0 ns |     9.53 ns |     8.92 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,796.2 ns |    15.89 ns |    14.09 ns |    2688 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   1,803.9 ns |    10.37 ns |     9.70 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,495.4 ns |     7.19 ns |     6.73 ns |    2608 B |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,758.9 ns |     9.47 ns |     8.86 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   1,765.5 ns |     6.35 ns |     5.63 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,974.1 ns |    70.63 ns |    66.07 ns |   17024 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  11,952.7 ns |    45.91 ns |    42.94 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,128.1 ns |    69.19 ns |    64.72 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,841.4 ns |    40.64 ns |    38.01 ns |   16944 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  11,938.8 ns |    64.53 ns |    60.36 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,092.6 ns |    60.03 ns |    56.15 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 185,564.6 ns |   478.31 ns |   399.41 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,654.2 ns | 1,101.53 ns | 1,030.37 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 208,190.9 ns | 1,548.54 ns | 1,448.50 ns |  262812 B |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 186,142.8 ns | 1,049.35 ns |   981.56 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 205,166.9 ns | 2,149.14 ns | 2,010.30 ns |  262732 B |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,568.0 ns | 1,437.06 ns | 1,344.23 ns |         - |