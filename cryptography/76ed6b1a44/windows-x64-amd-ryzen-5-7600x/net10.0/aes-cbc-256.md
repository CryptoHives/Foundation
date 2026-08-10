| Description                                | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|------------------------------------------- |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      60.13 ns |      0.842 ns |      0.703 ns |      60.36 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     286.39 ns |      5.573 ns |      7.992 ns |     285.44 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     613.96 ns |     11.111 ns |     11.411 ns |     614.87 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     988.14 ns |     19.769 ns |     46.984 ns |     972.03 ns |    1024 B |
|                                            |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     213.88 ns |      4.113 ns |      4.040 ns |     213.53 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     360.80 ns |      7.045 ns |     20.212 ns |     353.51 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     608.13 ns |     11.523 ns |     12.808 ns |     607.21 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     902.38 ns |     17.950 ns |     47.601 ns |     886.57 ns |    1024 B |
|                                            |              |               |               |               |               |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     309.93 ns |      6.200 ns |      9.280 ns |     309.50 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     357.34 ns |      6.547 ns |      5.112 ns |     355.88 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,241.34 ns |     61.796 ns |     60.692 ns |   4,232.60 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,144.83 ns |    100.978 ns |     84.321 ns |   5,128.68 ns |    1024 B |
|                                            |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     938.54 ns |     15.059 ns |     14.790 ns |     933.62 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |   1,455.39 ns |     28.455 ns |     38.950 ns |   1,464.82 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,565.57 ns |    168.485 ns |    480.698 ns |   4,356.88 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,079.85 ns |     97.531 ns |    126.817 ns |   5,064.02 ns |    1024 B |
|                                            |              |               |               |               |               |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     985.52 ns |     15.230 ns |     12.717 ns |     986.67 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,369.06 ns |     46.685 ns |    107.267 ns |   2,338.56 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  33,194.96 ns |    478.317 ns |    373.438 ns |  33,244.41 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  41,461.30 ns |  1,191.603 ns |  3,360.938 ns |  40,848.87 ns |    1024 B |
|                                            |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   5,840.01 ns |     88.780 ns |     78.701 ns |   5,828.20 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |  11,159.26 ns |    217.158 ns |    232.357 ns |  11,014.81 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  33,833.43 ns |    666.347 ns |    912.103 ns |  33,654.73 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  38,529.05 ns |    732.790 ns |    752.522 ns |  38,366.07 ns |    1024 B |
|                                            |              |               |               |               |               |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  11,859.28 ns |    236.544 ns |    253.100 ns |  11,776.66 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  35,613.34 ns |    247.756 ns |    231.751 ns |  35,664.48 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 535,220.51 ns | 10,621.034 ns | 10,431.275 ns | 533,173.10 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 602,660.32 ns | 11,308.283 ns | 12,569.127 ns | 601,370.80 ns |    1024 B |
|                                            |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |  90,424.66 ns |  1,315.210 ns |  1,165.899 ns |  90,202.11 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        | 175,511.06 ns |  2,019.578 ns |  1,790.303 ns | 175,025.89 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 538,863.93 ns |  9,357.779 ns | 10,012.719 ns | 536,745.31 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 612,879.74 ns | 11,075.703 ns | 10,360.220 ns | 613,046.44 ns |    1024 B |