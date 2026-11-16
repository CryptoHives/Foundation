| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |       100.5 ns |      0.48 ns |      0.44 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |       572.0 ns |      1.97 ns |      1.85 ns |  12,049 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |       754.7 ns |      0.61 ns |      0.57 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     1,602.8 ns |      2.78 ns |      2.47 ns |   2,929 B |     832 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |       153.3 ns |      0.09 ns |      0.08 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |       644.8 ns |      1.22 ns |      1.14 ns |   9,517 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |       810.7 ns |      5.65 ns |      5.29 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     1,419.7 ns |      3.50 ns |      3.28 ns |   2,918 B |     832 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |       411.9 ns |      0.99 ns |      0.92 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |       747.9 ns |      2.05 ns |      1.71 ns |  12,041 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |     5,095.6 ns |      1.44 ns |      1.28 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |     9,419.8 ns |     20.65 ns |     19.32 ns |   2,933 B |     832 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |       893.8 ns |      0.21 ns |      0.20 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     1,348.0 ns |      3.34 ns |      3.13 ns |   9,975 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |     5,522.2 ns |     21.61 ns |     20.22 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |     8,306.0 ns |     51.47 ns |     48.14 ns |   2,924 B |     832 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     2,136.8 ns |      7.01 ns |      6.56 ns |  11,833 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |     2,647.4 ns |      4.68 ns |      4.38 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |    40,029.1 ns |     17.21 ns |     15.25 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |    73,869.7 ns |    188.39 ns |    167.00 ns |   2,935 B |     832 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |     6,838.4 ns |      2.67 ns |      2.23 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |     7,033.0 ns |      6.92 ns |      6.47 ns |  10,405 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |    43,299.2 ns |    202.20 ns |    179.25 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |    63,825.9 ns |    134.90 ns |    126.19 ns |   2,935 B |     832 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |    26,118.1 ns |     23.11 ns |     20.48 ns |  12,949 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |    41,691.6 ns |    197.88 ns |    185.09 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        |   640,469.5 ns |    282.40 ns |    235.82 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 1,132,649.7 ns |  2,294.69 ns |  1,916.17 ns |   2,935 B |     832 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |   106,187.0 ns |     93.37 ns |     87.33 ns |  10,930 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |   108,555.5 ns |     37.48 ns |     35.06 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        |   690,531.2 ns |  3,530.25 ns |  2,947.92 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 1,069,915.1 ns | 13,702.89 ns | 12,817.69 ns |   2,935 B |     832 B |