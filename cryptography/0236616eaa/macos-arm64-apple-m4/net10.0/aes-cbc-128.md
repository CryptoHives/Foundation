| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.18 ns |     0.005 ns |     0.004 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     189.21 ns |     0.852 ns |     0.797 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     391.13 ns |     0.069 ns |     0.061 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     601.53 ns |     0.529 ns |     0.495 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      41.56 ns |     0.052 ns |     0.046 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     199.14 ns |     0.553 ns |     0.490 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     448.88 ns |     0.222 ns |     0.208 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     556.45 ns |     0.273 ns |     0.228 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      91.61 ns |     0.059 ns |     0.052 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     233.89 ns |     0.768 ns |     0.681 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,729.75 ns |     0.761 ns |     0.674 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,374.36 ns |     3.653 ns |     3.417 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     377.57 ns |     1.040 ns |     0.973 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     566.44 ns |     3.397 ns |     3.177 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,210.57 ns |     0.937 ns |     0.782 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,251.08 ns |     0.970 ns |     0.860 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     590.59 ns |     2.488 ns |     2.078 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     644.51 ns |     0.328 ns |     0.290 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  21,474.58 ns |     7.428 ns |     6.948 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,290.11 ns |    75.162 ns |    70.307 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,293.68 ns |    15.165 ns |    14.186 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,400.09 ns |     3.002 ns |     2.507 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,827.55 ns |     2.751 ns |     2.574 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  25,298.39 ns |     7.197 ns |     6.380 ns |         - |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,647.34 ns |    36.181 ns |    33.844 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  10,057.19 ns |     1.957 ns |     1.830 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 343,983.59 ns |   249.503 ns |   221.178 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 406,575.60 ns | 4,530.318 ns | 3,536.975 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  51,158.80 ns |   316.161 ns |   295.737 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  55,391.24 ns |   106.650 ns |    99.761 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 396,183.10 ns |   138.318 ns |   122.615 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 404,261.88 ns |    81.322 ns |    72.090 ns |         - |