| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      56.53 ns |     0.548 ns |     0.512 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     299.14 ns |     2.625 ns |     2.456 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     494.84 ns |     7.708 ns |     7.210 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     798.94 ns |    10.539 ns |     9.858 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      96.24 ns |     0.187 ns |     0.175 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     322.19 ns |     5.840 ns |     5.463 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     473.34 ns |     0.409 ns |     0.363 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     707.51 ns |     8.699 ns |     8.137 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     251.38 ns |     2.405 ns |     2.249 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     349.15 ns |     5.777 ns |     5.404 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,446.45 ns |    49.531 ns |    46.331 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,598.52 ns |    79.063 ns |    70.088 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     606.74 ns |     1.359 ns |     1.272 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     815.25 ns |     3.789 ns |     3.544 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,382.64 ns |    20.374 ns |    19.058 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,310.82 ns |    26.761 ns |    25.032 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     866.60 ns |     7.731 ns |     7.232 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,842.63 ns |    16.422 ns |    15.362 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  27,059.77 ns |   410.803 ns |   384.265 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  34,317.78 ns |   520.507 ns |   486.883 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,671.64 ns |     2.275 ns |     2.017 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,789.71 ns |    11.368 ns |    10.633 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  26,220.94 ns |   191.916 ns |   179.518 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  33,192.99 ns |   271.612 ns |   254.066 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   9,863.85 ns |    65.652 ns |    61.411 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  29,011.32 ns |   246.288 ns |   230.378 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 433,968.31 ns | 6,390.313 ns | 5,977.503 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 542,029.53 ns | 8,838.056 ns | 8,267.123 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  73,154.51 ns |    93.898 ns |    87.832 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  74,605.17 ns |   147.302 ns |   130.579 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 418,941.72 ns | 4,601.171 ns | 3,842.186 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 534,709.49 ns | 7,980.254 ns | 6,230.457 ns |     832 B |