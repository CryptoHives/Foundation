| Description                                 | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.28 ns |   0.022 ns |   0.020 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     195.87 ns |   0.573 ns |   0.508 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     389.34 ns |   0.160 ns |   0.141 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     618.78 ns |   0.453 ns |   0.378 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      41.72 ns |   0.072 ns |   0.067 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     202.77 ns |   0.618 ns |   0.578 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     438.91 ns |   0.936 ns |   0.830 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     578.86 ns |   0.623 ns |   0.583 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      92.02 ns |   0.069 ns |   0.064 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     236.15 ns |   1.658 ns |   1.551 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,721.42 ns |   1.378 ns |   1.221 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,403.89 ns |   4.346 ns |   4.066 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     383.73 ns |   2.091 ns |   1.956 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     581.88 ns |   2.990 ns |   2.797 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,153.74 ns |   1.679 ns |   1.402 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,284.34 ns |   1.874 ns |   1.565 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     592.20 ns |   1.399 ns |   1.309 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     648.70 ns |   0.393 ns |   0.367 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  21,349.42 ns |  53.929 ns |  45.033 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,561.76 ns |  43.756 ns |  40.929 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,378.69 ns |  14.631 ns |  13.686 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,454.78 ns |   8.556 ns |   7.585 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,848.71 ns |  17.635 ns |  15.633 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,877.93 ns |  53.407 ns |  47.344 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,731.10 ns |  18.495 ns |  16.395 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  10,102.42 ns |  14.994 ns |  13.292 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 344,233.05 ns | 897.912 ns | 701.031 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 405,193.64 ns | 832.932 ns | 779.125 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  52,127.39 ns | 255.279 ns | 226.298 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  56,213.00 ns | 219.217 ns | 205.056 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 396,249.51 ns | 949.109 ns | 841.360 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 397,204.76 ns | 290.551 ns | 257.566 ns |     832 B |