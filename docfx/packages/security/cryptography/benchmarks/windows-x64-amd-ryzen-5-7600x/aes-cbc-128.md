| Description                                | TestDataSize | Mean          | Error        | StdDev        | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      46.29 ns |     0.865 ns |      0.809 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     267.96 ns |     5.322 ns |      5.465 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     472.49 ns |     9.205 ns |      8.610 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     746.98 ns |    14.534 ns |     15.551 ns |     832 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |     179.76 ns |     3.476 ns |      2.903 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     297.25 ns |     2.923 ns |      2.440 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     544.00 ns |     9.066 ns |      8.481 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     676.90 ns |    10.596 ns |      9.911 ns |     832 B |
|                                            |              |               |              |               |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     218.10 ns |     3.329 ns |      3.114 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     318.93 ns |     4.463 ns |      3.956 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,327.49 ns |    64.734 ns |     57.385 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,153.21 ns |    80.542 ns |    110.246 ns |     832 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     756.04 ns |    14.571 ns |     13.629 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |   1,227.17 ns |    23.998 ns |     32.849 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,316.62 ns |    45.072 ns |     42.160 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,969.28 ns |    74.556 ns |     76.563 ns |     832 B |
|                                            |              |               |              |               |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     787.69 ns |    15.408 ns |     15.133 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,631.84 ns |    26.699 ns |     24.975 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,913.09 ns |   370.545 ns |    346.608 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  31,100.76 ns |   620.806 ns |    690.025 ns |     832 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,259.19 ns |    83.325 ns |    102.331 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   9,469.91 ns |   130.696 ns |    115.858 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  28,629.61 ns |   856.548 ns |  2,485.001 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  30,377.40 ns |   586.129 ns |    548.265 ns |     832 B |
|                                            |              |               |              |               |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   8,831.08 ns |   151.807 ns |    134.573 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  26,059.87 ns |   516.010 ns |    552.125 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 417,289.85 ns | 7,896.018 ns |  7,385.940 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 494,379.46 ns | 9,452.536 ns | 10,885.554 ns |     832 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  64,719.45 ns | 1,059.299 ns |    939.041 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        | 154,095.26 ns | 3,050.188 ns |  4,071.913 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 480,607.72 ns | 6,161.056 ns |  5,763.056 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 491,958.31 ns | 8,633.671 ns |  9,942.549 ns |         - |