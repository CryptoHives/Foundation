| Description                                | TestDataSize | Mean          | Error        | StdDev        | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|--------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      63.21 ns |     0.282 ns |      0.264 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     271.48 ns |     2.954 ns |      2.306 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     548.66 ns |     3.209 ns |      2.505 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     892.18 ns |     6.175 ns |      5.776 ns |    1024 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     112.31 ns |     0.848 ns |      0.708 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     312.46 ns |     1.953 ns |      1.731 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     536.32 ns |     3.860 ns |      3.224 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     799.83 ns |     7.254 ns |      6.430 ns |    1024 B |
|                                            |              |               |              |               |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     303.00 ns |     0.553 ns |      0.462 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     350.92 ns |     2.400 ns |      2.357 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   3,828.33 ns |    15.287 ns |     13.551 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,945.61 ns |    36.050 ns |     30.104 ns |    1024 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     731.11 ns |    10.308 ns |      9.642 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     910.50 ns |     2.025 ns |      1.691 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   3,935.84 ns |    20.172 ns |     16.844 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,862.71 ns |    24.301 ns |     21.542 ns |    1024 B |
|                                            |              |               |              |               |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     987.64 ns |    17.356 ns |     21.315 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,227.64 ns |     3.362 ns |      2.625 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  30,139.57 ns |   100.092 ns |     83.581 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  36,943.03 ns |   240.938 ns |    201.194 ns |    1024 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   5,727.89 ns |    51.739 ns |     48.397 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   5,729.80 ns |   104.396 ns |     97.652 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  29,647.80 ns |   109.474 ns |     91.416 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  37,485.31 ns |   242.974 ns |    227.278 ns |    1024 B |
|                                            |              |               |              |               |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  11,794.66 ns |    26.250 ns |     24.554 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  35,157.09 ns |   101.447 ns |     94.893 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 482,840.32 ns | 2,393.528 ns |  1,868.709 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 589,328.03 ns | 5,310.248 ns |  4,434.298 ns |    1024 B |
|                                            |              |               |              |               |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |  90,465.74 ns |   846.438 ns |    791.759 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  91,825.45 ns |   907.356 ns |    848.741 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 474,041.88 ns | 3,021.689 ns |  2,523.247 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 596,648.19 ns | 9,766.419 ns | 10,449.958 ns |    1024 B |