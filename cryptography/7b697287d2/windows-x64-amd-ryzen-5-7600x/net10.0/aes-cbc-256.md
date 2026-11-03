| Description                                | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      66.59 ns |     0.172 ns |     0.161 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     314.52 ns |     1.354 ns |     1.266 ns |  11,790 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     576.90 ns |     1.248 ns |     1.042 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     990.12 ns |     3.887 ns |     3.636 ns |   2,909 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     130.96 ns |     0.154 ns |     0.144 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     363.96 ns |     0.774 ns |     0.687 ns |   9,480 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     601.28 ns |     1.571 ns |     1.470 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     887.54 ns |     1.823 ns |     1.705 ns |   2,898 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     340.78 ns |     0.389 ns |     0.325 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     384.03 ns |     1.209 ns |     1.131 ns |  11,791 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,039.61 ns |    10.299 ns |     9.130 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,540.89 ns |    14.130 ns |    12.526 ns |   2,913 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     830.11 ns |     0.308 ns |     0.288 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |   1,053.98 ns |     1.481 ns |     1.237 ns |   9,462 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,440.50 ns |     6.767 ns |     6.330 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,436.32 ns |    11.187 ns |     9.917 ns |   2,902 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |   1,091.20 ns |     2.290 ns |     2.142 ns |  11,864 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,533.79 ns |     3.264 ns |     3.053 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  31,804.04 ns |   124.741 ns |   116.683 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  42,237.95 ns |   234.012 ns |   207.445 ns |   2,911 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   6,440.39 ns |     1.798 ns |     1.502 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   6,542.80 ns |     2.951 ns |     2.464 ns |  10,413 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  33,191.16 ns |   127.902 ns |   119.640 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  41,880.79 ns |    93.339 ns |    82.742 ns |   2,911 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  13,614.29 ns |     7.746 ns |     6.867 ns |  12,846 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  40,218.94 ns |    51.919 ns |    48.565 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 508,891.53 ns | 1,856.288 ns | 1,736.373 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 660,966.18 ns | 1,365.624 ns | 1,277.406 ns |   2,911 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        | 101,277.12 ns |    43.139 ns |    40.352 ns |  11,285 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        | 102,741.78 ns |    43.006 ns |    38.124 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 531,776.97 ns | 1,336.115 ns | 1,249.803 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 664,853.35 ns | 1,602.166 ns | 1,337.882 ns |   2,911 B |    1024 B |