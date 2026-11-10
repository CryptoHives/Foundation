| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |       106.9 ns |     0.35 ns |     0.31 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |       596.1 ns |     1.52 ns |     1.35 ns |  11,802 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |       946.8 ns |     2.32 ns |     2.17 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     2,064.8 ns |     3.81 ns |     3.56 ns |   2,929 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |       197.4 ns |     0.08 ns |     0.07 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |       684.3 ns |     1.34 ns |     1.25 ns |   9,936 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |       999.6 ns |     6.23 ns |     5.83 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     1,783.5 ns |     4.57 ns |     4.28 ns |   2,920 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |       475.1 ns |     2.98 ns |     2.78 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |       837.3 ns |     1.50 ns |     1.26 ns |  12,058 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     6,584.7 ns |     9.19 ns |     8.59 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |    11,849.7 ns |    15.42 ns |    14.43 ns |   2,927 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     1,214.4 ns |     0.46 ns |     0.43 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     1,672.1 ns |     1.75 ns |     1.64 ns |   9,941 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     7,002.2 ns |    17.57 ns |    16.43 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |    10,769.9 ns |    19.74 ns |    17.50 ns |   2,920 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     2,771.8 ns |     3.16 ns |     2.80 ns |  12,053 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     3,411.9 ns |     8.60 ns |     7.18 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    51,770.9 ns |   122.13 ns |   108.27 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    86,317.2 ns |   151.21 ns |   141.44 ns |   2,935 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     9,333.3 ns |     3.77 ns |     3.53 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |     9,588.7 ns |     6.18 ns |     5.48 ns |  10,918 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    54,607.2 ns |    62.96 ns |    52.57 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    81,587.7 ns |   133.36 ns |   118.22 ns |   2,935 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |    36,162.4 ns |    55.23 ns |    51.66 ns |  12,900 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |    53,642.6 ns |   122.27 ns |    95.46 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   827,458.0 ns |   519.69 ns |   433.96 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,422,831.1 ns | 1,464.94 ns | 1,223.29 ns |   2,935 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |   146,626.4 ns |    57.48 ns |    50.96 ns |  11,318 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |   148,588.3 ns |    77.19 ns |    72.20 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   872,896.9 ns | 1,491.29 ns | 1,394.95 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,354,769.4 ns | 1,876.99 ns | 1,465.43 ns |   2,935 B |    1024 B |