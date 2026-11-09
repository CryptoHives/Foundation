| Description                                | TestDataSize | Mean            | Error         | StdDev        | Median          | Code Size | Allocated |
|------------------------------------------- |------------- |----------------:|--------------:|--------------:|----------------:|----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |        82.67 ns |      0.433 ns |      0.361 ns |        82.70 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |       472.88 ns |      4.384 ns |      3.886 ns |       473.15 ns |  12,060 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |       764.16 ns |     14.849 ns |     17.677 ns |       765.78 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     1,646.94 ns |     11.649 ns |     10.896 ns |     1,647.94 ns |   2,929 B |    1024 B |
|                                            |              |                 |               |               |                 |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |       155.11 ns |      1.363 ns |      1.275 ns |       154.95 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |       542.38 ns |      7.476 ns |      6.993 ns |       542.43 ns |   9,946 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |       787.83 ns |      6.633 ns |      5.880 ns |       786.30 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     1,424.45 ns |     22.633 ns |     20.063 ns |     1,419.01 ns |   2,918 B |    1024 B |
|                                            |              |                 |               |               |                 |           |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |       372.07 ns |      2.965 ns |      2.773 ns |       371.73 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |       655.59 ns |      6.213 ns |      5.508 ns |       656.83 ns |  11,793 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     5,160.77 ns |     34.768 ns |     32.522 ns |     5,161.62 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |     9,229.61 ns |     78.666 ns |     73.584 ns |     9,207.70 ns |   2,933 B |    1024 B |
|                                            |              |                 |               |               |                 |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |       940.06 ns |      3.045 ns |      2.699 ns |       939.61 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     1,316.96 ns |     18.530 ns |     17.333 ns |     1,317.29 ns |   9,492 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     5,503.09 ns |     45.623 ns |     42.676 ns |     5,499.27 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |     8,753.10 ns |    173.380 ns |    456.753 ns |     8,551.01 ns |   2,924 B |    1024 B |
|                                            |              |                 |               |               |                 |           |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     2,200.78 ns |     11.306 ns |     10.023 ns |     2,199.63 ns |  11,887 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     2,756.00 ns |     30.614 ns |     28.636 ns |     2,757.93 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    41,296.95 ns |    364.598 ns |    341.045 ns |    41,155.02 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    73,289.16 ns |    703.387 ns |    587.360 ns |    73,117.77 ns |   2,935 B |    1024 B |
|                                            |              |                 |               |               |                 |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     7,289.41 ns |     73.317 ns |     68.580 ns |     7,317.93 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |     7,491.22 ns |     45.072 ns |     42.160 ns |     7,500.04 ns |   9,996 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    42,750.36 ns |    521.252 ns |    487.579 ns |    42,570.09 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    63,233.97 ns |    668.722 ns |    592.805 ns |    63,210.68 ns |   2,933 B |    1024 B |
|                                            |              |                 |               |               |                 |           |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |    28,339.84 ns |    135.731 ns |    120.322 ns |    28,332.41 ns |  12,897 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |    42,952.91 ns |    212.464 ns |    188.344 ns |    42,939.13 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   655,447.25 ns | 10,198.735 ns |  9,539.903 ns |   657,094.73 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,123,965.46 ns | 18,771.733 ns | 16,640.652 ns | 1,126,207.42 ns |   2,935 B |    1024 B |
|                                            |              |                 |               |               |                 |           |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |   114,779.20 ns |    605.139 ns |    566.048 ns |   114,823.90 ns |  11,325 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |   116,074.33 ns |    874.161 ns |    817.691 ns |   116,146.89 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   679,511.91 ns |  2,785.722 ns |  2,605.766 ns |   679,304.88 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,003,564.76 ns |  9,063.880 ns |  8,034.893 ns | 1,002,426.07 ns |   2,935 B |    1024 B |