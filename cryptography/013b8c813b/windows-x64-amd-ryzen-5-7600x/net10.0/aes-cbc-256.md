| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      66.68 ns |     0.272 ns |     0.241 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     290.44 ns |     2.560 ns |     2.270 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     611.80 ns |     3.187 ns |     2.981 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     985.69 ns |     5.685 ns |     5.317 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     114.24 ns |     0.345 ns |     0.306 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     343.56 ns |     1.745 ns |     1.547 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     613.36 ns |     4.484 ns |     4.194 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     886.79 ns |    10.073 ns |     9.422 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     319.77 ns |     1.596 ns |     1.493 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     366.77 ns |     2.422 ns |     2.265 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,328.26 ns |    40.939 ns |    38.295 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,266.45 ns |    31.456 ns |    29.424 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     718.47 ns |     3.014 ns |     2.820 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     942.30 ns |     2.901 ns |     2.713 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,358.86 ns |    43.811 ns |    40.981 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,129.30 ns |    40.913 ns |    38.270 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |   1,014.12 ns |     6.862 ns |     5.730 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,340.49 ns |     8.785 ns |     8.217 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  33,904.69 ns |   287.835 ns |   269.241 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  39,365.76 ns |   502.892 ns |   419.938 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   5,561.59 ns |    17.481 ns |    14.597 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   5,695.69 ns |    11.119 ns |    10.401 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  34,248.96 ns |   374.584 ns |   350.386 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  39,408.37 ns |   244.538 ns |   216.776 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  12,171.58 ns |   241.450 ns |   225.853 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  36,890.42 ns |   182.912 ns |   162.147 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 541,261.19 ns | 2,943.075 ns | 2,608.959 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 629,974.34 ns | 7,011.255 ns | 6,215.295 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |  87,667.03 ns |   320.283 ns |   299.593 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  88,415.27 ns |   256.733 ns |   240.148 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 546,126.26 ns | 3,684.706 ns | 3,446.676 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 624,853.57 ns | 4,598.242 ns | 4,301.199 ns |    1024 B |