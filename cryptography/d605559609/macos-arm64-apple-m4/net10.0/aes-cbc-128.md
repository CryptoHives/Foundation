| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.30 ns |     0.045 ns |     0.037 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     194.39 ns |     1.217 ns |     1.139 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     379.23 ns |     0.620 ns |     0.580 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     602.25 ns |     1.246 ns |     1.166 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      42.06 ns |     0.086 ns |     0.067 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     200.67 ns |     0.563 ns |     0.499 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     427.03 ns |     0.415 ns |     0.388 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     557.64 ns |     0.605 ns |     0.566 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      91.77 ns |     0.153 ns |     0.128 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     236.93 ns |     2.534 ns |     2.370 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,653.52 ns |     5.802 ns |     4.845 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,386.41 ns |    15.776 ns |    13.985 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     388.28 ns |     1.817 ns |     1.700 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     578.89 ns |     2.176 ns |     1.929 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,074.05 ns |     0.567 ns |     0.473 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,247.71 ns |     0.468 ns |     0.365 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     597.05 ns |     2.457 ns |     2.052 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     645.88 ns |     0.648 ns |     0.506 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  20,926.01 ns |   121.571 ns |   101.517 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,396.71 ns |    84.755 ns |    70.774 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,433.23 ns |    13.106 ns |    12.259 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,459.07 ns |    23.413 ns |    21.900 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,072.98 ns |     6.955 ns |     5.808 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,767.96 ns |     9.730 ns |     8.125 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,695.17 ns |    15.569 ns |    12.156 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  10,088.39 ns |    27.813 ns |    24.655 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 334,790.32 ns |   510.094 ns |   425.952 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 402,998.43 ns | 1,399.754 ns | 1,309.331 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  52,544.73 ns |   292.822 ns |   273.906 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  56,404.66 ns |   295.879 ns |   262.289 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 384,336.07 ns |   182.470 ns |   142.460 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 395,880.43 ns |   528.716 ns |   468.693 ns |     832 B |