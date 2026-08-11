| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      62.13 ns |     0.394 ns |     0.368 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     260.64 ns |     1.416 ns |     1.255 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     570.58 ns |     5.357 ns |     5.011 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     871.79 ns |     6.119 ns |     5.424 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     110.82 ns |     0.465 ns |     0.435 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     311.94 ns |     1.266 ns |     1.184 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     659.56 ns |     4.478 ns |     4.188 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     791.77 ns |     6.924 ns |     6.476 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     300.51 ns |     0.806 ns |     0.714 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     338.01 ns |     2.737 ns |     2.560 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,028.76 ns |    36.168 ns |    32.062 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,872.78 ns |    32.069 ns |    29.998 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     748.57 ns |     5.123 ns |     4.792 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     897.64 ns |     4.248 ns |     3.974 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,073.61 ns |    29.675 ns |    27.758 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,821.86 ns |    49.164 ns |    45.988 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     944.54 ns |     4.524 ns |     4.231 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,200.90 ns |     9.196 ns |     8.602 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  31,701.51 ns |   243.667 ns |   216.005 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  36,538.91 ns |   247.784 ns |   231.778 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   5,776.32 ns |    80.723 ns |    75.509 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   5,818.47 ns |    37.244 ns |    34.838 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  32,095.91 ns |   354.155 ns |   331.276 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  37,010.25 ns |   359.387 ns |   318.587 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  11,653.02 ns |    55.898 ns |    52.287 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  34,836.80 ns |   172.991 ns |   161.815 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 507,004.44 ns | 2,640.967 ns | 2,470.362 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 578,502.20 ns | 2,451.962 ns | 2,173.600 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |  91,067.26 ns |   160.771 ns |   142.519 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  92,140.94 ns |   776.855 ns |   726.671 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 506,569.13 ns | 2,478.908 ns | 2,070.001 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 587,564.47 ns | 5,059.506 ns | 4,732.665 ns |    1024 B |