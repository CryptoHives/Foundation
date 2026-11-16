| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |       107.2 ns |      1.24 ns |      1.10 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |       596.6 ns |      1.34 ns |      1.12 ns |  12,056 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |       954.6 ns |      4.50 ns |      3.99 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     2,047.9 ns |      6.04 ns |      5.65 ns |   2,929 B |    1024 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |       197.7 ns |      0.18 ns |      0.16 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |       684.7 ns |      2.57 ns |      2.40 ns |   9,984 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     1,001.9 ns |      3.13 ns |      2.77 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     1,797.7 ns |      6.91 ns |      5.77 ns |   2,918 B |    1024 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |       479.5 ns |      5.97 ns |      5.30 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |       846.0 ns |      1.19 ns |      0.99 ns |  12,058 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     6,583.2 ns |     12.21 ns |     10.19 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |    11,881.6 ns |     18.08 ns |     16.03 ns |   2,931 B |    1024 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     1,212.1 ns |      0.55 ns |      0.52 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     1,677.8 ns |      2.70 ns |      2.40 ns |   9,946 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     7,000.4 ns |     26.99 ns |     23.92 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |    10,579.7 ns |     29.03 ns |     24.24 ns |   2,920 B |    1024 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     2,779.8 ns |      3.80 ns |      3.37 ns |  11,820 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     3,480.4 ns |     21.54 ns |     19.10 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    51,705.6 ns |    115.60 ns |     96.53 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    91,748.5 ns |    175.57 ns |    155.64 ns |   2,935 B |    1024 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     9,336.6 ns |      4.63 ns |      4.33 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |     9,577.8 ns |     10.09 ns |      8.95 ns |  10,918 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    55,005.4 ns |    154.91 ns |    144.91 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    80,996.1 ns |    184.50 ns |    163.56 ns |   2,935 B |    1024 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |    36,108.3 ns |     27.59 ns |     24.46 ns |  12,897 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |    54,707.3 ns |    904.81 ns |    802.09 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   829,693.8 ns |  4,634.53 ns |  4,335.15 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,422,052.4 ns |  2,780.52 ns |  2,321.86 ns |   2,935 B |    1024 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |   146,708.4 ns |     80.65 ns |     71.50 ns |  11,318 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |   148,480.2 ns |     92.73 ns |     82.21 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   881,897.9 ns |  4,441.00 ns |  3,708.43 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,353,783.3 ns | 12,587.74 ns | 11,774.58 ns |   2,935 B |    1024 B |